using EscapeRoom.Properties;
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
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public bool Recogido { get; set; } = false;

        [JsonIgnore]
        public Image IconoInventario { get; set; }


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

        public void CargarImagen()
        {
            if (this.IconoInventario != null) return;

            switch (this.Id)
            {
                case string id when id.Contains("llave"):
                    this.IconoInventario = Properties.Resources.llavee;
                    break;
                case string id when id.Contains("nota"):
                    this.IconoInventario = Properties.Resources.nota;
                    break;
                case string id when id.Contains("pista") || id.Contains("cam"):
                    this.IconoInventario = Resources.USB;  
                    break;
            }
        }
    }
}
