using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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
using System.Xml;

namespace PetShop
{
    /// <summary>
    /// Interaction logic for registerPage.xaml
    /// </summary>
    public partial class registerPage : Page
    {
        DirectoryInfo parentFolder;
        public registerPage()
        {
            string expath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            parentFolder = Directory.GetParent(expath);
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            int uid = 0;
            using (RNGCryptoServiceProvider RCSP = new RNGCryptoServiceProvider())
            {
                byte[] random = new byte[5];
                RCSP.GetBytes(random);
                uid = BitConverter.ToInt32(random, 0);
            }
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Users.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNode user = doc.CreateElement("User");
            XmlNode username = doc.CreateElement("username");
            username.InnerText = usernameTB.Text.Trim();
            XmlNode uid_node = doc.CreateElement("uid");
            uid_node.InnerText = Math.Abs(uid).ToString();
            XmlNode password = doc.CreateElement("password");

            if (passwordTB.Text.Trim().Equals(password2TB.Text.Trim()))
            {
                password.InnerText = password2TB.Text.Trim();
                user.AppendChild(uid_node); user.AppendChild(username); user.AppendChild(password);
                doc.DocumentElement.AppendChild(user);
                doc.Save(fileName);
                MessageBox.Show("New user has been added!!");
                this.NavigationService.Navigate(new loginPage());

            }
            else
            {
                MessageBox.Show("Passwords do not match!!");
            }
        }
    }
}
