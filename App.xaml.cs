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
        public static string[] funcToArr(string func)
        {
            func = "x^2+3(x+x^3)-5cosx";
            string[] parsedArr = new string[func.Length];
            for (int i = 0; i < func.Length; i++)
            {
                parsedArr[i] = func[i].ToString();
            }
            return parsedArr;
        }
        public static double Parser(string func)
        {
            string[] funcArr = funcToArr(func);
            double result;
            string str;

            for (int n = 0; n < funcToArr(func).Length; n++)
            {
                if (funcArr[n] == "(")
                {
                    do
                    {
                        str = funcArr[n] + funcArr[n + 1];
                        n += 2;
                    }
                    while (funcArr[n] != ")");
                }
            }
            return 1;
        }
    }
}
