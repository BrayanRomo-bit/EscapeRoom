using System.Text.Json;
using System.IO;
using System.Reflection.Emit;
using Label = System.Windows.Forms.Label;
using System.Diagnostics;
namespace EscapeRoom
{
    public partial class Form1 : Form
    {
        bool movArriba, movAbajo, movIzquierda, movDerecha, accion, accionBloqueada;
        NivelBase nivel;
        Prisionero prisionero;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarMenuPrincipal();
        }

        private void PanelJuego_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MostrarMenuPrincipal()
        {
            PanelJuego.Visible = false;
            btnPausaJuego.Visible = false;

            PanelMenuPrincipal.Visible = true;
            PanelMenuPrincipal.BringToFront();
            timer1.Stop();
        }

        private void IniciarJuego()
        {
            PanelMenuPrincipal.Visible = false;

            PanelJuego.Visible = true;
            btnPausaJuego.Visible = true;
            btnPausaJuego.BringToFront();

            timer1.Start();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (nivel == null) return; // o timer1.Enabled = false;
            nivel.ActualizarNivel(movArriba, movAbajo, movIzquierda, movDerecha, accion, PanelJuego.Width, PanelJuego.Height);
            if (nivel.NivelSuperado== true)
            {
                timer1.Stop();
                MessageBox.Show("¡Nivel superado! Pasando al siguiente nivel...");
                PanelJuego.Controls.Clear();
                nivel = new Nivel2();
                PanelJuego.Controls.Add(nivel);
                nivel.IniciarNivel();
                timer1.Start();
            }

            foreach (Guardia guardia in nivel.Guardias)
            {
                guardia.Actualizar(movArriba, movAbajo, movIzquierda, movDerecha, accion, nivel);
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up) movArriba = true;
            if (keyData == Keys.Down) movAbajo = true;
            if (keyData == Keys.Left) movIzquierda = true;
            if (keyData == Keys.Right) movDerecha = true;

            if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right)
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I)
            {
                PanelMenuJuego.Visible = true;
                timer1.Stop();
            }
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up) movArriba = true;
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down) movAbajo = true;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) movIzquierda = true;
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) movDerecha = true;
            if (e.KeyCode == Keys.E && accionBloqueada == false)
            {
                accion = true;
                accionBloqueada = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up) movArriba = false;
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down) movAbajo = false;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) movIzquierda = false;
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) movDerecha = false;

            if (e.KeyCode == Keys.E)
            {
                accion = false;
                accionBloqueada = false;
            }
        }

        private void btnCargarPartida_Click_1(object sender, EventArgs e)
        {

            if (!File.Exists("guardado.json"))
            {
                MessageBox.Show("No hay partida guardada.");
                return;
            }
            else
            {
                string json = File.ReadAllText("guardado.json");
                Guardado guardado = JsonSerializer.Deserialize<Guardado>(json);
                Prisionero datosGuardados = guardado.Prisionero;

                IniciarJuego();
                nivel = new Nivel1();
                PanelJuego.Controls.Add(nivel);
                nivel.IniciarNivel();

                Prisionero prisioneroActual = nivel.Prisioneros[0];

                prisioneroActual.X = datosGuardados.X;
                prisioneroActual.Y = datosGuardados.Y;
                prisioneroActual.Inventario = datosGuardados.Inventario;

                prisioneroActual.Imagen.Location = new Point(prisioneroActual.X, prisioneroActual.Y);

                btnPausaJuego.Visible = true;
                btnPausaJuego.BringToFront();
            }

        }


        private void BtnNuevaPartida_Click(object sender, EventArgs e)
        {
            IniciarJuego();
            nivel = new Nivel1();
            PanelJuego.Controls.Add(nivel);
            nivel.IniciarNivel();
            btnPausaJuego.Visible = true;
            btnPausaJuego.BringToFront();
        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            if (PanelMenuJuego.Visible == false)
            {
                PanelMenuJuego.Visible = true;
                PanelMenuJuego.BringToFront();
                timer1.Stop();
            }
        }


        private void PanelMenuPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalirAlTitulo_Click(object sender, EventArgs e)
        {
            PanelMenuJuego.Visible = false;
            PanelJuego.Controls.Clear();
            MostrarMenuPrincipal();
        }
        private void btnGuadarPartida_Click(object sender, EventArgs e)
        {

            if (nivel.Prisioneros == null || nivel.Prisioneros.Count == 0)
                return;

            Prisionero prisionero = nivel.Prisioneros[0];
            int NivelActual;
            Guardado guardado = new Guardado
            {
                Prisionero = prisionero,
                NivelActual = 1,
                ObjetosRecogidos = prisionero.Inventario,

            };
            string json = JsonSerializer.Serialize(guardado);
            File.WriteAllText("guardado.json", json);
            MessageBox.Show("El archivo se guardó en: " + Path.GetFullPath("guardado.json"));
        }

        private void btncargar_Click(object sender, EventArgs e)
        {
            if (!File.Exists("guardado.json"))
            {
                MessageBox.Show("No hay partida guardada.");
                return;
            }
            else if (nivel.Prisioneros == null || nivel.Prisioneros.Count == 0)
            {
                MessageBox.Show("No hay prisionero en el nivel para cargar la partida.");
                return;
            }
            else
            {
                string json = File.ReadAllText("guardado.json");
                Guardado guardado = JsonSerializer.Deserialize<Guardado>(json);
                Prisionero datosGuardados = guardado.Prisionero;

                // 2. Tomamos al Goku que ya está vivo en el nivel
                Prisionero prisioneroActual = nivel.Prisioneros[0];

                // 3. ¡Hacemos el transplante de datos!
                prisioneroActual.X = datosGuardados.X;
                prisioneroActual.Y = datosGuardados.Y;
                prisioneroActual.Inventario = datosGuardados.Inventario;

                // 4. Actualizamos la posición visual de la imagen en la pantalla
                prisioneroActual.Imagen.Location = new Point(prisioneroActual.X, prisioneroActual.Y);

                btncargar.Text = "Partida Cargada";
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            // 1. Programación Defensiva: Nos aseguramos de que haya una partida activa
            if (nivel == null || nivel.Prisioneros.Count == 0)
            {
                MessageBox.Show("Aún no hay ningún prisionero en el nivel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Encontramos a Goku
            Prisionero goku = nivel.Prisioneros[0];

            // 3. Le pedimos a Goku que nos dicte qué trae en la mochila
            string textoMochila = goku.ObtenerTextoInventario();

            // 4. Mostramos el resultado en una ventana emergente limpia y nativa de Windows
            MessageBox.Show(textoMochila, "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReanudar_Click(object sender, EventArgs e)
        {

            PanelMenuJuego.Visible = false;

            timer1.Start();
        }
    }

}
