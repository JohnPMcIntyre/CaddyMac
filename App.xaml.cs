using CaddyMac.Data;
using CaddyMac.Views;

namespace CaddyMac
{
    public partial class App : Application
    {
        private readonly DatabaseService _databaseService;

        public App(DatabaseService databaseService)
        {
            InitializeComponent();

            _databaseService = databaseService;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(
                new NavigationPage(
                    new LoginPage(_databaseService)));
        }
    }
}