using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MatModel.View
{
    /// <summary>
    /// Логика взаимодействия для ModelLotkiVoltera.xaml
    /// </summary>
    public partial class ModelLotkiVoltera : Window
    {
        void GraphInit()
        {
            Graph.ChartAreas.Add(new ChartArea());
            Graph.ChartAreas[0].AxisX.IsMarginVisible = false;
            Graph.ChartAreas[0].AxisY.IsMarginVisible = false;
            Graph.Series.Add(new Series());
            Graph.Series[0].ChartType = SeriesChartType.Line;
            Graph.Series[0].Points.AddXY(0, 0);
            Graph.Series[0].Points.AddXY(1, 1);
            Graph.Series[0].Points.AddXY(2, 2);
        }
        public ModelLotkiVoltera()
        {
            InitializeComponent();
            GraphInit();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (Window window in App.Current.Windows)
            {
                if (window is MainWindow)
                {
                    window.Show();
                }
            }
        }

        private void okBut_Click(object sender, RoutedEventArgs e)
        {
            Graph.Series.Clear();
            double eps = Convert.ToDouble(epsBox.Text.ToString());
            double beta = Convert.ToDouble(betaBox.Text.ToString());
            double alfa = Convert.ToDouble(alfBox.Text.ToString());
            double delta = Convert.ToDouble(delBox.Text.ToString());
            double x0 = Convert.ToDouble(x0Box.Text.ToString());
            double y0 = Convert.ToDouble(y0Box.Text.ToString());
            double x = x0;
            double y = y0;
            int count = Convert.ToInt32(loopBox.Text.ToString());
            int cycle = 1;
            if(count != 1) cycle = count % 2 == 0 ? count : count + 1;
            for (int j = 0; j < count; ++j)
            {
                Graph.Series.Add(new Series());
                Graph.Series[j].ChartType = SeriesChartType.Line;
                y = y0 - y0 / cycle * j;
                Graph.Series[j].Points.AddXY(x, y);
                for (int i = 0; i < 150; i++)
                {
                    x = (eps - alfa * y) * x + x;
                    y = (delta * x - beta) * y + y;
                    Graph.Series[j].Points.AddXY((double)x, (double)y);
                }
            }
        }
    }
}
