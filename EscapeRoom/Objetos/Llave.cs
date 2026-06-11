using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace EscapeRoom.Objetos
{
    public class Llave : Objeto
    {
        public Llave(): base()
        { 
            this.IconoInventario = Properties.Resources.llavee;
        }
        public Llave( string id, string descripcion) : base(id, descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.IconoInventario = Properties.Resources.llavee;
        }
    }
}
