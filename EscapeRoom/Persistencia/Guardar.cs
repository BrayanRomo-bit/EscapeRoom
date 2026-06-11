using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace EscapeRoom.Persistencia
{
    public static class Guardar
    {
        private static string carpetaPartidas = Path.Combine(Application.StartupPath, "Partidas Guardadas");

        public static void Guardado(EstadoJuego estado, string nombreUsuario)
        {
            if (!Directory.Exists(carpetaPartidas))
            {
                Directory.CreateDirectory(carpetaPartidas);
            }

            string nombreArchivo = nombreUsuario + ".json";
            string ruta = Path.Combine(carpetaPartidas, nombreArchivo);

            string json = JsonSerializer.Serialize(estado);

            File.WriteAllText(ruta, json);
        }

        public static EstadoJuego Cargar(string nombreUsuario)
        {
            string nombreArchivo = nombreUsuario + ".json";
            string ruta = Path.Combine(carpetaPartidas, nombreArchivo);

            if (!File.Exists(ruta))
            {
                return null;
            }

            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<EstadoJuego>(json);
        }

        public static int ObtenerRecords()
        {
            int recordMaximo = 0;
            string rutaCarpeta = "Partidas Guardadas";
            if (Directory.Exists(rutaCarpeta))
            {

                string[] archivos = Directory.GetFiles(rutaCarpeta, "*.json");

                foreach (string archivo in archivos)
                {
                    try
                    {
                        string json = File.ReadAllText(archivo);
                        EstadoJuego estado = JsonSerializer.Deserialize<EstadoJuego>(json);

                        if (estado != null && estado.PuntajePrisionero > recordMaximo) recordMaximo = estado.PuntajePrisionero;
                    }
                    catch
                    {
                        //decir si hay un archivo corrupto
                        

                        //System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }
            }
            return recordMaximo;
        }
    }
}