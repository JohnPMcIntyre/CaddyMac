using CaddyMac.Data;
using Microsoft.Maui.Storage;

namespace CaddyMac.Views;

public partial class ViewRoundsPage : ContentPage
{
    private readonly DatabaseService _database;

    public ViewRoundsPage(DatabaseService database)
    {
        InitializeComponent();
        _database = database;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var username = Preferences.Get("current_user", null);

        if (string.IsNullOrEmpty(username))
        {
            await DisplayAlert("Error", "No user logged in", "OK");
            return;
        }

        var rounds = await _database.GetRounds(username);

        RoundsList.ItemsSource = rounds;
    }
}