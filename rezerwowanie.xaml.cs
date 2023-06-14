using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
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
using Path = System.IO.Path;
using System.Globalization;

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

            string FileName = "Restauracja.mdf";
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string ProjectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(CurrentDirectory).FullName).FullName).FullName;
            string FilePath = Path.Combine(ProjectDirectory, FileName);

            string conn = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={FilePath};Integrated Security=True;Connect Timeout=30;";
            SqlConnection connection = new SqlConnection(conn);
            // koniec zmiennych
            connection.Open();
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

        private void rez_Click(object sender, RoutedEventArgs e)
        {
            if (imie.Text == string.Empty || nazwisko.Text == string.Empty || liczba.Text == string.Empty)
            {
                MessageBox.Show("Pozostawiłeś puste pole!", "Błąd", MessageBoxButton.OK);
                rezerwowanie okno = new rezerwowanie();
                okno.Show();
                this.Close();
            }

            string[] dataur1 = Dataa.Text.Split(".");
            string dataur2 = dataur1[2] + "." + dataur1[1] + "." + dataur1[0];
            DateTime dataur3 = DateTime.ParseExact(dataur2, "yyyy.MM.dd", CultureInfo.InvariantCulture);




            string FileName = "Restauracja.mdf";
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string ProjectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(CurrentDirectory).FullName).FullName).FullName;
            string FilePath = Path.Combine(ProjectDirectory, FileName);

            string conn = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={FilePath};Integrated Security=True;Connect Timeout=30;";
            SqlConnection connection = new SqlConnection(conn);
            // koniec zmiennych
            connection.Open();



            SqlCommand cmd1 = new SqlCommand("INSERT INTO Rezerwacje2 (Imie, Nazwisko, LiczbaGosci, Data) VALUES (@Imie, @Nazwisko, @LiczbaGosci)", connection);
            cmd1.Parameters.AddWithValue("@Imie", imie.Text);
            cmd1.Parameters.AddWithValue("@Nazwisko", nazwisko.Text);
            cmd1.Parameters.AddWithValue("@LiczbaGosci", liczba.Text);
            cmd1.Parameters.AddWithValue("@DataRezerwacji", dataur3);

            //int a = cmd1.ExecuteNonQuery();
 
            //if (a == 1)
            //{
                MessageBox.Show($"{imie.Text} {nazwisko.Text} pomyślnie dokonałeś rezerwacji!");
                MainWindow okno1 = new MainWindow();
                okno1.Show();
                this.Close();
            //}
        }
    }

}
