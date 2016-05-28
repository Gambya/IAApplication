using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSom
{
    public class Node
    {
        public int linha { get; set; }
        public Node Vencedor { get; set; }
        public double[] valores { get; set; }
        public double[] peso { get; set; }
        public double[] distancia { get; set; }
        public List<int> Vizinhos { get; set; }
    }
}
