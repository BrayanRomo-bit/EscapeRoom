namespace EscapeRoom
{
    partial class UCPantallaJuego
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PanelMenuJuego = new Panel();
            btnReanudar = new Button();
            btnInventario = new Button();
            btncargar = new Button();
            btnSaliraMenu = new Button();
            btnGuadarPartida = new Button();
            btnPausaJuego = new Button();
            timerjuego = new System.Windows.Forms.Timer(components);
            PanelJuego = new Panel();
            PanelMenuJuego.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMenuJuego
            // 
            PanelMenuJuego.BackColor = Color.Transparent;
            PanelMenuJuego.Controls.Add(btnReanudar);
            PanelMenuJuego.Controls.Add(btnInventario);
            PanelMenuJuego.Controls.Add(btncargar);
            PanelMenuJuego.Controls.Add(btnSaliraMenu);
            PanelMenuJuego.Controls.Add(btnGuadarPartida);
            PanelMenuJuego.ForeColor = Color.Black;
            PanelMenuJuego.Location = new Point(217, 130);
            PanelMenuJuego.Name = "PanelMenuJuego";
            PanelMenuJuego.Size = new Size(367, 341);
            PanelMenuJuego.TabIndex = 7;
            PanelMenuJuego.Visible = false;
            PanelMenuJuego.Paint += PanelMenuJuego_Paint;
            // 
            // btnReanudar
            // 
            btnReanudar.Location = new Point(76, 86);
            btnReanudar.Name = "btnReanudar";
            btnReanudar.Size = new Size(215, 35);
            btnReanudar.TabIndex = 4;
            btnReanudar.Text = "Reanudar";
            btnReanudar.UseVisualStyleBackColor = true;
            btnReanudar.Click += btnReanudar_Click;
            // 
            // btnInventario
            // 
            btnInventario.Location = new Point(76, 216);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(215, 35);
            btnInventario.TabIndex = 3;
            btnInventario.Text = "Mostrar Inventario";
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click;
            // 
            // btncargar
            // 
            btncargar.Location = new Point(76, 169);
            btncargar.Name = "btncargar";
            btncargar.Size = new Size(215, 35);
            btncargar.TabIndex = 2;
            btncargar.Text = "Cargar Partida";
            btncargar.UseVisualStyleBackColor = true;
            btncargar.Click += btncargar_Click;
            // 
            // btnSaliraMenu
            // 
            btnSaliraMenu.Location = new Point(76, 260);
            btnSaliraMenu.Name = "btnSaliraMenu";
            btnSaliraMenu.Size = new Size(215, 35);
            btnSaliraMenu.TabIndex = 1;
            btnSaliraMenu.Text = "Salir";
            btnSaliraMenu.UseVisualStyleBackColor = true;
            btnSaliraMenu.Click += btnSaliraMenu_Click;
            // 
            // btnGuadarPartida
            // 
            btnGuadarPartida.Location = new Point(76, 127);
            btnGuadarPartida.Name = "btnGuadarPartida";
            btnGuadarPartida.Size = new Size(215, 35);
            btnGuadarPartida.TabIndex = 0;
            btnGuadarPartida.Text = "Guardar Partida";
            btnGuadarPartida.UseVisualStyleBackColor = true;
            btnGuadarPartida.Click += btnGuadarPartida_Click;
            // 
            // btnPausaJuego
            // 
            btnPausaJuego.Location = new Point(0, 0);
            btnPausaJuego.Name = "btnPausaJuego";
            btnPausaJuego.Size = new Size(75, 34);
            btnPausaJuego.TabIndex = 8;
            btnPausaJuego.Text = "Pausa";
            btnPausaJuego.UseVisualStyleBackColor = true;
            btnPausaJuego.Click += btnPausaJuego_Click;
            // 
            // timerjuego
            // 
            timerjuego.Enabled = true;
            timerjuego.Interval = 20;
            timerjuego.Tick += timerjuego_Tick;
            // 
            // PanelJuego
            // 
            PanelJuego.BackColor = Color.Black;
            PanelJuego.Location = new Point(0, 0);
            PanelJuego.Name = "PanelJuego";
            PanelJuego.Size = new Size(800, 700);
            PanelJuego.TabIndex = 10;
            PanelJuego.Paint += PanelJuego_Paint;
            // 
            // UCPantallaJuego
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            Controls.Add(PanelMenuJuego);
            Controls.Add(btnPausaJuego);
            Controls.Add(PanelJuego);
            Name = "UCPantallaJuego";
            Size = new Size(800, 600);
            Load += UCPantallaJuego_Load;
            PanelMenuJuego.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMenuJuego;
        private Button btnReanudar;
        private Button btnInventario;
        private Button btncargar;
        private Button btnSaliraMenu;
        private Button btnGuadarPartida;
        private Button btnPausaJuego;
        private System.Windows.Forms.Timer timerjuego;
        private Panel PanelJuego;
    }
}
