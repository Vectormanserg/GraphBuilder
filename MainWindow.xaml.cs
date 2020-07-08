using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphBuilder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            plot();
        }
        public void plot()
        {
            Polygon frame = new Polygon
            {
                Points = new PointCollection()
            };
            frame.Points.Add(new Point(10, 10));
            frame.Points.Add(new Point(10, 510));
            frame.Points.Add(new Point(510, 510));
            frame.Points.Add(new Point(510, 10));
            frame.Stroke = Brushes.Black;
            Canvas1.Children.Add(frame);
            //------------------------------------------
            //Линия абсцисс + стрелочка:
            //------------------------------------------
            Line Abs = new Line
            {
                X1 = 10,
                X2 = 510,
                Y1 = 260,
                Y2 = 260,
                StrokeThickness = 2,
                Stroke = Brushes.Black
            };
            Canvas1.Children.Add(Abs);

            Polyline AbsArr = new Polyline
            {
                Points = new PointCollection()
            };
            AbsArr.Points.Add(new Point(490, 255));
            AbsArr.Points.Add(new Point(510, 260));
            AbsArr.Points.Add(new Point(490, 265));
            AbsArr.Stroke = Brushes.Black;
            Canvas1.Children.Add(AbsArr);
            //-------------------------------------------
            //Линия ординат + стрелочка
            //-------------------------------------------
            Line Ord = new Line
            {
                X1 = 260,
                X2 = 260,
                Y1 = 10,
                Y2 = 510,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            Canvas1.Children.Add(Ord);

            Polyline OrdArr = new Polyline
            {
                Points = new PointCollection()
            };
            OrdArr.Points.Add(new Point(255, 30));
            OrdArr.Points.Add(new Point(260, 10));
            OrdArr.Points.Add(new Point(265, 30));
            OrdArr.Stroke = Brushes.Black;
            Canvas1.Children.Add(OrdArr);
            //------------------------------------------
            //Разметка координатной плоскости
            //------------------------------------------
            for (int i = 60; i < Abs.X2; i += 50)
            {
                Line AbsSub = new Line
                {
                    X1 = i,
                    X2 = i,
                    Y1 = 10,
                    Y2 = 510,
                    Stroke = Brushes.Gray,
                    StrokeThickness = 1
                };
                Canvas1.Children.Add(AbsSub);
            }
            for (int j = 60; j < Ord.Y2; j += 50)
            {
                Line OrdSub = new Line
                {
                    X1 = 10,
                    X2 = 510,
                    Y1 = j,
                    Y2 = j,
                    Stroke = Brushes.Gray,
                    StrokeThickness = 1,
                };
                
                Canvas1.Children.Add(OrdSub);
            }
        }
        public void ClearTxtFunc(object sender, RoutedEventArgs e)
        {
            if (txtFunc.Text == "Введите функцию")
            {
                txtFunc.Text = "";
            }
        }
        public void ClearTxtXmax(object sender, RoutedEventArgs e)
        {
            if (txtXmax.Text == "Введите максимальный Х")
            {
                txtXmax.Text = "";
            }
        }
        public void ClearTxtXmin(object sender, RoutedEventArgs e)
        {
            if (txtXmin.Text == "Введите минимальный Х")
            {
                txtXmin.Text = "";
            }
        }
        public void ClearTxtScale(object sender, RoutedEventArgs e)
        {
            if (txtScale.Text == "Введите масштаб, единиц на клетку (по умолчанию, 50)")
            {
                txtScale.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Canvas1.Children.Clear();
            plot();
            try
            {
                PlotBuild(double.Parse(txtXmin.Text), double.Parse(txtXmax.Text), txtFunc.Text);
            }
            catch(System.FormatException)
            {
                txtXmax.Text = "Введите значение!";
                txtXmin.Text = "Введите значение!";
            }
        }
        private void defTxtFunc(object sender, RoutedEventArgs e)
        {
            if (txtFunc.Text == "")
            {
                txtFunc.Text = "Введите функцию";
            }
        }
        private void defTxtXmin(object sender, RoutedEventArgs e)
        {
            if (txtXmin.Text == "")
            {
                txtXmin.Text = "Введите минимальный Х";
            }
        }
        private void defTxtXmax(object sender, RoutedEventArgs e)
        {
            if (txtXmax.Text == "")
            {
                txtXmax.Text = "Введите максимальный Х";
            }
        }
        private void PlotBuild(double Min, double Max,string func)
        {
            double sc = 1;
            double x, e = 0.01;
            if (txtScale.Text == "Введите масштаб, единиц на клетку (по умолчанию, 50)")
            {
                sc = 1;
            }
            else sc = (double.Parse(txtScale.Text))/50;
            for (x = Min; x < Max; x += e)
            {
                Line OneEl = new Line();
                try
                {
                    
                    {
                        OneEl.X1 = 260 + x / sc;
                        OneEl.X2 = 260 + (x + e) / sc;
                        OneEl.Y1 = 260 - MathParser.Calculate(func, x)/sc;
                        OneEl.Y2 = 260 - MathParser.Calculate(func, x + e)/sc;
                        OneEl.Stroke = Brushes.Red;
                        OneEl.StrokeThickness = 3;
                    };
                }
                catch (System.ArgumentException)
                {
                    txtXmin.Text = "Недопустимый аргумент";
                }
                if (OneEl.X1 > 10 && OneEl.X2 < 510 && OneEl.Y1 > 10 && OneEl.Y2 < 510)
                {
                    Canvas1.Children.Add(OneEl);
                }
            }
        }

        private void defTxtScale(object sender, RoutedEventArgs e)
        {
            if (txtScale.Text == "")
            {
                txtScale.Text = "Введите масштаб, единиц на клетку (по умолчанию, 50)";
            }
        }
    }
}
