
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace PetShop
{
    /// <summary>
    /// Interaction logic for loginPage.xaml
    /// </summary>
    public partial class loginPage : Page
    {
        DirectoryInfo parentFolder;
        public loginPage()
        {
            string expath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            parentFolder = Directory.GetParent(expath);
            InitializeComponent();
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new registerPage());
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {

            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Users.xml";
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(fileName);
            bool found = false;
            XmlNodeList nodes = xdoc.GetElementsByTagName("User");
            for (int i = 0; i < nodes.Count; i++)
            {

                if (nodes[i]["username"].InnerText.Equals(usernameLogTB.Text.Trim()) && nodes[i]["password"].InnerText.Equals(passwordLogTB.Text.Trim()))
                {
                    found = true;
                    string uname =  nodes[i]["name"].InnerText;
                    shopperScreen ss = new shopperScreen(uname);
                    ss.Show();
                }
            }

            if (!found)
            {
                MessageBox.Show("No user by those credentials!!");
            }
        }
    }
}
