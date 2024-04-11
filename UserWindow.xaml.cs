using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace azs
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }
        private void user_Loaded(object sender, RoutedEventArgs e)
        {

            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=azs;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [sklad]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("sklad");
                sda.Fill(dt);
                user.ItemsSource = dt.DefaultView;
            }
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ;Initial Catalog=azs;Integrated Security=True"))
            {
                Random random = new Random();
                int randomValue = random.Next(300, 1500);

                con.Open();
                var cmd = new SqlCommand($"INSERT INTO [sklad] ([stoika], [benzin], [count], [status]) VALUES ('{stoika.Text}', '{benzin.Text}', {randomValue}, '1')", con);
                cmd.ExecuteNonQuery();
            }
        }

        private void refresh_click(object sender, RoutedEventArgs e)
        {
            using (var con = new SqlConnection("Data Source=DESKTOP-N9AD6FJ; Initial Catalog=krendelek2; Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM [zakazes]", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("zakazes");
                sda.Fill(dt);
                user.ItemsSource = dt.DefaultView;
            }
        }
    }
}
