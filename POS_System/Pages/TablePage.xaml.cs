using System;
using System.Collections.Generic;
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
using System.Xml.Linq;

namespace POS_System.Pages
{
    public partial class TablePage : Window
    {
        public TablePage()
        {
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Perform logout actions here
            // For example, you can close the current window and navigate back to the login screen
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            this.Close();
        }

        //Handle table number, order number, order type
        private void Open_Table(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string tableName = button.Name; // get the name of the button
                string orderType = button.Name; //get the name of button

                int index = tableName.IndexOf('_'); //get the index number after "_"

                // Show table number or take-our order number
                string tableNumber = tableName.Substring(index + 1);// remove the first 5 characters ("table")
                orderType = tableName.Substring(0, index);

                String Type = "";
                if (orderType.Equals("table"))
                {
                    Type = "Dine-In"; 
                } 
                else if (orderType.Equals ("takeOut"))
                {
                    Type = "Take-Out";
                }


                MenuPage menuPage = new MenuPage(tableNumber, Type); // pass the table number as a string
                menuPage.Show();
                this.Close();
            }
        }


    }
}
