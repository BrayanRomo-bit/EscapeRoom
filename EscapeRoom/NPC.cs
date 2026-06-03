using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
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

        public NPC(int id,  Image imagen, Point posicion)
        {
            this.Id = id;
            this.Image = imagen;
            this.Location = posicion;
            this.Size = new Size(50, 50);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.YaHablo = false;
            this.BackColor = Color.Transparent;
        }
        public string Hablar()
        {
            if (DialogosPorPasos.Count == 0) return "";

            string textoActual = DialogosPorPasos[PaginaActual];
            if (PaginaActual < DialogosPorPasos.Count - 1)
            {
                PaginaActual++;
            }
            return textoActual;
        }


    }
}
