using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace WPFApp
{
    /// <summary>
    /// Logika interakcji dla klasy zarezerwowane.xaml
    /// </summary>
    public partial class zarezerwowane : Window
    {
        public zarezerwowane()
        {
            InitializeComponent();

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
            SqlCommand command = new SqlCommand("SELECT * FROM Rezerwacje", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();

            rezerwacje.ItemsSource = dataTable.DefaultView;
        }

        public static DataView ItemsSource { get; internal set; }

        private void glowna_click(object sender, RoutedEventArgs e)
        {
            MainWindow objGlowna = new MainWindow();
            objGlowna.Show();
            this.Close();
        }
    }
}
