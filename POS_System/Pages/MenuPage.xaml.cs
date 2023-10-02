using MySql.Data.MySqlClient;
using POS.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using POS_System.Models;

namespace POS_System.Pages
{
    public partial class MenuPage : Window
    {
        public MenuPage()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Loaded += Window_Loaded;
        }

        public MenuPage(string tableNumber, string Type) : this()
        {
            TableNumberTextBox.Text = tableNumber;
            TypeTextBox.Text = Type;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryData(); // Call LoadCategoryData to load category buttons
            LoadItemsData(); // Call LoadItemsData to load item buttons
        }

        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

        private void LoadItemsData()
        {
            string connStr = "SERVER=localhost;DATABASE=pos_db;UID=root;PASSWORD=password;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                string sql = "SELECT * FROM item;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Item item = new Item()
                    {
                        Id = Convert.ToInt32(rdr["item_id"]),
                        Name = rdr["item_name"].ToString(),
                        Price = Convert.ToDouble(rdr["item_price"]),
                        Description = rdr["item_description"].ToString(),
                        Category = rdr["item_category"].ToString()
                    };

                    Button newButton = new Button();
                    newButton.Content = rdr["item_name"].ToString();
                    newButton.Tag = item;
                    newButton.Click += NewButton_Click;
                    newButton.Width = 150;
                    newButton.Height = 60;
                    SetButtonStyle(newButton);

                    categoryButtonPanel.Children.Add(newButton);
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
                if (item != null)
                {
                    // Create an OrderedItem object with the correct property names
                    OrderedItem orderedItem = new OrderedItem
                    {
                        ItemName = item.Name,
                        Quantity = 1, // You can set the quantity as needed
                        ItemPrice = item.Price
                    };

                    // Add the orderedItem to the ObservableCollection of OrderedItem
                    OrdersListBox.Items.Add(orderedItem);

                    // Calculate and update the total amount
                    TotalAmount += item.Price;
                    TotalAmountTextBlock.Text = TotalAmount.ToString("C");
                }
            }
        }





        private void LoadCategoryData()
        {
            string connStr = "SERVER=localhost;DATABASE=pos_db;UID=root;PASSWORD=password;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                string sql = "SELECT category_name FROM category;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Button newButton = new Button();
                    newButton.Content = rdr["category_name"].ToString();
                    newButton.Width = 150;
                    newButton.Height = 60;
                    SetButtonStyle(newButton);
                    newButton.Click += (sender, e) => LoadItemsByCategory(newButton.Content.ToString());
                    categoryButtonPanel.Children.Add(newButton);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void LoadItemsByCategory(string categoryName)
        {
            itemButtonPanel.Children.Clear();
            string connStr = "SERVER=localhost;DATABASE=pos_db;UID=root;PASSWORD=password;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                string sql = "SELECT item_name FROM item WHERE item_category = @category;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@category", categoryName);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Button newButton = new Button();
                    newButton.Content = rdr["item_name"].ToString();
                    newButton.Width = 150;
                    newButton.Height = 60;
                    SetButtonStyle(newButton);
                    newButton.Click += NewButton_Click;
                    itemButtonPanel.Children.Add(newButton);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void SetButtonStyle(Button button)
        {
            button.FontFamily = new FontFamily("Verdana");
            button.FontSize = 20;
            button.Background = Brushes.Orange;
            button.FontWeight = FontWeights.Bold;
            button.BorderBrush = Brushes.Orange;
            button.Margin = new Thickness(5);
        }

        private double TotalAmount = 0.0;

        private void Back_to_TablePage(object sender, RoutedEventArgs e)
        {
            TablePage tablePage = new TablePage();
            tablePage.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
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
