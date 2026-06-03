using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json.Serialization;

namespace EscapeRoom
{
    public class Personaje
    {

        protected int x;
        protected int y;
        protected int velocidad;

        public int X { 
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Velocidad
        {
            get { return velocidad; }
            set { velocidad = value; }
        }
        public PictureBox Imagen { get; set; }
        public Personaje(int x, int y, int velocidad, PictureBox imagen)
        {
            this.x = x;
            this.y = y;
            this.velocidad = velocidad;
            this.Imagen = imagen;
        }
        // Su memoria
        public bool moviendoDerecha = true;

        public void Actualizar(bool arr, bool abj, bool izq, bool der, bool accion, NivelBase nivel)
        {

        }
    }
}
