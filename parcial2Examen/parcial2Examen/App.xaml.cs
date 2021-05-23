using parcial2Examen.Data;
using parcial2Examen.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace parcial2Examen
{
    public partial class App : Application
    {

        static DataB datab;
        public static DataB DataB
        {
            get
            {
                if (datab == null) datab = new DataB();
                return datab;
            }
        }

        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new ListL());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryPurple"];
            nav.BarTextColor = Color.White;
            MainPage = nav;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
