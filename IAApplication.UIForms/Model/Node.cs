using System.Collections.Generic;

namespace IAApplication.UIForms.Model
{
    public class Node
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public double Value { get; set; }
        public double Peso { get; set; }
        public List<Node> Visinhos { get; set; }

        public Node()
        {
            Visinhos = new List<Node>();
        }

    }
}