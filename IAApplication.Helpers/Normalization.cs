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
        /// <summary>
        /// Método para normalizar base de dados
        /// </summary>
        /// <param name="path">Caminho do arquivo da base de dados</param>
        /// <param name="posicaoClasse">Número da coluna onde se localiza os dados que informam a classe</param>
        /// <param name="linhas">Número de linhas com dados existem na base</param>
        /// <param name="colunas">Número de colunas com dados que existem na base</param>
        /// <returns>retorna um stringbuilder para trabalhar com os dados lidos e normalizados</returns>
        public static StringBuilder NormalizarBase(string path, int posicaoClasse)
        {
            pathBase = path;

            listaDados = GetListaDados();
            var strBuilderDado = new StringBuilder();
            if (!File.Exists(pathBase)) return strBuilderDado;
            using (var stream = new StreamReader(pathBase))
            {
                string line;
                //percorrer a lista linha a linha novamente para normalizar linha por linha
                while ((line = stream.ReadLine()) != null)
                {
                    //Transformando uma linha em array e logo depois em uma lista convertendo para a lista os dados já como double
                    var dados = line.Split(',').ToList().ConvertAll(new Converter<string, double>(Normalization.ConvertToDouble));
                    //percorrer lista criada dado a dado e efetuando a normalização minmax
                    for (var dado = 0; dado < dados.Count; dado++)
                    {
                        if (posicaoClasse == dado) continue;//Verifica a posição que a classe se encontra para esta não ser normalizada, caso seja a posição, ele vai pular para o proximo dado
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
        /// <summary>
        /// Criar list de dados para cálculo de normalização
        /// </summary>
        /// <returns>retorna uma lista já convertida em double para ser normalizada</returns>
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
