using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace parcial2Examen.Model
{
    [Table("Task")]
    public class GasModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Establishment { get; set; }

        public string ImageBase64 { get; set; }

        public string GreenGasP { get; set; }

        public string RedGasP { get; set; }

        public string DieselP { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}