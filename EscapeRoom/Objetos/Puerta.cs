using EscapeRoom.Entidades;
using EscapeRoom.Personajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Objetos
{
    public class Puerta 
    {
        public string Id { get; set; } 
        public string Descripcion { get; set; } 
        public PictureBox Imagen { get; set; } 
        public bool RequiereCodigo { get; set; } = false;
        public bool EsSalidaFinal { get; set; } = false;
        public string Codigo { get; set; } = "";
        public bool EstaAbierta { get; set; } = false;

        public Puerta(string id, string descripcion, PictureBox imagen)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
        }

        public string IntentarAbrir(Prisionero Jugador)
        {
            if (this.EstaAbierta) return "";

            if (this.RequiereCodigo) return "PINPAD";

            Objeto llaveUsada=null;

            foreach (Objeto item in Jugador.Inventario)
            {
            if (item.Id==this.Id)
                {
                    llaveUsada = item;
                    break;
                }
            }
            if (llaveUsada!=null)
            {
                this.EstaAbierta = true;
                if (this.Imagen != null)
                {
                    this.Imagen.Bounds = Rectangle.Empty;
                    this.Imagen.Visible = false;
                }
                Jugador.Inventario.Remove(llaveUsada);
                Jugador.Puntaje += CONSTANTES.Puntaje.PUNTOS_PUERTA;
                
                if (this.EsSalidaFinal)
                {
                    return Traductor.Obtener("mensajes_juego.prisionero.puerta_final_abierta", llaveUsada.Descripcion);
                }
                else
                {
                    return Traductor.Obtener("mensajes_juego.prisionero.puerta_abierta", llaveUsada.Descripcion);
                }
            }
            return Traductor.Obtener("mensajes_juego.prisionero.puerta_necesita_llave", this.Descripcion);
        }
    }
}
