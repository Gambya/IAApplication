﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml;
using IAApplication.Domain.Entities;
using IAApplication.Domain.Services;
using IAApplication.Helpers;

namespace IAApplication.Infra.IA.Services
{
    public class KMeanService : IKMeanService
    {
        public void KMeansRun(List<Objetos> groupObjects, List<Centroide> groupCentroides)
        {
            var distancias = new List<dynamic>();
            var condicaoParada = true;
            do
            {
                for (var i = 0; i < groupObjects.Count; i++)
                {
                    for (var j = 0; j < groupCentroides.Count; j++)
                    {
                        var distancia = new
                        {
                            Distancia =
                                CommonHelper.CalcularDistanciaEuclidiana(
                                    groupObjects[i].X, groupObjects[i].Y,
                                    groupCentroides[j].X, groupCentroides[j].Y
                                    )
                        };
                        distancias.Add(distancia);
                    }
                    var vencedor = ResolverCentroides(distancias);
                    groupCentroides[vencedor].Objects.Add(groupObjects[i]);
                    distancias.Clear();
                }
                var resultadoCentroides = RecalcularCentroides(ref groupCentroides);
                for (var i =0;i< resultadoCentroides.Count;i++)
                {
                    if (resultadoCentroides[i].X == groupCentroides[i].X &&
                        resultadoCentroides[i].Y == groupCentroides[i].Y)
                    {
                        condicaoParada = false;
                    }
                }
            } while (condicaoParada);
        }

        private List<Centroide> RecalcularCentroides(ref List<Centroide> groupCentroides)
        {
            var retorno = new List<Centroide>();
            var mediaX = new double();
            var mediaY = new double();
            for (var i = 0; i < groupCentroides.Count; i++)
            {
                for (var j = 0; j < groupCentroides[i].Objects.Count; j++)
                {
                    mediaX += groupCentroides[i].Objects[j].X;
                    mediaY += groupCentroides[i].Objects[j].Y;
                }
                if (groupCentroides[i].Objects.Count > 0)
                {
                    mediaX = mediaX/groupCentroides[i].Objects.Count;
                    mediaY = mediaY/groupCentroides[i].Objects.Count;
                    groupCentroides[i].X = mediaX;
                    groupCentroides[i].Y = mediaY;
                    mediaX = mediaY = 0.00;
                }
                retorno.Add(groupCentroides[i]);
                groupCentroides[i].Objects.Clear();
            }

            return retorno;
        }

        public List<Objetos> LerDados(string pathBase)
        {
            var listaDados = new List<Objetos>();
            using (var stream = new StreamReader(pathBase))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    var cor = line.Split(',');
                    var objeto = new Objetos
                    {
                        X = Convert.ToDouble(cor[0].Replace(".",",")),
                        Y = Convert.ToDouble(cor[1].Replace(".", ","))
                    };
                    listaDados.Add(objeto);
                }
                
            }
            return listaDados;
        }

        private int ResolverCentroides(List<dynamic> distancias)
        {
            var min = distancias.Min(d=>d.Distancia);
            return distancias.FindIndex(d => d.Distancia == min);
        }

    }
}