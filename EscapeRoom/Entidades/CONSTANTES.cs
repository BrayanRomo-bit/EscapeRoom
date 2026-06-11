using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Entidades
{
    internal static class CONSTANTES
    {
        public static class Puntaje
        {
            public const int PUNTOS_ESCONDITE = 50;
            public const int PUNTOS_PUERTA = 100;
            public const int PENALIZACION_ATRAPADO= 200;
            public const int PENALIZACION_TIEMPO = 2;
        }

        public static class Jugador
        {
            public const int RADIO_INTERACCION = 15;
            public const int MARGEN_INTERACCION = 30;
            public const int FRAMES_PARA_ANIMACION = 12;
        }
        public static class Motor
        {
            public const int FRAMES_REDUCCION_PUNTOS = 50;
            public const int VELOCIDAD_CINEMATICA = 10;
        }
        public static class Interfaz
        {
            public const int TAMANO_ICONO_INVENTARIO = 64;
        }

        public static class Juego
        {
            public const int LONGITUD_CODIGO_FINAL = 3;
        }
    }
}
