using CaddyMac.Data;

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

        var rounds = await _database.GetRounds("test");
        RoundsList.ItemsSource = rounds;
    }
}