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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string myMailAddress { get; } = "ebranik15@gmail.com";
        public string accountPassword { get; } = "pzte vuyf pvuh jhii";

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MailTextBox.Text != myMailAddress)
            {
                MessageBox.Show("error mail"); 
                return;
            }


            if (PasswordTextBox.Text != accountPassword)
            {
                MessageBox.Show("error password");
                return;
            }

            _mainFrame.NavigationService.Navigate(new Window1());
        }
    }
}
