using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using MailKit;
using MailKit.Net.Imap;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Page
    {
        public string myMailAddress { get; } = "ebranik15@gmail.com";
        public string accountPassword { get; } = "pzte vuyf pvuh jhii";
        
        MailMessage mail = new();

        public SendMessage sendMessagePage { get; set; } = new SendMessage();
        public Page1 page1 { get; set; } = new Page1();

        private ImapClient client = new();


        public Window1()
        {
            InitializeComponent();

            client.Connect("imap.gmail.com", 993, MailKit.Security.SecureSocketOptions.SslOnConnect);

            client.Authenticate(myMailAddress, accountPassword);
        }

        
        private void Menu_Selected(object sender, RoutedEventArgs e)
        {
            if (Menu.Items.OfType<ComboBoxItem>().Where(x => x.Name == "ShowMailBoxMenu").First().IsSelected == true)
            {
                PageNav.Navigate(sendMessagePage);
            }
            else
            {
                PageNav.Navigate(page1);
            }
        }
    }
}
