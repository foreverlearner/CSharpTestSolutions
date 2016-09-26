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

namespace GetTextboxInput
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Numbers _numbers;
        public MainWindow()
        {
            InitializeComponent();
            _numbers = (Numbers)this.DataContext;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _numbers.NotifyPropertyChange("Answer");
        }
    }
}
