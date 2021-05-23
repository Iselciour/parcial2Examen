using parcial2Examen.Model;
using parcial2Examen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace parcial2Examen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details : ContentPage
    {
        public Details()
        {
            InitializeComponent();

            BindingContext = new GasDetailViewModel();
        }

        public Details(GasModel gasSelected)
        {
            InitializeComponent();

            BindingContext = new GasDetailViewModel(gasSelected);
        }
    }
}