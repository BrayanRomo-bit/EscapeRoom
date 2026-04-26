using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class Puerta : Objeto
    {
        private bool estaAbierta;
        public bool EstaAbierta { get; set; } = false;


        public Puerta(int x, int y, string id, string descripcion, PictureBox imagen) : base(x, y, id, descripcion, imagen)
        {
            EstaAbierta = false;
        }
    }
}
