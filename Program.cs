using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionesMoogle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> queryll = new List<string>() { "a", "b", "c", "f" };
            List<double> distancia = new List<double>() { 0.876, 0.643, 0.43534, 0 };
            List<int> nombresTxt = new List<int>() { 1, 2, 3, 4, 5, 6 };
            Dictionary<string, List<int>> Txt1 = new Dictionary<string, List<int>>();
            Txt1.Add("a", new List<int>() { 4, 56, 242, 255, 534, 711 });
            Txt1.Add("b", new List<int>() { 7, 59, 246, 256, 554, 723 });
            Txt1.Add("c", new List<int>() { 23, 74, 286, 226, 600, 773 });
            Txt1.Add("f", new List<int>() { 24, 75, 287, 227, 623, 776 });
            Dictionary<string, List<int>> Txt2 = new Dictionary<string, List<int>>();
            Txt2.Add("a", new List<int>() { 4, 56, 242, 255, 534, 711 });
            Txt2.Add("b", new List<int>() { 34, 69, 256, 266, 584, 743 });
            Txt2.Add("c", new List<int>() { 47, 80, 270, 286, 600, 773 });
            Dictionary<string, List<int>> Txt3 = new Dictionary<string, List<int>>();
            Txt3.Add("a", new List<int>() { 4, 56, 242, 255, 534, 711 });
            Txt3.Add("b", new List<int>() { 5, 57, 243, 256, 554, 723 });
            Txt3.Add("c", new List<int>() { 8, 59, 286, 226, 600, 773 });
            List<Dictionary<string, List<int>>> listTxt = new List<Dictionary<string, List<int>>>() { Txt1, Txt2, Txt3 };

            var x = RelevanciaDist(nombresTxt, listTxt, queryll, distancia);
            foreach (var item in x)
            {
                Console.WriteLine(item.Value + "  " + item.Key);
            }
            Console.ReadLine();
        }
        // retorna un diccionario<double, string> ordenado de menor a mayor con un indice en la Key del 1 al 10. 
        public static Dictionary<int, double> RelevanciaDist(List<int> nombresTxt, List<Dictionary<string, List<int>>> listDiccionary, List<string> queryll, List<double> valor)
        {
            Dictionary<int, double> resultados = new Dictionary<int, double>();
            int contTxt = 0;
            foreach (var diccionario in listDiccionary)
            {
                List<int> promedio = new List<int>();
                int cont = 0;
                for (int i = cont + 1; i < queryll.Count; i++)
                {
                    int rel = 10;
                    if (valor[i] == 0) { if (i == queryll.Count - 1) { cont++; i = cont; } continue; }
                    if (valor[cont] == 0) { if (cont + 1 == queryll.Count - 1) break; else { cont++; continue; } };
                    int dif = i - cont;
                    foreach (var indexCont in diccionario[queryll[cont]])
                    {
                        foreach (var indexI in diccionario[queryll[i]])
                        {
                            int res = indexI - indexCont > dif ? (indexI - indexCont) - dif : dif - (indexI - indexCont);
                            if (res < rel) rel = res;
                        }
                    }
                    promedio.Add((10 - rel) / 10);
                    if (i == queryll.Count - 1) { rel = 10; cont++; i = cont; }
                }
                double pro = 0;
                if (promedio != null) pro = promedio.Average();
                resultados.Add(nombresTxt[contTxt], pro); contTxt++;
            }
            resultados.OrderBy(result => result.Key);
            return resultados;
        }
    }
}
