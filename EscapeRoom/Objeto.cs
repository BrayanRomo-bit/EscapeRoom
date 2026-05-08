using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class Objeto
    {
        protected int x;
        protected int y;
        [JsonIgnore] public PictureBox Imagen { get; set; }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public string Id { get; set; }
        public string Descripcion { get;}
        public bool Recogido { get; set; }= false;

        public Objeto(int x, int y, string id, string descripcion, PictureBox imagen)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Imagen = imagen;

        }
    }
}
