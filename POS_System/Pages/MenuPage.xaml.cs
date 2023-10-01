using MySql.Data.MySqlClient;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;

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
            this.DataContext = this;
            this.Loaded += Window_Loaded; // Subscribe to the Loaded event
            
            


        }
        public MenuPage(string tableNumber, string Type) : this()
        {
            TableNumberTextBox.Text = tableNumber;
            TypeTextBox.Text = Type;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadItemsData(); // Call LoadFoodData when the window is loaded
        }

        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

        private void LoadItemsData()
        {
            
            // Your connection string here
            string connStr = "SERVER=localhost;DATABASE=pos_db;UID=root;PASSWORD=password;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                // Your query to fetch items
                string sql = "SELECT * FROM item;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    // Create an Item object for each item in database
                    Item item = new Item()
                    {
                        Id = Convert.ToInt32(rdr["item_id"]),
                        Name = rdr["item_name"].ToString(),
                        Price = Convert.ToDouble(rdr["item_price"]),
                        Description = rdr["item_description"].ToString(),
                        Category = rdr["item_category"].ToString()
                    };

/*                    // Add item to Items collection
                    Items.Add(item);*/

                    // Creating a new button for each item in database
                    Button newButton = new Button();
                    newButton.Content = rdr["item_name"].ToString(); // Set the text of the button to the item name
                    newButton.Tag = item;
                    newButton.Click += NewButton_Click; // Assign a click event handler
                    newButton.Width = 150; // Set other properties as needed
                    newButton.Height = 30;
                    newButton.Margin = new Thickness(5);

                    // Add the new button to a container on your window
                    // For example, a StackPanel with the name 'buttonPanel'
                    buttonPanel.Children.Add(newButton);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }




        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null && clickedButton.Tag is Item)
            {
                Item item = (Item)clickedButton.Tag as Item;
                // Assuming Items is your ObservableCollection<Item>
                if (item != null)
                {
                    Items.Add(item);
                }
            }
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

