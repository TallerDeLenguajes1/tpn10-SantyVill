using System;
using System.Collections.Generic;
using System.Text;

namespace punto1
{
    class Propiedad
    {
        public enum TipoDeOperacion
        {
            Venta = 0,
            Alquiler = 1,
        }
        public enum TipoDePropiedad
        {
            Departamento,
            Casa,
            Duplex,
            Penthhouse,
            Terreno,
        }
        public int id;
        public string tipoDePropiedad;
        public string tipoDeOperacion;
        public float tamanio;
        public int cantidadDeBanios;
        public int cantidadDeHabitaciones;
        public string domicilio;
        public int precio;
        public bool estado;
        
        public float ValorDelInmueble()
        {
            if (tipoDeOperacion==TipoDeOperacion.Venta.ToString())
            {
                return ((float)(precio * 1.21+ (precio*1.21)*0.1+ 10000));
            }
            else
            {
                return ((float)((float)(precio*1.02)*1.005));
            }
        }

    }
}
