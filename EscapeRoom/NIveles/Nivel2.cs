using EscapeRoom.Objetos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscapeRoom.NIveles
{
    public partial class Nivel2 : NivelBase
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

            paredesMatematicas.Add(new Rectangle(297, 283, 120, 30));
            paredesMatematicas.Add(new Rectangle(20, 85, 753, 25));
            paredesMatematicas.Add(new Rectangle(773, 110, 12, 475));
            paredesMatematicas.Add(new Rectangle(20, 585, 753, 10));
            paredesMatematicas.Add(new Rectangle(5, 431, 15, 154));
            paredesMatematicas.Add(new Rectangle(20, 406, 33, 25));
            paredesMatematicas.Add(new Rectangle(114, 406, 116, 25));
            paredesMatematicas.Add(new Rectangle(297, 406, 120, 25));
            paredesMatematicas.Add(new Rectangle(473, 406, 152, 25));
            paredesMatematicas.Add(new Rectangle(180, 431, 25, 154));
            paredesMatematicas.Add(new Rectangle(360, 431, 26, 154));
            paredesMatematicas.Add(new Rectangle(537, 431, 29, 154));
            paredesMatematicas.Add(new Rectangle(692, 406, 82, 25));
            paredesMatematicas.Add(new Rectangle(692, 283, 82, 32));
            paredesMatematicas.Add(new Rectangle(473, 283, 152, 32));
            paredesMatematicas.Add(new Rectangle(118, 283, 165, 32));
            paredesMatematicas.Add(new Rectangle(31, 283, 22, 32));
            paredesMatematicas.Add(new Rectangle(15, 98, 16, 185));
            paredesMatematicas.Add(new Rectangle(356, 98, 30, 185));
            paredesMatematicas.Add(new Rectangle(536, 98, 30, 185));

            Camara camara1 = new Camara(pbcamara1);
            Camara camara2 = new Camara(pbcamara2);
            listaCamaras.Add(camara1);
            listaCamaras.Add(camara2);

            string horaCamion = DateTime.Now.AddMinutes(12).ToString("HH:mm");

            Nota nota = new Nota("nota_basura", "Horario", Traductor.Obtener("niveles.Nivel2.notas.nota_basura.descripcion", horaCamion));

            Escondite botebasura2 = new Escondite();
            botebasura2.Nombre = Traductor.Obtener("niveles.Nivel2.escondites.bote_basura");
            botebasura2.Imagen = pbBasura2;
            botebasura2.ObjetoOculto = nota;
            Escondites.Add(botebasura2);
            Llave llave4 = new Llave("llave4", Traductor.Obtener("niveles.Nivel2.llaves.llave4.descripcion"));

            Llave llaveSalida = new Llave("llaveSalida", Traductor.Obtener("niveles.Nivel2.llaves.llaveSalida.descripcion"));

            Escondite boteBasura = new Escondite();
            boteBasura.Nombre = Traductor.Obtener("niveles.Nivel2.escondites.bote_basura");
            boteBasura.Imagen = pbBasura1;
            boteBasura.ObjetoOculto = llave4;
            Escondites.Add(boteBasura);

            Escondite cofresalida = new Escondite();
            cofresalida.Nombre = Traductor.Obtener("niveles.Nivel2.escondites.cofre_salida");
            cofresalida.Imagen = pbcofre4;
            cofresalida.ObjetoOculto = llaveSalida;
            Escondites.Add(cofresalida);

            Llave llave1 = new Llave("llave1", Traductor.Obtener("niveles.Nivel2.llaves.llave1.descripcion"));
            Llave llave2 = new Llave("llave2", Traductor.Obtener("niveles.Nivel2.llaves.llave2.descripcion"));
            Llave llave3 = new Llave("llave3", Traductor.Obtener("niveles.Nivel2.llaves.llave3.descripcion"));

            Escondite escritorio = new Escondite();
            escritorio.Nombre = Traductor.Obtener("niveles.Nivel2.escondites.escritorio");
            escritorio.Imagen = pbescritorio;
            Escondites.Add(escritorio);

            string nombreCama = Traductor.Obtener("niveles.Nivel2.escondites.cama");
            string nombreCofre = Traductor.Obtener("niveles.Nivel2.escondites.cofre");

            Escondite cama1 = new Escondite();
            cama1.Nombre = nombreCama;
            cama1.Imagen = pbcama1;
            Escondites.Add(cama1);

            Escondite cama2 = new Escondite();
            cama2.Nombre = nombreCama;
            cama2.Imagen = pbCama2;
            Escondites.Add(cama2);

            Random rnd = new Random();
            int ruta = rnd.Next(1, 3);

            if (ruta == 1)
            {
                llave1.Descripcion += "\n\n" + Traductor.Obtener("niveles.Nivel2.dialogo_planos");
                escritorio.ObjetoOculto = llave1;
                cama1.ObjetoOculto = llave2;
                cama2.ObjetoOculto = llave3;
            }
            else
            {
                llave2.Descripcion += "\n\n" + Traductor.Obtener("niveles.Nivel2.dialogo_planos");
                escritorio.ObjetoOculto = llave2;
                cama2.ObjetoOculto = llave1;
                cama1.ObjetoOculto = llave3;
            }

            Escondite escondite1 = new Escondite() { Nombre = nombreCofre, Imagen = pbcofre1 };
            Escondites.Add(escondite1);

            Escondite escondites2 = new Escondite() { Nombre = nombreCofre, Imagen = pbcofre2 };
            Escondites.Add(escondites2);

            Escondite escondite3 = new Escondite() { Nombre = nombreCofre, Imagen = pbcofre3 };
            Escondites.Add(escondite3);

            Puerta puerta1 = new Puerta("llave1", Traductor.Obtener("niveles.Nivel2.puertas.puerta1.descripcion"), pbpuerta1);
            listaPuertas.Add(puerta1);

            Puerta puerta2 = new Puerta("llave2", Traductor.Obtener("niveles.Nivel2.puertas.puerta2.descripcion"), pbpuerta2);
            listaPuertas.Add(puerta2);

            Puerta puerta3 = new Puerta("llave3", Traductor.Obtener("niveles.Nivel2.puertas.puerta3.descripcion"), pbpuerta3);
            listaPuertas.Add(puerta3);

            Puerta puerta4 = new Puerta("llave4", Traductor.Obtener("niveles.Nivel2.puertas.puerta4.descripcion"), pbpuerta4);
            listaPuertas.Add(puerta4);

            Puerta salida = new Puerta("llaveSalida", Traductor.Obtener("niveles.Nivel2.puertas.salida.descripcion"), pbsalida);
            salida.EsSalidaFinal = true;
            listaPuertas.Add(salida);

            Random randomCamara = new Random();
            int codigo1 = randomCamara.Next(0, 10);
            int codigo2 = randomCamara.Next(0, 10);
            int codigo3 = randomCamara.Next(0, 10);
            string codigoCompleto = $"{codigo1}{codigo2}{codigo3}";
            this.MonitorNivel = new MonitorSeguridad(pbMonitores, codigoCompleto);

            Objeto pistacam = new Objeto { Id = "pistacam", Descripcion = Traductor.Obtener("niveles.Nivel2.pistas_camaras.pistacam", codigo1.ToString()), IconoInventario = Properties.Resources.USB };
            Objeto pistacam2 = new Objeto { Id = "pistacam2", Descripcion = Traductor.Obtener("niveles.Nivel2.pistas_camaras.pistacam2", codigo2.ToString()), IconoInventario = Properties.Resources.USB };
            Objeto pistacam3 = new Objeto { Id = "pistacam3", Descripcion = Traductor.Obtener("niveles.Nivel2.pistas_camaras.pistacam3", codigo3.ToString()), IconoInventario = Properties.Resources.USB };

            List<Objeto> pistasCamaras = new List<Objeto> { pistacam, pistacam2, pistacam3 };

            List<Escondite> esconditesVacios = new List<Escondite>();
           
            foreach (Escondite esc in Escondites)
            {
                if (esc.ObjetoOculto == null)
                {
                    esconditesVacios.Add(esc);
                }
            }

            foreach (Objeto pista in pistasCamaras)
            {
                int indiceRandom = randomCamara.Next(esconditesVacios.Count);

                esconditesVacios[indiceRandom].ObjetoOculto = pista;

                esconditesVacios.RemoveAt(indiceRandom);
            }

            CrearJugador(30, 340);
            CrearGuardia(721, 340);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nivel2));
            pbMonitores = new PictureBox();
            pictureBox1 = new PictureBox();
            pbcofre1 = new PictureBox();
            pbcamara2 = new PictureBox();
            pbcofre3 = new PictureBox();
            pbcofre2 = new PictureBox();
            pbpuerta4 = new PictureBox();
            pbpuerta2 = new PictureBox();
            pbpuerta3 = new PictureBox();
            pbpuerta1 = new PictureBox();
            pbBasura1 = new PictureBox();
            pbescritorio = new PictureBox();
            pbcamara1 = new PictureBox();
            pbCama2 = new PictureBox();
            pbcama1 = new PictureBox();
            pbcofre4 = new PictureBox();
            pbsalida = new PictureBox();
            pbBasura2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbMonitores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcamara2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBasura1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbescritorio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcamara1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCama2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcama1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbsalida).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBasura2).BeginInit();
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
            // pbcofre1
            // 
            pbcofre1.Image = (Image)resources.GetObject("pbcofre1.Image");
            pbcofre1.Location = new Point(120, 431);
            pbcofre1.Name = "pbcofre1";
            pbcofre1.Size = new Size(60, 40);
            pbcofre1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbcofre1.TabIndex = 2;
            pbcofre1.TabStop = false;
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
            // pbcofre3
            // 
            pbcofre3.Image = (Image)resources.GetObject("pbcofre3.Image");
            pbcofre3.Location = new Point(484, 431);
            pbcofre3.Name = "pbcofre3";
            pbcofre3.Size = new Size(62, 40);
            pbcofre3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbcofre3.TabIndex = 5;
            pbcofre3.TabStop = false;
            pbcofre3.Click += pictureBox5_Click;
            // 
            // pbcofre2
            // 
            pbcofre2.Image = (Image)resources.GetObject("pbcofre2.Image");
            pbcofre2.Location = new Point(308, 431);
            pbcofre2.Name = "pbcofre2";
            pbcofre2.Size = new Size(51, 40);
            pbcofre2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbcofre2.TabIndex = 6;
            pbcofre2.TabStop = false;
            // 
            // pbpuerta4
            // 
            pbpuerta4.Image = Properties.Resources.salidaa;
            pbpuerta4.Location = new Point(417, 283);
            pbpuerta4.Name = "pbpuerta4";
            pbpuerta4.Size = new Size(61, 34);
            pbpuerta4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbpuerta4.TabIndex = 8;
            pbpuerta4.TabStop = false;
            // 
            // pbpuerta2
            // 
            pbpuerta2.Image = Properties.Resources.salidaa;
            pbpuerta2.Location = new Point(241, 406);
            pbpuerta2.Name = "pbpuerta2";
            pbpuerta2.Size = new Size(61, 32);
            pbpuerta2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbpuerta2.TabIndex = 9;
            pbpuerta2.TabStop = false;
            // 
            // pbpuerta3
            // 
            pbpuerta3.Image = Properties.Resources.salidaa;
            pbpuerta3.Location = new Point(417, 406);
            pbpuerta3.Name = "pbpuerta3";
            pbpuerta3.Size = new Size(61, 32);
            pbpuerta3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbpuerta3.TabIndex = 10;
            pbpuerta3.TabStop = false;
            // 
            // pbpuerta1
            // 
            pbpuerta1.Image = Properties.Resources.salidaa;
            pbpuerta1.Location = new Point(53, 406);
            pbpuerta1.Name = "pbpuerta1";
            pbpuerta1.Size = new Size(68, 32);
            pbpuerta1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbpuerta1.TabIndex = 11;
            pbpuerta1.TabStop = false;
            // 
            // pbBasura1
            // 
            pbBasura1.Image = (Image)resources.GetObject("pbBasura1.Image");
            pbBasura1.Location = new Point(732, 237);
            pbBasura1.Name = "pbBasura1";
            pbBasura1.Size = new Size(46, 48);
            pbBasura1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasura1.TabIndex = 12;
            pbBasura1.TabStop = false;
            // 
            // pbescritorio
            // 
            pbescritorio.Image = (Image)resources.GetObject("pbescritorio.Image");
            pbescritorio.Location = new Point(31, 115);
            pbescritorio.Name = "pbescritorio";
            pbescritorio.Size = new Size(123, 80);
            pbescritorio.SizeMode = PictureBoxSizeMode.StretchImage;
            pbescritorio.TabIndex = 21;
            pbescritorio.TabStop = false;
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
            // pbCama2
            // 
            pbCama2.Image = (Image)resources.GetObject("pbCama2.Image");
            pbCama2.Location = new Point(299, 509);
            pbCama2.Name = "pbCama2";
            pbCama2.Size = new Size(60, 71);
            pbCama2.SizeMode = PictureBoxSizeMode.Zoom;
            pbCama2.TabIndex = 16;
            pbCama2.TabStop = false;
            // 
            // pbcama1
            // 
            pbcama1.Image = (Image)resources.GetObject("pbcama1.Image");
            pbcama1.Location = new Point(120, 509);
            pbcama1.Name = "pbcama1";
            pbcama1.Size = new Size(60, 71);
            pbcama1.SizeMode = PictureBoxSizeMode.Zoom;
            pbcama1.TabIndex = 17;
            pbcama1.TabStop = false;
            // 
            // pbcofre4
            // 
            pbcofre4.Image = (Image)resources.GetObject("pbcofre4.Image");
            pbcofre4.Location = new Point(470, 115);
            pbcofre4.Name = "pbcofre4";
            pbcofre4.Size = new Size(62, 40);
            pbcofre4.SizeMode = PictureBoxSizeMode.StretchImage;
            pbcofre4.TabIndex = 19;
            pbcofre4.TabStop = false;
            // 
            // pbsalida
            // 
            pbsalida.Image = Properties.Resources.salidaa;
            pbsalida.Location = new Point(717, 523);
            pbsalida.Name = "pbsalida";
            pbsalida.Size = new Size(61, 57);
            pbsalida.SizeMode = PictureBoxSizeMode.StretchImage;
            pbsalida.TabIndex = 22;
            pbsalida.TabStop = false;
            // 
            // pbBasura2
            // 
            pbBasura2.Image = (Image)resources.GetObject("pbBasura2.Image");
            pbBasura2.Location = new Point(308, 229);
            pbBasura2.Name = "pbBasura2";
            pbBasura2.Size = new Size(46, 48);
            pbBasura2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasura2.TabIndex = 23;
            pbBasura2.TabStop = false;
            // 
            // Nivel2
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(pbBasura2);
            Controls.Add(pbsalida);
            Controls.Add(pbcofre4);
            Controls.Add(pbcama1);
            Controls.Add(pbCama2);
            Controls.Add(pbcamara1);
            Controls.Add(pbescritorio);
            Controls.Add(pbBasura1);
            Controls.Add(pbpuerta1);
            Controls.Add(pbpuerta3);
            Controls.Add(pbpuerta2);
            Controls.Add(pbpuerta4);
            Controls.Add(pbcofre2);
            Controls.Add(pbcofre3);
            Controls.Add(pbcamara2);
            Controls.Add(pbcofre1);
            Controls.Add(pictureBox1);
            Controls.Add(pbMonitores);
            Name = "Nivel2";
            Size = new Size(800, 700);
            Load += Nivel2_Load_1;
            ((System.ComponentModel.ISupportInitialize)pbMonitores).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcamara2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbpuerta1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBasura1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbescritorio).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcamara1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCama2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcama1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbcofre4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbsalida).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBasura2).EndInit();
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
        private PictureBox pbcofre1;
        private PictureBox pbcamara2;
        private PictureBox pbcofre2;
        private PictureBox pbpuerta4;
        private PictureBox pbpuerta2;
        private PictureBox pbpuerta3;
        private PictureBox pbpuerta1;
        private PictureBox pbBasura1;
        private PictureBox pbescritorio;
        private PictureBox pbcamara1;
        private PictureBox pbCama2;
        private PictureBox pbcama1;
        private PictureBox pbcofre4;
        private PictureBox pbsalida;
        private PictureBox pbBasura2;
        private PictureBox pbcofre3;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}