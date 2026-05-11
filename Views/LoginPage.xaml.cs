using CaddyMac.Data;
using CaddyMac.Models;
using Microsoft.Maui.Storage;

namespace CaddyMac.Views;

public partial class LoginPage : ContentPage
{
    private readonly DatabaseService _database;

    public LoginPage(DatabaseService database)
    {
        InitializeComponent();
        _database = database;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text;
        var password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Enter username and password", "OK");
            return;
        }

        var existingUser = await _database.GetUser(username);

        if (existingUser == null)
        {
            var newUser = new User
            {
                Username = username,
                Password = password
            };

            await _database.AddUser(newUser);

            Preferences.Set("current_user", username);

            await DisplayAlert("Success", "Account Created", "OK");
        }
        else
        {
            if (existingUser.Password != password)
            {
                await DisplayAlert("Error", "Incorrect Password", "OK");
                return;
            }

            Preferences.Set("current_user", username);

            await DisplayAlert("Success", "Login Successful", "OK");
        }

        await Navigation.PushAsync(new DashboardPage(_database));
    }
}