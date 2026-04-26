using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace EscapeRoom
{
    public class Llave : Objeto
    {
        public Llave(int x, int y, string id, string descripcion, PictureBox imagen) : base(x, y, id, descripcion, imagen)
        {
        }
    }
}
