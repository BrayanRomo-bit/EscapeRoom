using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Objetos
{
    internal class Nota: Objeto
    {
        public string Titulo { get; set; }

        public Nota(): base() { }

        public Nota(string id, string titulo, string descripcion ) : base(id, descripcion)
        {
            this.Titulo = titulo;
        }

        public override string ToString()
        {
        return $"Nota: {Titulo} - {Descripcion}";
        }
    }
}
