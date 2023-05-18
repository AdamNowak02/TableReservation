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

namespace WPFApp
{
    /// <summary>
    /// Logika interakcji dla klasy rezerwowanie.xaml
    /// </summary>
    public partial class rezerwowanie : Window
    {
        public rezerwowanie()
        {
            InitializeComponent();
        }

        private void glowna_click(object sender, RoutedEventArgs e)
        {
            MainWindow objGlowna = new MainWindow();
            objGlowna.Show();
            this.Close();
        }

        private void TextBox_TextChanged0(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
        }

        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
        }
    }
}
