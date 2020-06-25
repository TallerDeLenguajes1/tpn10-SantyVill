using System;
using System.IO;

namespace ConversorMorse
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadena;
            Console.WriteLine("Ingrese un texto para convertirlo a morse y guardarlo en un archivo: ");
            cadena=Console.ReadLine();
            Console.WriteLine("Codigo Morse guardado: "+ConversorDeMorse.TextoAMorse(cadena));
            /*string path = ConversorDeMorse.CrearMorse(cadena);
            string nuevaCad = ConversorDeMorse.LeerMorse(path);
            Console.WriteLine("Codigo convertido nuevamente a texto: "+nuevaCad);
            FileInfo ruta = new FileInfo(path);
            Console.WriteLine("Revisar archivos guardados en: "+ruta.Directory);*/
            ConversorDeMorse.CrearMp3(cadena);

        }
    }
}
