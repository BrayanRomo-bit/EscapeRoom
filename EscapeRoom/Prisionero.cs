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


        public Prisionero(int x, int y, int velocidad, PictureBox imagen) : base(x, y, velocidad, imagen)
        {

        }
        public void Actualizar(bool arr, bool abj, bool izq, bool der, bool accion, NivelBase nivel)
        {
            bool estoyEnPuerta = false;
            bool estoyEnNPC = false;
            bool chocaDer = false, chocaIzq = false, chocaArr = false, chocaAbj = false;

            Rectangle futuroDer = new Rectangle(x + velocidad, y, Imagen.Width, Imagen.Height);
            Rectangle futuroIzq = new Rectangle(x - velocidad, y, Imagen.Width, Imagen.Height);
            Rectangle futuroArr = new Rectangle(x, y - velocidad, Imagen.Width, Imagen.Height);
            Rectangle futuroAbj = new Rectangle(x, y + velocidad, Imagen.Width, Imagen.Height);

            Rectangle areaInteraccion = new Rectangle(x - 5, y - 5, Imagen.Width + 10, Imagen.Height + 10);

            List<Rectangle> objetosSolidos = new List<Rectangle>();

            foreach (var muro in nivel.Muros) objetosSolidos.Add(muro.Bounds);
            foreach (var npc in nivel.NPCs) objetosSolidos.Add(npc.Bounds);
            foreach (var guardia in nivel.Guardias) objetosSolidos.Add(guardia.Imagen.Bounds);

            foreach (var puerta in nivel.Puertas)
            {
                if (puerta.EstaAbierta == false) objetosSolidos.Add(puerta.Imagen.Bounds);
            }

            foreach (var solido in objetosSolidos)
            {
                if (der && futuroDer.IntersectsWith(solido)) chocaDer = true;
                if (izq && futuroIzq.IntersectsWith(solido)) chocaIzq = true;
                if (arr && futuroArr.IntersectsWith(solido)) chocaArr = true;
                if (abj && futuroAbj.IntersectsWith(solido)) chocaAbj = true;
            }

            if (accion == false)seguroSoltarTecla = true;
            

            if (Atrapado == true)
            {
                if (accion == true && seguroSoltarTecla == true)
                {
                    Atrapado = false;
                    nivel.ReiniciarNivel();
                }
                return;
            }

            if (EstaLeyendo == true)
            {
                
                if (accion == true && seguroSoltarTecla == true)
                {
                    EstaLeyendo = false;
                    nivel.LabelDialogo.Hide();

                    seguroSoltarTecla = false;
                }
                return;
            }

            foreach (var npc in nivel.NPCs)
            {
                if (areaInteraccion.IntersectsWith(npc.Bounds) && accion == true && seguroSoltarTecla == true)
                {
                    nivel.LabelDialogo.Text = npc.Dialogo;
                    nivel.LabelDialogo.Show();
                    estoyEnNPC = true;
                    accion = false;
                    EstaLeyendo = true;
                    seguroSoltarTecla = false;
                    return;
                }
            }

            foreach (var puerta in nivel.Puertas)
            {
                if (areaInteraccion.IntersectsWith(puerta.Imagen.Bounds) && puerta.EstaAbierta == false && accion == true && seguroSoltarTecla == true)
                {
                    bool LlaveCorrecta = false;
                    Objeto llaveUsada = null;

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
                        nivel.LabelDialogo.Text = $"Has abierto la puerta con: Llave {llaveUsada.Descripcion}";
                        nivel.LabelDialogo.Show();
                        puerta.Imagen.Bounds = Rectangle.Empty;
                        //Resources.puerta_abierta; // Cambia la imagen de la puerta a abierta
                        Inventario.Remove(llaveUsada);
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return;
                    }

                    else
                    {
                        estoyEnPuerta = true;
                        nivel.LabelDialogo.Text = $"Necesitas: Llave{puerta.Descripcion} para abrir esta puerta.";
                        nivel.LabelDialogo.Show();
                        EstaLeyendo = true;
                        seguroSoltarTecla = false;
                        return;
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
                        nivel.LabelDialogo.Text = $"Has recogido: Llave {llave.Descripcion}";
                        nivel.LabelDialogo.Show();
                        nivel.LabelDialogo.BringToFront();

                        Inventario.Add(llave);
                        llave.Recogido = true;

                        EstaLeyendo = true;
                        seguroSoltarTecla = false;

                        return;
                    }
                }
            }

            foreach (var guardia in nivel.Guardias)
            {

                if (areaInteraccion.IntersectsWith(guardia.Imagen.Bounds))
                {
                    
                        nivel.LabelDialogo.Text = guardia.Dialogo;
                        nivel.LabelDialogo.Show();
                        Atrapado = true;
                        seguroSoltarTecla = false;
                        return;
                    
                }
            }

            if (estoyEnNPC == false) nivel.LabelDialogo?.Hide();
            if (estoyEnPuerta == false) nivel.LabelDialogo?.Hide();
            if (der && chocaDer == false && x + Imagen.Width < nivel.Width) x += velocidad;
            if (izq && chocaIzq == false && x > 0) x -= velocidad;
            if (arr && chocaArr == false && y > 0) y -= velocidad;
            if (abj && chocaAbj == false && y + Imagen.Height < nivel.Height) y += velocidad;

            Imagen.Location = new Point(x, y);

        }

        public string MostrarInventario(NivelBase nivel, bool accion)
        {

            if (accion == false) seguroSoltarTecla = true;
            if (EstaLeyendo == true)
            {
                if (accion == true && seguroSoltarTecla == true)
                {
                    EstaLeyendo = false;
                    nivel.LabelDialogo.Hide();

                    seguroSoltarTecla = false;
                }
            }

            if (Inventario.Count == 0)
            {
                nivel.LabelDialogo.Text = "Inventario vacío.";
                EstaLeyendo = true;
            }
            else
            {
                nivel.LabelDialogo.Text = "Inventario:" + string.Join("\r\n ", Inventario.Select(i => i.Descripcion));
                EstaLeyendo = true;
            }
            nivel.LabelDialogo.Show();
            nivel.LabelDialogo.BringToFront();
            return nivel.LabelDialogo.Text;
        }
    }
}

