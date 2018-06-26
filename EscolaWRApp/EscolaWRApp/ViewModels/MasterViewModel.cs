using EscolaWRApp.Models;
using EscolaWRApp.Pages;
using EscolaWRApp.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EscolaWRApp.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        public ICommand LogoutCommand {get;set;}

        private User _user;
        public User User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
                NotifyPropertyChanged("User");
            }
        }

        public MasterViewModel()
        {
            this.LogoutCommand = new Command(Logout);
            User = UserService.GetUserLogged();
        }

        private void Logout()
        {
            UserService.Logout(User);
            App.Current.MainPage = new NavigationPage(new IntroductionPage());
        }
    }
}
