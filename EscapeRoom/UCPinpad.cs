using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscapeRoom
{
    public partial class UCPinpad : UserControl
    {
        public event Action<string> ConfirmarCodigo;
        public event Action CancelarCodigo;
        string codigoIngresado = "";

        private Button[,] matrizBotones;
        private int filaActual = 0;
        private int colActual = 0;

        public UCPinpad()
        {
            InitializeComponent();

            matrizBotones = new Button[,]
            {
                { btnNum1, btnNum2, btnNum3 },
                { btnNum4, btnNum5, btnNum6 },
                { btnNum7, btnNum8, btnNum9 },
                { btnCancelar, btnNum0, btnOK }
            };

            ResaltarBoton();
        }

        private void ResaltarBoton()
        {
            foreach (Button btn in matrizBotones)
            {
                if (btn != null)
                {
                    btn.BackColor = Color.LightGray;
                    btn.ForeColor = Color.Black;
                }
            }

            Button botonActivo = matrizBotones[filaActual, colActual];
            if (botonActivo != null)
            {
                botonActivo.Focus();
                botonActivo.BackColor = Color.DarkRed;
                botonActivo.ForeColor = Color.Yellow;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.W || keyData == Keys.Up)
            {
                filaActual--;
                if (filaActual < 0) filaActual = 3; 
                ResaltarBoton();
                return true;
            }
            else if (keyData == Keys.S || keyData == Keys.Down)
            {
                filaActual++;
                if (filaActual > 3) filaActual = 0; 
                ResaltarBoton();
                return true;
            }
            else if (keyData == Keys.A || keyData == Keys.Left)
            {
                colActual--;
                if (colActual < 0) colActual = 2;
                ResaltarBoton();
                return true;
            }
            else if (keyData == Keys.D || keyData == Keys.Right)
            {
                colActual++;
                if (colActual > 2) colActual = 0; 
                ResaltarBoton();
                return true;
            }
            else if (keyData == Keys.Space || keyData == Keys.Enter)
            {
                matrizBotones[filaActual, colActual].PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnDigito_Click(object sender, EventArgs e)
        {
            if (codigoIngresado.Length < 3)
            {
                Button botonPresionado = (Button)sender;
                codigoIngresado += botonPresionado.Text;
                label1.Text = codigoIngresado;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (codigoIngresado.Length > 0)
            {
                codigoIngresado = codigoIngresado.Substring(0, codigoIngresado.Length - 1);
                label1.Text = codigoIngresado == "" ? "---" : codigoIngresado;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ConfirmarCodigo?.Invoke(codigoIngresado);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarCodigo?.Invoke();
        }

        private void UCPinpad_Load(object sender, EventArgs e)
        {
        }
    }
}