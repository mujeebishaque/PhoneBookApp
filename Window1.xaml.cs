using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace PhoneBookAlpha
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void saveData_Click_1(object sender, RoutedEventArgs e)
        {
            string Name = ContactName.Text.ToString().ToLower();
            string Number = ContactNumber.Text.ToString().ToLower();

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Number))
            {
                MessageBox.Show("Name and Number field must be filled");
                return;
            }

            AddData(Name, Number);

            CloseMainWindowNow();
            var accessMethod = new MainWindow();
            accessMethod.OpenConnection();
            accessMethod.Show();

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
        public static void AddData(string Name, string Number)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PhoneBookAlpha.Properties.Settings.PhoneBookConnectionString"].ConnectionString;
            string query = "INSERT INTO PhoneBook VALUES (@Nname, @Nnumber)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand insert = new SqlCommand(query, connection))
            {
                connection.Open();
                insert.Parameters.AddWithValue("@Nname", Name);
                insert.Parameters.AddWithValue("@Nnumber", Number);

                /*insert.Parameters.AddWithValue("@IdNumber", 7);
                insert.Parameters.AddWithValue("@contactName", Name);
                insert.Parameters.AddWithValue("@contactNumber", Number);*/
                insert.ExecuteNonQuery();
                //MessageBox.Show(affectedRows + " Row Inserted !");
                //connection.Close();
            }
        }


    }
}
