using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class Guardado
    {
        public Prisionero Prisionero { get; set; }
        public int NivelActual { get; set; }
        // Agrega aquí otras propiedades necesarias para guardar el estado del juego, como NPCs, objetos, puertas, etc.

        public List<Objeto> ObjetosRecogidos { get; set; } = new List<Objeto>();
        public List<Puerta> PuertasAbiertas { get; set; } = new List<Puerta>();


    }
}
