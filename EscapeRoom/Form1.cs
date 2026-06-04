using System;
using System.Windows.Forms;

namespace EscapeRoom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new Size(800, 720);
            Traductor.CargarIdioma("es");
            this.StartPosition = FormStartPosition.CenterScreen;
            // Configuración de la ventana (puedes descomentarlo cuando gustes)
            /*
            this.ClientSize = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarMenuPrincipal();
        }

        public void MostrarMenuPrincipal()
        {
            this.Controls.Clear();

            UCPantallaMenu menu = new UCPantallaMenu();
            menu.Dock = DockStyle.Fill;
menu.AlIniciarNuevaPartida += RecibirNuevaPartida;
            menu.AlCargarPartidaExistente += RecibirCargarPartida;

            this.Controls.Add(menu);
        }

        // --- MÉTODOS RECEPTORES DEL MENÚ ---
        private void RecibirNuevaPartida(string nombreJugador)
        {
            // Llama a la máquina principal avisando que NO es carga
            IniciarJuego(nombreJugador, false);
        }

        private void RecibirCargarPartida(string nombreJugador)
        {
            // Llama a la máquina principal avisando que SÍ es carga
            IniciarJuego(nombreJugador, true);
        }

        // --- MÁQUINA PRINCIPAL DE ARRANQUE ---
        private void IniciarJuego(string nombreJugador, bool esCarga)
        {
            this.Controls.Clear();

            UCPantallaJuego juego = new UCPantallaJuego();
            juego.Dock = DockStyle.Fill;

            // 2. CONECTAMOS EL CABLE DEL JUEGO (Sin lambdas)
            // Cuando el juego grite que quiere salir, ejecutamos SalirDelJuego
            juego.SaliraMenu += SalirDelJuego;

            this.Controls.Add(juego);

            // Orden de arranque
            if (esCarga)
            {
                juego.CargarPartidaDesdeMenu(nombreJugador);
            }
            else
            {
                juego.ArrancarNuevaPartida(nombreJugador);
            }
        }

        // --- MÉTODO RECEPTOR DEL JUEGO ---
        // Este método obligatoriamente debe recibir (object sender, EventArgs e) 
        // porque así es la regla de los EventHandler estándar de C#.
        private void SalirDelJuego(object sender, EventArgs e)
        {
            MostrarMenuPrincipal();
        }
    }
}