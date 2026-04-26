using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace EscapeRoom
{
    // Hereda de UserControl e implementa tu interfaz
    public class NivelBase : UserControl, INivel
    {
        protected Label lblDialogo;
        protected Prisionero prisionero;
        protected Llave llave;
        protected Puerta salida;
        protected int contadorNPCs = 0;
        protected int contadorLLaves = 0;
        protected int contadorPuertas = 0;

        protected List<Puerta> listaPuertas = new List<Puerta>();
        protected List<Llave> listaLlaves = new List<Llave>();
        protected List<PictureBox> listaMuros = new List<PictureBox>();
        protected List<NPC> listaNPCs = new List<NPC>();
        protected List<Guardia> listaGuardias = new List<Guardia>();
        protected List<Prisionero> listaPrisioneros = new List<Prisionero>();

        public List<PictureBox> Muros { get { return listaMuros; } }
        public List<NPC> NPCs { get { return listaNPCs; } }
        public List<Guardia> Guardias { get { return listaGuardias; } }
        public List<Prisionero> Prisioneros { get { return listaPrisioneros; } }
        public List<Llave> Llaves { get { return listaLlaves; } }
        public List<Puerta> Puertas { get { return listaPuertas; } }
        public Label LabelDialogo { get { return lblDialogo; } }


        protected Dictionary<int, string> baseDeDialogos = new Dictionary<int, string>();
        protected Dictionary<int, string> baseDeLLaves = new Dictionary<int, string>();
        protected Dictionary<int, string> baseDePuertas = new Dictionary<int, string>();

        int contadorLlavesMapa = 0;
        int contadorPuertasMapa = 0;

        public NivelBase()
        {
            this.BackColor = Color.Transparent;
        }

        protected void ConstruirMapa(string[] mapa)
        {
            for (int y = 0; y < mapa.Length; y++)
            {
                for (int x = 0; x < mapa[y].Length; x++)
                {
                    switch (mapa[y][x])
                    {
                        case 'x': CrearMuro(x, y); break;
                        case 'P': CrearPared(x, y); break;
                        case 'J': CrearJugador(x, y); break;
                        case 'N': CrearNPC(x, y); break;
                        case 'B': CrearVacio(x, y); break;
                        case 'L':
                            CrearLLave(x, y, contadorLlavesMapa);
                            contadorLlavesMapa++;
                            break;
                        case 'S':
                            CrearSalida(x, y, contadorPuertasMapa);
                            contadorPuertasMapa++;
                            break;
                        case 'G': CrearGuardia(x, y); break;
                    }
                }
            }
            lblDialogo?.BringToFront();
        }

        protected void CrearGuardia(int x, int y)
        {
            PictureBox pbGuardia = new PictureBox();
            pbGuardia.Image = Properties.Resources.goku;
            pbGuardia.SizeMode = PictureBoxSizeMode.Zoom;
            pbGuardia.Size = new Size(50, 50);
            pbGuardia.Location = new Point(x * 50, y * 50);
            Guardia guardia = new Guardia(x * 50, y * 50, 3, pbGuardia, "¡Alto! No puedes pasar.");
            this.Controls.Add(pbGuardia);
            listaGuardias.Add(guardia);
            pbGuardia.BringToFront();
        }

        protected void CrearLLave(int x, int y, int Idobject)
        {
            PictureBox pbllave = new PictureBox();
            pbllave.Image = Properties.Resources.llavee;
            pbllave.SizeMode = PictureBoxSizeMode.Zoom;
            pbllave.Size = new Size(50, 50);
            pbllave.Location = new Point(x * 50, y * 50);

            string descripcion = baseDeLLaves.ContainsKey(contadorLLaves) ? baseDeLLaves[contadorLLaves] : $"llave {Idobject}";

            llave = new Llave(x * 50, y * 50, Idobject.ToString(), descripcion, pbllave);

            this.Controls.Add(pbllave);

            listaLlaves.Add(llave);
            pbllave.BringToFront();
            contadorLLaves++;

        }
        protected void CrearSalida(int x, int y, int Idobject)
        {
            PictureBox pbsalida = new PictureBox();
            pbsalida.Image = Properties.Resources.salidaa;
            pbsalida.SizeMode = PictureBoxSizeMode.Zoom;
            pbsalida.Size = new Size(50, 50);
            pbsalida.Location = new Point(x * 50, y * 50);
            string descripcion = baseDePuertas.ContainsKey(contadorPuertas) ? baseDePuertas[contadorPuertas] :
                $" {Idobject}";

            salida = new Puerta(x * 50, y * 50, Idobject.ToString(), descripcion, pbsalida);
            this.Controls.Add(pbsalida);
            listaPuertas.Add(salida);
            pbsalida.BringToFront();
            contadorPuertas++;
        }
        protected void CrearJugador(int x, int y)
        {
            PictureBox nuevoPb = new PictureBox();
            nuevoPb.Image = Properties.Resources.gokuu;
            nuevoPb.SizeMode = PictureBoxSizeMode.Zoom;
            nuevoPb.Size = new Size(50, 50);
            nuevoPb.Location = new Point(x * 50, y * 50);

            prisionero = new Prisionero(x * 50, y * 50, 5, nuevoPb);
            this.Controls.Add(nuevoPb);
            listaPrisioneros.Add(prisionero);
            nuevoPb.BringToFront();
        }
        protected void CrearPared(int x, int y)
        {
            PictureBox muro = new PictureBox

            {

                Image = Properties.Resources.pareed,

                Size = new Size(50, 50),

                Location = new Point(x * 50, y * 50),

                SizeMode = PictureBoxSizeMode.CenterImage

            };

            this.Controls.Add(muro);

            listaMuros.Add(muro);
        }

        protected void CrearMuro(int x, int y)
        {
            PictureBox muro = new PictureBox

            {
                Image = Properties.Resources.muroo_,
                Size = new Size(50, 50),
                Location = new Point(x * 50, y * 50),
                SizeMode = PictureBoxSizeMode.CenterImage

            };
            this.Controls.Add(muro);
            listaMuros.Add(muro);
        }

        protected void CrearVacio(int x, int y)

        {
            Panel bloqueNegro = new Panel()
            {
                BackColor = Color.Black,
                Size = new Size(50, 50),
                Location = new Point(x * 50, y * 50)

            };
            this.Controls.Add(bloqueNegro);
            bloqueNegro.BringToFront();
        }

        protected void CrearNPC(int x, int y)
        {
            string texto = baseDeDialogos.ContainsKey(contadorNPCs) ? baseDeDialogos[contadorNPCs] : "NPC sin diálogo.";
            NPC Npc = new NPC(contadorNPCs, texto, Properties.Resources.gokuu, new Point(x * 50, y * 50));
            listaNPCs?.Add(Npc);
            this.Controls.Add(Npc);
            contadorNPCs++;
        }

        public void ActualizarNivel(bool arr, bool abj, bool izq, bool der, bool accion, int ancho, int alto)
        {
            if (prisionero != null)
            {
                prisionero.Actualizar(arr, abj, izq, der, accion, this);
                prisionero.Imagen.Location = new Point(prisionero.X, prisionero.Y);
            }
            foreach (var guardia in listaGuardias)
            {
                guardia.Actualizar(arr, abj, izq, der, accion, this);
                guardia.Imagen.Location = new Point(guardia.X, guardia.Y);
            }


            for (int i = listaLlaves.Count - 1; i >= 0; i--)
            {
                if (listaLlaves[i].Recogido == true)
                {
                    this.Controls.Remove(listaLlaves[i].Imagen);
                    listaLlaves.RemoveAt(i);
                }
            }
        }



        public void IniciarNivel()
        {
        }
        public void ReiniciarNivel()
        {
            this.Controls.Clear();

            listaMuros.Clear();
            listaNPCs.Clear();
            listaLlaves.Clear();
            listaPuertas.Clear();
            listaGuardias.Clear();
            baseDeDialogos.Clear();
            baseDeLLaves.Clear();
            baseDePuertas.Clear();

            contadorNPCs = 0;
            contadorLLaves = 0;
            contadorPuertas = 0;

            IniciarNivel();
        }

      
     

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // NivelBase
            // 
            Name = "NivelBase";
            Size = new Size(989, 693);
            ResumeLayout(false);

        }


    }
}