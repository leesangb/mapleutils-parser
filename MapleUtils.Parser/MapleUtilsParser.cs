using MapleUtils.Parser.Constants;
using MapleUtils.Parser.Exceptions;
using MapleUtils.Parser.Extensions;
using MapleUtils.Parser.Models;
using MapleUtils.Parser.Parsers;
using Microsoft.Extensions.Logging;
using PuppeteerSharp;

namespace MapleUtils.Parser
{
    public class MapleUtilsParser : IMapleUtilsParser, IDisposable
    {
        private readonly Browser Browser;
        private readonly ILogger Logger;
        private readonly ISpecParser SpecParser;
        private readonly IEquipmentParser EquipmentParser;
        private readonly IArcaneParser ArcaneParser;
        private readonly IPetEquipmentParser PetEquipmentParser;

        public MapleUtilsParser(ILogger<MapleUtilsParser> logger,
            Browser browser,
            ISpecParser specParser,
            IEquipmentParser equipmentParser,
            IArcaneParser arcaneParser,
            IPetEquipmentParser petEquipmentParser
            )
        {
            Browser = browser;
            Logger = logger;
            SpecParser = specParser;
            EquipmentParser = equipmentParser;
            ArcaneParser = arcaneParser;
            PetEquipmentParser = petEquipmentParser;
        }

        public static MapleUtilsParser Create(bool isHeadless = true)
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var browser = PuppeteerExtensions.GetBrowser(isHeadless);
            var logger = loggerFactory.CreateLogger<MapleUtilsParser>();
            var abilitiesParser = new AbilitiesParser();
            var hyperStatsParser = new HyperStatsParser();
            var specParser = new SpecParser(abilitiesParser, hyperStatsParser);
            var equipmentParser = new EquipmentParser();
            var arcaneParser = new ArcaneParser();
            var petEquipmentParser = new PetEquipmentParser();

            return new MapleUtilsParser(logger, browser, specParser, equipmentParser, arcaneParser, petEquipmentParser);
        }


        private async Task<(string name, string detailLink)> GetDetailLinkAsync(Page page, string nickName)
        {
            var getNameAndLinkJs =
                    $"() => {{ " +
                    $"const c = Array.from(document.querySelectorAll('div.rank_table_wrap > table > tbody > tr > td.left > dl > dt > a'))" +
                    $".find(a => a.innerText.toUpperCase() === '{nickName}'.toUpperCase()); " +
                    $"return c" +
                    $" ? `${{c.innerText}} ${{c.href}}`" +
                    $" : ''; }}";

            var characterDetail = (await page.EvaluateFunctionAsync<string>(getNameAndLinkJs)).Split(" ");
            if (characterDetail.Length != 2)
            {
                throw new CharacterNotFoundException(nickName);
            }
            return (characterDetail[0], characterDetail[1]);
        }

        private async Task EnsureIsPublicAsync(Page page, string nickName)
        {
            var isPublic = await page.EvaluateFunctionAsync<bool>(@"() => !document.querySelector('div.private2')");
            if (!isPublic)
            {
                throw new CharacterPrivateException(nickName);
            }
        }

        private async Task<(Page equipmentPage, Page petPage)> OpenEquipmentAndPetPagesAsync(Page page, string nickName)
        {
            var equipmentLink = await page.GetLinkFromSelector(Selectors.EQUIP_LINK);
            var petLink = await page.GetLinkFromSelector(Selectors.PET_LINK);

            var equipmentPageTask = Browser.NewLitePageAsync(equipmentLink);
            var petPageTask = Browser.NewLitePageAsync(petLink);

            await Task.WhenAll(equipmentPageTask, petPageTask);

            var equipmentPage = equipmentPageTask.Result;
            var petPage = petPageTask.Result;

            return (equipmentPage, petPage);
        }

        private async Task<CharacterGeneralInformation> GetGeneralInformationAsync(Page page, string nickName)
        {
            try
            {
                var generalInformationText = await page.GetInnerTextFromSelector(Selectors.GENERAL_INFO_TABLE);

                var lines = generalInformationText.Replace("\t", "\n").Split("\n").Where(l => !string.IsNullOrWhiteSpace(l)).ToList();

                var world = lines[1].Trim();
                var job = lines[3].Split("/")[1].Trim();

                var level = (await page.GetInnerTextFromSelector(Selectors.CHAR_INFO_LEVEL)).ParseInt();
                var image = await page.GetImageLinkFromSelector(Selectors.CHAR_IMAGE);

                var traitsNode = await page.EvaluateFunctionAsync("() => Array.from(document.querySelectorAll('div.tab02_con_wrap div.lv')).map(e => e.innerText).join(',')");
                var levels = traitsNode
                    .ToString()
                    .Split(",")
                    .Select(s => s.ParseInt())
                    .ToList();
                var traits = new Traits(levels[0], levels[1], levels[2], levels[3], levels[4], levels[5]);


                var generalInformation = new CharacterGeneralInformation
                {
                    Name = nickName,
                    World = world,
                    Job = job,
                    Level = level,
                    ImageUrl = image,
                    Traits = traits,
                };

                return generalInformation;
            }
            catch (Exception ex)
            {
                Logger.LogError($"{nickName} : 기본 정보를 불러오지 못했습니다", ex);
                throw;
            }
        }

