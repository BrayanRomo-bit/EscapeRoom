using EscapeRoom.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class Prisionero : Personaje
    {
        public List<Objeto> Inventario { get; set; }
        public bool Atrapado { get; set; } = false;
        public bool EstaLeyendo { get; set; } = false;
        public bool seguroSoltarTecla = false;
        public string Nombre { get; set; }


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
            foreach (var pared in nivel.Paredes) objetosSolidos.Add(pared.Bounds);
            if (nivel.Escondites != null) foreach (var escondite in nivel.Escondites) objetosSolidos.Add(escondite.Imagen.Bounds);
            if (nivel.Cofres != null) foreach (var cofre in nivel.Cofres) objetosSolidos.Add(cofre.Imagen.Bounds);
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

                return "¡Te han atrapado! Presiona la tecla de acción (E) para reiniciar.";
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
                if (areaInteraccion.IntersectsWith(npc.Bounds) && estoyEnNPC == false && accion == true && seguroSoltarTecla == true)
                {
                    npc.Hablar(nivel);
                    estoyEnNPC = true;
                    EstaLeyendo = true;
                    seguroSoltarTecla = false;
                    if (npc.ObjetoaDar != null && npc.YaDioObjeto == false)
                    {
                        Inventario.Add(npc.ObjetoaDar);
                        npc.YaDioObjeto = true;
                        return $"NPC: {npc.Dialogo} \n\nAdemás, te da: {npc.ObjetoaDar.Descripcion}";
                    }
                    return $"{npc.Dialogo}";

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
                        return $"Ya revisaste {escondite.Nombre} y no hay nada más aquí.";
                    }
                    escondite.YaRevisado = true;

                    if (escondite.ObjetoOculto != null)
                    {
                        Inventario.Add(escondite.ObjetoOculto);
                        escondite.ObjetoOculto.Recogido = true;

                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return $"¡Revisas {escondite.Nombre} y encuentras algo! Recibes: {escondite.ObjetoOculto.Descripcion}";
                    }
                    else
                    {
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return $"Revisas {escondite.Nombre}... pero solo hay polvo y telarañas.";
                    }
                }
            }


            foreach (var cofre in nivel.Cofres)
            {
                if (areaInteraccion.IntersectsWith(cofre.Imagen.Bounds) && interactuar == false && accion == true && seguroSoltarTecla == true)
                {
                    if (cofre.YaRevisado == true)
                    {
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;

                        return $"Ya revisaste {cofre.Nombre} y no hay nada más aquí.";
                    }
                    cofre.YaRevisado = true;
                    if (cofre.ObjetoOculto != null)
                    {
                        Inventario.Add(cofre.ObjetoOculto);
                        cofre.ObjetoOculto.Recogido = true;
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return $"¡Abres {cofre.Nombre} y encuentras algo! Recibes: {cofre.ObjetoOculto.Descripcion}";
                    }
                    else
                    {
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return $"Abres {cofre.Nombre}... pero solo hay polvo y telarañas.";
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

                        nivel.PausarNivel();
                        string respuestaJugador = Microsoft.VisualBasic.Interaction.InputBox(
                            "La puerta tiene un teclado electrónico. Ingresa el PIN de 3 dígitos:",
                            "Cerradura de Seguridad",
                            "");
                        nivel.ReanudarNivel();
                        if (respuestaJugador == puerta.Codigo)
                        {
                            puerta.EstaAbierta = true;
                            puerta.Imagen.Bounds = Rectangle.Empty;
                            nivel.NivelSuperado = true;

                            return "¡BEEP! Código aceptado. La puerta se ha abierto.";
                        }
                        else if (respuestaJugador != "") // Si no le dio a Cancelar
                        {
                            return "¡ERROR! Código incorrecto. Búscalo en las celdas.";
                        }

                        return ""; // Si le dio a cancelar, no decimos nada
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
                        //Resources.puerta_abierta; // Cambia la imagen de la puerta a abierta
                        Inventario.Remove(llaveUsada);
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return $"Has abierto la puerta con: Llave {llaveUsada.Descripcion}";
                    }

                    else
                    {
                        estoyEnPuerta = true;
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return $"Necesitas: Llave{puerta.Descripcion} para abrir esta puerta.";
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

                        return $"Has recogido: Llave {llave.Descripcion}";
                    }
                }
            }

            foreach (var guardia in nivel.Guardias)
            {

                if (areaInteraccion.IntersectsWith(guardia.Imagen.Bounds))
                {

                    Atrapado = true;
                    seguroSoltarTecla = false;
                    return $"Guardia: {guardia.Dialogo}";

                }
            }
            foreach (var camara in nivel.Camaras)
            {
                if (camara.estaActiva == true && areaInteraccion.IntersectsWith(camara.Imagen.Bounds))
                {
                    Atrapado = true;
                    seguroSoltarTecla = false;
                    return $"¡Una cámara de seguridad te ha detectado!";
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
                        return $"El monitor muestra una imagen borrosa... parece que ya lo desactivaste.";
                    }
                    estoyEnPuerta = true;
                    EstaLeyendo = true;
                    seguroSoltarTecla = false;
                    nivel.PausarNivel();

                    string respuestaJugador = Microsoft.VisualBasic.Interaction.InputBox(
            "Terminal de Seguridad Bloqueada.\nIngresa el código PIN de 3 dígitos para apagar las cámaras:",
            "Monitor de Cámaras", "");

                    nivel.ReanudarNivel();
                    if (respuestaJugador == nivel.MonitorNivel.Codigo)
                    {
                        nivel.MonitorNivel.Desactivado = true;

                        foreach (var camara in nivel.Camaras)
                        {
                            camara.estaActiva = false;
                            camara.Imagen.SizeMode = PictureBoxSizeMode.Zoom;
                            camara.Imagen.Image = Properties.Resources.camara_off;
                        }
                        return "¡BEEP! Código aceptado. Las cámaras han sido desactivadas.";
                    }
                    else if (respuestaJugador != "" || respuestaJugador != nivel.MonitorNivel.Codigo)
                    {
                        return "¡ERROR! Código incorrecto. Búscalo en las celdas.";
                    }
                    return "";
                }
            }
            if (estoyEnNPC == false && estoyEnPuerta == false) nivel.LabelDialogo?.Hide();
            if (der && chocaDer == false && x + Imagen.Width < nivel.Width) x += velocidad;
            if (izq && chocaIzq == false && x > 0) x -= velocidad;
            if (arr && chocaArr == false && y > 0) y -= velocidad;
            if (abj && chocaAbj == false && y + Imagen.Height < nivel.Height) y += velocidad;

            Imagen.Location = new Point(x, y);
            return "";
        }
        public string ObtenerTextoInventario()
        {
            if (Inventario.Count == 0)
            {
                return "Tu mochila está vacía.";
            }

            string contenido = "Llevas contigo:\n\n";
            contenido += string.Join("\n- ", Inventario.Select(i => i.Descripcion));

            return contenido;
        }
    }
}

