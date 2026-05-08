using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscapeRoom
{

    public partial class Nivel1 : NivelBase
    {

        public Nivel1()
        {
            InitializeComponent();
        }

        public override void IniciarNivel()
        {
            lblDialogo = new Label();
            lblDialogo.BackColor = Color.Black;
            lblDialogo.ForeColor = Color.White;
            lblDialogo.Dock = DockStyle.Bottom;
            lblDialogo.Height = 100;
            lblDialogo.Font = new Font("Consolas", 14, FontStyle.Bold);
            lblDialogo.TextAlign = ContentAlignment.MiddleCenter;
            lblDialogo.Visible = false;
            this.Controls.Add(lblDialogo);


            baseDeDialogos.Add(0, "Jhon: Escuché que le darán pena de muerte a Mario...");
            baseDeDialogos.Add(1, "Mario:No puede ser me daran pena de muerte,jamas escapare");
            baseDeDialogos.Add(2, "Guardia: ¡Vuelve a tu celda!");

            baseDeLLaves.Add(5, "Llave de la celda de Mario");
            baseDeLLaves.Add(6, "Llave de la celda de Jhon");
            baseDePuertas.Add(5, "Puerta de la celda de Mario");
            baseDePuertas.Add(6, "Puerta de la celda de Jhon");

            // 3. Definimos nuestro mapa
            string[] mapa = new string[]
            {
                "xxxxxxxxxxxxxxxxxxxx",
                "PN.P...P.N.P.......x",
                "P..P...P...P.....G.x",
                "xx.xx.xxSxxB.......x",
                "xL.......J..L......x",
                "xxxxxxxxxxxxxxxxxVxx"
            };

            ConstruirMapa(mapa);
        }

        private void Nivel1_Load(object sender, EventArgs e)
        {

        }

    }
}