using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Interaction logic for SendMessage.xaml
    /// </summary>
    public partial class SendMessage : Page
    {
        public string myMailAddress { get; } = "ebranik15@gmail.com";
        public string accountPassword { get; } = "pzte vuyf pvuh jhii";

        MailMessage mail = new();

        public SendMessage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mail = new MailMessage(myMailAddress, toTxtBox.Text)
            {
                Subject = subjectTxtBox.Text,
                Body = $"{bodyTxtBox.Text}",
                IsBodyHtml = true,
                Priority = MailPriority.Normal
            };

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(myMailAddress, accountPassword),
                EnableSsl = true
            };

            client.Send(mail);

        }

        private void AddAttachments_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
                mail.Attachments.Add(new Attachment(dialog.FileName));
        }

        private void isImportant_Checked(object sender, RoutedEventArgs e)
        {
            if (isImportant.IsChecked == true)
            {
                mail.Priority = MailPriority.High;
            }
            else mail.Priority = MailPriority.Normal;
        }

    }
}
