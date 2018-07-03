using Acr.UserDialogs;
using EscolaWRApp.Helpers;
using EscolaWRApp.Models;
using EscolaWRApp.Pages;
using EscolaWRApp.Service;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EscolaWRApp.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        public ICommand LogoutCommand { get; set; }
        public ICommand PhotoCommand { get; set; }

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
            this.PhotoCommand = new Command(Photo);
            GetUser();
        }

        private void GetUser()
        {
            User = new User()
            {
                Email = Settings.Email,
                Name = Settings.Name,
                UrlPhoto = string.IsNullOrEmpty(Settings.UrlPhoto) ? "profile_default.png" : Settings.UrlPhoto
            };
        }

        private void Logout()
        {
            Settings.Email = string.Empty;
            Settings.Name = string.Empty;
            App.Current.MainPage = new NavigationPage(new IntroductionPage());
        }

        private async void Photo()
        {
            var op = await UserDialogs.Instance.ActionSheetAsync("Deseja tirar uma foto ou pega-la na galeria?", "Cancelar", "", null, "Tirar foto", "Galeria de fotos");
            if (op == "Tirar foto")
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    AllowCropping = true,
                    CompressionQuality = 90,
                    DefaultCamera = CameraDevice.Rear,
                    SaveToAlbum = false
                });

                if (file == null)
                    return;

                await UserService.SaveOrUpdatePhoto(file.GetStream(), Settings.Email);
                GetUser();
            }
            else if (op == "Galeria de fotos")
            {
                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    CompressionQuality = 80,
                });

                if (file == null)
                    return;

                await UserService.SaveOrUpdatePhoto(file.GetStream(), Settings.Email);
                GetUser();
            }
        }
    }
}
