using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EscapeRoom
{
    public partial class UCPantallaMenu : UserControl
    {
        public event Action<string> AlIniciarNuevaPartida;
        public event Action<string> AlCargarPartidaExistente;

        private List<Button> botonesNavegacion;

        private int indiceSeleccionado = 0;

        private string carpetaPartidas = Path.Combine(Application.StartupPath, "Partidas Guardadas");

        public UCPantallaMenu()
        {
            InitializeComponent();
            botonesNavegacion = new List<Button>
            {
                BtnNuevaPartida,
                btnCargarPartida,
                btnIdioma,
                btnSalir
            };
            ResaltarBotonActual();
        }

        private void UCPantallaMenu_Load(object sender, EventArgs e)
        {
            panelnombre.Visible = false;
            panelcargar.Visible = false;
            ActualizarTextosMenu();
        }

        private void ActualizarTextosMenu()
        {
            BtnNuevaPartida.Text = Traductor.Obtener("pantallas.UCPantallaMenu.botones.BtnNuevaPartida");
            btnCargarPartida.Text = Traductor.Obtener("pantallas.UCPantallaMenu.botones.btnCargarPartida");
            btnSalir.Text = Traductor.Obtener("pantallas.UCPantallaMenu.botones.btnSalir");
            btnConfirmarCarga.Text = Traductor.Obtener("pantallas.UCPantallaMenu.botones.btnConfirmarCarga");
            btnAceptarNombr.Text = Traductor.Obtener("pantallas.UCPantallaMenu.botones.btnAceptarNombr");

            if (Traductor.IdiomaActual == "es")
            {
                btnIdioma.Text = "Idioma: ESP";
            }
            else
            {
                btnIdioma.Text = "Language: ENG";
            }
        }

        private void BtnNuevaPartida_Click(object sender, EventArgs e)
        {
            panelcargar.Visible = false;
            panelnombre.BringToFront();
            panelnombre.Visible = true;
            panelnombre.Enabled = true;
        }

        private void btnCargarPartida_Click(object sender, EventArgs e)
        {
            panelnombre.Visible = false;
            panelcargar.BringToFront();
            panelcargar.Visible = true;
            panelcargar.Enabled = true;
            LlenarListaDePartidas();
        }

        private void LlenarListaDePartidas()
        {
            listpartidas.Items.Clear();

            if (Directory.Exists(carpetaPartidas))
            {
                string[] archivos = Directory.GetFiles(carpetaPartidas, "*.json");

                foreach (string ruta in archivos)
                {
                    string nombreLimpio = Path.GetFileNameWithoutExtension(ruta);
                    listpartidas.Items.Add(nombreLimpio);
                }

                if (listpartidas.Items.Count > 0)
                {
                    listpartidas.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaMenu.messageboxes.carpeta_vacia"));
                }
            }
            else
            {
                MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaMenu.messageboxes.carpeta_no_encontrada"));
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptarNombr_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreUsuario.Text;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaMenu.messageboxes.nombre_vacio"));
                return;
            }

            AlIniciarNuevaPartida?.Invoke(nombre);
        }

        private void panelcargar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmarCarga_Click_1(object sender, EventArgs e)
        {
            if (listpartidas.SelectedItem != null)
            {
                string nombreElegido = listpartidas.SelectedItem.ToString();

                AlCargarPartidaExistente?.Invoke(nombreElegido);
            }
            else
            {
                MessageBox.Show(Traductor.Obtener("pantallas.UCPantallaMenu.messageboxes.selecciona_partida"));
            }
        }

        private void panelnombre_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

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

        private void btnIdioma_Click(object sender, EventArgs e)
        {
            if (Traductor.IdiomaActual == "es")
            {
                Traductor.CargarIdioma("en");
            }
            else
            {
                Traductor.CargarIdioma("es");
            }
            ActualizarTextosMenu();
        }
    }
}