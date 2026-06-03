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
        public Objeto ObjetoaDar {  get; set; }
        public bool YaDioObjeto { get; set; }

        public NPC(int id, string dialogo, Image imagen, Point posicion)
        {
            this.Id = id;
            this.Dialogo = dialogo;
            this.Image = imagen;
            this.Location = posicion;
            this.Size = new Size(50, 50);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.YaHablo = false;
            this.BackColor = Color.Transparent;
        }
        public string Hablar(NivelBase nivel)
        {
            if (YaHablo) return "Ya te he dicho todo lo que sé.";
            YaHablo = true;
            nivel.LabelDialogo.Text = Dialogo;
            nivel.LabelDialogo.Show();
            return Dialogo;
        }


    }
}
