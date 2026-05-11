using CaddyMac.Data;
using CaddyMac.Models;

namespace CaddyMac.Views;

public partial class AddRoundPage : ContentPage
{
    private readonly DatabaseService _database;

    public AddRoundPage(DatabaseService database)
    {
        InitializeComponent();
        _database = database;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(CourseEntry.Text) ||
            string.IsNullOrWhiteSpace(ScoreEntry.Text))
        {
            await DisplayAlert("Error", "Enter course and score", "OK");
            return;
        }

        var round = new Round
        {
            CourseName = CourseEntry.Text,
            Score = int.Parse(ScoreEntry.Text),
            DatePlayed = DateTime.Now,
            Username = "test" // temporary (we fix later)
        };

        await _database.AddRound(round);

        await DisplayAlert("Success", "Round saved!", "OK");

        await Navigation.PopAsync();
    }
}