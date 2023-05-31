using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace WPFApp
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //połączenie z bazą
            InitializeComponent();
            string FileName = "Restauracja.mdf";
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string ProjectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(CurrentDirectory).FullName).FullName).FullName;
            string FilePath = Path.Combine(ProjectDirectory, FileName);

            string conn = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={FilePath};Integrated Security=True;Connect Timeout=30;";
            SqlConnection connection = new SqlConnection(conn);
            // koniec zmiennych
            connection.Open();



            //wstawianie do tabelki           
            SqlCommand command = new SqlCommand("SELECT * FROM Wydarzenia", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();

            tabelka.ItemsSource = dataTable.DefaultView;
        }


        private void rezerwacja_click(object sender, RoutedEventArgs e)
        {
           rezerwowanie objRezerwacja = new rezerwowanie();
            objRezerwacja.Show();
            this.Close();
        }

        private void juzzarezerwowane_click(object sender, RoutedEventArgs e)
        {
            zarezerwowane objZarezerwowane = new zarezerwowane();
            objZarezerwowane.Show();
            this.Close();
        }

        





    }
}
