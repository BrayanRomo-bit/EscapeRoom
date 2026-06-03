using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class Puerta 
    {
        public string Id { get; set; } 
        public string Descripcion { get; set; } 
        public PictureBox Imagen { get; set; } 
        public bool RequiereCodigo { get; set; } = false;
        public string Codigo { get; set; } = "";
        public bool EstaAbierta { get; set; } = false;

        public Puerta(string id, string descripcion, PictureBox imagen)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
        }
    }
}
