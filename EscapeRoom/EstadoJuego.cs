using EscapeRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class EstadoJuego

    {
        public string NombrePrisionero { get; set; }
        public int PrisioneroX { get; set; }
        public int PrisioneroY { get; set; }
        public int NivelActual { get; set; }
        public string idioma { get; set; }
        public string CodigoSecretoFInal { get; set; }
        public int Dificultad { get; set; }
         public List<string> InventarioPrisionero { get; set; }
        public List<string> IdsLlavesRecogidas { get; set; }
        public List<string> IdsPuertasAbiertas { get; set; }
    }
}