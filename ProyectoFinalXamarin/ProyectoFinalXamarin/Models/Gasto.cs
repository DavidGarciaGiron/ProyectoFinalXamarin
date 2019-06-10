using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalXamarin.Models
{
    public class Gasto
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaGasto { get; set; }

        public double Monto { get; set; }

        public string TipoGasto { get; set; }
    }
}
