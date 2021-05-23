using parcial2Examen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Media;
using Xamarin.Forms;
using parcial2Examen.Services;
using parcial2Examen.Views;
using Xamarin.Essentials;

namespace parcial2Examen.ViewModels
{
    public class GasDetailViewModel : BaseViewModel
    {


        Command selectPictureCommand;
        public Command SelectPictureCommand => selectPictureCommand ?? (selectPictureCommand = new Command(SelectPictureAction));

        Command saveCommand;
        public Command SaveCommand => saveCommand ?? (saveCommand = new Command(SaveAction));

        Command mapCommand;
        public Command MapCommand => mapCommand ?? (mapCommand = new Command(MapAction));

        Command deleteCommand;
        public Command DeleteCommand => deleteCommand ?? (deleteCommand = new Command(DeleteAction));

        Command cancelCommand;
        public Command CancelCommand => cancelCommand ?? (cancelCommand = new Command(CancelAction));

        GasModel gasSelected;
        public GasModel GasSelected
        {
            get => gasSelected;
            set => SetProperty(ref gasSelected, value);
        }

        string imageBase64;
        public string ImageBase64
        {
            get => imageBase64;
            set => SetProperty(ref imageBase64, value);
        }

        ImageSource imageSource_;
        public ImageSource ImageSource_
        {
            get => imageSource_;
            set => SetProperty(ref imageSource_, value);
        }

        public GasDetailViewModel()
        {
            GasSelected = new GasModel();
        }

        public GasDetailViewModel(GasModel gasSelected)
        {
            GasSelected = gasSelected;
            ImageBase64 = gasSelected.ImageBase64;
        }

        private async void SaveAction()
        {
            await App.DataB.SaveTaskAsync(GasSelected);
            GasListViewModel.GetInstance().LoadTasks();
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void DeleteAction()
        {
            await App.DataB.DeleteTaskAsync(GasSelected);
            GasListViewModel.GetInstance().LoadTasks();
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void SelectPictureAction()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                await CrossMedia.Current.Initialize();
            }

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Seleccionar fotografías no soportada", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            if (file == null)
                return;

            GasSelected.ImageBase64 = ImageBase64 = await new ImageService().ConvertImageFilePathToBase64(file.Path);
        }

        private async void CancelAction()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void MapAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(
                new Mapp(new GasModel
                {
                    ID = gasSelected.ID,
                    Name = gasSelected.Name,
                    Establishment = gasSelected.Establishment,
                    GreenGasP = gasSelected.GreenGasP,
                    RedGasP = gasSelected.RedGasP,
                    DieselP = gasSelected.DieselP,
                    Latitude = gasSelected.Latitude,
                    Longitude = gasSelected.Longitude
                })
            ); ;
        }
    }
}