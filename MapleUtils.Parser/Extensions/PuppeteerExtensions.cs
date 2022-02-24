using PuppeteerSharp;

namespace MapleUtils.Parser.Extensions
{
    internal static class PuppeteerExtensions
    {
        internal static Browser GetBrowser(bool isHeadless = true)
        {
            string[] args =
            {
                "--disable-default-apps",
                "--disable-notifications",
                "--disable-extensions",
                "--no-sandbox",
                "--disable-setuid-sandbox",
                "--disable-dev-shm-usage",
                "--no-zygote",
                "--disable-accelerated-2d-canvas",
                "--disable-gpu",
                "--window-size=1600,900"
            };
            var launchOptions = new LaunchOptions()
            {
                Headless = isHeadless,
                IgnoreHTTPSErrors = true,
                LogProcess = false,
                Args = args,
                DefaultViewport = new ViewPortOptions
                {
                    Width = 1600,
                    Height = 900,
                }
            };

            Browser browser = null;

            try
            {
                browser = Puppeteer.LaunchAsync(launchOptions).Result;
            }
            catch (Exception ex)
            {
                var browserFetcher = new BrowserFetcher();
                var revisionInfo = browserFetcher.DownloadAsync().Result;
                browser = Puppeteer.LaunchAsync(launchOptions).Result;
            }
            return browser;
        }

        private static readonly ResourceType[] Blocked =
        {
            ResourceType.Font,
            ResourceType.Media,
            ResourceType.Ping,
        };

        public static async Task<Page> NewLitePageAsync(this Browser browser, string url)
        {
            var page = await browser.NewPageAsync();
            await page.SetRequestInterceptionAsync(true);

            page.Request += (sender, e) =>
            {
                if (Blocked.Any(b => b == e.Request.ResourceType))
                {
                    e.Request.AbortAsync();
                }
                else
                {
                    e.Request.ContinueAsync();
                }
            };
            await page.GoToAsync(url, WaitUntilNavigation.DOMContentLoaded);

            return page;
        }

        public static async Task<string> GetLinkFromSelector(this Page page, string selector)
        {
            var linkNode = await page.EvaluateFunctionAsync<string>(@"(sel) => document.querySelector(sel)?.href", selector);
            return linkNode;
        }

        public static async Task<string> GetImageLinkFromSelector(this Page page, string selector)
        {
            var linkNode = await page.EvaluateFunctionAsync<string>(@"(sel) => document.querySelector(sel)?.src", selector);
            return linkNode;
        }

        public static async Task<string> GetInnerTextFromSelector(this Page page, string selector)
        {
            var node = await page.EvaluateFunctionAsync<string>(@"(sel) => document.querySelector(sel)?.innerText", selector);
            return node;
        }
    }
}
