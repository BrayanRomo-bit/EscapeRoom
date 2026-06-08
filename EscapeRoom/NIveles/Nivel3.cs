using EscapeRoom.Entidades;
using EscapeRoom.NIveles;
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
    public partial class Nivel3 : NivelBase
    {
        public Nivel3()
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

            CrearJugador(80, 420);

            this.miAutobus = new Autobus(99, pbautobus);
            this.miAutobus.DialogosPorPasos.Add(Traductor.Obtener("niveles.Nivel3.npcs.miAutobus.dialogos_0"));
            this.miAutobus.DialogosPorPasos.Add(Traductor.Obtener("niveles.Nivel3.npcs.miAutobus.dialogos_1"));
           
            listaNPCs.Add(this.miAutobus);
        }

        private void Nivel3_Load(object sender, EventArgs e)
        {
        }
    }
}