using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Objetos
{
    public class MonitorSeguridad
    {
        public PictureBox Imagen { get; set; }
        public string Codigo { get; set; }
        public bool Desactivado { get; set; } = false;
        
        public MonitorSeguridad(PictureBox imagen, string codigo)
        {
            this.Imagen = imagen;
            this.Codigo = codigo;
        }
        public string IntentarDesactivar()
        {
            if (this.Desactivado == true)
            {
                return Traductor.Obtener("mensajes_juego.prisionero.monitor_ya_desactivado");
            }

            return "PINPAD_MONITOR";
        }
    }
}
