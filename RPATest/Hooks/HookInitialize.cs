using RPAFramework.Base;
using RPAFramework.Config;
using RPAFramework.Helpers;
using TechTalk.SpecFlow;

namespace RPATest.Hooks
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize() : base(BrowserType.FireFox)
        {
            InitializeSettings();
            Settings.ApplicationCon = Settings.ApplicationCon.DBConnect(Settings.AppConnectionString);
        }

        [BeforeFeature]
        public static void TestStart()
        {
            HookInitialize init = new HookInitialize();
        }
    }
}
