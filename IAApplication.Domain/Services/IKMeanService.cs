using System.Collections.Generic;
using System.Drawing;
using IAApplication.Domain.Entities;

namespace IAApplication.Domain.Services
{
    public interface IKMeanService
    {
        void KMeansRun(List<Objetos> groupObjects, List<Centroide> groupCentroides);
        List<Objetos> LerDados(string pathBase);
    }
}