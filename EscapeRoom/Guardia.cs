using System.Drawing;
using System.Windows.Forms;

namespace EscapeRoom
{
    public class Guardia : Personaje
    {
        public string Dialogo { get; set; }

        public bool MoviendoDerecha { get; set; } = true;

        public Guardia(int x, int y, int velocidad, PictureBox imagen, string dialogo)
            : base(x, y, velocidad, imagen)
        {
            this.Dialogo = dialogo;

            if (this.Imagen != null)
            {
                this.Imagen.Image = Properties.Resources.guardiader;
            }
        }

        public void Actualizar(bool arr, bool abj, bool izq, bool der, bool accion, NivelBase nivel)
        {
            bool choca = false;
            
            Rectangle futuro = MoviendoDerecha ?
                new Rectangle(x + velocidad, y, Imagen.Width, Imagen.Height) :
                new Rectangle(x - velocidad, y, Imagen.Width, Imagen.Height);

            if (nivel.ParedesMatematicas != null)
            {
                foreach (var pared in nivel.ParedesMatematicas)
                {
                    if (futuro.IntersectsWith(pared))
                    {
                        choca = true;
                        break;
                    }
                }
            }

            if (nivel.Puertas != null && !choca)
            {
                foreach (var puerta in nivel.Puertas)
                {
                    if (puerta.EstaAbierta == false && futuro.IntersectsWith(puerta.Imagen.Bounds))
                    {
                        choca = true;
                        break;
                    }
                }
            }

            if (nivel.Escondites != null && !choca)
            {
                foreach (var escondite in nivel.Escondites)
                {
                    if (futuro.IntersectsWith(escondite.Imagen.Bounds))
                    {
                        choca = true;
                        break;
                    }
                }
            }

            if (nivel.EsconditeCod != null && !choca)
            {
                foreach (var cofre in nivel.EsconditeCod)
                {
                    if (futuro.IntersectsWith(cofre.Imagen.Bounds))
                    {
                        choca = true;
                        break;
                    }
                }
            }

            if (MoviendoDerecha && x + Imagen.Width + velocidad > nivel.Width) choca = true;
            if (!MoviendoDerecha && x - velocidad < 0) choca = true;

            if (choca)
            {
                MoviendoDerecha = !MoviendoDerecha;
            }

            if (MoviendoDerecha)
            {
                x += velocidad;
                this.Imagen.Image = Properties.Resources.guardiader;
            }
            else
            {
                x -= velocidad;
                this.Imagen.Image = Properties.Resources.guardiaizq;
            }
        }
    }
}