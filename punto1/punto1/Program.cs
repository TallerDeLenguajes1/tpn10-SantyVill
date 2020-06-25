using System;
using System.Collections.Generic;
using System.IO;

namespace punto1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = @"c:/Repogit/tpn10-SantyVill/punto1/punto1/bin/debug/";
            string[] filas = File.ReadAllLines(path+"propiedades.csv");
            List<Propiedad> propiedades = new List<Propiedad>();
            int id = 0;
            Random rand= new Random();
            Array valores = Enum.GetValues(typeof(Propiedad.TipoDeOperacion));
            foreach (string item in filas)
            {
                Propiedad prop = new Propiedad();
                string[] datos = item.Split(";");
                Console.WriteLine("datos 1: "+datos[0]+"  datos2:"+datos[1]+"\n");
                prop.id = id;
                id++;
                prop.tipoDePropiedad=datos[1];
                prop.tipoDeOperacion = valores.GetValue(rand.Next(valores.Length)).ToString();
                prop.tamanio = rand.Next(100, 400);
                prop.cantidadDeBanios = rand.Next(1, 6);
                prop.cantidadDeHabitaciones = rand.Next(1,6);
                prop.domicilio = datos[0];
                prop.precio = rand.Next(90000,1000000);
                prop.estado = rand.Next(2) == 1;
                propiedades.Add(prop);
            }
            if (File.Exists(path+ "NPropiedades.csv"))
            {
                FileStream aux = File.Create(path+"NPropiedades.csv");
                aux.Close();
            }
            using (StreamWriter file = new StreamWriter(path + "NPropiedades.csv", true))
            {
                foreach (Propiedad item in propiedades) {   
                    file.WriteLine(item.id + ";" + item.tipoDePropiedad + ";" + item.tipoDeOperacion + ";" + item.tamanio + ";" + item.cantidadDeBanios + ";" + item.cantidadDeHabitaciones + ";" + item.domicilio + ";" + item.precio + ";" + item.estado);
                }
            }
        }
    }
}
