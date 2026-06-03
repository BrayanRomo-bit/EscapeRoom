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

            /*
            Paredes.Add(pbPared);
            Paredes.Add(pbPared2);
            Paredes.Add(pbPared3);
            Paredes.Add(pbPared4);
            Paredes.Add(pbPared5);
            Paredes.Add(pbPared6);
            Paredes.Add(pbPared7);
            Paredes.Add(pbPared8);
            Paredes.Add(pbPared9);
            Paredes.Add(pbPared10);
            Paredes.Add(pbPared11);
            Paredes.Add(pbPared12);
            Paredes.Add(pbPared13);
            */
            CrearJugador(500, 150);
            NPC jhon = CrearNPC(600, 200, "Oye, toma esta llave para salir de aquí.");
            Llave llaveJhon = new Llave("llave", "Llave de la celda de Jhon");
            jhon.ObjetoaDar = llaveJhon;
            listaNPCs.Add(jhon);
            //CrearGuardia(90, 267);
            //CrearGuardia(690,330);
            Escondite cama = new Escondite();
            cama.Nombre = "la Cama";
            cama.Imagen = pbCama;
            Escondites.Add(cama);
            Escondite cama2 = new Escondite();
            cama2.Nombre = "la Cama";
            cama2.Imagen = pbCama2;
            Escondites.Add(cama2);
            Escondite cama3 = new Escondite();
            cama3.Nombre = "la Cama";
            cama3.Imagen = pbCama3;
            Escondites.Add(cama3);
            Escondite cama4 = new Escondite();
            cama4.Nombre = "la Cama";
            cama4.Imagen = pbCama4;
            Escondites.Add(cama4);

            Escondite cofre = new Escondite();
            cofre.Nombre = "el Cofre";
            cofre.Imagen = pbcofre;
            Cofres.Add(cofre);
            Escondite cofre2 = new Escondite();
            cofre2.Nombre = "el Cofre";
            cofre2.Imagen = pbcofre2;
            Cofres.Add(cofre2);
            Escondite cofre3 = new Escondite();
            cofre3.Nombre = "el Cofre";
            cofre3.Imagen = pbcofre3;
            Cofres.Add(cofre3);

            Puerta puerta1 = new Puerta("llave", " de la celda 1", pbpuerta1);
            listaPuertas.Add(puerta1);
            Puerta puerta2 = new Puerta("llave2", " de la celda 2", pbPuerta2);
            listaPuertas.Add(puerta2);
            Puerta puerta3 = new Puerta("llave3", " de la celda 3", pbpuerta3);
            listaPuertas.Add(puerta3);
            Puerta puerta4 = new Puerta("llave4", " de la celda 4", pbpuerta4);
            listaPuertas.Add(puerta4);

            Llave llavePrision2 = new Llave("llave2", "de la Celda 2");
            Llave llavePrision3 = new Llave("llave3", "de la Celda 3");
            Llave llavePrision4 = new Llave("llave4", "de la Celda 4");

            List<Llave> llavesA_Esconder = new List<Llave> { llavePrision2, llavePrision3, llavePrision4 };

            Random codigo = new Random();
            int digito1 = codigo.Next(0, 10);
            int digito2 = codigo.Next(0, 10);
            int digito3 = codigo.Next(0, 10);
            string codigoGenerado = $"{digito1}{digito2}{digito3}";

            Puerta salida = new Puerta("llave3", "Puerta de la celda", pbSalida);
            salida.RequiereCodigo = true;
            salida.Codigo = codigoGenerado;
            listaPuertas.Add(salida);

            Objeto pista1 = new Objeto { Id = "nota1", Descripcion = $"Nota arrugada: El 1er número es {digito1}" };
            Objeto pista2 = new Objeto { Id = "nota2", Descripcion = $"Nota arrugada: El 2do número es {digito2}" };
            Objeto pista3 = new Objeto { Id = "nota3", Descripcion = $"Nota arrugada: El 3er número es {digito3}" };

            List<Objeto> pistas = new List<Objeto> { pista1, pista2, pista3 };
            Random aleatorio = new Random();

            foreach (var pista in pistas)
            {
                bool colocada = false;
                while (colocada == false)
                {
                    int indice = aleatorio.Next(0, Cofres.Count);
                    if (Cofres[indice].ObjetoOculto == null)
                    {
                        Cofres[indice].ObjetoOculto = pista;
                        colocada = true;
                    }
                }
            }
            Random random = new Random();
            // 1. Mezclamos la lista de llaves de forma aleatoria en cada partida
            llavesA_Esconder = llavesA_Esconder.OrderBy(x => random.Next()).ToList();

            // 2. Creamos un mapa (Diccionario) para conectar el ID de la llave con la cama que está DENTRO de esa celda
            Dictionary<string, Escondite> mapaCamas = new Dictionary<string, Escondite>();
            mapaCamas.Add("llave2", cama2); // La llave2 abre la celda donde está la cama2
            mapaCamas.Add("llave3", cama3); // La llave3 abre la celda donde está la cama3
            mapaCamas.Add("llave4", cama4); // La llave4 abre la celda donde está la cama4

            // 3. ARMAMOS LA CADENA PERFECTA (Anti-Softlock):

            // Eslabón 1: La cama de la celda 1 siempre es accesible porque Jhon nos da esa llave. 
            // Aquí guardamos la primera llave misteriosa.
            cama.ObjetoOculto = llavesA_Esconder[0];

            // Eslabón 2: En la cama que acabamos de desbloquear, guardamos la segunda llave.
            mapaCamas[llavesA_Esconder[0].Id].ObjetoOculto = llavesA_Esconder[1];

            // Eslabón 3: En la siguiente cama desbloqueada, guardamos la última llave.
            mapaCamas[llavesA_Esconder[1].Id].ObjetoOculto = llavesA_Esconder[2];

            // Eslabón 4: La cama de la última celda se quedará vacía (o puedes ponerle polvo y telarañas).

            baseDeDialogos.Add(0, "Jhon: Escuché que le darán pena de muerte a Mario...");
            baseDeDialogos.Add(1, "Mario:No puede ser me daran pena de muerte,jamas escapare");
            baseDeDialogos.Add(2, "Guardia: ¡Vuelve a tu celda!");

            baseDeLLaves.Add(5, "Llave de la celda de Mario");
            baseDeLLaves.Add(6, "Llave de la celda de Jhon");
            baseDePuertas.Add(5, "Puerta de la celda de Mario");
            baseDePuertas.Add(6, "Puerta de la celda de Jhon");

        }

        private void Nivel1_Load(object sender, EventArgs e)
        {
        }

        private void paredinvisible_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
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