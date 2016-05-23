using System.Collections.Generic;
using System.Drawing;

namespace IAApplication.Domain.Entities
{
    public class Centroide
    {
        public double X { get; set; }
        public double Y { get; set; }
        public List<Objetos> Objects { get; set; }

        public Centroide(double x, double y)
        {
            this.X = x;
            this.Y = y;
            this.Objects = new List<Objetos>();
        }
    }
}