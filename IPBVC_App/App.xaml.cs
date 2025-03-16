using System.Globalization;

namespace IPBVC_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            MainPage = new AppShell();
        }
    }
}