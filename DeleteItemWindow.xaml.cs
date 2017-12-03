using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace PhoneBookAlpha
{
    /// <summary>
    /// Interaction logic for DeleteItemWindow.xaml
    /// FD8C2QW-D27-317F260AAN
    /// </summary>
    public partial class DeleteItemWindow : Window
    {
        public DeleteItemWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string toDelete = nameToDelete.Text;
            string connectionString = ConfigurationManager.ConnectionStrings["PhoneBookAlpha.Properties.Settings.PhoneBookConnectionString"].ConnectionString;
            string query = "DELETE FROM PhoneBook WHERE Name = @DeleteIt";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@DeleteIt", toDelete);
                command.ExecuteNonQuery();
            }

            CloseMainWindowNow();


            var startAgain = new MainWindow();
            startAgain.OpenConnection();
            startAgain.Show();


            Close();
        }
        public void CloseMainWindowNow()
        {
            var mainWindow = (Application.Current.MainWindow as MainWindow);
            if (mainWindow != null)
            {
                mainWindow.Close();
            }
        }
    }
}
