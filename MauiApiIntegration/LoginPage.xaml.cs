using MauiApiIntegration.Pages;
using MauiApiIntegration.Services;

namespace MauiApiIntegration;

public partial class LoginPage : ContentPage
{
    readonly ILoginRepository _loginRepository = new LoginService();
	public LoginPage()
	{
		InitializeComponent();
	}
	private async void Login_Clicked(Object sender,EventArgs e)
	{
        string userName = txtUserName.Text;
        string password = txtPassword.Text;
        if (userName == null || password == null)
        {
            await DisplayAlert("Warning", "Please Input Username & Password", "Ok");
            return;
        }
        var userinfo = await _loginRepository.Login(userName, password);
        if (userinfo!=null)
        {
            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            await DisplayAlert("Invalid User", " Username or Password incorrect", "Ok");
        }
    }
}