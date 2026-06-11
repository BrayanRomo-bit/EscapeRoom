using EscapeRoom.Entidades;
using EscapeRoom.NIveles;
using EscapeRoom.Objetos;
using EscapeRoom.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EscapeRoom.Personajes
{
    public class Prisionero : Personaje
    {
        public List<Objeto> Inventario { get; set; }
        public bool Atrapado { get; set; } = false;
        public bool EstaLeyendo { get; set; } = false;

        public bool seguroSoltarTecla = false;
        public string Nombre { get; set; }

        public NPC NPCconversando = null;

        public int Puntaje { get; set; } = 0;
        public List<string> TextosPorLeer = new List<string>();

        private List<Image> animacionAbajo;
        private List<Image> animacionIzquierda;
        private List<Image> animacionDerecha;
        private List<Image> animacionArriba;

        private int direccionActual = 0;
        private int cuadroActual = 0;
        private int pixelesRecorridos = 0;

        public Prisionero(int x, int y, int velocidad, PictureBox imagen) : base(x, y, velocidad, imagen)
        {
            Inventario = new List<Objeto>();
            animacionAbajo = new List<Image> { Resources.abajo_1, Resources.abajo_2, Resources.abajo_3, Resources.abajo_4, Resources.abajo_5, Resources.abajo_6 };
            animacionIzquierda = new List<Image> { Resources.izq_1, Resources.izq_2, };
            animacionDerecha = new List<Image> { Resources.der_1, Resources.der_2, };
            animacionArriba = new List<Image> { Resources.arr_1, Resources.arr_2, };
            this.Imagen.Image = animacionAbajo[0];
        }

        public string ActualizarEstado(bool arr, bool abj, bool izq, bool der, bool accion, NivelBase nivel)
        {
            if (accion == false) seguroSoltarTecla = true;

            string mensajePeligro = VerificarPeligros(nivel, accion);
            if (mensajePeligro != "") return mensajePeligro;

            string mensajeLectura = ProcesarLecturasPendientes(accion);
            if (mensajeLectura != "") return mensajeLectura;

            if (accion == true && seguroSoltarTecla == true)
            {
                string mensajeInteraccion = Interactuar(nivel);
                if (mensajeInteraccion != "") return mensajeInteraccion;
            }

            if (NPCconversando == null && EstaLeyendo == false && Atrapado == false)
            {
                Moverse(arr, abj, izq, der, nivel);
            }

            if (EstaLeyendo == false && NPCconversando == null)
            {
                nivel.LabelDialogo?.Hide();
            }

            return "";
        }

        private string VerificarPeligros(NivelBase nivel, bool accion)
        {
            if (Atrapado == true)
            {
                if (accion == true && seguroSoltarTecla == true)
                {
                    Atrapado = false;
                    nivel.ReiniciarNivel();
                    return "";
                }
                return Traductor.Obtener("mensajes_juego.prisionero.atrapado");
            }

            Rectangle areaInteraccion = new Rectangle(x - CONSTANTES.Jugador.RADIO_INTERACCION, y- CONSTANTES.Jugador.RADIO_INTERACCION, Imagen.Width + CONSTANTES.Jugador.MARGEN_INTERACCION, Imagen.Height + 30);

            foreach (var guardia in nivel.Guardias)
            {
                if (areaInteraccion.IntersectsWith(guardia.Imagen.Bounds))
                {
                    Atrapado = true;
                    seguroSoltarTecla = false;
                    return Traductor.Obtener("mensajes_juego.prisionero.dialogo_guardia", guardia.Dialogo);
                }
            }

            foreach (var camara in nivel.Camaras)
            {
                if (camara.estaActiva == true && areaInteraccion.IntersectsWith(camara.Imagen.Bounds))
                {
                    Atrapado = true;
                    seguroSoltarTecla = false;
                    return Traductor.Obtener("mensajes_juego.prisionero.camara_detectada");
                }
            }

            return "";
        }

        private string ProcesarLecturasPendientes(bool accion)
        {
            if (this.NPCconversando != null)
            {
                string textoEnPantalla = NPCconversando.Hablar(this);

                if (textoEnPantalla.Contains("{0}")) textoEnPantalla = string.Format(textoEnPantalla, this.Nombre);

                if (accion == true && seguroSoltarTecla == true)
                {
                    seguroSoltarTecla = false;
                    if (NPCconversando.EsUltimaPagina())
                    {
                        this.NPCconversando.PaginaActual = 0;
                        this.NPCconversando = null;
                        this.EstaLeyendo = false;
                        return "";
                    }
                    else
                    {
                        NPCconversando.AvanzarPagina();
                        string textoSiguiente = NPCconversando.Hablar(this);
                        if (textoSiguiente.Contains("{0}")) textoSiguiente = string.Format(textoSiguiente, this.Nombre);
                        return textoSiguiente;
                    }
                }
                return textoEnPantalla;
            }

            if (EstaLeyendo == true && NPCconversando == null)
            {
                if (accion == true && seguroSoltarTecla == true)
                {
                    seguroSoltarTecla = false;

                    if (TextosPorLeer.Count > 0)
                    {
                        string siguiente = TextosPorLeer[0];
                        TextosPorLeer.RemoveAt(0);
                        return siguiente;
                    }
                    else
                    {
                        EstaLeyendo = false;
                        return "";
                    }
                }
                return "";
            }
            return "";
        }

        private string Interactuar(NivelBase nivel)
        {
            Rectangle areaInteraccion = new Rectangle(x - CONSTANTES.Jugador.RADIO_INTERACCION, y - CONSTANTES.Jugador.RADIO_INTERACCION, Imagen.Width + 30, Imagen.Height + 30);

            foreach (var npc in nivel.NPCs)
            {
                if (nivel.miAutobus != null && npc == nivel.miAutobus) continue;

                if (areaInteraccion.IntersectsWith(npc.Bounds))
                {
                    seguroSoltarTecla = false;
                    this.NPCconversando = npc;
                    this.EstaLeyendo = true;
                    npc.PaginaActual = 0;

                    string textoHabla = npc.Hablar(this);
                    if (textoHabla.Contains("{0}")) textoHabla = string.Format(textoHabla, this.Nombre);

                    return textoHabla;
                }
            }

            foreach (var escondite in nivel.Escondites)
            {
                if (areaInteraccion.IntersectsWith(escondite.Imagen.Bounds))
                {
                    EstaLeyendo = true;
                    seguroSoltarTecla = false;
                    string resultado = escondite.Revisar(this);
                    return PaginadeTextos(resultado);
                }
            }

            foreach (var cofre in nivel.EsconditeCod)
            {
                if (areaInteraccion.IntersectsWith(cofre.Imagen.Bounds))
                {
                    EstaLeyendo = true;
                    seguroSoltarTecla = false;
                    string resultado = cofre.Revisar(this);
                    return PaginadeTextos(resultado);
                }
            }

            foreach (var puerta in nivel.Puertas)
            {
                if (areaInteraccion.IntersectsWith(puerta.Imagen.Bounds) && puerta.EstaAbierta == false)
                {
                    string resultado = puerta.IntentarAbrir(this);

                    if (resultado == "PINPAD" || resultado == "REQUIERE_PINPAD")
                    {
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        nivel.MostrarPinpadPuerta(puerta);
                        return "";
                    }
                    else
                    {
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        if (puerta.EstaAbierta == true && puerta.EsSalidaFinal == true) nivel.NivelSuperado = true;
                        return PaginadeTextos(resultado);
                    }
                }
            }

            if (nivel.MonitorNivel != null && areaInteraccion.IntersectsWith(nivel.MonitorNivel.Imagen.Bounds))
            {
                EstaLeyendo = true;
                seguroSoltarTecla = false;
                string resultado = nivel.MonitorNivel.IntentarDesactivar();

                if (resultado == "PINPAD_MONITOR" || resultado == "REQUIERE_PINPAD_MONITOR")
                {
                    nivel.MostrarPinpadMonitor();
                    return "";
                }
                else
                {
                    return resultado;
                }
            }

            if (nivel.miAutobus != null && areaInteraccion.IntersectsWith(nivel.miAutobus.Imagen.Bounds))
            {
                EstaLeyendo = true;
                seguroSoltarTecla = false;

                nivel.miAutobus.YaDioObjeto = true;
                string textoBus = Traductor.Obtener("mensajes_juego.prisionero.dialogo_autobus", this.Nombre);
                return PaginadeTextos(textoBus);
            }
            return "";
        }

        private void Moverse(bool arr, bool abj, bool izq, bool der, NivelBase nivel)
        {
            bool chocaDer = false, chocaIzq = false, chocaArr = false, chocaAbj = false;

            Rectangle futuroDer = new Rectangle(x + velocidad, y, Imagen.Width, Imagen.Height);
            Rectangle futuroIzq = new Rectangle(x - velocidad, y, Imagen.Width, Imagen.Height);
            Rectangle futuroArr = new Rectangle(x, y - velocidad, Imagen.Width, Imagen.Height);
            Rectangle futuroAbj = new Rectangle(x, y + velocidad, Imagen.Width, Imagen.Height);

            List<Rectangle> objetosSolidos = new List<Rectangle>();

            foreach (var npc in nivel.NPCs) objetosSolidos.Add(npc.Bounds);
            foreach (var guardia in nivel.Guardias) objetosSolidos.Add(guardia.Imagen.Bounds);
            foreach (var puerta in nivel.Puertas) if (puerta.EstaAbierta == false) objetosSolidos.Add(puerta.Imagen.Bounds);
            if (nivel.ParedesMatematicas != null) foreach (var pared in nivel.ParedesMatematicas) objetosSolidos.Add(pared);
            if (nivel.Escondites != null) foreach (var escondite in nivel.Escondites) objetosSolidos.Add(escondite.Imagen.Bounds);
            if (nivel.EsconditeCod != null) foreach (var cofre in nivel.EsconditeCod) objetosSolidos.Add(cofre.Imagen.Bounds);
            if (nivel.MonitorNivel != null) objetosSolidos.Add(nivel.MonitorNivel.Imagen.Bounds);
            foreach (var camara in nivel.Camaras) if (camara.estaActiva == true) objetosSolidos.Add(camara.Imagen.Bounds);

            foreach (var solido in objetosSolidos)
            {
                if (der && futuroDer.IntersectsWith(solido)) chocaDer = true;
                if (izq && futuroIzq.IntersectsWith(solido)) chocaIzq = true;
                if (arr && futuroArr.IntersectsWith(solido)) chocaArr = true;
                if (abj && futuroAbj.IntersectsWith(solido)) chocaAbj = true;
            }

            bool seMovio = false;
            if (der && chocaDer == false && x + Imagen.Width < nivel.Width)
            { x += velocidad; direccionActual = 2; seMovio = true; }
            else if (izq && chocaIzq == false && x > 0)
            { x -= velocidad; direccionActual = 1; seMovio = true; }
            else if (arr && chocaArr == false && y > 0)
            { y -= velocidad; direccionActual = 3; seMovio = true; }
            else if (abj && chocaAbj == false && y + Imagen.Height < nivel.Height)
            { y += velocidad; direccionActual = 0; seMovio = true; }

            if (seMovio)
            {
                pixelesRecorridos += velocidad;
                if (pixelesRecorridos >= CONSTANTES.Jugador.FRAMES_PARA_ANIMACION)
                {
                    cuadroActual++;
                    pixelesRecorridos = 0;
                }
            }
            else
            {
                cuadroActual = 0;
                pixelesRecorridos = 0;
            }

            switch (direccionActual)
            {
                case 0:
                    Imagen.Image = animacionAbajo[cuadroActual % animacionAbajo.Count]; break;
                case 1:
                    Imagen.Image = animacionIzquierda[cuadroActual % animacionIzquierda.Count]; break;
                case 2:
                    Imagen.Image = animacionDerecha[cuadroActual % animacionDerecha.Count]; break;
                case 3:
                    Imagen.Image = animacionArriba[cuadroActual % animacionArriba.Count]; break;
            }

            Imagen.Location = new Point(x, y);
        }

        private string PaginadeTextos(string mensajeCompleto)
        {
            TextosPorLeer.Clear();
            string[] paginas = mensajeCompleto.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (paginas.Length > 1)
            {
                for (int i = 1; i < paginas.Length; i++)
                {
                    TextosPorLeer.Add(paginas[i].Trim());
                }
            }
            EstaLeyendo = true;
            seguroSoltarTecla = false;
            return paginas.Length > 0 ? paginas[0].Trim() : "";
        }

        public string ObtenerTextoInventario()
        {
            if (Inventario.Count == 0)
            {
                return Traductor.Obtener("mensajes_juego.prisionero.inventario_vacio");
            }

            string contenido = Traductor.Obtener("mensajes_juego.prisionero.inventario_encabezado");
            contenido += string.Join("\n- ", Inventario.Select(i => i.ToString()));
            return contenido;
        }
    }
}