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
    public class LoginViewModel : BaseViewModel
    {
        public ICommand EntrarCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
                NotifyPropertyChanged("Email");
            }
        }

        private string _error;
        public string Error
        {
            get
            {
                return _error;
            }

            set
            {
                _error = value;
                NotifyPropertyChanged("Error");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public LoginViewModel()
        {
            this.EntrarCommand = new Command(Entrar);
            this.RegisterCommand = new Command(Register);
        }

        private void Entrar()
        {
            if (string.IsNullOrEmpty(Email))
            {
                Error = "Por favor, digite um e-mail";
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                Error = "Por favor, digite uma senha";
                return;
            }

            var usuario = UserService.Authenticate(Email, Password);
            if(usuario == null)
            {
                Error = "E-mail ou senha inválidos.";
                return;
            }

            App.Current.MainPage = new IndexPage();
        }

        private async void Register()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
