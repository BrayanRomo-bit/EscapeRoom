using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EscapeRoom
{
    public class Escondite
    {
        public string Nombre {  get; set; }
        public PictureBox Imagen {  get; set; }
        public Objeto ObjetoOculto { get; set; }
        public bool YaRevisado { get; set; }=false;
    }
}
