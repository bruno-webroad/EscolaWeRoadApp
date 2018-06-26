using EscolaWRApp.Models;
using EscolaWRApp.Pages;
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

        private Cliente _cliente;
        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }

            set
            {
                _cliente = value;
                NotifyPropertyChanged("Cliente");
            }
        }

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

        private string _senha;
        public string Senha
        {
            get
            {
                return _senha;
            }

            set
            {
                _senha = value;
                NotifyPropertyChanged("Senha");
            }
        }

        public LoginViewModel()
        {
            this.EntrarCommand = new Command(Entrar);
            Cliente = new Cliente();
        }

        private void Entrar()
        {
            if (string.IsNullOrEmpty(Email))
            {
                Erro = "Por favor, digite um e-mail";
                return;
            }

            if (string.IsNullOrEmpty(Senha))
            {
                Erro = "Por favor, digite uma senha";
                return;
            }

            App.Current.MainPage = new IndexPage();
        }
    }
}
