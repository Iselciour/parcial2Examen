using parcial2Examen.Model;
using parcial2Examen.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace parcial2Examen.ViewModels
{
    public class GasListViewModel : BaseViewModel
    {
        static GasListViewModel instance;

        Command newTaskCommand;
        public Command NewTaskCommand => newTaskCommand ?? (newTaskCommand = new Command(NewTaskAction));

        List<GasModel> gas;
        public List<GasModel> Gas
        {
            get => gas;
            set => SetProperty(ref gas, value);
        }

        GasModel gasSelected;
        public GasModel GasSelected
        {
            get => gasSelected;
            set
            {
                if (SetProperty(ref gasSelected, value))
                {
                    SelectTaskAction();
                }
            }
        }

        public GasListViewModel()
        {
            instance = this;

            LoadTasks();
        }

        public static GasListViewModel GetInstance()
        {
            if (instance == null) instance = new GasListViewModel();
            return instance;
        }

        public async void LoadTasks()
        {
            Gas = await App.DataB.GetAllTasksAsync();
        }

        private void NewTaskAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Details());
        }

        private void SelectTaskAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Details(GasSelected));
        }
    }
}