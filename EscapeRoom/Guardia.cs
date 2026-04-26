using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class Guardia : Personaje
    {
        public bool moveDerecha = true;
        public string Dialogo { get; set; }
        public bool Atrapado { get; set; } = false;
        public Guardia(int x, int y, int velocidad, PictureBox imagen, string dialogo) : base(x, y, velocidad, imagen)
        {
            this.Dialogo = dialogo;
        }

        public void Actualizar(bool arr, bool abj, bool izq, bool der, bool accion, NivelBase nivel)
        {
            List<Rectangle> objetosSolidos = new List<Rectangle>();
            foreach (var muro in nivel.Muros) objetosSolidos.Add(muro.Bounds);
            foreach (var puerta in nivel.Puertas) objetosSolidos.Add(puerta.Imagen.Bounds);
            foreach (var npc in nivel.NPCs) objetosSolidos.Add(npc.Bounds);
            foreach (var prisionero in nivel.Prisioneros) objetosSolidos.Add(prisionero.Imagen.Bounds);

            bool chocaDer = false, chocaIzq = false;
            Rectangle futuroDer = new Rectangle(x + velocidad, y, Imagen.Width, Imagen.Height);
            Rectangle futuroIzq = new Rectangle(x - velocidad, y, Imagen.Width, Imagen.Height);
        
            foreach (var obj in objetosSolidos)
            {
                if (futuroDer.IntersectsWith(obj)) chocaDer = true;
                if (futuroIzq.IntersectsWith(obj)) chocaIzq = true;
            }
            if (moveDerecha)
            {
                if (!chocaDer) x += velocidad;
                else moveDerecha = false;
            }
            else
            {
                if (!chocaIzq) x -= velocidad;
                else moveDerecha = true;
            }

        }
    }
}
