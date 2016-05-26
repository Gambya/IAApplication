using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using IAApplication.Domain.Services;
using IAApplication.Helpers;

namespace IAApplication.Infra.IA.Services
{
    public class Som : ISomService
    {
        private double[][] dados;
        private double[][][] dadosPesos;
        /// <summary>
        /// Ler arquivo e carrega array multidimensional com os dados por linha e coluna
        /// </summary>
        /// <param name="pathBase">caminho do arquivo</param>
        /// <returns>retorna um array multidimensional de double</returns>
        public double[][] LerDados(string pathBase)
        {
            using (var stream = new StreamReader(pathBase))
            {
                string line;
                var linha = 0;
                while ((line = stream.ReadLine()) != null)
                {
                    var listaDados = line.Split(',').ToList().ConvertAll(new Converter<string, double>(ConvertToDouble));;
                    for (var i = 0; i < listaDados.Count; i++)
                    {
                        dados[linha][i] = listaDados[i];
                    }
                    linha++;
                }
            }
            return dados;
        }
        /// <summary>
        /// Efetuar o carregamento de array de dados com seus respectivos pesos
        /// </summary>
        /// <returns>retorna um double multidimensional</returns>
        private double[][][] CarregarPesos()
        {
            for (var i = 0; i < dados.Length; i++)
            {
                for (var j = 0; j < dados[i].Length; j++)
                {
                    for (var k = 0; k < dadosPesos[i][j].Length; k++)
                    {
                        var rnd = new Random(int.MaxValue);
                        dadosPesos[i][j][k] = rnd.NextDouble();
                    }
                }
            }
            return dadosPesos;
        }

        public double CalcularDistanciaEuclidiana()
        {
            throw new System.NotImplementedException();
        }

        public int DefinirVencedor()
        {
            throw new System.NotImplementedException();
        }

        public double CalcularNovoPesoVencedor(double peso)
        {
            throw new System.NotImplementedException();
        }

        public double CalcularPercentualErro()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Conversor de string para double
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static double ConvertToDouble(string input)
        {
            if (Regex.IsMatch(input, @"^\."))
                input = input.Replace(".", "0,");
            input = input.Replace(".", ",");
            return Convert.ToDouble(input);
        }
    }
}