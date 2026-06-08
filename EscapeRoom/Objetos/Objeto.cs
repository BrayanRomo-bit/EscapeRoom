using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EscapeRoom.Objetos
{
    public class Objeto
    {
        public PictureBox Imagen { get; set; }
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public bool Recogido { get; set; } = false;


        public Objeto() { } 
        public Objeto(string id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
        public override string ToString()
        {
            return Descripcion;
        }

    }
}
