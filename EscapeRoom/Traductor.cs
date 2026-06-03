using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace EscapeRoom
{
    public static class Traductor
    {
        private static Dictionary<string, string> textosActuales = new Dictionary<string, string>();

        public static string IdiomaActual { get; private set; } = "es";

        public static void CargarIdioma(string idioma)
        {
            try
            {
                IdiomaActual = idioma;
                string nombreArchivo = $"textos_{idioma}.json";
                string rutaArchivo = Path.Combine(Application.StartupPath, nombreArchivo);

                if (File.Exists(rutaArchivo))
                {
                    textosActuales.Clear();
                    string jsonString = File.ReadAllText(rutaArchivo);

                    using (JsonDocument doc = JsonDocument.Parse(jsonString))
                    {
                        AplanarJson(doc.RootElement, "", textosActuales);
                    }
                }
                else
                {
                    MessageBox.Show($"Error crítico: No se encontró el archivo de idioma en:\n{rutaArchivo}");
                }
            }
            catch (Exception ex)
            {
                // Si algo sale mal al leer el JSON, ahora el juego te lo dirá en lugar de callarse
                MessageBox.Show("Error al leer el archivo JSON: " + ex.Message);
            }
        }

        private static void AplanarJson(JsonElement elemento, string prefijoActual, Dictionary<string, string> diccionario)
        {
            if (elemento.ValueKind == JsonValueKind.Object)
            {
                foreach (JsonProperty propiedad in elemento.EnumerateObject())
                {
                    string nuevoPrefijo = string.IsNullOrEmpty(prefijoActual) ? propiedad.Name : $"{prefijoActual}.{propiedad.Name}";
                    AplanarJson(propiedad.Value, nuevoPrefijo, diccionario);
                }
            }
            else if (elemento.ValueKind == JsonValueKind.Array)
            {
                int indice = 0;
                foreach (JsonElement item in elemento.EnumerateArray())
                {
                    AplanarJson(item, $"{prefijoActual}_{indice}", diccionario);
                    indice++;
                }
            }
            else
            {
                // SOLUCIÓN AL BUG: Usar ToString() en lugar de GetString() evita que el programa 
                // explote cuando el JSON tiene un true, un false o un número.
                diccionario[prefijoActual] = elemento.ToString();
            }
        }

        public static string Obtener(string clave, params object[] variables)
        {
            if (textosActuales.TryGetValue(clave, out string textoTraducido))
            {
                if (variables != null && variables.Length > 0)
                {
                    return string.Format(textoTraducido, variables);
                }
                return textoTraducido;
            }

            return $"[{clave}_FALTA]";
        }
    }
}