using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class Monitor
    {
        public PictureBox Imagen { get; set; }
        public string Codigo { get; set; }
        public bool Desactivado { get; set; } = false;
        
        public Monitor(PictureBox imagen, string codigo)
        {
            this.Imagen = imagen;
            this.Codigo = codigo;
        }
    }
}
