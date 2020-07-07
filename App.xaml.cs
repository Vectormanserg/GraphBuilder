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
            string Temp = func;
            //for (int i = 0;)
            return result;
        }
        public static double Skobki(string func)
        {
            List<string> Sub = new List<string>();
            double result;
            string Temp = func;

            return result;
        }
    }
}
