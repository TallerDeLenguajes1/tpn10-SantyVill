using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace ConversorMorse
{
    static public class ConversorDeMorse
    {
        static Dictionary<string, string> DiccMorse = new Dictionary<string, string>()
        {
            { ".-", "a" },{ "-...", "b" },{ "-.-.", "c" },
            { "-..", "d" },{ ".", "e" },{ "..-.", "f" },
            { "--.", "g" },{ "....", "h" },{ "..", "i" },
            { ".---", "j" },{ "-.-", "k" },{ ".-..", "l" },
            { "--", "m" },{ "-.", "n" },{ "---", "o" },
            { ".--.", "p" },{ "--.-", "q" },{ ".-.", "r" },
            { "...", "s" },{ "-", "t" },{ "..-", "u" },
            { "...-", "v" },{ ".--", "w" },{ "-..-", "x" },
            { "-.--", "y" },{ "--..", "z" }
        };
        static Dictionary<string, string> DiccTextAMorse = new Dictionary<string, string>()
        {
            { "a",".-"  },{ "b","-..."  },{ "c", "-.-." },
            { "d","-.."  },{ "e","."  },{ "f","..-."  },
            { "g","--."  },{"h" ,"...."  },{ "i",".."  },
            { "j",".---"  },{ "k","-.-"  },{ "l",".-.."  },
            { "m", "--" },{"n", "-."  },{ "o", "---" },
            { "p", ".--." },{ "q", "--.-" },{ "r", ".-." },
            { "s", "..." },{ "t", "-" },{ "u", "..-" },
            { "v", "...-" },{ "w", ".--" },{ "x", "-..-" },
            { "y", "-.--" },{ "z" , "--.."}
        };

        static public string MorseATexto(string cadena)
        {
            string conversion="";
            string[] palabras = cadena.Split("/");
            foreach (string item in palabras)
            {
                string[] letras = item.Split(" ");
                foreach (string letra in letras)
                {
                    if (DiccMorse.ContainsKey(letra))
                    {
                        conversion += DiccMorse[letra];
                    }
                }
                conversion += " ";
            }
            return conversion;
        }
        static public string TextoAMorse(string cadena)
        {
            cadena = cadena.ToLower();
            string conversion = "";
            foreach (char item in cadena)
            {
                if (DiccTextAMorse.ContainsKey(item.ToString()))
                {
                    conversion += DiccTextAMorse[item.ToString()] + " ";
                }
                else if (item.ToString()==" ")
                {
                    conversion += "/";
                }
            }
            return conversion;
        }
        static public string CrearMorse(string cadena)
        {
            string ruta = @"C:\Repogit\Mensajes\";
            string nombre = "Morse_" + DateTime.Now.ToString("yy-MM-dd hh-mm-ss");
            string Path=ruta+nombre+".txt";
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
            FileStream archivos = File.Create(Path);
            archivos.Close();
            File.WriteAllText(Path, TextoAMorse(cadena));
            return Path;
        }
        static public string LeerMorse(string path)
        {
            if (File.Exists(path))
            {
                FileInfo archivo = new FileInfo(path);
                string[] fecha = archivo.Name.Split("_");
                string texto=File.ReadAllText(path);
                string NPath = archivo.Directory + "/Texto_" + fecha[1];
                FileStream aux = File.Create(NPath);
                aux.Close();
                texto = MorseATexto(texto);
                File.WriteAllText(NPath, texto);
                return texto;
            }
            return "No se encontro el archivo.";
        }
        static public void CrearMp3(string texto){
            string path = @"c:/Repogit/tpn10-SantyVill/punto2/ConversorMorse/";
            byte[] mp3Punto = File.ReadAllBytes(path + @"/prueba/punto.mp3");
            byte[] mp3Raya = File.ReadAllBytes(path + @"/prueba/raya.mp3");
            if (!(texto.Contains("-") || texto.Contains(".")))
            {
                texto = TextoAMorse(texto);
            }
            if (File.Exists(path+"/prueba/AudioMorse.mp3"))
            {
                File.Delete(path + "/prueba/AudioMorse.mp3");
                FileStream aux = File.Create(path + "/prueba/AudioMorse.mp3");
                aux.Close();
            }
            else
            {
                FileStream aux = File.Create(path + "/prueba/AudioMorse.mp3");
                aux.Close();
            }
            using (FileStream mp3 = File.OpenWrite(path + "/prueba/AudioMorse.mp3"))
            {
                foreach (char item in texto)
                {
                    if (item.ToString() == ".")
                    {
                        for (int i = 0; i < mp3Punto.Length; i++)
                        {
                            mp3.WriteByte(mp3Punto[i]);
                            //Console.WriteLine(mp3Punto[i]);
                        }
                    }
                    else if (item.ToString() == "-")
                    {
                        for (int i = 0; i < mp3Raya.Length; i++)
                        {
                            mp3.WriteByte(mp3Raya[i]);
                            //Console.WriteLine(mp3Raya[i]);
                        }
                    }
                }
                mp3.Close();
            }
        }
    }
}
