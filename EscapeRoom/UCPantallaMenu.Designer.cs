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
            btnRegresarNombre = new Button();
            txtNombreUsuario = new TextBox();
            btnAceptarNombr = new Button();
            panelcargar.SuspendLayout();
            panelnombre.SuspendLayout();
            SuspendLayout();
            // 
            // BtnNuevaPartida
            // 
            BtnNuevaPartida.Location = new Point(299, 212);
            BtnNuevaPartida.Name = "BtnNuevaPartida";
            BtnNuevaPartida.Size = new Size(202, 57);
            BtnNuevaPartida.TabIndex = 10;
            BtnNuevaPartida.Text = "Nueva Partida";
            BtnNuevaPartida.UseVisualStyleBackColor = true;
            BtnNuevaPartida.Click += BtnNuevaPartida_Click;
            // 
            // btnCargarPartida
            // 
            btnCargarPartida.Location = new Point(299, 313);
            btnCargarPartida.Name = "btnCargarPartida";
            btnCargarPartida.Size = new Size(202, 54);
            btnCargarPartida.TabIndex = 11;
            btnCargarPartida.Text = "Cargar Partida";
            btnCargarPartida.UseVisualStyleBackColor = true;
            btnCargarPartida.Click += btnCargarPartida_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(299, 513);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(202, 54);
            btnSalir.TabIndex = 12;
            btnSalir.Text = "Salir del Juego";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // panelcargar
            // 
            panelcargar.Controls.Add(listpartidas);
            panelcargar.Controls.Add(btnRegresarCargar);
            panelcargar.Controls.Add(btnConfirmarCarga);
            panelcargar.Location = new Point(52, 24);
            panelcargar.Name = "panelcargar";
            panelcargar.Size = new Size(735, 564);
            panelcargar.TabIndex = 13;
            panelcargar.Paint += panelcargar_Paint;
            // 
            // btnRegresarCargar
            // 
            btnRegresarCargar.Location = new Point(428, 228);
            btnRegresarCargar.Name = "btnRegresarCargar";
            btnRegresarCargar.Size = new Size(94, 29);
            btnRegresarCargar.TabIndex = 4;
            btnRegresarCargar.UseVisualStyleBackColor = true;
            btnRegresarCargar.Click += btnRegresarCargar_Click;
            // 
            // btnConfirmarCarga
            // 
            btnConfirmarCarga.Location = new Point(425, 105);
            btnConfirmarCarga.Name = "btnConfirmarCarga";
            btnConfirmarCarga.Size = new Size(116, 49);
            btnConfirmarCarga.TabIndex = 2;
            btnConfirmarCarga.Text = "button1";
            btnConfirmarCarga.UseVisualStyleBackColor = true;
            btnConfirmarCarga.Click += btnConfirmarCarga_Click_1;
            // 
            // listpartidas
            // 
            listpartidas.FormattingEnabled = true;
            listpartidas.Location = new Point(0, 52);
            listpartidas.Name = "listpartidas";
            listpartidas.Size = new Size(389, 444);
            listpartidas.TabIndex = 1;
            listpartidas.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // btnIdioma
            // 
            btnIdioma.Location = new Point(299, 419);
            btnIdioma.Name = "btnIdioma";
            btnIdioma.Size = new Size(202, 54);
            btnIdioma.TabIndex = 13;
            btnIdioma.UseVisualStyleBackColor = true;
            btnIdioma.Click += btnIdioma_Click;
            // 
            // panelnombre
            // 
            panelnombre.BackColor = SystemColors.Highlight;
            panelnombre.BackgroundImage = (Image)resources.GetObject("panelnombre.BackgroundImage");
            panelnombre.BackgroundImageLayout = ImageLayout.Stretch;
            panelnombre.BorderStyle = BorderStyle.Fixed3D;
            panelnombre.Controls.Add(btnRegresarNombre);
            panelnombre.Controls.Add(txtNombreUsuario);
            panelnombre.Controls.Add(btnAceptarNombr);
            panelnombre.Location = new Point(81, 137);
            panelnombre.Name = "panelnombre";
            panelnombre.Size = new Size(638, 427);
            panelnombre.TabIndex = 16;
            // 
            // btnRegresarNombre
            // 
            btnRegresarNombre.BackColor = Color.Transparent;
            btnRegresarNombre.FlatAppearance.BorderSize = 0;
            btnRegresarNombre.FlatStyle = FlatStyle.Flat;
            btnRegresarNombre.Location = new Point(94, 35);
            btnRegresarNombre.Name = "btnRegresarNombre";
            btnRegresarNombre.Size = new Size(171, 45);
            btnRegresarNombre.TabIndex = 3;
            btnRegresarNombre.UseVisualStyleBackColor = false;
            btnRegresarNombre.Click += btnRegresarNombre_Click;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(345, 354);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(199, 27);
            txtNombreUsuario.TabIndex = 2;
            // 
            // btnAceptarNombr
            // 
            btnAceptarNombr.BackColor = Color.Transparent;
            btnAceptarNombr.FlatAppearance.MouseDownBackColor = Color.LawnGreen;
            btnAceptarNombr.FlatAppearance.MouseOverBackColor = Color.Red;
            btnAceptarNombr.FlatStyle = FlatStyle.Flat;
            btnAceptarNombr.Location = new Point(125, 318);
            btnAceptarNombr.Name = "btnAceptarNombr";
            btnAceptarNombr.Size = new Size(122, 51);
            btnAceptarNombr.TabIndex = 1;
            btnAceptarNombr.Text = "ok";
            btnAceptarNombr.UseVisualStyleBackColor = false;
            btnAceptarNombr.Click += btnAceptarNombr_Click;
            // 
            // UCPantallaMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(BtnNuevaPartida);
            Controls.Add(btnCargarPartida);
            Controls.Add(btnIdioma);
            Controls.Add(btnSalir);
            Controls.Add(panelnombre);
            Controls.Add(panelcargar);
            DoubleBuffered = true;
            Name = "UCPantallaMenu";
            Size = new Size(800, 700);
            Load += UCPantallaMenu_Load;
            panelcargar.ResumeLayout(false);
            panelnombre.ResumeLayout(false);
            panelnombre.PerformLayout();
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
    }
}
