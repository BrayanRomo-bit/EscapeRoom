using EscapeRoom.Entidades;
using EscapeRoom.NIveles;
using EscapeRoom.Objetos;
using EscapeRoom.Persistencia;
using EscapeRoom.Personajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscapeRoom
{
    public partial class UCPantallaJuego : UserControl
    {
        bool movArriba, movAbajo, movIzquierda, movDerecha, accion, accionBloqueada;
        NivelBase nivel;
        Prisionero prisionero;
        private List<Button> botonesNavegacion;
        private int contadorFrames = 0;
        private int indiceSeleccionado = 0;
        public event EventHandler SaliraMenu;

        public UCPantallaJuego()
        {
            InitializeComponent();
            botonesNavegacion = new List<Button>
            {
                btnReanudar,
                btnGuadarPartida,
                btncargar,
                btnInventario,
                btnSaliraMenu
            };
            ResaltarBotonActual();
        }

        private void ResaltarBotonActual()
        {
            foreach (var btn in botonesNavegacion)
            {
                btn.BackColor = Color.Gray;
                btn.ForeColor = Color.White;
            }

            botonesNavegacion[indiceSeleccionado].Focus();

            botonesNavegacion[indiceSeleccionado].BackColor = Color.DarkRed;
            botonesNavegacion[indiceSeleccionado].ForeColor = Color.Yellow;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.W)
            {
                indiceSeleccionado--;

                if (indiceSeleccionado < 0)
                {
                    indiceSeleccionado = botonesNavegacion.Count - 1;
                }

                ResaltarBotonActual();
                return true;
            }
            else if (keyData == Keys.Down || keyData == Keys.S)
            {
                indiceSeleccionado++;

                if (indiceSeleccionado >= botonesNavegacion.Count)
                {
                    indiceSeleccionado = 0;
                }

                ResaltarBotonActual();
                return true;
            }
            else if (keyData == Keys.E)
            {
                botonesNavegacion[indiceSeleccionado].PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UCPantallaJuego_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode) ActualizarTextosMenu();
            this.Focus();
        }

        private void ActualizarTextosMenu()
        {
            btnReanudar.Text = Traductor.Obtener("pantallas.UCPantallaJuego.botones.btnReanudar");
            btnGuadarPartida.Text = Traductor.Obtener("pantallas.UCPantallaJuego.botones.btnGuadarPartida");
            btncargar.Text = Traductor.Obtener("pantallas.UCPantallaJuego.botones.btncargar");
            btnInventario.Text = Traductor.Obtener("pantallas.UCPantallaJuego.botones.btnInventario");
            btnSaliraMenu.Text = Traductor.Obtener("pantallas.UCPantallaJuego.botones.btnSaliraMenu");
            btnSalirVictoria.Text = Traductor.Obtener("pantallas.UCPantallaVictoria.botones.btnSalirVictoria");
        }

        private void btnPausaJuego_Click(object sender, EventArgs e)
        {

            timerjuego.Stop();
            PanelMenuJuego.Visible = true;
            PanelMenuJuego.BringToFront();
        }

        private void btnReanudar_Click(object sender, EventArgs e)
        {
            PanelMenuJuego.Visible = false;
            timerjuego.Start();
            this.Focus();
        }

        private void btnGuadarPartida_Click(object sender, EventArgs e)
        {
            string nombre = this.prisionero.Nombre;
            int nivelDetectado = 1;
            if (nivel is Nivel1) nivelDetectado = 1;
            else if (nivel is Nivel2) nivelDetectado = 2;
            else if (nivel is Nivel3) nivelDetectado = 3;

            if (this.prisionero.Imagen != null)
            {
                this.prisionero.X = this.prisionero.Imagen.Left;
                this.prisionero.Y = this.prisionero.Imagen.Top;
            }

            List<string> llavesGuardar = new List<string>();
            List<string> puertasGuardar = new List<string>();

            foreach (var llave in nivel.Llaves)
            {
                if (llave != null && llave.Recogido) llavesGuardar.Add(llave.Id);
            }

            foreach (var puerta in nivel.Puertas)
            {
                if (puerta != null && puerta.EstaAbierta) puertasGuardar.Add(puerta.Id);
            }

            string codigoGenerado = "";

            foreach (var p in nivel.Puertas)
            {
                if (p.RequiereCodigo == true)
                {
                    codigoGenerado = p.Codigo;
                    break;
                }
            }

            EstadoJuego miGuardado = new EstadoJuego
            {
                NombrePrisionero = this.prisionero.Nombre,
                PrisioneroX = this.prisionero.X,
                PrisioneroY = this.prisionero.Y,
                NivelActual = nivelDetectado,
                IdsLlavesRecogidas = llavesGuardar,
                IdsPuertasAbiertas = puertasGuardar,
                idioma = Traductor.IdiomaActual,
                InventarioPrisionero = this.prisionero.Inventario,
                CodigoPuertaFinal = codigoGenerado,
                PuntajePrisionero = this.prisionero.Puntaje,
            };

            Guardar.Guardado(miGuardado, nombre);
            MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaJuego.messageboxes.juego_guardado", nombre));
            this.Focus();
        }

        private void btncargar_Click(object sender, EventArgs e)
        {
            string nombre = this.prisionero.Nombre;
            EstadoJuego guardado = Guardar.Cargar(nombre);

            if (guardado == null)
            {
                MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaJuego.messageboxes.guardado_no_encontrado"));
                return;
            }

            if (nivel == null || nivel.Prisioneros == null || nivel.Prisioneros.Count == 0)
            {
                MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaJuego.messageboxes.nivel_no_iniciado"));
                return;
            }

            Prisionero prisioneroActual = nivel.Prisioneros[0];
            prisioneroActual.X = guardado.PrisioneroX;
            prisioneroActual.Y = guardado.PrisioneroY;
            prisioneroActual.Imagen.Location = new Point(prisioneroActual.X, prisioneroActual.Y);
            this.prisionero.Puntaje = guardado.PuntajePrisionero;

            SincronizarNivelCargado(guardado);

            MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaJuego.messageboxes.punto_de_control_cargado"));
            PanelMenuJuego.Visible = false;
            timerjuego.Start();
            this.Focus();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Prisionero prisionero = nivel.Prisioneros[0];
            string textoMochila = prisionero.ObtenerTextoInventario();
            RefrescarInventario();
            pnlInventario.Visible = true;
            pnlInventario.BringToFront();
            this.Focus();
        }

        private void btnSaliraMenu_Click(object sender, EventArgs e)
        {
            SaliraMenu?.Invoke(this, EventArgs.Empty);
        }

        private void timerjuego_Tick(object sender, EventArgs e)
        {
            contadorFrames++;
            if (contadorFrames >= CONSTANTES.Motor.FRAMES_REDUCCION_PUNTOS)
            {
                contadorFrames = 0;
                if (prisionero.Puntaje > 0 && nivel.EstaEnCinematica == false)
                {
                    prisionero.Puntaje -= CONSTANTES.Puntaje.PENALIZACION_TIEMPO;
                }
            }
            if (nivel.EstaEnCinematica && nivel.miAutobus != null)
            {
                nivel.miAutobus.Imagen.BringToFront();
                nivel.miAutobus.Imagen.Left += 10;
                if (nivel.miAutobus.Imagen.Left > Width)
                {
                    timerjuego.Stop();
                    int misPuntos = prisionero.Puntaje;
                    int recordViejo = Guardar.ObtenerRecords();

                    bool esNuevoRecord = misPuntos > recordViejo;

                    int recordAMostrar = esNuevoRecord ? misPuntos : recordViejo;

                    string mensajefinal = Traductor.Obtener("pantallas.record.mensaje_victoria", prisionero.Nombre);

                    lblPuntosFinales.Text = Traductor.Obtener("pantallas.record.puntaje_final", misPuntos.ToString());
                    lblRecord.Text = "Record: " + recordAMostrar.ToString();
                    lblNuevoRecord.Visible = esNuevoRecord;
                    lblVictoriaTitulo.Text = mensajefinal;

                    pnlVictoria.BringToFront();
                    pnlVictoria.Visible = true;

                    if (nivel.LabelDialogo != null)
                    {
                        nivel.LabelDialogo.Text = mensajefinal;
                        nivel.LabelDialogo.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show(mensajefinal);
                    }
                }
                return;
            }

            if (nivel.miAutobus != null && prisionero.NPCconversando == null &&
                prisionero.EstaLeyendo == false && nivel.miAutobus.YaDioObjeto == true && !nivel.EstaEnCinematica)
            {
                nivel.EstaEnCinematica = true;
                prisionero.Imagen.Visible = false;


                return;
            }

            movArriba = (GetAsyncKeyState(Keys.W) < 0) || (GetAsyncKeyState(Keys.Up) < 0);
            movAbajo = (GetAsyncKeyState(Keys.S) < 0) || (GetAsyncKeyState(Keys.Down) < 0);
            movIzquierda = (GetAsyncKeyState(Keys.A) < 0) || (GetAsyncKeyState(Keys.Left) < 0);
            movDerecha = (GetAsyncKeyState(Keys.D) < 0) || (GetAsyncKeyState(Keys.Right) < 0);

            bool presionaE = (GetAsyncKeyState(Keys.E) < 0);
            if (presionaE && !accionBloqueada) { accion = true; accionBloqueada = true; }
            else if (!presionaE) { accion = false; accionBloqueada = false; }

            if (GetAsyncKeyState(Keys.Space) < 0)
            {
                PanelMenuJuego.Visible = true;
                timerjuego.Stop();
                PanelMenuJuego.BringToFront();
                return;
            }

            string mensaje = nivel.ActualizarNivel(movArriba, movAbajo, movIzquierda, movDerecha, accion, PanelJuego.Width, PanelJuego.Height);

            if (nivel.LabelDialogo != null)
            {
                if (!string.IsNullOrEmpty(mensaje))
                {
                    nivel.LabelDialogo.Text = mensaje;
                    nivel.LabelDialogo.Visible = true;
                }
                else if (prisionero.EstaLeyendo == false)
                {
                    nivel.LabelDialogo.Visible = false;
                }
            }

            if (nivel.NivelSuperado == true)
            {
                timerjuego.Stop();
                MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaJuego.messageboxes.nivel_superado"));

                int puntosRescatados = this.prisionero.Puntaje;
                string nombreJugador = this.prisionero.Nombre;
                //List<Objeto> inventarioJugador=this.prisionero.Inventario;
                PanelJuego.Controls.Clear();

                if (nivel is Nivel1)
                {
                    nivel = new Nivel2();
                }
                else if (nivel is Nivel2)
                {
                    nivel = new Nivel3();
                }
                else
                {
                    MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaJuego.messageboxes.todos_niveles_superados"));
                    return;
                }
                nivel.Dock = DockStyle.Fill;
                nivel.Reinicio += ReiniciarPorDerrota;
                nivel.PedirPausa += () => timerjuego.Stop();
                nivel.PedirReanudar += () => timerjuego.Start();
                nivel.IniciarNivel();
                PanelJuego.Controls.Add(nivel);
                this.prisionero = nivel.Prisioneros[0];
                this.prisionero.Puntaje = puntosRescatados;
                this.prisionero.Nombre = nombreJugador;
                //this.prisionero.Inventario = inventarioJugador;
                this.Focus();
                timerjuego.Start();
            }
            lblPuntaje.Text = Traductor.Obtener("pantallas.UCPantallaJuego.textos.puntos") + ": " + prisionero.Puntaje.ToString();
        }

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        public void ReiniciarPorDerrota()
        {
            string nombreRescatado = this.prisionero.Nombre;
            int puntosRescatados = this.prisionero.Puntaje;

            puntosRescatados -= CONSTANTES.Puntaje.PENALIZACION_ATRAPADO;
            if (puntosRescatados < 0) puntosRescatados = 0;
            PanelJuego.Controls.Clear();
            if (nivel is Nivel1) nivel = new Nivel1();
            else if (nivel is Nivel2) nivel = new Nivel2();
            nivel.Reinicio += ReiniciarPorDerrota;
            nivel.PedirPausa += () => timerjuego.Stop();
            nivel.PedirReanudar += () => timerjuego.Start();
            PanelJuego.Controls.Add(nivel);
            nivel.IniciarNivel();
            this.prisionero = nivel.Prisioneros[0];
            this.prisionero.Nombre = nombreRescatado;
            this.prisionero.Puntaje = puntosRescatados;
            nivel.LabelDialogo?.Hide();
            this.Focus();
        }

        public void ArrancarNuevaPartida(string nombreJugador)
        {
            PanelJuego.Controls.Clear();
            nivel = new Nivel1();
            nivel.Reinicio += ReiniciarPorDerrota;
            nivel.PedirPausa += () => timerjuego.Stop();
            nivel.PedirReanudar += () => timerjuego.Start();
            nivel.Dock = DockStyle.Fill;
            PanelJuego.Controls.Add(nivel);
            nivel.IniciarNivel();
            this.prisionero = nivel.Prisioneros[0];

            this.prisionero.Nombre = nombreJugador;

            btnPausaJuego.Visible = true;
            btnPausaJuego.BringToFront();
            timerjuego.Start();
            this.Focus();
        }

        public void CargarPartidaDesdeMenu(string nombreJugador)
        {
            EstadoJuego guardado = Guardar.Cargar(nombreJugador);

            if (guardado == null)
            {
                MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaJuego.messageboxes.error_al_cargar"));
                SaliraMenu?.Invoke(this, EventArgs.Empty);
                return;
            }

            PanelJuego.Controls.Clear();
            switch (guardado.NivelActual)
            {
                case 1:
                    { nivel = new Nivel1(); }
                    break;
                case 2:
                    { nivel = new Nivel2(); }
                    break;
                case 3:
                    { nivel = new Nivel3(); }
                    break;
            }

            nivel.Reinicio += ReiniciarPorDerrota;
            nivel.PedirPausa += () => timerjuego.Stop();
            nivel.PedirReanudar += () => timerjuego.Start();

            nivel.Dock = DockStyle.Fill;
            PanelJuego.Controls.Add(nivel);
            nivel.IniciarNivel();

            this.prisionero = nivel.Prisioneros[0];
            this.prisionero.Nombre = nombreJugador;
            this.prisionero.X = guardado.PrisioneroX;
            this.prisionero.Y = guardado.PrisioneroY;
            this.prisionero.Imagen.Location = new Point(this.prisionero.X, this.prisionero.Y);
            this.prisionero.Puntaje = guardado.PuntajePrisionero;

            SincronizarNivelCargado(guardado);

            btnPausaJuego.Visible = true;
            btnPausaJuego.BringToFront();

            timerjuego.Start();
            this.Focus();
        }
        private void SincronizarNivelCargado(EstadoJuego guardado)
        {
            if (guardado.InventarioPrisionero != null) this.prisionero.Inventario = guardado.InventarioPrisionero;

            if (!string.IsNullOrEmpty(guardado.CodigoPuertaFinal))
            {
                foreach (var p in nivel.Puertas)
                {
                    if (p.RequiereCodigo == true)
                    {
                        p.Codigo = guardado.CodigoPuertaFinal;
                        break;
                    }
                }

                string cod = guardado.CodigoPuertaFinal;
                if (cod.Length == 3 && nivel.EsconditeCod != null)
                {
                    foreach (var cofre in nivel.EsconditeCod)
                    {
                        if (cofre.ObjetoOculto != null)
                        {
                            if (cofre.ObjetoOculto.Id == "nota1") cofre.ObjetoOculto.Descripcion = Traductor.Obtener("niveles.Nivel1.pistas_codigo.nota1", cod[0].ToString());
                            else if (cofre.ObjetoOculto.Id == "nota2") cofre.ObjetoOculto.Descripcion = Traductor.Obtener("niveles.Nivel1.pistas_codigo.nota2", cod[1].ToString());
                            else if (cofre.ObjetoOculto.Id == "nota3") cofre.ObjetoOculto.Descripcion = Traductor.Obtener("niveles.Nivel1.pistas_codigo.nota3", cod[2].ToString());
                        }
                    }
                }
            }
            if (guardado.IdsPuertasAbiertas != null)
            {
                foreach (string idPuerta in guardado.IdsPuertasAbiertas)
                {
                    foreach (var p in nivel.Puertas)
                    {
                        if (p.Id == idPuerta)
                        {
                            p.EstaAbierta = true;
                            if (p.Imagen != null) p.Imagen.Bounds = Rectangle.Empty;
                            break;
                        }
                    }
                }
            }

            List<Escondite> todosLosEscondites = new List<Escondite>();
            if (nivel.Escondites != null) todosLosEscondites.AddRange(nivel.Escondites);
            if (nivel.Escondites != null) todosLosEscondites.AddRange(nivel.EsconditeCod);

            foreach (var escondite in todosLosEscondites)
            {
                if (escondite.ObjetoOculto != null)
                {
                    bool yaloTengo = false;

                    if (this.prisionero.Inventario != null)
                    {
                        foreach (var obj in this.prisionero.Inventario)
                        {
                            if (obj.Id == escondite.ObjetoOculto.Id) { yaloTengo = true; break; }
                        }
                    }
                    if (yaloTengo == false && guardado.IdsPuertasAbiertas != null)
                    {
                        foreach (var idPuerta in guardado.IdsPuertasAbiertas)
                        {
                            if (idPuerta == escondite.ObjetoOculto.Id) { yaloTengo = true; break; }
                        }
                    }

                    if (yaloTengo == false && guardado.IdsLlavesRecogidas != null)
                    {
                        foreach (var idHistorial in guardado.IdsLlavesRecogidas)
                        {
                            if (idHistorial == escondite.ObjetoOculto.Id) { yaloTengo = true; break; }
                        }
                    }
                    if (yaloTengo == true)
                    {
                        escondite.YaRevisado = true;
                        escondite.ObjetoOculto.Recogido = true;
                    }
                }
            }
        }
        public void RefrescarInventario()
        {
            flpItems.Visible = true;
            flpItems.Controls.Clear();

            foreach (var item in prisionero.Inventario)
            {
                item.CargarImagen();
                PictureBox pbItem = new PictureBox();
                pbItem.Size = new Size(64, 64);
                pbItem.SizeMode = PictureBoxSizeMode.Zoom;

                if (item.IconoInventario != null)
                {
                    pbItem.Image = item.IconoInventario;
                }
                else
                {
                    pbItem.BackColor = Color.Red;
                }


                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(pbItem, item.Descripcion);

                flpItems.Controls.Add(pbItem);
            }
        }
        private void PanelJuego_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PanelMenuJuego_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlInventario.Visible = false;
        }

        private void btnSalirVictoria_Click(object sender, EventArgs e)
        {
            SaliraMenu?.Invoke(this, EventArgs.Empty);
        }

        private void pnlVictoria_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlVictoria_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void lblVictoriaTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}