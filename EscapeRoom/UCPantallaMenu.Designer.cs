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
            BtnNuevaPartida = new Button();
            btnCargarPartida = new Button();
            btnSalir = new Button();
            panelcargar = new Panel();
            btnConfirmarCarga = new Button();
            listBox1 = new ListBox();
            partidascargadas = new ComboBox();
            panelnombre = new Panel();
            btnAceptarNombr = new Button();
            txtNombreUsuario = new TextBox();
            panelcargar.SuspendLayout();
            panelnombre.SuspendLayout();
            SuspendLayout();
            // 
            // BtnNuevaPartida
            // 
            BtnNuevaPartida.Location = new Point(299, 141);
            BtnNuevaPartida.Name = "BtnNuevaPartida";
            BtnNuevaPartida.Size = new Size(165, 39);
            BtnNuevaPartida.TabIndex = 10;
            BtnNuevaPartida.Text = "Nueva Partida";
            BtnNuevaPartida.UseVisualStyleBackColor = true;
            BtnNuevaPartida.Click += BtnNuevaPartida_Click;
            // 
            // btnCargarPartida
            // 
            btnCargarPartida.Location = new Point(299, 204);
            btnCargarPartida.Name = "btnCargarPartida";
            btnCargarPartida.Size = new Size(165, 36);
            btnCargarPartida.TabIndex = 11;
            btnCargarPartida.Text = "Cargar Partida";
            btnCargarPartida.UseVisualStyleBackColor = true;
            btnCargarPartida.Click += btnCargarPartida_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(299, 279);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(165, 42);
            btnSalir.TabIndex = 12;
            btnSalir.Text = "Salir del Juego";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // panelcargar
            // 
            panelcargar.Controls.Add(btnConfirmarCarga);
            panelcargar.Controls.Add(listBox1);
            panelcargar.Controls.Add(partidascargadas);
            panelcargar.Location = new Point(324, 35);
            panelcargar.Name = "panelcargar";
            panelcargar.Size = new Size(460, 343);
            panelcargar.TabIndex = 13;
            panelcargar.Paint += panelcargar_Paint;
            // 
            // btnConfirmarCarga
            // 
            btnConfirmarCarga.Location = new Point(95, 200);
            btnConfirmarCarga.Name = "btnConfirmarCarga";
            btnConfirmarCarga.Size = new Size(94, 29);
            btnConfirmarCarga.TabIndex = 2;
            btnConfirmarCarga.Text = "button1";
            btnConfirmarCarga.UseVisualStyleBackColor = true;
            btnConfirmarCarga.Click += btnConfirmarCarga_Click_1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(48, 79);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 84);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // partidascargadas
            // 
            partidascargadas.FormattingEnabled = true;
            partidascargadas.Location = new Point(47, 12);
            partidascargadas.Name = "partidascargadas";
            partidascargadas.Size = new Size(151, 28);
            partidascargadas.TabIndex = 0;
            // 
            // panelnombre
            // 
            panelnombre.BackColor = SystemColors.ButtonHighlight;
            panelnombre.Controls.Add(btnAceptarNombr);
            panelnombre.Controls.Add(txtNombreUsuario);
            panelnombre.Location = new Point(18, 148);
            panelnombre.Name = "panelnombre";
            panelnombre.Size = new Size(765, 305);
            panelnombre.TabIndex = 14;
            panelnombre.Paint += panelnombre_Paint;
            // 
            // btnAceptarNombr
            // 
            btnAceptarNombr.Location = new Point(498, 76);
            btnAceptarNombr.Name = "btnAceptarNombr";
            btnAceptarNombr.Size = new Size(94, 51);
            btnAceptarNombr.TabIndex = 1;
            btnAceptarNombr.Text = "ok";
            btnAceptarNombr.UseVisualStyleBackColor = true;
            btnAceptarNombr.Click += btnAceptarNombr_Click;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(330, 59);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(125, 27);
            txtNombreUsuario.TabIndex = 0;
            txtNombreUsuario.TextChanged += txtNombreUsuario_TextChanged;
            // 
            // UCPantallaMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(btnSalir);
            Controls.Add(btnCargarPartida);
            Controls.Add(BtnNuevaPartida);
            Controls.Add(panelnombre);
            Controls.Add(panelcargar);
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
        private ListBox listBox1;
        private ComboBox partidascargadas;
        private Panel panelnombre;
        private Button btnAceptarNombr;
        private TextBox txtNombreUsuario;
        private Button btnConfirmarCarga;
    }
}
