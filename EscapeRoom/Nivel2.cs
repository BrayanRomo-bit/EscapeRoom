using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    internal class Nivel2 : NivelBase
    {
        public Nivel2()
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

            Camara camara1 = new Camara(pbcamara1);
            Camara camara2 = new Camara(pbcamara2);
            listaCamaras.Add(camara1);
            listaCamaras.Add(camara2);

            Escondite escondite1 = new Escondite();
            escondite1.Nombre = "Cama";
            escondite1.Imagen = pb4;
            Escondites.Add(escondite1);

            Escondite escondites2 = new Escondite();
            escondites2.Nombre = "Escritorio";
            escondites2.Imagen = pb3;
            Escondites.Add(escondites2);

            Escondite escondite3 = new Escondite();
            escondite3.Nombre = "queso";
            escondite3.Imagen = pb5;
            Escondites.Add(escondite3);

            Random randomCamara = new Random();
            int codigo1 = randomCamara.Next(0, 10);
            int codigo2 = randomCamara.Next(0, 10);
            int codigo3 = randomCamara.Next(0, 10);
            string codigoCompleto = $"{codigo1}{codigo2}{codigo3}";
            this.MonitorNivel = new Monitor(pbMonitores, codigoCompleto);

            Objeto pistacam = new Objeto { Id = "pistacam", Descripcion = $"Archivo USB: el 1er numero de las camaras es {codigo1}" };
            Objeto pistacam2 = new Objeto { Id = "pistacam2", Descripcion = $"Archivo USB: el 2do numero de las camaras es {codigo2}" };
            Objeto pistacam3 = new Objeto { Id = "pistacam3", Descripcion = $"Archivo USB: el 3er numero de las camaras es {codigo3}" };

            List<Objeto> pistasCamaras = new List<Objeto> { pistacam, pistacam2, pistacam3 };

            foreach (var pista in pistasCamaras)
            {
                bool colocada = false;
                while (colocada == false)
                {
                    int indice = randomCamara.Next(0, Escondites.Count);
                    if (Escondites[indice].ObjetoOculto == null)
                    {
                        Escondites[indice].ObjetoOculto = pista;
                        colocada = true;
                    }
                }
            }
            /*
            Llave llavePrision = new Llave("llave2", "Llave Oxidada");
            Llave llave = new Llave("llave1", "Llave de la celda de Jhon");
            List<Objeto> llavesA_Esconder = new List<Objeto>();
            llavesA_Esconder.Add(llave);
            Random aleatorio= new Random();
            foreach (var llaves in llavesA_Esconder)
            {
                bool colocada = false;

                while (colocada == false)
                {
                    int indice = aleatorio.Next(0, Escondites.Count);

                    if (Escondites[indice].ObjetoOculto == null)
                    {
                        Escondites[indice].ObjetoOculto = llaves;

                        colocada = true;
                    }
                }
            }*/
            baseDeDialogos.Add(5, "Jhon: Escuché que le darán pena de muerte a Mario...");
            baseDeDialogos.Add(1, "Mario: Psst... busca una grieta.");
            baseDeDialogos.Add(2, "Guardia: ¡Vuelve a tu celda!");

            // 3. Definimos nuestro mapa


            CrearJugador(30, 120);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nivel2));
            pbMonitores = new PictureBox();
            pictureBox1 = new PictureBox();
            pb4 = new PictureBox();
            pbcamara2 = new PictureBox();
            pb3 = new PictureBox();
            pb5 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox5 = new PictureBox();
            pbBasura1 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox8 = new PictureBox();
            pbcamara1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbMonitores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcamara2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBasura1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcamara1).BeginInit();
            SuspendLayout();
            // 
            // pbMonitores
            // 
            pbMonitores.Image = (Image)resources.GetObject("pbMonitores.Image");
            pbMonitores.Location = new Point(566, 98);
            pbMonitores.Name = "pbMonitores";
            pbMonitores.Size = new Size(201, 80);
            pbMonitores.SizeMode = PictureBoxSizeMode.Zoom;
            pbMonitores.TabIndex = 0;
            pbMonitores.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(62, 165);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pb4
            // 
            pb4.Image = (Image)resources.GetObject("pb4.Image");
            pb4.Location = new Point(221, 470);
            pb4.Name = "pb4";
            pb4.Size = new Size(81, 62);
            pb4.SizeMode = PictureBoxSizeMode.Zoom;
            pb4.TabIndex = 2;
            pb4.TabStop = false;
            // 
            // pbcamara2
            // 
            pbcamara2.Image = (Image)resources.GetObject("pbcamara2.Image");
            pbcamara2.Location = new Point(566, 431);
            pbcamara2.Name = "pbcamara2";
            pbcamara2.Size = new Size(120, 40);
            pbcamara2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbcamara2.TabIndex = 3;
            pbcamara2.TabStop = false;
            // 
            // pb3
            // 
            pb3.Image = (Image)resources.GetObject("pb3.Image");
            pb3.Location = new Point(397, 470);
            pb3.Name = "pb3";
            pb3.Size = new Size(81, 62);
            pb3.SizeMode = PictureBoxSizeMode.Zoom;
            pb3.TabIndex = 5;
            pb3.TabStop = false;
            pb3.Click += pictureBox5_Click;
            // 
            // pb5
            // 
            pb5.Image = (Image)resources.GetObject("pb5.Image");
            pb5.Location = new Point(31, 496);
            pb5.Name = "pb5";
            pb5.Size = new Size(75, 62);
            pb5.SizeMode = PictureBoxSizeMode.Zoom;
            pb5.TabIndex = 6;
            pb5.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.salidaa;
            pictureBox3.Location = new Point(417, 283);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(61, 34);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.salidaa;
            pictureBox4.Location = new Point(241, 406);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(61, 32);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.salidaa;
            pictureBox2.Location = new Point(417, 406);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(61, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.salidaa;
            pictureBox5.Location = new Point(53, 406);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(68, 32);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 11;
            pictureBox5.TabStop = false;
            // 
            // pbBasura1
            // 
            pbBasura1.Image = (Image)resources.GetObject("pbBasura1.Image");
            pbBasura1.Location = new Point(311, 109);
            pbBasura1.Name = "pbBasura1";
            pbBasura1.Size = new Size(46, 48);
            pbBasura1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasura1.TabIndex = 12;
            pbBasura1.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(31, 109);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(123, 80);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 13;
            pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = Properties.Resources.salidaa;
            pictureBox8.Location = new Point(718, 529);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(61, 51);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 14;
            pictureBox8.TabStop = false;
            // 
            // pbcamara1
            // 
            pbcamara1.Image = (Image)resources.GetObject("pbcamara1.Image");
            pbcamara1.Location = new Point(386, 237);
            pbcamara1.Name = "pbcamara1";
            pbcamara1.Size = new Size(120, 40);
            pbcamara1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbcamara1.TabIndex = 15;
            pbcamara1.TabStop = false;
            // 
            // Nivel2
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(pbcamara1);
            Controls.Add(pictureBox8);
            Controls.Add(pictureBox7);
            Controls.Add(pbBasura1);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pb5);
            Controls.Add(pb3);
            Controls.Add(pbcamara2);
            Controls.Add(pb4);
            Controls.Add(pictureBox1);
            Controls.Add(pbMonitores);
            Name = "Nivel2";
            Size = new Size(800, 700);
            Load += Nivel2_Load_1;
            ((System.ComponentModel.ISupportInitialize)pbMonitores).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcamara2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBasura1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcamara1).EndInit();
            ResumeLayout(false);

        }


        private void Nivel2_Load_1(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private PictureBox pbMonitores;
        private PictureBox pictureBox1;
        private PictureBox pb4;
        private PictureBox pbcamara2;
        private PictureBox pb5;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox2;
        private PictureBox pictureBox5;
        private PictureBox pbBasura1;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pbcamara1;
        private PictureBox pb3;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
