using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomNK
{
    /// <summary>
    /// Classe responsável pelos Neurônios
    /// </summary>
    class Neuronio
    {
        // inteiro que armazena o código de identificação do dado neurônio
        public int cod { get; set; }
        // array de double que armazena os pesos do neurônio
        public double[] pesos { get; set; }
        // Lista de Nodes que informa os vizinhos do dado neurônio
        public List<Node> vizinhos { get; set; }
    }
}
