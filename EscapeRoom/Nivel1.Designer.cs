namespace EscapeRoom
{
    partial class Nivel1
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nivel1));
            pbCama = new PictureBox();
            pbCama4 = new PictureBox();
            pbCama2 = new PictureBox();
            pbCama3 = new PictureBox();
            pbSalida = new PictureBox();
            lblDialogo = new Label();
            lbltexto = new Label();
            pbPuerta2 = new PictureBox();
            pbpuerta1 = new PictureBox();
            pbcofre = new PictureBox();
            pbcofre2 = new PictureBox();
            pbcofre3 = new PictureBox();
            pbpuerta3 = new PictureBox();
            pbpuerta4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbCama).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCama4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCama2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCama3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSalida).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPuerta2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta4).BeginInit();
            SuspendLayout();
            // 
            // pbCama
            // 
            pbCama.Image = (Image)resources.GetObject("pbCama.Image");
            pbCama.Location = new Point(704, 153);
            pbCama.Name = "pbCama";
            pbCama.Size = new Size(60, 71);
            pbCama.SizeMode = PictureBoxSizeMode.Zoom;
            pbCama.TabIndex = 5;
            pbCama.TabStop = false;
            pbCama.Click += pbCama_Click;
            // 
            // pbCama4
            // 
            pbCama4.Image = (Image)resources.GetObject("pbCama4.Image");
            pbCama4.Location = new Point(718, 456);
            pbCama4.Name = "pbCama4";
            pbCama4.Size = new Size(60, 71);
            pbCama4.SizeMode = PictureBoxSizeMode.Zoom;
            pbCama4.TabIndex = 14;
            pbCama4.TabStop = false;
            // 
            // pbCama2
            // 
            pbCama2.Image = (Image)resources.GetObject("pbCama2.Image");
            pbCama2.Location = new Point(87, 153);
            pbCama2.Name = "pbCama2";
            pbCama2.Size = new Size(60, 71);
            pbCama2.SizeMode = PictureBoxSizeMode.Zoom;
            pbCama2.TabIndex = 15;
            pbCama2.TabStop = false;
            // 
            // pbCama3
            // 
            pbCama3.Image = (Image)resources.GetObject("pbCama3.Image");
            pbCama3.Location = new Point(87, 468);
            pbCama3.Name = "pbCama3";
            pbCama3.Size = new Size(60, 71);
            pbCama3.SizeMode = PictureBoxSizeMode.Zoom;
            pbCama3.TabIndex = 16;
            pbCama3.TabStop = false;
            // 
            // pbSalida
            // 
            pbSalida.Image = Properties.Resources.salidaa;
            pbSalida.Location = new Point(747, 312);
            pbSalida.Name = "pbSalida";
            pbSalida.Size = new Size(53, 113);
            pbSalida.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSalida.TabIndex = 18;
            pbSalida.TabStop = false;
            // 
            // lblDialogo
            // 
            lblDialogo.AutoSize = true;
            lblDialogo.BackColor = Color.Black;
            lblDialogo.Dock = DockStyle.Bottom;
            lblDialogo.Font = new Font("Consolas", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDialogo.Location = new Point(0, 579);
            lblDialogo.Name = "lblDialogo";
            lblDialogo.Size = new Size(0, 27);
            lblDialogo.TabIndex = 19;
            lblDialogo.TextAlign = ContentAlignment.MiddleCenter;
            lblDialogo.Visible = false;
            // 
            // lbltexto
            // 
            lbltexto.BackColor = Color.Black;
            lbltexto.Dock = DockStyle.Bottom;
            lbltexto.Font = new Font("Consolas", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbltexto.Location = new Point(0, 606);
            lbltexto.Name = "lbltexto";
            lbltexto.Padding = new Padding(15, 0, 15, 0);
            lbltexto.Size = new Size(800, 94);
            lbltexto.TabIndex = 20;
            lbltexto.TextAlign = ContentAlignment.MiddleLeft;
            lbltexto.Visible = false;
            lbltexto.Click += lbltexto_Click;
            // 
            // pbPuerta2
            // 
            pbPuerta2.Image = Properties.Resources.salidaa;
            pbPuerta2.Location = new Point(320, 279);
            pbPuerta2.Name = "pbPuerta2";
            pbPuerta2.Size = new Size(62, 38);
            pbPuerta2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPuerta2.TabIndex = 17;
            pbPuerta2.TabStop = false;
            pbPuerta2.Click += pbPuerta2_Click;
            // 
            // pbpuerta1
            // 
            pbpuerta1.Image = Properties.Resources.salidaa;
            pbpuerta1.Location = new Point(500, 280);
            pbpuerta1.Name = "pbpuerta1";
            pbpuerta1.Size = new Size(62, 37);
            pbpuerta1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbpuerta1.TabIndex = 21;
            pbpuerta1.TabStop = false;
            // 
            // pbcofre
            // 
            pbcofre.Image = (Image)resources.GetObject("pbcofre.Image");
            pbcofre.Location = new Point(336, 153);
            pbcofre.Name = "pbcofre";
            pbcofre.Size = new Size(75, 50);
            pbcofre.SizeMode = PictureBoxSizeMode.Zoom;
            pbcofre.TabIndex = 22;
            pbcofre.TabStop = false;
            // 
            // pbcofre2
            // 
            pbcofre2.Image = (Image)resources.GetObject("pbcofre2.Image");
            pbcofre2.Location = new Point(242, 456);
            pbcofre2.Name = "pbcofre2";
            pbcofre2.Size = new Size(75, 50);
            pbcofre2.SizeMode = PictureBoxSizeMode.Zoom;
            pbcofre2.TabIndex = 23;
            pbcofre2.TabStop = false;
            // 
            // pbcofre3
            // 
            pbcofre3.Image = (Image)resources.GetObject("pbcofre3.Image");
            pbcofre3.Location = new Point(568, 456);
            pbcofre3.Name = "pbcofre3";
            pbcofre3.Size = new Size(75, 50);
            pbcofre3.SizeMode = PictureBoxSizeMode.Zoom;
            pbcofre3.TabIndex = 24;
            pbcofre3.TabStop = false;
            // 
            // pbpuerta3
            // 
            pbpuerta3.Image = Properties.Resources.salidaa;
            pbpuerta3.Location = new Point(323, 431);
            pbpuerta3.Name = "pbpuerta3";
            pbpuerta3.Size = new Size(59, 38);
            pbpuerta3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbpuerta3.TabIndex = 25;
            pbpuerta3.TabStop = false;
            // 
            // pbpuerta4
            // 
            pbpuerta4.Image = Properties.Resources.salidaa;
            pbpuerta4.Location = new Point(503, 431);
            pbpuerta4.Name = "pbpuerta4";
            pbpuerta4.Size = new Size(59, 35);
            pbpuerta4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbpuerta4.TabIndex = 26;
            pbpuerta4.TabStop = false;
            // 
            // Nivel1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(pbpuerta4);
            Controls.Add(pbpuerta3);
            Controls.Add(pbcofre3);
            Controls.Add(pbcofre2);
            Controls.Add(pbcofre);
            Controls.Add(pbpuerta1);
            Controls.Add(lblDialogo);
            Controls.Add(pbSalida);
            Controls.Add(pbPuerta2);
            Controls.Add(pbCama3);
            Controls.Add(pbCama2);
            Controls.Add(pbCama4);
            Controls.Add(pbCama);
            Controls.Add(lbltexto);
            ForeColor = SystemColors.ControlLightLight;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Nivel1";
            Size = new Size(800, 700);
            Load += Nivel1_Load;
            ((System.ComponentModel.ISupportInitialize)pbCama).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCama4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCama2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCama3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSalida).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPuerta2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pbCama;
        private PictureBox pbCama4;
        private PictureBox pbCama2;
        private PictureBox pbCama3;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pbSalida;
        private Label lblDialogo;
        private Label lbltexto;
        private PictureBox pbPuerta2;
        private PictureBox pbpuerta1;
        private PictureBox pbcofre;
        private PictureBox pbcofre2;
        private PictureBox pbcofre3;
        private PictureBox pbpuerta3;
        private PictureBox pbpuerta4;
    }
}
