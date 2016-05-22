using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAApplication.Domain.Services;

namespace IAApplication.Infra.IA.Services
{
    public class RedeNeuralService:IRedeNeuralService
    {
        public double CalcularDistanciaEuclidiana(Point pontoA, Point pontoB)
        {
            return Math.Sqrt(Math.Pow((pontoB.X - pontoA.X), 2) + Math.Pow((pontoB.Y + pontoA.Y), 2));
        }
    }
}
