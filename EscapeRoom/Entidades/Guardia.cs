using EscapeRoom.NIveles;
using EscapeRoom.Personajes;
using System.Collections.Generic; // Obligatorio para usar List<>
using System.Drawing;
using System.Windows.Forms;

namespace EscapeRoom.Entidades
{
    public class Guardia : Personaje
    {
        public string Dialogo { get; set; }
        public bool MoviendoDerecha { get; set; } = true;

        private List<Image> animacionDerecha;
        private List<Image> animacionIzquierda;
        private int cuadroActual = 0;
        private int pixelesRecorridos = 0; 

        public Guardia(int x, int y, int velocidad, PictureBox imagen, string dialogo)
            : base(x, y, velocidad, imagen)
        {
            this.Dialogo = dialogo;

            animacionDerecha = new List<Image> { Properties.Resources.g_der_1, Properties.Resources.g_der_2 };
            animacionIzquierda = new List<Image> { Properties.Resources.g_izq_1, Properties.Resources.g_izq_2 };

            if (this.Imagen != null && animacionDerecha.Count > 0)
            {
                this.Imagen.Image = animacionDerecha[0];
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
                    if (futuro.IntersectsWith(pared)) { choca = true; break; }
                }
            }

            if (nivel.Puertas != null && !choca)
            {
                foreach (var puerta in nivel.Puertas)
                {
                    if (puerta.EstaAbierta == false && futuro.IntersectsWith(puerta.Imagen.Bounds))
                    { choca = true; break; }
                }
            }

            if (nivel.Escondites != null && !choca)
            {
                foreach (var escondite in nivel.Escondites)
                {
                    if (futuro.IntersectsWith(escondite.Imagen.Bounds))
                    { choca = true; break; }
                }
            }

            if (nivel.EsconditeCod != null && !choca)
            {
                foreach (var cofre in nivel.EsconditeCod)
                {
                    if (futuro.IntersectsWith(cofre.Imagen.Bounds))
                    { choca = true; break; }
                }
            }

            if (MoviendoDerecha && x + Imagen.Width + velocidad > nivel.Width) choca = true;
            if (!MoviendoDerecha && x - velocidad < 0) choca = true;

            if (choca)
            {
                MoviendoDerecha = !MoviendoDerecha;
                cuadroActual = 0;
                pixelesRecorridos = 0;
            }

            pixelesRecorridos += velocidad;

            if (pixelesRecorridos >= 15)
            {
                cuadroActual++;
                pixelesRecorridos = 0;
            }

            if (MoviendoDerecha)
            {
                x += velocidad;
                this.Imagen.Image = animacionDerecha[cuadroActual % animacionDerecha.Count];
            }
            else
            {
                x -= velocidad;
                this.Imagen.Image = animacionIzquierda[cuadroActual % animacionIzquierda.Count];
            }

            this.Imagen.Location = new Point(x, y);
        }
    }
}