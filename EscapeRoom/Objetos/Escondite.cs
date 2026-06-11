using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using EscapeRoom.Personajes;
using EscapeRoom.Entidades;

namespace EscapeRoom.Objetos
{
    public class Escondite
    {
        public string Nombre { get; set; }
        public PictureBox Imagen { get; set; }
        public Objeto ObjetoOculto { get; set; }
        public bool YaRevisado { get; set; } = false;



        public string Revisar(Prisionero jugador)
        {
            if (this.YaRevisado==true) return Traductor.Obtener("mensajes_juego.prisionero.escondite_ya_revisado", this.Nombre);
        
            this.YaRevisado= true;

            if (this.ObjetoOculto!=null)
            {
                jugador.Inventario.Add(this.ObjetoOculto);
                this.ObjetoOculto.Recogido = true;
                jugador.Puntaje += CONSTANTES.Puntaje.PUNTOS_ESCONDITE;

                return Traductor.Obtener("mensajes_juego.prisionero.escondite_encontro_algo", this.Nombre, this.ObjetoOculto.Descripcion);
            }
            else
            {
                return Traductor.Obtener("mensajes_juego.prisionero.escondite_vacio", this.Nombre);
            }
        }
    }
}
