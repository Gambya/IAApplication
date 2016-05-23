using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IAApplication.Helpers
{
    public class Normalization
    {
        private static List<double> listaDados;
        private static string pathBase;
        public static StringBuilder NormalizarBase(string path)
        {
            pathBase = path;

            listaDados = GetListaDados();
            var strBuilderDado = new StringBuilder();
            if (!File.Exists(pathBase)) return strBuilderDado;
            using (var stream = new StreamReader(pathBase))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    var dados =
                        line.Split(',')
                            .ToList()
                            .ConvertAll(new Converter<string, double>(Normalization.ConvertToDouble));
                    foreach (var dado in dados)
                    {
                        strBuilderDado.Append($"{Normalization.NormalizeToMinMax(dado, listaDados)}".Replace(",", "."));
                        strBuilderDado.Append(",");
                    }
                    strBuilderDado.Remove(strBuilderDado.Length - 1, 1);
                    strBuilderDado.AppendLine();
                }
            }
            return strBuilderDado;
        }
        public static double NormalizeToMinMax(double value, List<double> dados)
        {
            var max = dados.Max();
            var min = dados.Min();
            var result = ((value - min) / (max - min)) * ((1 - 0) + 0);
            return result;
        }

        private static List<double> GetListaDados()
        {
            listaDados = new List<double>();
            using (var stream = new StreamReader(pathBase))
            {
                var strFile = Regex.Replace(stream.ReadToEnd(), Environment.NewLine, ",");
                listaDados.AddRange(strFile.Split(',').ToList().ConvertAll(new Converter<string, double>(ConvertToDouble)));
            }
            return listaDados;
        }

        private static double ConvertToDouble(string input)
        {
            if (Regex.IsMatch(input, @"^\."))
                input = input.Replace(".", "0,");
            input = input.Replace(".", ",");
            return Convert.ToDouble(input);
        }
    }
}
