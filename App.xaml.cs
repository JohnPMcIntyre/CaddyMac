using CaddyMac.Data;
using CaddyMac.Views;
using Microsoft.Maui.Storage;

namespace CaddyMac;

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
        var username = Preferences.Get("current_user", null);

        Page startPage;

        if (string.IsNullOrEmpty(username))
        {
            startPage = new NavigationPage(new LoginPage(_databaseService));
        }
        else
        {
            startPage = new NavigationPage(new DashboardPage(_databaseService));
        }

        return new Window(startPage);
    }
}