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
    public class RegisterViewModel : BaseViewModel
    {
        public ICommand RegisterCommand { get; set; }

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

        private string _erro;
        public string Erro
        {
            get
            {
                return _erro;
            }

            set
            {
                _erro = value;
                NotifyPropertyChanged("Erro");
            }
        }

        public RegisterViewModel()
        {
            this.RegisterCommand = new Command(Register);
            User = new User();
        }

        private void Register()
        {
            try
            {
                UserService.Insert(User);
                App.Current.MainPage = new IndexPage();
            }
            catch (Exception ex)
            {
                Erro = ex.Message;
            }
        }
    }
}
