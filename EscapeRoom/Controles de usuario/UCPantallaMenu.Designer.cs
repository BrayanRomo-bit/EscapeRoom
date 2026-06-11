namespace EscapeRoom
{
    partial class UCPantallaMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPantallaMenu));
            BtnNuevaPartida = new Button();
            btnCargarPartida = new Button();
            btnSalir = new Button();
            panelcargar = new Panel();
            btnRegresarCargar = new Button();
            btnConfirmarCarga = new Button();
            listpartidas = new ListBox();
            btnIdioma = new Button();
            panelnombre = new Panel();
            lblCrearPartida = new Label();
            btnRegresarNombre = new Button();
            txtNombreUsuario = new TextBox();
            btnAceptarNombr = new Button();
            btnTutorial = new Button();
            pnlTutorial = new Panel();
            btnCerrarTutorial = new Button();
            lblTextoTutorial = new Label();
            lblTituloTutorial = new Label();
            panelcargar.SuspendLayout();
            panelnombre.SuspendLayout();
            pnlTutorial.SuspendLayout();
            SuspendLayout();
            // 
            // BtnNuevaPartida
            // 
            BtnNuevaPartida.Location = new Point(296, 204);
            BtnNuevaPartida.Name = "BtnNuevaPartida";
            BtnNuevaPartida.Size = new Size(202, 57);
            BtnNuevaPartida.TabIndex = 10;
            BtnNuevaPartida.Text = "Nueva Partida";
            BtnNuevaPartida.UseVisualStyleBackColor = true;
            BtnNuevaPartida.Click += BtnNuevaPartida_Click;
            // 
            // btnCargarPartida
            // 
            btnCargarPartida.Location = new Point(296, 280);
            btnCargarPartida.Name = "btnCargarPartida";
            btnCargarPartida.Size = new Size(202, 54);
            btnCargarPartida.TabIndex = 11;
            btnCargarPartida.Text = "Cargar Partida";
            btnCargarPartida.UseVisualStyleBackColor = true;
            btnCargarPartida.Click += btnCargarPartida_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(296, 498);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(202, 54);
            btnSalir.TabIndex = 12;
            btnSalir.Text = "Salir del Juego";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // panelcargar
            // 
            panelcargar.BackColor = SystemColors.ActiveCaptionText;
            panelcargar.Controls.Add(btnRegresarCargar);
            panelcargar.Controls.Add(btnConfirmarCarga);
            panelcargar.Controls.Add(listpartidas);
            panelcargar.Location = new Point(51, 33);
            panelcargar.Name = "panelcargar";
            panelcargar.Size = new Size(735, 564);
            panelcargar.TabIndex = 13;
            panelcargar.Paint += panelcargar_Paint;
            // 
            // btnRegresarCargar
            // 
            btnRegresarCargar.Location = new Point(29, 31);
            btnRegresarCargar.Name = "btnRegresarCargar";
            btnRegresarCargar.Size = new Size(199, 39);
            btnRegresarCargar.TabIndex = 4;
            btnRegresarCargar.UseVisualStyleBackColor = true;
            btnRegresarCargar.Click += btnRegresarCargar_Click;
            // 
            // btnConfirmarCarga
            // 
            btnConfirmarCarga.Location = new Point(376, 31);
            btnConfirmarCarga.Name = "btnConfirmarCarga";
            btnConfirmarCarga.Size = new Size(199, 39);
            btnConfirmarCarga.TabIndex = 2;
            btnConfirmarCarga.UseVisualStyleBackColor = true;
            btnConfirmarCarga.Click += btnConfirmarCarga_Click_1;
            // 
            // listpartidas
            // 
            listpartidas.BackColor = SystemColors.ControlDark;
            listpartidas.FormattingEnabled = true;
            listpartidas.Location = new Point(29, 91);
            listpartidas.Name = "listpartidas";
            listpartidas.Size = new Size(546, 444);
            listpartidas.TabIndex = 1;
            listpartidas.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // btnIdioma
            // 
            btnIdioma.Location = new Point(296, 426);
            btnIdioma.Name = "btnIdioma";
            btnIdioma.Size = new Size(202, 54);
            btnIdioma.TabIndex = 13;
            btnIdioma.UseVisualStyleBackColor = true;
            btnIdioma.Click += btnIdioma_Click;
            // 
            // panelnombre
            // 
            panelnombre.BackColor = Color.MediumBlue;
            panelnombre.BackgroundImageLayout = ImageLayout.Stretch;
            panelnombre.BorderStyle = BorderStyle.Fixed3D;
            panelnombre.Controls.Add(lblCrearPartida);
            panelnombre.Controls.Add(btnRegresarNombre);
            panelnombre.Controls.Add(txtNombreUsuario);
            panelnombre.Controls.Add(btnAceptarNombr);
            panelnombre.Location = new Point(85, 134);
            panelnombre.Name = "panelnombre";
            panelnombre.Size = new Size(638, 427);
            panelnombre.TabIndex = 16;
            panelnombre.Paint += panelnombre_Paint;
            // 
            // lblCrearPartida
            // 
            lblCrearPartida.AutoSize = true;
            lblCrearPartida.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCrearPartida.ForeColor = Color.Yellow;
            lblCrearPartida.ImageAlign = ContentAlignment.BottomCenter;
            lblCrearPartida.Location = new Point(3, 28);
            lblCrearPartida.Name = "lblCrearPartida";
            lblCrearPartida.Size = new Size(17, 28);
            lblCrearPartida.TabIndex = 4;
            lblCrearPartida.Text = ".";
            lblCrearPartida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRegresarNombre
            // 
            btnRegresarNombre.BackColor = Color.Transparent;
            btnRegresarNombre.FlatAppearance.BorderSize = 0;
            btnRegresarNombre.FlatStyle = FlatStyle.Popup;
            btnRegresarNombre.ForeColor = Color.Transparent;
            btnRegresarNombre.Location = new Point(73, 174);
            btnRegresarNombre.Name = "btnRegresarNombre";
            btnRegresarNombre.Size = new Size(171, 45);
            btnRegresarNombre.TabIndex = 3;
            btnRegresarNombre.UseVisualStyleBackColor = false;
            btnRegresarNombre.Click += btnRegresarNombre_Click;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(176, 103);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(282, 27);
            txtNombreUsuario.TabIndex = 2;
            txtNombreUsuario.TextChanged += txtNombreUsuario_TextChanged;
            // 
            // btnAceptarNombr
            // 
            btnAceptarNombr.BackColor = Color.Transparent;
            btnAceptarNombr.FlatAppearance.MouseDownBackColor = Color.LawnGreen;
            btnAceptarNombr.FlatAppearance.MouseOverBackColor = Color.Red;
            btnAceptarNombr.FlatStyle = FlatStyle.Flat;
            btnAceptarNombr.ForeColor = Color.Transparent;
            btnAceptarNombr.Location = new Point(367, 174);
            btnAceptarNombr.Name = "btnAceptarNombr";
            btnAceptarNombr.Size = new Size(165, 45);
            btnAceptarNombr.TabIndex = 1;
            btnAceptarNombr.Text = "ok";
            btnAceptarNombr.UseVisualStyleBackColor = false;
            btnAceptarNombr.Click += btnAceptarNombr_Click;
            // 
            // btnTutorial
            // 
            btnTutorial.Location = new Point(296, 351);
            btnTutorial.Name = "btnTutorial";
            btnTutorial.Size = new Size(202, 54);
            btnTutorial.TabIndex = 17;
            btnTutorial.Text = "Tutorial";
            btnTutorial.UseVisualStyleBackColor = true;
            btnTutorial.Click += btnTutorial_Click;
            // 
            // pnlTutorial
            // 
            pnlTutorial.BackColor = SystemColors.ControlText;
            pnlTutorial.BorderStyle = BorderStyle.FixedSingle;
            pnlTutorial.Controls.Add(btnCerrarTutorial);
            pnlTutorial.Controls.Add(lblTextoTutorial);
            pnlTutorial.Controls.Add(lblTituloTutorial);
            pnlTutorial.Location = new Point(160, 16);
            pnlTutorial.Name = "pnlTutorial";
            pnlTutorial.Size = new Size(500, 500);
            pnlTutorial.TabIndex = 18;
            pnlTutorial.Visible = false;
            // 
            // btnCerrarTutorial
            // 
            btnCerrarTutorial.BackColor = Color.DarkRed;
            btnCerrarTutorial.FlatStyle = FlatStyle.Flat;
            btnCerrarTutorial.ForeColor = Color.White;
            btnCerrarTutorial.Location = new Point(354, 443);
            btnCerrarTutorial.Name = "btnCerrarTutorial";
            btnCerrarTutorial.Size = new Size(115, 34);
            btnCerrarTutorial.TabIndex = 2;
            btnCerrarTutorial.Text = "cerrar";
            btnCerrarTutorial.UseVisualStyleBackColor = false;
            btnCerrarTutorial.Click += btnCerrarTutorial_Click;
            // 
            // lblTextoTutorial
            // 
            lblTextoTutorial.Font = new Font("Consolas", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTextoTutorial.ForeColor = Color.LightGray;
            lblTextoTutorial.Location = new Point(43, 45);
            lblTextoTutorial.Name = "lblTextoTutorial";
            lblTextoTutorial.Size = new Size(426, 377);
            lblTextoTutorial.TabIndex = 1;
            lblTextoTutorial.Text = "label1";
            // 
            // lblTituloTutorial
            // 
            lblTituloTutorial.AutoSize = true;
            lblTituloTutorial.Dock = DockStyle.Top;
            lblTituloTutorial.Font = new Font("Consolas", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloTutorial.ForeColor = SystemColors.ButtonHighlight;
            lblTituloTutorial.Location = new Point(0, 0);
            lblTituloTutorial.Name = "lblTituloTutorial";
            lblTituloTutorial.Size = new Size(90, 27);
            lblTituloTutorial.TabIndex = 0;
            lblTituloTutorial.Text = "label1";
            lblTituloTutorial.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UCPantallaMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(btnSalir);
            Controls.Add(btnIdioma);
            Controls.Add(btnCargarPartida);
            Controls.Add(btnTutorial);
            Controls.Add(BtnNuevaPartida);
            Controls.Add(pnlTutorial);
            Controls.Add(panelnombre);
            Controls.Add(panelcargar);
            DoubleBuffered = true;
            Name = "UCPantallaMenu";
            Size = new Size(800, 700);
            Load += UCPantallaMenu_Load;
            panelcargar.ResumeLayout(false);
            panelnombre.ResumeLayout(false);
            panelnombre.PerformLayout();
            pnlTutorial.ResumeLayout(false);
            pnlTutorial.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnNuevaPartida;
        private Button btnCargarPartida;
        private Button btnSalir;
        private Panel panelcargar;
        private ListBox listpartidas;
        private Button btnConfirmarCarga;
        private Button btnIdioma;
        private Button btnRegresarCargar;
        private Panel panelnombre;
        private Button btnRegresarNombre;
        private TextBox txtNombreUsuario;
        private Button btnAceptarNombr;
        private Label lbllistapartidas;
        private Label lblCrearPartida;
        private Button btnTutorial;
        private Panel pnlTutorial;
        private Label lblTextoTutorial;
        private Label lblTituloTutorial;
        private Button btnCerrarTutorial;
    }
}
