using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GraphBuilder
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
    public partial class MathParser
    {
        public static double Parser(string func)
        {
            double result;
            if (func.Contains("(") && func.Contains(")"))
            {
                result = Skobki(func);
            }
            else result = BezSkobok(func);
            return result;
        }
        public static double BezSkobok(string func)
        {
            List<string> Sub = new List<string>();
            double result;
            result = 1.25;
            return result;
        }
        public static double Skobki(string func)
        {
            string[] vars = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            double result;
            List<string> Sub = new List<string>();
            string Temp = func, trimmed;
            int open, close;
            result = Parser(Temp);
            for (int i = 0; i < Temp.Length; i++)
            {
                open = Temp.IndexOf('(');
                close = Temp.LastIndexOf(')');
                trimmed = Temp.Substring(open, close);
                Sub.Add(trimmed);
                Temp = Temp.Replace(trimmed, vars[i]);
            }
            return result;
        }
    }
    public partial class graphic
    {
        public static double calc(double x)
        {
            double y = x * x-50;
            return y;
        }
    }
}
