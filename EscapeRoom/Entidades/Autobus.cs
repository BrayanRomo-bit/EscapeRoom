using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EscapeRoom.Entidades
{
    public class Autobus : NPC
    {
        public PictureBox Imagen { get; set; }
        public Autobus(int id, PictureBox pb) : base(id, pb.Image, pb.Location)
        {
            this.Imagen = pb;
            this.Bounds = pb.Bounds;
        }
    }
}
