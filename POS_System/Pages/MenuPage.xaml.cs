using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POS_System.Pages
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Window
    {
        public MenuPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {

            string connectionString = "SERVER=localhost;DATABASE=pos_db;UID=root;PASSWORD=password;";

            //connect database
            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand command = new MySqlCommand("select * from item order by 1", connection);

            connection.Open();

            DataTable table = new DataTable();

            table.Load(command.ExecuteReader());

            connection.Close();

            foreach (DataRow row in table.Rows)
            {
                Button button = new Button()
                {
                    Content = row["item_name"].ToString(),
                    Tag = row,
                    Width = 150,
                    Height = 50,
                    Margin = new Thickness(5)
                };
                button.Click += Button_Click;
                FoodItemsListBox.Items.Add(button);
            }
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            DataRow row = (DataRow)button.Tag;

            // Here you can handle the button click event
            // For example, display the selected item in a MessageBox
            MessageBox.Show($"Item Selected: {row["itemName"]}");
        }


        public MenuPage(string tableNumber, string Type)
        {
            InitializeComponent();
            TableNumberTextBox.Text = tableNumber;
            TypeTextBox.Text = Type;
        }



        private void Back_to_TablePage(object sender, RoutedEventArgs e)
        {
            // Go to TablePage.xaml when they click on Back button
            TablePage tablePage = new TablePage();
            tablePage.Show();
            this.Close();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Change number to correspoding table.
            TablePage tablePage = new TablePage();

        }

        private void PaymentButton(object sender, RoutedEventArgs e)
        {
            PaymentPage paymentPage = new PaymentPage();
            paymentPage.Show();
            this.Close();

        }

        private void OrderTypeTextBox(object sender, TextChangedEventArgs e)
        {
            TablePage tablePage = new TablePage();

        }
    }
}

