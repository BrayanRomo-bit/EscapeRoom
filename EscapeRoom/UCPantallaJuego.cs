using EscapeRoom;
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
            else if (keyData == Keys.Space)
            {
                botonesNavegacion[indiceSeleccionado].PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UCPantallaJuego_Load(object sender, EventArgs e)
        {
            ActualizarTextosMenu();
            this.Focus();
        }

        private void ActualizarTextosMenu()
        {
            btnReanudar.Text = Traductor.Obtener("pantallas.UCPantallaJuego.botones.btnReanudar");
            btnGuadarPartida.Text = Traductor.Obtener("pantallas.UCPantallaJuego.botones.btnGuadarPartida");
            btncargar.Text = Traductor.Obtener("pantallas.UCPantallaJuego.botones.btncargar");
            btnInventario.Text = Traductor.Obtener("pantallas.UCPantallaJuego.botones.btnInventario");
            btnSaliraMenu.Text = Traductor.Obtener("pantallas.UCPantallaJuego.botones.btnSaliraMenu");
        }

        private void btnPausaJuego_Click(object sender, EventArgs e)
        {
            PanelMenuJuego.Visible = true;
            timerjuego.Stop();
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
            var puertaConCodigo = nivel.Puertas.FirstOrDefault(p => p.RequiereCodigo == true);
            if (puertaConCodigo != null)
            {
                codigoGenerado = puertaConCodigo.Codigo;
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
                CodigoPuertaFinal = codigoGenerado
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

            if (guardado.InventarioPrisionero != null) prisioneroActual.Inventario = guardado.InventarioPrisionero;

            if (!string.IsNullOrEmpty(guardado.CodigoPuertaFinal))
            {
                var puertaSalida = nivel.Puertas.FirstOrDefault(p => p.RequiereCodigo == true);
                if (puertaSalida != null)
                {
                    puertaSalida.Codigo = guardado.CodigoPuertaFinal;
                }
                string cod = guardado.CodigoPuertaFinal;
                if (cod.Length == 3 && nivel.EsconditeCod != null)
                {
                    foreach (var cofre in nivel.EsconditeCod)
                    {
                        if (cofre.ObjetoOculto != null)
                        {
                            if (cofre.ObjetoOculto.Id == "nota1")
                                cofre.ObjetoOculto.Descripcion = Traductor.Obtener("niveles.Nivel1.pistas_codigo.nota1", cod[0].ToString());
                            else if (cofre.ObjetoOculto.Id == "nota2")
                                cofre.ObjetoOculto.Descripcion = Traductor.Obtener("niveles.Nivel1.pistas_codigo.nota2", cod[1].ToString());
                            else if (cofre.ObjetoOculto.Id == "nota3")
                                cofre.ObjetoOculto.Descripcion = Traductor.Obtener("niveles.Nivel1.pistas_codigo.nota3", cod[2].ToString());
                        }
                    }
                }
            }

            if (guardado.IdsPuertasAbiertas != null)
            {
                foreach (var idPuerta in guardado.IdsPuertasAbiertas)
                {
                    var p = nivel.Puertas.FirstOrDefault(x => x.Id == idPuerta);
                    if (p != null)
                    {
                        p.EstaAbierta = true;
                        if (p.Imagen != null) p.Imagen.Bounds = Rectangle.Empty;
                    }
                }
            }
            MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaJuego.messageboxes.punto_de_control_cargado"));
            PanelMenuJuego.Visible = false;
            timerjuego.Start();
            this.Focus();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Prisionero goku = nivel.Prisioneros[0];
            string textoMochila = goku.ObtenerTextoInventario();
            MessageBox.Show(textoMochila, Traductor.Obtener("pantallas.UCPantallaJuego.messageboxes.titulo_inventario"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Focus();
        }

        private void btnSaliraMenu_Click(object sender, EventArgs e)
        {
            SaliraMenu?.Invoke(this, EventArgs.Empty);
        }

        private void timerjuego_Tick(object sender, EventArgs e)
        {
            if (nivel == null) return;

            if (nivel.EstaEnCinematica && nivel.miAutobus != null)
            {
                nivel.miAutobus.Imagen.Left += 10;
                if (nivel.miAutobus.Imagen.Left > this.Width)
                {
                    timerjuego.Stop();
                    MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaJuego.messageboxes.escape_exitoso"));
                    SaliraMenu?.Invoke(this, EventArgs.Empty);
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

            if ((GetAsyncKeyState(Keys.I) < 0) || (GetAsyncKeyState(Keys.Enter) < 0))
            {
                PanelMenuJuego.Visible = true;
                timerjuego.Stop();
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
                    SaliraMenu?.Invoke(this, EventArgs.Empty);
                    return;
                }
                nivel.Dock = DockStyle.Fill;
                nivel.Reinicio += ReiniciarPorDerrota;
                nivel.IniciarNivel();
                PanelJuego.Controls.Add(nivel);
                this.prisionero = nivel.Prisioneros[0];
                this.Focus();
                timerjuego.Start();
            }
        }

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        public void ReiniciarPorDerrota()
        {
            PanelJuego.Controls.Clear();
            if (nivel is Nivel1) nivel = new Nivel1();
            else if (nivel is Nivel2) nivel = new Nivel2();

            nivel.Reinicio += ReiniciarPorDerrota;
            PanelJuego.Controls.Add(nivel);
            nivel.IniciarNivel();
            this.prisionero = nivel.Prisioneros[0];
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
                    {
                        nivel = new Nivel1();
                    }
                    break;
                case 2:
                    {
                        nivel = new Nivel2();
                    }
                    break;
                case 3:
                    {
                        nivel = new Nivel3();
                    }
                    break;
            }
            nivel.Dock = DockStyle.Fill;
            PanelJuego.Controls.Add(nivel);
            nivel.IniciarNivel();

            this.prisionero = nivel.Prisioneros[0];
            this.prisionero.Nombre = nombreJugador;
            this.prisionero.X = guardado.PrisioneroX;
            this.prisionero.Y = guardado.PrisioneroY;
            this.prisionero.Imagen.Location = new Point(this.prisionero.X, this.prisionero.Y);

            if (guardado.InventarioPrisionero != null) this.prisionero.Inventario = guardado.InventarioPrisionero;

            if (!string.IsNullOrEmpty(guardado.CodigoPuertaFinal))
            {
                var puertaSalida = nivel.Puertas.FirstOrDefault(p => p.RequiereCodigo == true);
                if (puertaSalida != null)
                {
                    puertaSalida.Codigo = guardado.CodigoPuertaFinal;
                }
                string cod = guardado.CodigoPuertaFinal;
                if (cod.Length == 3 && nivel.EsconditeCod != null)
                {
                    foreach (var cofre in nivel.EsconditeCod)
                    {
                        if (cofre.ObjetoOculto != null)
                        {
                            if (cofre.ObjetoOculto.Id == "nota1")
                                cofre.ObjetoOculto.Descripcion = Traductor.Obtener("niveles.Nivel1.pistas_codigo.nota1", cod[0].ToString());
                            else if (cofre.ObjetoOculto.Id == "nota2")
                                cofre.ObjetoOculto.Descripcion = Traductor.Obtener("niveles.Nivel1.pistas_codigo.nota2", cod[1].ToString());
                            else if (cofre.ObjetoOculto.Id == "nota3")
                                cofre.ObjetoOculto.Descripcion = Traductor.Obtener("niveles.Nivel1.pistas_codigo.nota3", cod[2].ToString());
                        }
                    }
                }
            }

            if (guardado.IdsPuertasAbiertas != null)
            {
                foreach (var idPuerta in guardado.IdsPuertasAbiertas)
                {
                    var p = nivel.Puertas.FirstOrDefault(x => x.Id == idPuerta);
                    if (p != null)
                    {
                        p.EstaAbierta = true;
                        if (p.Imagen != null) p.Imagen.Bounds = Rectangle.Empty;
                    }
                }
            }
            btnPausaJuego.Visible = true;
            btnPausaJuego.BringToFront();

            timerjuego.Start();
            this.Focus();
        }

        private void PanelJuego_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PanelMenuJuego_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}