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
        protected Monitor monitorNivel;
        protected int contadorNPCs = 0;
        protected int contadorLLaves = 0;
        protected int contadorPuertas = 0;

        protected List<Puerta> listaPuertas = new List<Puerta>();
        protected List<Llave> listaLlaves = new List<Llave>();
        protected List<NPC> listaNPCs = new List<NPC>();
        protected List<Guardia> listaGuardias = new List<Guardia>();
        protected List<Prisionero> listaPrisioneros = new List<Prisionero>();
        protected List<Camara> listaCamaras = new List<Camara>();
        protected List<Rectangle> paredesMatematicas = new List<Rectangle>();

        public List<Camara> Camaras { get { return listaCamaras; } }
        public List<Escondite> Escondites { get; set; } = new List<Escondite>();
        public List<Escondite> EsconditeCod { get; set; } = new List<Escondite>();
        public List<Rectangle> ParedesMatematicas { get { return paredesMatematicas; } }

        public Monitor MonitorNivel { get { return monitorNivel; } set { monitorNivel = value; } }
        public List<NPC> NPCs { get { return listaNPCs; } }
        public List<Guardia> Guardias { get { return listaGuardias; } }
        public List<Prisionero> Prisioneros { get { return listaPrisioneros; } }
        public List<Llave> Llaves { get { return listaLlaves; } }
        public List<Puerta> Puertas { get { return listaPuertas; } }
        public Label LabelDialogo { get { return lblDialogo; } }
        public bool NivelSuperado { get; set; } = false;
        public bool EstaEnCinematica { get; set; } = false;
        protected Dictionary<int, string> baseDeDialogos = new Dictionary<int, string>();
        protected Dictionary<int, string> baseDeLLaves = new Dictionary<int, string>();
        protected Dictionary<int, string> baseDePuertas = new Dictionary<int, string>();
        public Autobus miAutobus { get; set; }
        public event Action? Reinicio;
        public event Action? PedirPausa;
        public event Action? PedirReanudar;

        public NivelBase()
        {
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
        }

        public void PausarNivel()
        {
            PedirPausa?.Invoke();
        }
        public void ReanudarNivel()
        {
            PedirReanudar?.Invoke();
        }

        public void ReiniciarNivel()
        {
            Reinicio?.Invoke();
        }

        public virtual string ActualizarNivel(bool arr, bool abj, bool izq, bool der, bool accion, int ancho, int alto)
        {
            if (prisionero == null) return "";

            string mensaje = prisionero.ProcesarMovimiento(arr, abj, izq, der, accion, this);

            if (mensaje != "")
            {
                lblDialogo.Text = mensaje;
                lblDialogo.Show();
            }
            else if (prisionero.EstaLeyendo == false && prisionero.Atrapado == false)
            {
                if (lblDialogo != null) lblDialogo.Hide();
            }

            prisionero.Imagen.Location = new Point(prisionero.X, prisionero.Y);
            if (prisionero.EstaLeyendo == false && prisionero.Atrapado == false)
            {
                foreach (var guardia in listaGuardias)
                {
                    guardia.Actualizar(arr, abj, izq, der, accion, this);
                    guardia.Imagen.Location = new Point(guardia.X, guardia.Y);
                }
            }

            for (int i = listaLlaves.Count - 1; i >= 0; i--)
            {
                if (listaLlaves[i].Recogido == true)
                {
                    this.Controls.Remove(listaLlaves[i].Imagen);
                    listaLlaves.RemoveAt(i);
                }
            }

           return mensaje;
        }
        protected void CrearJugador(int x, int y)
        {

            PictureBox nuevopb = new PictureBox();
            nuevopb.Image = Properties.Resources.goku;
            nuevopb.SizeMode = PictureBoxSizeMode.Zoom;
            nuevopb.BackColor = Color.Transparent; // Para que no tengan un cuadro blanco atrás
            nuevopb.Size = new Size(50, 50);
            nuevopb.Location = new Point(x, y);

            this.prisionero = new Prisionero(x, y, 10, nuevopb);
            this.Controls.Add(nuevopb);
            listaPrisioneros.Add(prisionero);
            nuevopb.BringToFront();
        }
        protected void CrearGuardia(int x, int y)
        {
            PictureBox pbGuardia = new PictureBox();
            pbGuardia.Image = Properties.Resources.goku;
            pbGuardia.SizeMode = PictureBoxSizeMode.Zoom;
            pbGuardia.BackColor = Color.Transparent; // Para que no tengan un cuadro blanco atrás
            pbGuardia.Size = new Size(50, 50);
            pbGuardia.Location = new Point(x, y); // Ya no multiplicamos por 50, usamos la coordenada exacta

            Guardia guardia = new Guardia(x, y, 4, pbGuardia, "¡Alto!");
            this.Controls.Add(pbGuardia);
            listaGuardias.Add(guardia);
            pbGuardia.BringToFront();
        }

        protected NPC CrearNPC(int x, int y)
        {
            PictureBox pbNpc = new PictureBox();
            pbNpc.Image = Properties.Resources.goku;
            pbNpc.SizeMode = PictureBoxSizeMode.Zoom;
            pbNpc.BackColor = Color.Transparent;
            pbNpc.Size = new Size(50, 50);
            pbNpc.Location = new Point(x, y);

            NPC nPC = new NPC(1, pbNpc.Image, pbNpc.Location);
            this.Controls.Add(pbNpc);
            listaNPCs.Add(nPC);
            pbNpc.BringToFront();

            return nPC;
        }
        public void MostrarPinpadPuerta(Puerta puertaActual)
        {
            PausarNivel(); 

            UCPinpad pinpad = new UCPinpad();

            pinpad.Location = new Point((this.Width - pinpad.Width) / 2, (this.Height - pinpad.Height) / 2);

            this.Controls.Add(pinpad);
            pinpad.BringToFront();

            pinpad.ConfirmarCodigo += (codigoEscrito) =>
            {
                this.Controls.Remove(pinpad); 
                ReanudarNivel();

                if (codigoEscrito == puertaActual.Codigo)
                {
                    puertaActual.EstaAbierta = true;
                    puertaActual.Imagen.Bounds = Rectangle.Empty;
                    this.NivelSuperado = true;

                    lblDialogo.Text = Traductor.Obtener("mensajes_juego.terminal_seguridad.puerta_codigo_aceptado");
                    lblDialogo.Show();
                }
                else
                {
                    lblDialogo.Text = Traductor.Obtener("mensajes_juego.terminal_seguridad.puerta_codigo_incorrecto");
                    lblDialogo.Show();
                    Prisioneros[0].EstaLeyendo = true;
                }
            };
            pinpad.CancelarCodigo += () =>
            {
                this.Controls.Remove(pinpad);
                ReanudarNivel();
            };
        }

        public void MostrarPinpadMonitor()
        {
            PausarNivel(); 

            UCPinpad pinpad = new UCPinpad();
            pinpad.Location = new Point((this.Width - pinpad.Width) / 2, (this.Height - pinpad.Height) / 2);

            this.Controls.Add(pinpad);
            pinpad.BringToFront();

            pinpad.ConfirmarCodigo += (codigoEscrito) =>
            {
                this.Controls.Remove(pinpad);
                ReanudarNivel();

                if (MonitorNivel != null && codigoEscrito == MonitorNivel.Codigo)
                {
                    MonitorNivel.Desactivado = true;

                    foreach (var camara in Camaras)
                    {
                        camara.estaActiva = false;
                        camara.Imagen.SizeMode = PictureBoxSizeMode.Zoom;
                        camara.Imagen.Image = Properties.Resources.camara_off;
                    }

                    lblDialogo.Text = Traductor.Obtener("mensajes_juego.terminal_seguridad.camara_codigo_aceptado");
                    lblDialogo.Show();
                }
                else
                {
                    lblDialogo.Text = Traductor.Obtener("mensajes_juego.terminal_seguridad.camara_codigo_incorrecto");
                    lblDialogo.Show();
                    Prisioneros[0].EstaLeyendo = true;
                }
            };

            pinpad.CancelarCodigo += () =>
            {
                this.Controls.Remove(pinpad);
                ReanudarNivel();
            };
        }

        public virtual void IniciarNivel()
        {
        }

    }
}