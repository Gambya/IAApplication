using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SomNK
{
    class Program
    {
        #region Variáveis Statics

        public static double Raio = 1;          // Valor do Raio
        public static int k = 3;                // Quantidade de Neurônios
        public static List<Node> Nodes;         // Lista de Nodes
        public static List<Neuronio> Neuronios; // Lista de Neurônios
        public static double alfa = 1.651;      // Valor da taxa de aprendizado

        #endregion Variáveis Statics

        static void Main(string[] args)
        {
            string dadosPath = Environment.CurrentDirectory + "\\data.txt";     // Endereço do arquivo com os dados para a aprendizagem
            int epocas = 100;                                                   // Quantidade de épocas
            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\acompanhamento.txt", false);   // Stream Reader para acompanhamento

            Nodes = PreencherNodes(dadosPath);  // Preenchendo a Lista de Nodes
            Neuronios = PreencherNeuronios();   // Preenchendo a Lista de Neuronios

            /// For utilizado para percorrer as épocas
            for (int epoca = 0; epoca < epocas; epoca++)
            {
                /// For utilizado para percorrer todos os Nodes
                for (int node = 0; node < Nodes.Count; node++)
                {
                    double menor = 9999999; // Variável menor sendo criado com valor extremo, facilitando a troca de valores
                    int index = 9;          // Valor da index que armazenará o índice do Neurônio
                    /// For utilizado para percorrer todos os neurônios
                    for (int neuronio = 0; neuronio < Neuronios.Count; neuronio++)
                    {
                        var temp = DistanciaEuclidiana(Nodes[node], Neuronios[neuronio]); // variável para armazenar o valor da distância euclidiana
                        if (temp < menor) // caso o temp seja menor que o valor atual da variável menor
                        {                 // irá armazenar o valor atual e pegar o índice do neurônio
                            menor = temp;
                            index = neuronio;
                        }
                    }
                    Neuronios[index].vizinhos.Add(Nodes[node]);  //Adiciona o Node atual a vizinhança do  neurônio vencedor
                    AtualizarPesos(Neuronios[index], Nodes[node]);  // Atualiza os pesos do Neurônio vencedor
                }
                sw.WriteLine("Impressão da época " + epoca + Environment.NewLine); // Imprime a época 
                /// For utilizado para percorrer os neurônios e imprimir sua vizinhança na determianda época
                for (int i = 0; i < Neuronios.Count; i++)
                {
                    //Neuronios[i].vizinhos = EncontrarVizinhos(Neuronios[i]);
                    Neuronios[i].vizinhos.ForEach(c => sw.Write(c.ordem + ","));
                    sw.WriteLine();
                    Neuronios[i].vizinhos.Clear();
                }
                sw.WriteLine(Environment.NewLine);
                alfa *= 0.5; // Atualiza o valor da taxa de aprendizado
            }
            /// Fecha o StreamWriter
            sw.Close();
        }

        /// <summary>
        /// Método responsável para encontrar os vizinhos do Neurônio
        /// </summary>
        /// <param name="neuronio"></param>
        /// <returns></returns>
        public static List<Node> EncontrarVizinhos(Neuronio  neuronio)
        {
            List<Node> Vizinhos = new List<Node>();
            for (int i = 0; i < Nodes.Count; i++)
            {
                var temp = DistanciaEuclidiana(Nodes[i], neuronio);
                if (temp < Raio && temp != 0)
                {
                    Vizinhos.Add(Nodes[i]);
                }
            }
            return Vizinhos;
        }

        /// <summary>
        /// Método responsável para atualizar os pesos do dado neurônio
        /// </summary>
        /// <param name="neuronio"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Neuronio AtualizarPesos(Neuronio neuronio, Node node)
        {
            for (int i = 0; i < neuronio.pesos.Count(); i++)
            {
                neuronio.pesos[i] = neuronio.pesos[i] + (alfa * (node.valores[i] - neuronio.pesos[i]));
            }
            return neuronio;
        }

        /// <summary>
        /// Método responsável por preencher a lista de neurônios
        /// </summary>
        /// <returns></returns>
        private static List<Neuronio> PreencherNeuronios()
        {
            List<Neuronio> neuronios = new List<Neuronio>();
            Random rnd = new Random(1);
            for (int i = 0; i < k; i++)
            {
                var neuronio = new Neuronio();
                neuronio.cod = i + 1;
                neuronio.pesos = new double[Nodes[i].valores.Count()];
                neuronio.vizinhos = new List<Node>();
                for (int j = 0; j < neuronio.pesos.Length; j++)
                {
                    neuronio.pesos[j] = rnd.NextDouble();
                }
                neuronios.Add(neuronio);
            }
            return neuronios;
        }


        /// <summary>
        /// Método responsável por converter os valores dados no data.txt para double
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static double ConvertToDouble(string valor)
        {
            if (Regex.IsMatch(valor, @"^\."))
                valor = valor.Replace(".", "0,");
            valor = valor.Replace(".", ",");
            return Convert.ToDouble(valor);
        }


        /// <summary>
        /// Método responsável por preencher a lista de Nodes
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<Node> PreencherNodes(string path)
        {
            StreamReader sr = new StreamReader(path);
            int ordem = 1;
            List<Node> Nodes = new List<Node>();
            while (!sr.EndOfStream)
            {
                var node = new Node();
                node.ordem = ordem;
                node.valores = sr.ReadLine().Split(';').ToList().ConvertAll(new Converter<string, double>(ConvertToDouble)).ToArray();
                Nodes.Add(node);
                ordem++;
            }
            sr.Close();
            return Nodes;
        }

        /// <summary>
        /// Método responsável por medir a distância euclidiana
        /// </summary>
        /// <param name="node"></param>
        /// <param name="neuronio"></param>
        /// <returns></returns>
        public static double DistanciaEuclidiana(Node node, Neuronio neuronio)
        {
            double valor = 0;
            for (int i = 0; i < node.valores.Count(); i++)
            {
                valor += Math.Pow((node.valores[i] - neuronio.pesos[i]), 2);
            }
            return Math.Sqrt(valor);
        }

    }
}
