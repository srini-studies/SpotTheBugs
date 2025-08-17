using Microsoft.Extensions.Configuration;
using Microsoft.Playwright.NUnit;

namespace SpotTheBugs.Tests
{
    public class BaseTest: PageTest
    {
        public string? BaseUrl { get; set; }

        private readonly IConfiguration _configuration;

        public BaseTest()
        {
            // Set up the configuration from appsettings.json file
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Bind the configuration to the TestConfiguration class
            var testConfig = _configuration.GetSection("PlaywrightConfig").Get<TestConfiguration>();

            // BaseUrl = testConfig?.BaseUrl ?? Constants.Constants.BaseUrl;

            BaseUrl = testConfig?.BaseUrl;

            if (String.IsNullOrEmpty(BaseUrl))
            {
                TestContext.WriteLine("Url is missing in the appsettings configuration");
                throw new Exception("Url is missing in the appsettings configuration");
            }
        }

        [SetUp]
        public virtual async Task Setup()
        {
            // setup trace
            await Context.Tracing.StartAsync(new()
            {
                Title = TestContext.CurrentContext.Test.ClassName + "." + TestContext.CurrentContext.Test.Name,
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        [TearDown]
        public virtual async Task TearDown()
        {
            // produce trace
            await Context.Tracing.StopAsync(new()
            {
                Path = Path.Combine(
                    TestContext.CurrentContext.WorkDirectory,
                    "playwright-traces",
                    $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
                )
            });
        }

    }
}
