using EscolaWRApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EscolaWRApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
            this.BindingContext = new RegisterViewModel();
		}
	}
}