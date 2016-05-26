using System.Collections.Generic;
using System.IO;

namespace IAApplication.Domain.Services
{
    public interface ISomService
    {
        double[][] LerDados(string pathBase);
        double CalcularDistanciaEuclidiana();
        int DefinirVencedor();
        double CalcularNovoPesoVencedor(double peso);
        double CalcularPercentualErro();

    }
}