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
    }
}