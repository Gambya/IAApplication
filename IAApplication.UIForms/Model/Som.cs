using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using IAApplication.Helpers;

namespace IAApplication.UIForms.Model
{
    public class Som
    {
        private List<Node> listaNodes;
        public double TaxaAprendizado { get; set; }
        public string PathBase { get; set; }
        public List<Node> Nodes { get; set; }
        private const int Raio = 1;

        public Som(double taxaAprendizado, string pathBase)
        {
            PathBase = pathBase;
            TaxaAprendizado = taxaAprendizado;
            listaNodes = new List<Node>();
        }

        public void StartEpoca(int epocas)
        {
            listaNodes = LerDados().ToList();
            listaNodes = CarregarPesos().ToList();
            var bmu = DefinirVencedor();
            bmu = DefinirVisinhanca(bmu);
            foreach (var visinho in bmu.Visinhos)
            {
                Nodes.Add(AjustarPesos(bmu));
            }
        }
        /// <summary>
        /// Ler arquivo e carrega array multidimensional com os dados por linha e coluna
        /// </summary>
        /// <param name="pathBase">caminho do arquivo</param>
        /// <returns>retorna um array multidimensional de double</returns>
        private IEnumerable<Node> LerDados()
        {
            using (var stream = new StreamReader(PathBase))
            {
                string line;
                var linha = 0;
                while ((line = stream.ReadLine()) != null)
                {
                    var listaDados = line.Split(',').ToList().ConvertAll(new Converter<string, double>(ConvertToDouble)); ;
                    for (var i = 0; i < listaDados.Count; i++)
                    {
                        var node = new Node
                        {
                            Linha = linha,
                            Coluna = i,
                            Value = listaDados[i]
                        };
                        listaNodes.Add(node);
                    }
                    linha++;
                }
            }
            return listaNodes;
        }
        /// <summary>
        /// Efetuar o carregamento de array de dados com seus respectivos pesos
        /// </summary>
        /// <returns>retorna um double multidimensional</returns>
        private IEnumerable<Node> CarregarPesos()
        {
            for (var i = 0; i < listaNodes.Count; i++)
            {
                var rnd = new Random(1);
                listaNodes[i].Peso = rnd.NextDouble();
            }
            return listaNodes;
        }
        /// <summary>
        /// Calcular distância euclidiana dos pesos
        /// </summary>
        /// <param name="x">dado informado na base</param>
        /// <param name="w">peso indicado</param>
        /// <returns>double resultado do calculo da distância euclidiana de peso</returns>
        private double CalcularDistanciaEuclidiana(double x, double w)
        {
            return CommonHelper.CalcularDistanciaEuclidiana(x, w);
        }

        private Node DefinirVencedor()
        {
            var bmu = new Node();
            var y = 0.00;
            for (var i = 0; i < listaNodes.Count; i++)
            {
                var x = CalcularDistanciaEuclidiana(listaNodes[i].Value, listaNodes[i].Peso);
                if (!(x < y)) continue;
                bmu = listaNodes[i];
                y = x;
            }
            return bmu;
        }
        /// <summary>
        /// Definir pesos do vencedor e dos visinhos
        /// </summary>
        /// <param name="bmu">Nó vencedor</param>
        /// <returns>retorna nó com seus visinhos</returns>
        private Node DefinirVisinhanca(Node bmu)
        {
            for (var i = 0; i < listaNodes.Count; i++)
            {
                var d = CalcularDistanciaEuclidiana(bmu.Value, listaNodes[i].Peso);
                if(d < Raio)
                    bmu.Visinhos.Add(listaNodes[i]);
            }
            return bmu;
        }

        public Node AjustarPesos(Node bmu)
        {
            bmu.Peso = (bmu.Peso + TaxaAprendizado)*(bmu.Visinhos[0].Value - bmu.Peso);
            return bmu;
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