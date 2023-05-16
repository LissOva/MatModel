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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatModel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void modelMaltus_Click(object sender, RoutedEventArgs e)
        {
            View.ModelMaltus modelMaltus = new View.ModelMaltus();
            this.Hide();
            modelMaltus.Show();
        }

        private void modelLotkiVoltera_Click(object sender, RoutedEventArgs e)
        {
            View.ModelLotkiVoltera modelLotkiVoltera = new View.ModelLotkiVoltera();
            this.Hide();
            modelLotkiVoltera.Show();
        }

        private void matrichIgra_Click(object sender, RoutedEventArgs e)
        {

        }

        private void derevoReshen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
