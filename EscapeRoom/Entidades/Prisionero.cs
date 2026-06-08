using EscapeRoom.Entidades;
using EscapeRoom.NIveles;
using EscapeRoom.Objetos;
using EscapeRoom.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            animacionDerecha = new List<Image> { Resources.der_1, Resources.der_2,  };
            animacionArriba = new List<Image> { Resources.arr_1, Resources.arr_2, };
            this.Imagen.Image = animacionAbajo[0];
        }

        public string ProcesarMovimiento(bool arr, bool abj, bool izq, bool der, bool accion, NivelBase nivel)
        {
            bool estoyEnPuerta = false;
            bool estoyEnNPC = false;
            bool interactuar = false;
            bool chocaDer = false, chocaIzq = false, chocaArr = false, chocaAbj = false;

            Rectangle futuroDer = new Rectangle(x + velocidad, y, Imagen.Width, Imagen.Height);
            Rectangle futuroIzq = new Rectangle(x - velocidad, y, Imagen.Width, Imagen.Height);
            Rectangle futuroArr = new Rectangle(x, y - velocidad, Imagen.Width, Imagen.Height);
            Rectangle futuroAbj = new Rectangle(x, y + velocidad, Imagen.Width, Imagen.Height);

            Rectangle areaInteraccion = new Rectangle(x - 15, y - 15, Imagen.Width + 30, Imagen.Height + 30);
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

            if (accion == false) seguroSoltarTecla = true;

            if (Atrapado == true)
            {
                if (accion == true && seguroSoltarTecla == true)
                {
                    Atrapado = false;
                    nivel.ReiniciarNivel();
                }

                return Traductor.Obtener("mensajes_juego.prisionero.atrapado");
            }

            if (this.NPCconversando != null)
            {
                string textoActual = "";
                if (NPCconversando.DialogosPorPasos.Count > 0)
                    textoActual = NPCconversando.DialogosPorPasos[NPCconversando.PaginaActual];
                else
                    textoActual = NPCconversando.Dialogo;

                if (accion == true && seguroSoltarTecla == true)
                {
                    seguroSoltarTecla = false;
                    bool historiaTerminada = (NPCconversando.DialogosPorPasos.Count == 0) || (NPCconversando.PaginaActual >= NPCconversando.DialogosPorPasos.Count - 1);

                    if (historiaTerminada)
                    {
                        if (NPCconversando.ObjetoaDar != null && NPCconversando.YaDioObjeto == false)
                        {
                            Inventario.Add(NPCconversando.ObjetoaDar);
                            textoActual += Traductor.Obtener("mensajes_juego.prisionero.objeto_recibido", NPCconversando.ObjetoaDar.Descripcion);
                        }

                        NPCconversando.YaDioObjeto = true;

                        this.NPCconversando = null;
                        this.EstaLeyendo = false;
                        estoyEnNPC = false;
                        return textoActual;
                    }
                    else
                    {
                        NPCconversando.PaginaActual++;
                        return NPCconversando.DialogosPorPasos[NPCconversando.PaginaActual];
                    }
                }

                estoyEnNPC = true;
                return textoActual;
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

            foreach (var npc in nivel.NPCs)
            {
                if (areaInteraccion.IntersectsWith(npc.Bounds) && accion == true && seguroSoltarTecla == true)
                {
                    seguroSoltarTecla = false;

                    this.NPCconversando = npc;
                    this.EstaLeyendo = true;
                    estoyEnNPC = true;
                    npc.PaginaActual = 0;

                    if (npc.DialogosPorPasos.Count > 0)
                        return npc.DialogosPorPasos[0];
                    else
                        return npc.Dialogo;
                }
            }

            foreach (var escondite in nivel.Escondites)
            {
                if (areaInteraccion.IntersectsWith(escondite.Imagen.Bounds) && interactuar == false && accion == true && seguroSoltarTecla == true)
                {
                    if (escondite.YaRevisado == true)
                    {
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        string msj = Traductor.Obtener("mensajes_juego.prisionero.escondite_encontro_algo", escondite.Nombre, escondite.ObjetoOculto.Descripcion);
                        return PaginadeTextos(msj);
                    }
                    escondite.YaRevisado = true;

                    if (escondite.ObjetoOculto != null)
                    {
                        Inventario.Add(escondite.ObjetoOculto);
                        escondite.ObjetoOculto.Recogido = true;

                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return Traductor.Obtener("mensajes_juego.prisionero.escondite_encontro_algo", escondite.Nombre, escondite.ObjetoOculto.Descripcion);
                    }
                    else
                    {
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return Traductor.Obtener("mensajes_juego.prisionero.escondite_vacio", escondite.Nombre);
                    }
                }
            }


            foreach (var cofre in nivel.EsconditeCod)
            {
                if (areaInteraccion.IntersectsWith(cofre.Imagen.Bounds) && interactuar == false && accion == true && seguroSoltarTecla == true)
                {
                    if (cofre.YaRevisado == true)
                    {
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;

                        return Traductor.Obtener("mensajes_juego.prisionero.cofre_ya_revisado", cofre.Nombre);
                    }
                    cofre.YaRevisado = true;
                    if (cofre.ObjetoOculto != null)
                    {
                        Inventario.Add(cofre.ObjetoOculto);
                        cofre.ObjetoOculto.Recogido = true;
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        string msj = Traductor.Obtener("mensajes_juego.prisionero.cofre_encontro_algo", cofre.Nombre, cofre.ObjetoOculto.Descripcion);
                        return PaginadeTextos(msj);
                    }
                    else
                    {
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return Traductor.Obtener("mensajes_juego.prisionero.cofre_vacio", cofre.Nombre);
                    }
                }
            }

            foreach (var puerta in nivel.Puertas)
            {
                if (areaInteraccion.IntersectsWith(puerta.Imagen.Bounds) && puerta.EstaAbierta == false && accion == true && seguroSoltarTecla == true)
                {
                    bool LlaveCorrecta = false;
                    Objeto llaveUsada = null;

                    if (puerta.RequiereCodigo == true)
                    {
                        estoyEnPuerta = true;
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;

                        nivel.MostrarPinpadPuerta(puerta);

                        return "";
                    }

                    foreach (var item in Inventario)
                    {
                        if (item.Id == puerta.Id)
                        {
                            LlaveCorrecta = true;
                            llaveUsada = item;
                            break;
                        }
                    }
                    if (LlaveCorrecta == true)
                    {
                        estoyEnPuerta = true;
                        puerta.EstaAbierta = true;
                        puerta.Imagen.Bounds = Rectangle.Empty;
                        Inventario.Remove(llaveUsada);
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        if (puerta.EsSalidaFinal == true)
                        {
                            nivel.NivelSuperado = true;
                            return Traductor.Obtener("mensajes_juego.prisionero.puerta_final_abierta", llaveUsada.Descripcion);
                        }
                        return Traductor.Obtener("mensajes_juego.prisionero.puerta_abierta", llaveUsada.Descripcion);
                    }

                    else
                    {
                        estoyEnPuerta = true;
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return Traductor.Obtener("mensajes_juego.prisionero.puerta_necesita_llave", puerta.Descripcion);
                    }
                }
            }

            foreach (var llave in nivel.Llaves)
            {
                if (llave == null || llave.Imagen == null) continue;

                if (areaInteraccion.IntersectsWith(llave.Imagen.Bounds))
                {
                    if (accion == true)
                    {

                        Inventario.Add(llave);
                        llave.Recogido = true;

                        EstaLeyendo = true;
                        seguroSoltarTecla = false;

                        return Traductor.Obtener("mensajes_juego.prisionero.llave_recogida", llave.Descripcion);
                    }
                }
            }

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

            if (nivel.MonitorNivel != null && areaInteraccion.IntersectsWith(nivel.MonitorNivel.Imagen.Bounds))
            {
                if (accion == true && seguroSoltarTecla == true)
                {
                    if (nivel.MonitorNivel.Desactivado == true)
                    {
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return Traductor.Obtener("mensajes_juego.prisionero.monitor_ya_desactivado");
                    }

                    estoyEnPuerta = true;
                    EstaLeyendo = true;
                    seguroSoltarTecla = false;

                    nivel.MostrarPinpadMonitor();

                    return "";
                }
            }

            if (estoyEnNPC == false && estoyEnPuerta == false && EstaLeyendo == false && NPCconversando == null)
            {
                nivel.LabelDialogo?.Hide();
            }

            if (NPCconversando == null && EstaLeyendo == false && Atrapado == false)
            {
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
                    
                    if (pixelesRecorridos >= 12)
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

            return "";
        }

        private string PaginadeTextos(string mensajeCompleto)
        {
            TextosPorLeer.Clear();
            string[] paginas = mensajeCompleto.Split(new string[] { "\n\n" }, StringSplitOptions.None);

            if (paginas.Length > 1)
            {
                for (int i = 1; i < paginas.Length; i++)
                {
                    TextosPorLeer.Add(paginas[i]);
                }
            }
            EstaLeyendo = true;
            seguroSoltarTecla = false;
            return paginas[0];
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