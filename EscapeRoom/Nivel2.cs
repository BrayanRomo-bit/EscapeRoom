using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    internal class Nivel2: NivelBase
    {
        public Nivel2()
        {
        }
        public void IniciarNivel()
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


            baseDeDialogos.Add(5, "Jhon: Escuché que le darán pena de muerte a Mario...");
            baseDeDialogos.Add(1, "Mario: Psst... busca una grieta.");
            baseDeDialogos.Add(2, "Guardia: ¡Vuelve a tu celda!");

            // 3. Definimos nuestro mapa
            string[] mapa = new string[]
            {
                "xxxxxxxxxxxxxxxxxxxx",
                "P..P...P...P.......x",
                "P..P...P...P.......x",
                "xx.xx.xx.xxB.......x",
                ".......J...........x",
                "xxxxxxxxxxxxxxxxxxSx"
            };

            ConstruirMapa(mapa);
        }
    }
}