        private async Task<Spec> GetSpecAsync(Page page, string nickName)
        {
            try
            {
                var specText = await page.GetInnerTextFromSelector(Selectors.SPEC_INFO_TABLE);
                var spec = SpecParser.Parse(specText);
                return spec;
            }
            catch(Exception ex)
            {
                Logger.LogError($"{nickName} : 스펙 정보를 불러오지 못했습니다", ex);
                throw;
            }
        }

        private async Task<IList<Equipment>> GetEquipmentsAsync(Page equipmentPage, string nickName)
        {
            var waitSelectorOptions = new WaitForSelectorOptions { Timeout = 10000 };
            var equipments = new List<Equipment>();
            foreach (var item in Items.ITEMS_TO_PARSE)
            {
                try
                {
                    var itemSelector = string.Format(Selectors.EQUIPMENT_LIST_ITEM, (int) item);
                    var itemLink = await equipmentPage.GetLinkFromSelector($"{itemSelector} a");
                    if (string.IsNullOrEmpty(itemLink) || itemLink.StartsWith(Sites.MAPLESTORY_CHARACTER_DETAIL))
                    {
                        continue;
                    }
                    await equipmentPage.ClickAsync($"{itemSelector} img");
                    await Task.Delay(100);
                    await equipmentPage.WaitForSelectorAsync("div.tab01_con_wrap > div.item_info > div.item_info_wrap", waitSelectorOptions);
                    var content = await equipmentPage.GetInnerTextFromSelector(Selectors.ITEM_CONTENT);
                    var image = await equipmentPage.GetImageLinkFromSelector($"{Selectors.ITEM_CONTENT} img");
                    var equipmentLines = string.Join("\n", content, image);
                    var equipment = EquipmentParser.Parse(equipmentLines);
                    equipments.Add(equipment);
                    await equipmentPage.EvaluateFunctionAsync(@"() => document.querySelector('div.tab01_con_wrap > div.item_info > div.item_info_wrap').remove()");
                }
                catch (Exception ex)
                {
                    Logger.LogError($"{nickName}: {item}을 가져오지 못했습니다.", ex);
                    continue;
                }

            }
            return equipments;
        }

        private async Task<IList<Symbol>> GetArcaneSymbols(Page page, string name)
        {
            var waitSelectorOptions = new WaitForSelectorOptions { Timeout = 5000 };
            var equipments = new List<Symbol>();

            await Task.Delay(200);
            await page.ClickAsync(Selectors.ARCANE_INFO_TAB);
            await page.WaitForSelectorAsync("div.tab03_con_wrap > div.arcane_weapon_wrap", waitSelectorOptions);

            for (var i = 1; i <= 6; i++)
            {
                try
                {
                    var arcaneSelector = Selectors.GetArcaneInfoNumber(i);
                    var arcaneLink = await page.GetLinkFromSelector($"{arcaneSelector} a");
                    if (string.IsNullOrEmpty(arcaneLink) || arcaneLink.StartsWith(Sites.MAPLESTORY_CHARACTER_DETAIL))
                    {
                        continue;
                    }
                    await Task.Delay(500);
                    await page.ClickAsync(arcaneSelector);
                    await page.WaitForSelectorAsync("div.tab03_con_wrap > div.item_info > div.item_info_wrap > div.item_title", waitSelectorOptions);

                    var content = await page.GetInnerTextFromSelector("div.tab03_con_wrap > div.item_info > div.item_info_wrap");

                    var arcane = ArcaneParser.Parse(content);
                    equipments.Add(arcane);
                    await page.EvaluateFunctionAsync(@"() => document.querySelector('div.tab03_con_wrap > div.item_info > div.item_info_wrap').remove()");
                }
                catch (Exception ex)
                {
                    Logger.LogError($"{name} : {i}번째 아케인 심볼을 가져오지 못했습니다", ex);
                    continue;
                }
            }

            return equipments;
        }

