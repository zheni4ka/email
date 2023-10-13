using MailKit.Net.Imap;
using MailKit.Security;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public string myMailAddress { get; } = "ebranik15@gmail.com";
        public string accountPassword { get; } = "pzte vuyf pvuh jhii";

        private ImapClient client = new();

        List<string> folders = new();

        public Page1()
        {
            InitializeComponent();
            
            client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);

            client.Authenticate(myMailAddress, accountPassword);

            folders = client.GetFolders(client.PersonalNamespaces.First()).Select(x => x.Name).ToList();

            ListFolders.ItemsSource = folders;
        }
    }
}
