namespace EscapeRoom
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            PanelJuego = new Panel();
            btnPausaJuego = new Button();
            PanelMenuPrincipal = new Panel();
            btnCargarPartida = new Button();
            btnSalir = new Button();
            BtnNuevaPartida = new Button();
            PanelMenuJuego = new Panel();
            btnInventario = new Button();
            btncargar = new Button();
            btnSaliraMenu = new Button();
            btnGuadarPartida = new Button();
            btnReanudar = new Button();
            PanelJuego.SuspendLayout();
            PanelMenuPrincipal.SuspendLayout();
            PanelMenuJuego.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 20;
            timer1.Tick += timer1_Tick;
            // 
            // PanelJuego
            // 
            PanelJuego.Controls.Add(btnPausaJuego);
            PanelJuego.Dock = DockStyle.Fill;
            PanelJuego.Location = new Point(0, 0);
            PanelJuego.Name = "PanelJuego";
            PanelJuego.Size = new Size(984, 761);
            PanelJuego.TabIndex = 4;
            // 
            // btnPausaJuego
            // 
            btnPausaJuego.Location = new Point(897, 12);
            btnPausaJuego.Name = "btnPausaJuego";
            btnPausaJuego.Size = new Size(75, 34);
            btnPausaJuego.TabIndex = 0;
            btnPausaJuego.Text = "Pausa";
            btnPausaJuego.UseVisualStyleBackColor = true;
            btnPausaJuego.Click += btnPausa_Click;
            // 
            // PanelMenuPrincipal
            // 
            PanelMenuPrincipal.BackgroundImage = Properties.Resources.goku;
            PanelMenuPrincipal.Controls.Add(btnCargarPartida);
            PanelMenuPrincipal.Controls.Add(btnSalir);
            PanelMenuPrincipal.Controls.Add(BtnNuevaPartida);
            PanelMenuPrincipal.Dock = DockStyle.Fill;
            PanelMenuPrincipal.Location = new Point(0, 0);
            PanelMenuPrincipal.Name = "PanelMenuPrincipal";
            PanelMenuPrincipal.Size = new Size(984, 761);
            PanelMenuPrincipal.TabIndex = 5;
            PanelMenuPrincipal.Paint += PanelMenuPrincipal_Paint;
            // 
            // btnCargarPartida
            // 
            btnCargarPartida.Location = new Point(287, 202);
            btnCargarPartida.Name = "btnCargarPartida";
            btnCargarPartida.Size = new Size(165, 36);
            btnCargarPartida.TabIndex = 2;
            btnCargarPartida.Text = "Cargar Partida";
            btnCargarPartida.UseVisualStyleBackColor = true;
            btnCargarPartida.Click += btnCargarPartida_Click_1;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(287, 287);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(165, 42);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir del Juego";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // BtnNuevaPartida
            // 
            BtnNuevaPartida.Location = new Point(287, 130);
            BtnNuevaPartida.Name = "BtnNuevaPartida";
            BtnNuevaPartida.Size = new Size(165, 39);
            BtnNuevaPartida.TabIndex = 0;
            BtnNuevaPartida.Text = "Nueva Partida";
            BtnNuevaPartida.UseVisualStyleBackColor = true;
            BtnNuevaPartida.Click += BtnNuevaPartida_Click;
            // 
            // PanelMenuJuego
            // 
            PanelMenuJuego.BackColor = SystemColors.ScrollBar;
            PanelMenuJuego.Controls.Add(btnReanudar);
            PanelMenuJuego.Controls.Add(btnInventario);
            PanelMenuJuego.Controls.Add(btncargar);
            PanelMenuJuego.Controls.Add(btnSaliraMenu);
            PanelMenuJuego.Controls.Add(btnGuadarPartida);
            PanelMenuJuego.Location = new Point(330, 75);
            PanelMenuJuego.Name = "PanelMenuJuego";
            PanelMenuJuego.Size = new Size(367, 341);
            PanelMenuJuego.TabIndex = 6;
            PanelMenuJuego.Visible = false;
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
            btnSaliraMenu.Click += btnSalirAlTitulo_Click;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(984, 761);
            Controls.Add(PanelMenuJuego);
            Controls.Add(PanelJuego);
            Controls.Add(PanelMenuPrincipal);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ActiveCaptionText;
            KeyPreview = true;
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            PanelJuego.ResumeLayout(false);
            PanelMenuPrincipal.ResumeLayout(false);
            PanelMenuJuego.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Panel PanelJuego;
        private Button btnPausaJuego;
        private Panel PanelMenuPrincipal;
        private Button btnCargarPartida;
        private Button btnSalir;
        private Button BtnNuevaPartida;
        private Panel PanelMenuJuego;
        private Button btnSaliraMenu;
        private Button btnGuadarPartida;
        private Button btncargar;
        private Button btnInventario;
        private Button btnReanudar;
    }
}
