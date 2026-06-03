using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscapeRoom
{
    public partial class Nivel1 : NivelBase
    {
        public Nivel1()
        {
            InitializeComponent();
        }

        public override void IniciarNivel()
        {
            base.lblDialogo = this.lbltexto;
            
            paredesMatematicas.Add(new Rectangle(85, 135, 685, 20));
            paredesMatematicas.Add(new Rectangle(70, 150, 10, 425));
            paredesMatematicas.Add(new Rectangle(75, 590, 670, 20));
            paredesMatematicas.Add(new Rectangle(410, 460, 30, 125));
            paredesMatematicas.Add(new Rectangle(775, 460, 10, 125));
            paredesMatematicas.Add(new Rectangle(560, 431, 210, 29));
            paredesMatematicas.Add(new Rectangle(380, 431, 120, 29));
            paredesMatematicas.Add(new Rectangle(85, 431, 235, 29));
            paredesMatematicas.Add(new Rectangle(85, 283, 235, 29));
            paredesMatematicas.Add(new Rectangle(380, 283, 120, 29));
            paredesMatematicas.Add(new Rectangle(560, 283, 210, 29));
            paredesMatematicas.Add(new Rectangle(410, 153, 35, 135));
            paredesMatematicas.Add(new Rectangle(764, 153, 10, 127));
            
            CrearJugador(500, 180);

            NPC jhon = CrearNPC(451, 164);
            jhon.DialogosPorPasos.Add(Traductor.Obtener("niveles.Nivel1.npcs.jhon.dialogos_0"));
            jhon.DialogosPorPasos.Add(Traductor.Obtener("niveles.Nivel1.npcs.jhon.dialogos_1"));
            jhon.DialogosPorPasos.Add(Traductor.Obtener("niveles.Nivel1.npcs.jhon.dialogos_2"));
            jhon.DialogosPorPasos.Add(Traductor.Obtener("niveles.Nivel1.npcs.jhon.dialogos_3"));

            Llave llaveJhon = new Llave("llave", Traductor.Obtener("niveles.Nivel1.llaves.llave.descripcion"));
            jhon.ObjetoaDar = llaveJhon;
            listaNPCs.Add(jhon);

            CrearGuardia(680, 380);

            Llave llave2 = new Llave("llave2", Traductor.Obtener("niveles.Nivel1.llaves.llave2.descripcion"));
            Llave llave3 = new Llave("llave3", Traductor.Obtener("niveles.Nivel1.llaves.llave3.descripcion"));
            Llave llave4 = new Llave("llave4", Traductor.Obtener("niveles.Nivel1.llaves.llave4.descripcion"));

            List<Llave> llavesRestantes = new List<Llave> { llave2, llave3, llave4 };
            List<PictureBox> imagenesCamasRestantes = new List<PictureBox> { pbCama2, pbCama3, pbCama4 };

            Random rndCamas = new Random();
            List<int> secuencia = new List<int> { 0, 1, 2 };
            secuencia = secuencia.OrderBy(x => rndCamas.Next()).ToList();

            string nombreCama = Traductor.Obtener("niveles.Nivel1.escondites.cama");
            string nombreCofre = Traductor.Obtener("niveles.Nivel1.escondites.cofre");

            Escondite cama = new Escondite() { Nombre = nombreCama, Imagen = pbCama, ObjetoOculto = llavesRestantes[secuencia[0]] };
            Escondites.Add(cama);

            Escondite camaPaso1 = new Escondite() { Nombre = nombreCama, Imagen = imagenesCamasRestantes[secuencia[0]], ObjetoOculto = llavesRestantes[secuencia[1]] };
            Escondites.Add(camaPaso1);

            Escondite camaPaso2 = new Escondite() { Nombre = nombreCama, Imagen = imagenesCamasRestantes[secuencia[1]], ObjetoOculto = llavesRestantes[secuencia[2]] };
            Escondites.Add(camaPaso2);

            Escondite camaFinal = new Escondite() { Nombre = nombreCama, Imagen = imagenesCamasRestantes[secuencia[2]], ObjetoOculto = null };
            Escondites.Add(camaFinal);

            Escondite cofre = new Escondite() { Nombre = nombreCofre, Imagen = pbcofre };
            EsconditeCod.Add(cofre);

            Escondite cofre2 = new Escondite() { Nombre = nombreCofre, Imagen = pbcofre2 };
            EsconditeCod.Add(cofre2);

            Escondite cofre3 = new Escondite() { Nombre = nombreCofre, Imagen = pbcofre3 };
            EsconditeCod.Add(cofre3);

            Puerta puerta1 = new Puerta("llave", Traductor.Obtener("niveles.Nivel1.puertas.puerta1.descripcion"), pbpuerta1);
            listaPuertas.Add(puerta1);

            Puerta puerta2 = new Puerta("llave2", Traductor.Obtener("niveles.Nivel1.puertas.puerta2.descripcion"), pbPuerta2);
            listaPuertas.Add(puerta2);

            Puerta puerta3 = new Puerta("llave3", Traductor.Obtener("niveles.Nivel1.puertas.puerta3.descripcion"), pbpuerta3);
            listaPuertas.Add(puerta3);

            Puerta puerta4 = new Puerta("llave4", Traductor.Obtener("niveles.Nivel1.puertas.puerta4.descripcion"), pbpuerta4);
            listaPuertas.Add(puerta4);

            Random codigo = new Random();
            int digito1 = codigo.Next(0, 10);
            int digito2 = codigo.Next(0, 10);
            int digito3 = codigo.Next(0, 10);
            string codigoGenerado = $"{digito1}{digito2}{digito3}";

            Puerta salida = new Puerta("llave3", Traductor.Obtener("niveles.Nivel1.puertas.salida.descripcion"), pbSalida);
            salida.RequiereCodigo = true;
            salida.Codigo = codigoGenerado;
            salida.EsSalidaFinal = true;
            listaPuertas.Add(salida);

            Objeto pista1 = new Objeto { Id = "nota1", Descripcion = Traductor.Obtener("niveles.Nivel1.pistas_codigo.nota1", digito1) };
            Objeto pista2 = new Objeto { Id = "nota2", Descripcion = Traductor.Obtener("niveles.Nivel1.pistas_codigo.nota2", digito2) };
            Objeto pista3 = new Objeto { Id = "nota3", Descripcion = Traductor.Obtener("niveles.Nivel1.pistas_codigo.nota3", digito3) };

            List<Objeto> pistas = new List<Objeto> { pista1, pista2, pista3 };

            Random aleatorio = new Random();
            pistas = pistas.OrderBy(x => aleatorio.Next()).ToList();

            EsconditeCod[0].ObjetoOculto = pistas[0];
            EsconditeCod[1].ObjetoOculto = pistas[1];
            EsconditeCod[2].ObjetoOculto = pistas[2];
        }

        private void Nivel1_Load(object sender, EventArgs e)
        {
        }

        private void pbCama_Click(object sender, EventArgs e)
        {
        }

        private void lbltexto_Click(object sender, EventArgs e)
        {
        }

        private void pbPuerta2_Click(object sender, EventArgs e)
        {
        }
    }
}