using System;
using System.Drawing;

namespace IAApplication.Helpers
{
    public static class CommonHelper
    {
        public static double CalcularDistanciaEuclidiana(double x1,double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 + y1), 2));
        }

        public static double CalcularDistanciaEuclidiana(double x, double w)
        {
            return Math.Sqrt(x - w);
        }
    }
}