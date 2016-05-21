using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAApplication.Helpers
{
    public class Normalization
    {
        public static double NormalizeToMinMax(double value, List<double> dados)
        {
            var max = dados.Max();
            var min = dados.Min();
            var result = ((value - min) / (max - min)) * ((1 - 0) + 0);
            return result;
        }
    }
}
