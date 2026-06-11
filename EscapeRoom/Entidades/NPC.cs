using EscapeRoom.Objetos;
using EscapeRoom.Personajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Entidades
{
    public class NPC : PictureBox
    {
        public int Id { get; set; }
        public string Dialogo { get; set; }
        public bool YaHablo { get; set; }
        public Objeto ObjetoaDar { get; set; }
        public bool YaDioObjeto { get; set; }
        public List<string> DialogosPorPasos { get; set; } = new List<string>();

        public int PaginaActual { get; set; } = 0;

        public NPC(int id, Image imagen, Point posicion)
        {
            this.Id = id;
            this.Image = imagen;
            this.Location = posicion;
            this.Size = new Size(50, 50);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.YaHablo = false;
            this.BackColor = Color.Transparent;
        }
        public string Hablar(Prisionero jugador)
        {
            if (this.DialogosPorPasos == null || DialogosPorPasos.Count == 0) return EntregarObjetoFinal(jugador, this.Dialogo);

            string textoActual = this.DialogosPorPasos[this.PaginaActual];

            if (PaginaActual >= DialogosPorPasos.Count - 1)
            {
                return EntregarObjetoFinal(jugador, textoActual);
            }
            return textoActual;
        }

        public void AvanzarPagina()
        {
            if (this.DialogosPorPasos != null && this.PaginaActual < this.DialogosPorPasos.Count - 1)
            {
                this.PaginaActual++;
            }
        }
        public bool EsUltimaPagina()
        {
            if (this.DialogosPorPasos == null || this.DialogosPorPasos.Count == 0) return true;
            return this.PaginaActual >= this.DialogosPorPasos.Count - 1;
        }

        public string EntregarObjetoFinal(Prisionero jugador, string textoBase)
        {
            if (this.ObjetoaDar != null && this.YaDioObjeto == false)
            { 
            jugador.Inventario.Add(this.ObjetoaDar);
                this.YaDioObjeto = true;
                return textoBase + Traductor.Obtener("mensajes_juego.prisionero.objeto_recibido", this.ObjetoaDar.Descripcion);
            }
            return textoBase;
        }
    }
}
