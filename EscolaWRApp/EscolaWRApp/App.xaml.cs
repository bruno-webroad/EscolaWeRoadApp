using EscolaWRApp.Pages;
using EscolaWRApp.Service;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace EscolaWRApp
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            var user = UserService.GetUserLogged();
            if (user == null)
                MainPage = new NavigationPage(new IntroductionPage());
            else
                MainPage = new IndexPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
