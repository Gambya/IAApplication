using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewSom
{
    class Program
    {
        public static double taxaAprendizado = 5;
        public const int Raio = 1;

        static void Main(string[] args)
        {

            List<Node> ListNode = new List<Node>();
            StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\data.txt");
            int line = 0;
            int epocas = 10;
            Random rnd = new Random(1);

            while (!sr.EndOfStream)
            {
                var node = new Node();
                node.valores = sr.ReadLine().Split(';').ToList().ConvertAll(new Converter<string, double>(ConvertToDouble)).ToArray();
                node.linha = line;
                node.peso = new double[node.valores.Length];
                for (int i = 0; i < node.valores.Length; i++)
                {
                    node.peso[i] = rnd.NextDouble();
                }
                node.Vizinhos = new List<int>();
                ListNode.Add(node);
                line++;
            }

            for (int epoca = 0; epoca < epocas; epoca++)
            {
                for (int i = 0; i < ListNode.Count; i++)
                {
                    ListNode[i].distancia = new double[line];
                    double menor = 100;
                    int index = 0;
                    for (int j = i + 1; j < ListNode.Count - 1; j++)
                    {
                        ListNode[i].distancia[j] = DistanciaEuclidiana(ListNode[i], ListNode[j]);
                        if (ListNode[i].distancia[j] < menor)
                        {
                            menor = ListNode[i].distancia[j];
                            index = j;
                        }

                    }
                    ListNode[i].Vencedor = ListNode[index];
                    ListNode[index].Vizinhos = EncontrarVizinhos(ListNode[index], ListNode);
                    ListNode[index] = AtualizarPesos(ListNode[index]);
                    foreach (int vizinho in ListNode[index].Vizinhos)
                    {
                        ListNode[vizinho] = AtualizarPesos(ListNode[vizinho]);
                    }
                    ListNode[index].Vizinhos.Clear();
                }
                taxaAprendizado *= 0.5;
            }

            List<int> ListaTeste = new List<int>();

            for (int i = 0; i < ListNode.Count; i++)
            {
                if (!ListaTeste.Contains(i))
                {
                    ListNode[i].Vizinhos = EncontrarVizinhos(ListNode[i], ListNode);
                    ListNode[i].Vizinhos.RemoveAll(c => ListaTeste.Contains(c));
                    Console.Write("Vizinhos do Node " + i + ": {");
                    ListNode[i].Vizinhos.ForEach(c => Console.Write(c + ", "));
                    Console.WriteLine("}" + Environment.NewLine);
                    ListaTeste.AddRange(ListNode[i].Vizinhos);
                }
            }
            Console.ReadKey();
        }

        public static Node AtualizarPesos(Node node)
        {
            for (int i = 0; i < node.peso.Count(); i++)
            {
                node.peso[i] = node.peso[i] + taxaAprendizado * (node.valores[i] - node.peso[i]);
            }
            return node;
        }

        public static List<int> EncontrarVizinhos(Node node, List<Node> lista)
        {
            List<int> Vizinhos = new List<int>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (DistanciaEuclidiana(node, lista[i]) < Raio)
                {
                    Vizinhos.Add(i);
                }
            }
            return Vizinhos;
        }

        //private Node DefinirVencedor()
        //{
        //    var bmu = new Node();
        //    var y = 0.00;
        //    //Para cada entrada de valor do nó execute os procedimentos abaixo
        //    for (var i = 0; i < ListNode.Count - 1; i++)
        //    {
        //        var x = CalcularDistanciaEuclidiana(listaNodes[i].Value, listaNodes[i].Peso);
        //        if (!(x < y)) continue;
        //        bmu = listaNodes[i];
        //        y = x;
        //    }
        //    return bmu;
        //}


        public static double ConvertToDouble(string valor)
        {
            if (Regex.IsMatch(valor, @"^\."))
                valor = valor.Replace(".", "0,");
            valor = valor.Replace(".", ",");
            return Convert.ToDouble(valor);
        }

        public static double DistanciaEuclidiana(Node nodeA, Node nodeB)
        {
            double valor = 0;
            for (int i = 0; i < nodeA.valores.Count(); i++)
            {
                valor += Math.Pow((nodeA.valores[i] - nodeB.valores[i]), 2);
            }
            return Math.Sqrt(valor);
        }


    }
}
