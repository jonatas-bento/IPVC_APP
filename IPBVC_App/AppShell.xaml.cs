using IPBVC_App.Views;

namespace IPBVC_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomeScreen), typeof(HomeScreen));
            Routing.RegisterRoute(nameof(EventView), typeof(EventView));
            Routing.RegisterRoute(nameof(NewEventPage), typeof(NewEventPage));
            Routing.RegisterRoute(nameof(WhoWeArePage), typeof(WhoWeArePage));
            Routing.RegisterRoute(nameof(BirthdayPage), typeof(BirthdayPage));

        }

    }
}