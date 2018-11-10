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
            bool good = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNodeList nodes = doc.GetElementsByTagName("User");

            XmlNode user = doc.CreateElement("User");
            XmlNode username = doc.CreateElement("username");
            XmlNode uid_node = doc.CreateElement("uid");
            XmlNode password = doc.CreateElement("password");
            XmlNode email = doc.CreateElement("email");
            XmlNode name = doc.CreateElement("name");
            XmlNode shop_sell = doc.CreateElement("shopper_seller");

            for (int i = 0; i < nodes.Count; i++)
            {

                if (nodes[i]["email"].InnerXml.Trim().Equals(emailTb.Text.Trim()))
                {
                    MessageBox.Show("Email Taken");
                    good = false;
                    break;
                }
                else
                {
                    good = true;
                }

                if (nodes[i]["username"].InnerXml.Trim().Equals(usernameTB.Text.Trim()))
                {
                    MessageBox.Show("username Taken");
                    good = false;
                    break;
                }
                else
                {
                    good = true;
                }

            }

            if (good)
            {
                email.InnerText = emailTb.Text.Trim();
                name.InnerText = nameTB.Text.Trim();
                username.InnerText = usernameTB.Text.Trim();
                shop_sell.InnerText = shopSellCbx.Text.Trim();
                uid_node.InnerText = Math.Abs(uid).ToString();


                if (passwordTB.Text.Trim().Equals(password2TB.Text.Trim()))
                {
                    password.InnerText = password2TB.Text.Trim();

                }
                else
                {
                    MessageBox.Show("Passwords do not match!!");
                }

                if (string.IsNullOrEmpty(usernameTB.Text) && string.IsNullOrEmpty(passwordTB.Text) && string.IsNullOrEmpty(password2TB.Text) && string.IsNullOrEmpty(emailTb.Text) && string.IsNullOrEmpty(nameTB.Text) && string.IsNullOrEmpty(shopSellCbx.Text))
                {
                    MessageBox.Show("Every field must be filled in!");
                }
                else
                {
                    user.AppendChild(uid_node); user.AppendChild(username); user.AppendChild(password); user.AppendChild(name); user.AppendChild(email); user.AppendChild(shop_sell);
                    doc.DocumentElement.AppendChild(user);
                    doc.Save(fileName);
                    MessageBox.Show("New user has been added!!");
                    this.NavigationService.Navigate(new loginPage());
                }
            }

        }
    }
}
