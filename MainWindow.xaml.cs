using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneBookAlpha
{
    /// <summary>
    /// DB => Create a PhoneBook DB with PhoneBook table;
    /// Table => Should have fields like, Id, Name, Contact Number
    /// App => Menu contains an Action Tab ( INSERT, DELETE And Exit ) and a Help Tab with item as About Us.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.CanUserAddRows = false;
            dataGrid.CanUserDeleteRows = false;
            OpenConnection();
        }
        public void OpenConnection()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["PhoneBookAlpha.Properties.Settings.PhoneBookConnectionString"].ConnectionString;
            string query = "SELECT * FROM PhoneBook";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter data = new SqlDataAdapter(query, connectionString))
            {
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // Insert Data
            Window1 InsertDataWindow = new Window1();
            InsertDataWindow.Show();

        }

        private async void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //About Us
            await Task.Run(() =>
            {
                MessageBox.Show(" Programmed By Mujeeb Ishaq" + "\n\n Email : " + "mujeebishaqg@gmail.com");
            });
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            // Delete the Item.
            DeleteItemWindow Box = new DeleteItemWindow();
            Box.Show();

        }
    }
}
