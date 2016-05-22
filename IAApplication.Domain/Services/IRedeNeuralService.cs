using System.Drawing;
namespace IAApplication.Domain.Services
{
    public interface IRedeNeuralService
    {
        double CalcularDistanciaEuclidiana(Point pontoA, Point pontoB);
    }
}