using System;
using System.Collections.Generic;
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
        }

        public MenuPage(string tableNumber)
        {
            InitializeComponent();
            TableNumberTextBox.Text = tableNumber;
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

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void PaymentButton(object sender, RoutedEventArgs e)
        {
            PaymentPage paymentPage = new PaymentPage();
            paymentPage.Show();
            this.Close();

        }
    }
}
