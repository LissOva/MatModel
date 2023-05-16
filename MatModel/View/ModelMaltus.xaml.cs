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
    /// Логика взаимодействия для ModelMaltus.xaml
    /// </summary>
    public partial class ModelMaltus : Window
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

        public ModelMaltus()
        {
            InitializeComponent();
            GraphInit();
        }

        private void okBut_Click(object sender, RoutedEventArgs e)
        {
            Graph.Series.Clear();
            Graph.Series.Add(new Series());
            Graph.Series[0].ChartType = SeriesChartType.Line;
            double n = Convert.ToDouble(countYearBox.Text.ToString());
            double r = Convert.ToDouble(rBox.Text.ToString());
            double m = Convert.ToDouble(mBox.Text.ToString());
            double x = Convert.ToDouble(yearBox.Text.ToString());
            double y = Convert.ToDouble(countBox.Text.ToString());
            for (double i = x; i <= x + n; ++i) {
                Graph.Series[0].Points.AddXY((double)i, (double)y);
                y = (long)( y + (r - m) * y);

            }

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
    }
}
