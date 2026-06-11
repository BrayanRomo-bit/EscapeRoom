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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPantallaJuego));
            PanelMenuJuego = new Panel();
            btnReanudar = new Button();
            btnInventario = new Button();
            btncargar = new Button();
            btnSaliraMenu = new Button();
            btnGuadarPartida = new Button();
            btnPausaJuego = new Button();
            timerjuego = new System.Windows.Forms.Timer(components);
            pnlInventario = new Panel();
            button1 = new Button();
            flpItems = new FlowLayoutPanel();
            PanelJuego = new Panel();
            lblPuntaje = new Label();
            pnlVictoria = new Panel();
            btnSalirVictoria = new Button();
            lblNuevoRecord = new Label();
            lblRecord = new Label();
            lblPuntosFinales = new Label();
            lblVictoriaTitulo = new Label();
            PanelMenuJuego.SuspendLayout();
            pnlInventario.SuspendLayout();
            PanelJuego.SuspendLayout();
            pnlVictoria.SuspendLayout();
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
            btnPausaJuego.Location = new Point(643, 15);
            btnPausaJuego.Name = "btnPausaJuego";
            btnPausaJuego.Size = new Size(116, 35);
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
            // pnlInventario
            // 
            pnlInventario.AutoScroll = true;
            pnlInventario.BackColor = Color.DarkGray;
            pnlInventario.BackgroundImage = (Image)resources.GetObject("pnlInventario.BackgroundImage");
            pnlInventario.BackgroundImageLayout = ImageLayout.Zoom;
            pnlInventario.Controls.Add(button1);
            pnlInventario.Controls.Add(flpItems);
            pnlInventario.Location = new Point(169, 70);
            pnlInventario.Name = "pnlInventario";
            pnlInventario.Size = new Size(400, 300);
            pnlInventario.TabIndex = 0;
            pnlInventario.Visible = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(279, 7);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // flpItems
            // 
            flpItems.BackColor = Color.Transparent;
            flpItems.BackgroundImageLayout = ImageLayout.Stretch;
            flpItems.Location = new Point(97, 76);
            flpItems.Name = "flpItems";
            flpItems.Size = new Size(207, 147);
            flpItems.TabIndex = 0;
            flpItems.Visible = false;
            // 
            // PanelJuego
            // 
            PanelJuego.BackColor = Color.Black;
            PanelJuego.Controls.Add(btnPausaJuego);
            PanelJuego.Location = new Point(0, 0);
            PanelJuego.Name = "PanelJuego";
            PanelJuego.Size = new Size(800, 700);
            PanelJuego.TabIndex = 10;
            PanelJuego.Paint += PanelJuego_Paint;
            // 
            // lblPuntaje
            // 
            lblPuntaje.AutoSize = true;
            lblPuntaje.BackColor = Color.Transparent;
            lblPuntaje.ForeColor = Color.Yellow;
            lblPuntaje.Location = new Point(0, 0);
            lblPuntaje.Name = "lblPuntaje";
            lblPuntaje.Size = new Size(17, 20);
            lblPuntaje.TabIndex = 0;
            lblPuntaje.Text = "0";
            // 
            // pnlVictoria
            // 
            pnlVictoria.BackColor = SystemColors.Desktop;
            pnlVictoria.Controls.Add(btnSalirVictoria);
            pnlVictoria.Controls.Add(lblNuevoRecord);
            pnlVictoria.Controls.Add(lblRecord);
            pnlVictoria.Controls.Add(lblPuntosFinales);
            pnlVictoria.Controls.Add(lblVictoriaTitulo);
            pnlVictoria.Dock = DockStyle.Fill;
            pnlVictoria.Location = new Point(0, 0);
            pnlVictoria.Name = "pnlVictoria";
            pnlVictoria.Size = new Size(800, 600);
            pnlVictoria.TabIndex = 9;
            pnlVictoria.Visible = false;
            pnlVictoria.Paint += pnlVictoria_Paint_1;
            // 
            // btnSalirVictoria
            // 
            btnSalirVictoria.FlatStyle = FlatStyle.Popup;
            btnSalirVictoria.ForeColor = Color.White;
            btnSalirVictoria.Location = new Point(227, 382);
            btnSalirVictoria.Name = "btnSalirVictoria";
            btnSalirVictoria.Size = new Size(246, 55);
            btnSalirVictoria.TabIndex = 4;
            btnSalirVictoria.Text = "....";
            btnSalirVictoria.UseCompatibleTextRendering = true;
            btnSalirVictoria.UseVisualStyleBackColor = true;
            btnSalirVictoria.Click += btnSalirVictoria_Click;
            // 
            // lblNuevoRecord
            // 
            lblNuevoRecord.AutoSize = true;
            lblNuevoRecord.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNuevoRecord.ForeColor = Color.Gold;
            lblNuevoRecord.Location = new Point(259, 197);
            lblNuevoRecord.Name = "lblNuevoRecord";
            lblNuevoRecord.Size = new Size(200, 38);
            lblNuevoRecord.TabIndex = 3;
            lblNuevoRecord.Text = "Nuevo Record";
            lblNuevoRecord.Visible = false;
            // 
            // lblRecord
            // 
            lblRecord.AutoSize = true;
            lblRecord.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRecord.ForeColor = Color.Red;
            lblRecord.Location = new Point(259, 281);
            lblRecord.Name = "lblRecord";
            lblRecord.Size = new Size(202, 38);
            lblRecord.TabIndex = 2;
            lblRecord.Text = "Record Actual";
            // 
            // lblPuntosFinales
            // 
            lblPuntosFinales.AutoSize = true;
            lblPuntosFinales.Font = new Font("Unispace", 16.1999989F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPuntosFinales.ForeColor = Color.White;
            lblPuntosFinales.Location = new Point(259, 102);
            lblPuntosFinales.Name = "lblPuntosFinales";
            lblPuntosFinales.Size = new Size(111, 33);
            lblPuntosFinales.TabIndex = 1;
            lblPuntosFinales.Text = "label1";
            // 
            // lblVictoriaTitulo
            // 
            lblVictoriaTitulo.Font = new Font("Impact", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblVictoriaTitulo.ForeColor = Color.Red;
            lblVictoriaTitulo.Location = new Point(23, 15);
            lblVictoriaTitulo.Name = "lblVictoriaTitulo";
            lblVictoriaTitulo.Size = new Size(736, 74);
            lblVictoriaTitulo.TabIndex = 0;
            lblVictoriaTitulo.Text = "label1";
            lblVictoriaTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblVictoriaTitulo.Click += lblVictoriaTitulo_Click;
            // 
            // UCPantallaJuego
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            Controls.Add(lblPuntaje);
            Controls.Add(PanelMenuJuego);
            Controls.Add(pnlInventario);
            Controls.Add(PanelJuego);
            Controls.Add(pnlVictoria);
            Name = "UCPantallaJuego";
            Size = new Size(800, 600);
            Load += UCPantallaJuego_Load;
            PanelMenuJuego.ResumeLayout(false);
            pnlInventario.ResumeLayout(false);
            PanelJuego.ResumeLayout(false);
            pnlVictoria.ResumeLayout(false);
            pnlVictoria.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Panel pnlInventario;
        private Panel PanelJuego;
        private Button button1;
        private FlowLayoutPanel flpItems;
        private Label lblPuntaje;
        private Panel pnlVictoria;
        private Label lblPuntosFinales;
        private Label lblVictoriaTitulo;
        private Label lblRecord;
        private Label lblNuevoRecord;
        private Button btnSalirVictoria;
    }
}
