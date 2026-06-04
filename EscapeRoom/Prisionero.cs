using EscapeRoom.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscapeRoom
{
    public class Prisionero : Personaje
    {
        public List<Objeto> Inventario { get; set; }
        public bool Atrapado { get; set; } = false;
        public bool EstaLeyendo { get; set; } = false;

        public bool seguroSoltarTecla = false;
        public string Nombre { get; set; }

        public NPC NPCconversando = null;

        public Prisionero(int x, int y, int velocidad, PictureBox imagen) : base(x, y, velocidad, imagen)
        {
            Inventario = new List<Objeto>();
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

            if (EstaLeyendo == true)
            {
                if (accion == true && seguroSoltarTecla == true)
                {
                    EstaLeyendo = false;
                    seguroSoltarTecla = false;
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
                        return Traductor.Obtener("mensajes_juego.prisionero.escondite_ya_revisado", escondite.Nombre);
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
                        return Traductor.Obtener("mensajes_juego.prisionero.cofre_encontro_algo", cofre.Nombre, cofre.ObjetoOculto.Descripcion);
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
                        // AQUÍ ENTRA EN ACCIÓN TU NUEVO CONTROL DE USUARIO (UCPinpad)
                        estoyEnPuerta = true;
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;

                        // Mandamos llamar a nuestro método de NivelBase que crea el UCPinpad
                        nivel.MostrarPinpadPuerta(puerta);

                        return ""; // Retornamos vacío, la puerta se abrirá desde NivelBase
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
                if (der && chocaDer == false && x + Imagen.Width < nivel.Width) x += velocidad;
                if (izq && chocaIzq == false && x > 0) x -= velocidad;
                if (arr && chocaArr == false && y > 0) y -= velocidad;
                if (abj && chocaAbj == false && y + Imagen.Height < nivel.Height) y += velocidad;

                Imagen.Location = new Point(x, y);
            }

            return "";
        }

        public string ObtenerTextoInventario()
        {
            if (Inventario.Count == 0)
            {
                return Traductor.Obtener("mensajes_juego.prisionero.inventario_vacio");
            }

            string contenido = Traductor.Obtener("mensajes_juego.prisionero.inventario_encabezado");
            contenido += string.Join("\n- ", Inventario.Select(i => i.Descripcion));

            return contenido;
        }
    }
}