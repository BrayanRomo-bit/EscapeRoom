namespace EscapeRoom
{
    partial class Nivel3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nivel3));
            pbautobus = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbautobus).BeginInit();
            SuspendLayout();
            // 
            // pbautobus
            // 
            pbautobus.BackColor = Color.Transparent;
            pbautobus.Image = (Image)resources.GetObject("pbautobus.Image");
            pbautobus.Location = new Point(402, 380);
            pbautobus.Name = "pbautobus";
            pbautobus.Size = new Size(325, 147);
            pbautobus.SizeMode = PictureBoxSizeMode.StretchImage;
            pbautobus.TabIndex = 16;
            pbautobus.TabStop = false;
            // 
            // Nivel3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(pbautobus);
            Name = "Nivel3";
            Size = new Size(800, 700);
            Load += Nivel3_Load;
            ((System.ComponentModel.ISupportInitialize)pbautobus).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbautobus;
    }
}