        private async Task<IList<EquipmentBase>> GetOtherEquipmentsAsync(Page page, string name, string job)
        {
            var nbItem = job == "메카닉"
                ? 5
                : job == "에반"
                    ? 4
                    : 0;

            if (nbItem == 0)
            {
                Logger.LogInformation($"{name} : 메카닉 또는 에반이 아니어서 추가 장비를 가져오지 않습니다");
                return null;
            }

            var waitSelectorOptions = new WaitForSelectorOptions { Timeout = 5000 };
            var equipments = new List<EquipmentBase>();
            await Task.Delay(200);
            await page.ClickAsync(Selectors.OTHER_EQUIPMENT_TAB_SELECTOR);

            for (int i = 1; i <= nbItem; i++)
            {
                try
                {
                    var itemSelector = $"div.tab04_con_wrap > div:nth-child(1) > ul > li:nth-child({i})";
                    var itemLink = await page.GetLinkFromSelector($"{itemSelector} a");
                    if (string.IsNullOrEmpty(itemLink) || itemLink.StartsWith(Sites.MAPLESTORY_CHARACTER_DETAIL))
                    {
                        continue;
                    }
                    await page.ClickAsync(itemSelector);
                    await Task.Delay(100);
                    await page.WaitForSelectorAsync("div.tab04_con_wrap > div.item_info > div.item_info_wrap", waitSelectorOptions);
                    var content = await page.GetInnerTextFromSelector("div.tab04_con_wrap > div.item_info");
                    var image = await page.GetImageLinkFromSelector("div.tab04_con_wrap > div.item_info img");
                    var equipment = EquipmentParser.Parse($"{content}\n{image}");
                    equipments.Add(equipment);
                    await page.EvaluateFunctionAsync(@"() => document.querySelector('div.tab04_con_wrap > div.item_info > div.item_info_wrap').remove()");
                }
                catch (Exception ex)
                {
                    Logger.LogError($"{name} : {i}번째 추가장비를 가져오지 못했습니다", ex);
                    continue;
                }
            }

            return equipments;
        }

        private async Task<IList<CashEquipment>> GetPetEquipmentsAsync(Page page, string name)
        {
            var waitSelectorOptions = new WaitForSelectorOptions { Timeout = 5000 };
            var equipments = new List<CashEquipment>();
            await Task.Delay(200);
            await page.ClickAsync(Selectors.PET_INFO_TAB_SELECTOR);

            var lengthNode = await page.EvaluateFunctionAsync("() => document.querySelectorAll('div.pet_item_list li').length");
            var length = int.Parse(lengthNode.ToString());

            for (var i = 1; i <= length; i++)
            {
                try
                {
                    var itemSelector = Selectors.GetPetInfoNumber(i);
                    await page.ClickAsync(itemSelector);
                    await Task.Delay(500);
                    await page.WaitForSelectorAsync("#mCSB_1_container > div", waitSelectorOptions);
                    var content = await page.GetInnerTextFromSelector("#mCSB_1_container > div");
                    var image = await page.GetImageLinkFromSelector("#mCSB_1_container > div img");

                    var equipement = PetEquipmentParser.Parse($"{content}\n{image}");
                    equipments.Add(equipement);

                    await page.EvaluateFunctionAsync(@"() => document.querySelector('#mCSB_1_container > div').remove()");
                    await page.ClickAsync("body > div.layer_wrap > div > div.item_pop_title > span > a");
                    if (i < length)
                        await Task.Delay(500);
                }
                catch (Exception ex)
                {
                    Logger.LogError($"{name} : {i}번째 펫장비를 가져오지 못했습니다", ex);
                    continue;
                }
            }

            return equipments;
        }

        public async Task<Character> GetCharacterAsync(string nickName)
        {
            if (Browser.IsClosed)
            {
                throw new Exception("브라우저가 종료되었습니다.");
            }

            Logger.LogInformation($"{nickName}: 랭킹 페이지 검색중...");
            await using var page = await Browser.NewLitePageAsync(Sites.GetRankingSearchUrl(nickName));
            var (name, detailLink) = await GetDetailLinkAsync(page, nickName);

            Logger.LogInformation($"{name}: 상세 정보 페이지 {detailLink} 이동중...");
            await page.GoToAsync(detailLink, WaitUntilNavigation.DOMContentLoaded);
            await EnsureIsPublicAsync(page, name);

            Logger.LogInformation($"{name}: 펫, 장비 페이지 여는중...");
            var (equipmentPage, petPage) = await OpenEquipmentAndPetPagesAsync(page, name);

            Logger.LogInformation($"{name}: 월드, 직업, 레벨, 성향 긁어오는중...");
            var generalInformation = await GetGeneralInformationAsync(page, name);

            Logger.LogInformation($"{name}: 스펙 긁어오는중...");
            var spec = await GetSpecAsync(page, name);
            await page.CloseAsync();

            Logger.LogInformation($"{name}: 펫장비 긁어오는중...");
            var petEquipments = await GetPetEquipmentsAsync(petPage, name);
            await petPage.CloseAsync();

            Logger.LogInformation($"{name}: 장비 긁어오는중...");
            var equipments = await GetEquipmentsAsync(equipmentPage, name);

            Logger.LogInformation($"{name}: 아케인 심볼 긁어오는중...");
            var arcanes = await GetArcaneSymbols(equipmentPage, name);

            Logger.LogInformation($"{name}: 추가장비 긁어오는중...");
            var otherEquipments = await GetOtherEquipmentsAsync(equipmentPage, name, generalInformation.Job);

            var character = new Character(generalInformation)
            {
                Spec = spec,
                Equipments = equipments,
                Arcanes = arcanes,
                OtherEquipments = otherEquipments,
                PetEquipments = petEquipments,
            };

            return character;
        }

        public void Dispose()
        {
            Browser.CloseAsync();
        }
    }
}
