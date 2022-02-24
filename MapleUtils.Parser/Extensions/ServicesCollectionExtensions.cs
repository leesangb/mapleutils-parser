using MapleUtils.Parser.Parsers;
using Microsoft.Extensions.DependencyInjection;

namespace MapleUtils.Parser.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddMapleUtilsParser(this IServiceCollection services)
        {
            services.AddSingleton(PuppeteerExtensions.GetBrowser());
            services.AddSingleton<IAbilitiesParser, AbilitiesParser>();
            services.AddSingleton<IArcaneParser, ArcaneParser>();
            services.AddSingleton<IEquipmentParser, EquipmentParser>();
            services.AddSingleton<IHyperStatsParser, HyperStatsParser>();
            services.AddSingleton<IPetEquipmentParser, PetEquipmentParser>();
            services.AddSingleton<ISpecParser, SpecParser>();
            services.AddSingleton<IMapleUtilsParser, MapleUtilsParser>();
        }
    }
}
