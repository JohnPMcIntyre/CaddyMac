using CaddyMac.Data;
using CaddyMac.Models;
using Microsoft.Maui.Storage;

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

        if (!int.TryParse(ScoreEntry.Text, out int score))
        {
            await DisplayAlert("Error", "Score must be a number", "OK");
            return;
        }

        var username = Preferences.Get("current_user", null);

        if (string.IsNullOrEmpty(username))
        {
            await DisplayAlert("Error", "No user logged in", "OK");
            return;
        }

        var round = new Round
        {
            CourseName = CourseEntry.Text,
            Score = score,
            DatePlayed = DateTime.Now,
            Username = username
        };

        await _database.AddRound(round);

        await DisplayAlert("Success", "Round saved!", "OK");

        await Navigation.PopAsync();
    }
}