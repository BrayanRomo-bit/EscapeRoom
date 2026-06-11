using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Objetos
{
    public class Camara
    {
        public bool estaActiva { get; set; } = true;
        public PictureBox Imagen { get; set; }

        public Camara(PictureBox imagen)
        {
            this.Imagen = imagen;
        }
    }
}
