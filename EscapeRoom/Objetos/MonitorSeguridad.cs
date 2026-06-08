using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Objetos
{
    public class MonitorSeguridad
    {
        public PictureBox Imagen { get; set; }
        public string Codigo { get; set; }
        public bool Desactivado { get; set; } = false;
        
        public MonitorSeguridad(PictureBox imagen, string codigo)
        {
            this.Imagen = imagen;
            this.Codigo = codigo;
        }
    }
}
