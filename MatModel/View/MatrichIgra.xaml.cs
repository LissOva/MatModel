using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MatModel.View
{
    /// <summary>
    /// Логика взаимодействия для MatrichIgra.xaml
    /// </summary>
    public partial class MatrichIgra : Window
    {
        public MatrichIgra()
        {
            InitializeComponent();

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

        private void Window_Activated(object sender, EventArgs e)
        {

        }

        public int ChioceStepA(double[] row, string myCase)
        {
            int k = 0;
            double value = row[0];
            switch (myCase)
            {
                case "max":
                    if (value < row[1])
                    {
                        k = 1;
                        value = row[1];
                    }
                    if (value < row[2])
                    {
                        k = 2;
                    }
                    break;
                case "min":
                    if (value > row[1])
                    {
                        k = 1;
                        value = row[1];
                    }
                    if (value > row[2])
                    {
                        k = 2;
                    }
                    break;
            }
            return k;
        }

        private void okBut_Click(object sender, RoutedEventArgs e)
        {
            double n = Convert.ToDouble(countN.Text.ToString());
            double[] sumA = new double[] { 1, 0, 0 };
            double[] sumB = new double[] { 1, 0, 0 };
            double[] lastA = new double[] { matrix[0, 0], matrix[1, 0], matrix[2, 0] };
            double[] lastB = new double[] { matrix[0, 0], matrix[0, 1], matrix[0, 2] };
            double minA = 10000;
            double maxB = 0;
            int[,] matrix = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    object cellFind = myGrid.FindName("cell" + i.ToString() + j.ToString());
                    TextBox cell = cellFind as TextBox;
                    matrix[i, j] = Convert.ToInt32(cell.Text.ToString());
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                int kA = ChioceStepA(lastB, "min");
                int kB = ChioceStepA(lastA, "max");
                sumA[kB]++;
                sumB[kA]++;
                minA = Math.Min(minA, Math.Round((lastA[kB]) / (double)(i + 1), 2));
                maxB = Math.Max(maxB, Math.Round((lastB[kA]) / (double)(i + 1), 2));
                for (int j = 0; j < 3; j++)
                {
                    lastA[j] += matrix[j, kA];
                }
                for (int j = 0; j < 3; j++)
                {
                    lastB[j] += matrix[kB, j];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                sumA[i] = Math.Round(sumA[i] / n, 2);
                sumB[i] = Math.Round(sumB[i] / n, 2);
            }
            ans1.Text = Math.Min(maxB, minA).ToString() + " < V < " + Math.Max(maxB, minA).ToString();
            ans2.Text = "P = (" + sumA[0].ToString() + "; " + sumA[1].ToString() + "; " + sumA[2].ToString() + ")";
            ans3.Text = "Q = (" + sumB[0].ToString() + "; " + sumB[1].ToString() + "; " + sumB[2].ToString() + ")";
        }
    }
}
