using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomNK
{
    /// <summary>
    /// Classe responsável por armazenar os valores de entrada do data.txt
    /// </summary>
    class Node
    {
        // array para armazenar os valores lidos por linha
        public double[] valores { get; set; }
        // inteiro armazenando a ordem da linha para facilitar o acompanhamento
        public int ordem { get; set; }
    }
}
