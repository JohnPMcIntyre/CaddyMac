using CaddyMac.Data;
using CaddyMac.Views;

namespace CaddyMac.Views;

public partial class DashboardPage : ContentPage
{
    private readonly DatabaseService _database;

    public DashboardPage(DatabaseService database)
    {
        InitializeComponent();
        _database = database;
    }

    private async void OnAddRound(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddRoundPage(_database));
    }

    private async void OnViewRounds(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewRoundsPage(_database));
    }

    private async void OnLogout(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}