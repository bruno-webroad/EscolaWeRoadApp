using EscolaWRApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EscolaWRApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new RegisterPage());        
        }

        private async void Entrar_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(email.Text))
            {
                await DisplayAlert("", "Por favor, digite um e-mail.", "ok");
            }
            else
            {
                await DisplayAlert("", "Tem e-mail.", "ok");
            }
        }
    }
}