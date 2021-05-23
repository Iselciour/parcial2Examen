using parcial2Examen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace parcial2Examen.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapp : ContentPage
    {
        public Mapp(GasModel gasSelected)
        {
            InitializeComponent();

            GasMapp.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(
                        gasSelected.Latitude,
                        gasSelected.Longitude
                    ),
                    Distance.FromMiles(.5)
                )
            );

            GasMapp.Pins.Add(
                new Pin
                {
                    Type = PinType.Place,
                    Label = gasSelected.Establishment,
                    Position = new Position(
                        gasSelected.Latitude,
                        gasSelected.Longitude
                    )
                }
            );
            GasEstablishment.Text = gasSelected.Establishment.ToString();
            GasLatitude.Text = gasSelected.Latitude.ToString();
            GasLongitude.Text = gasSelected.Longitude.ToString();
        }
    }
}