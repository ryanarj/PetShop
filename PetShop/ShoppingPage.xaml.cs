using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for ShoppingPage.xaml
    /// </summary>
    public partial class ShoppingPage : Page
    {
        DirectoryInfo parentFolder;
        public ShoppingPage()
        {
            string expath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            parentFolder = Directory.GetParent(expath);
            SetupData();
            InitializeComponent();
        }

        private void SetupData()
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Pets.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNodeList nodes = doc.GetElementsByTagName("Pet");
            for (int i = 0; i < nodes.Count; i++)
            {

                if (nodes[i]["petName"].InnerXml.Trim().Equals("Cat"))
                {
                    catLbl.Content = "Cat Amount " + nodes[i]["amount"].InnerXml.Trim() + " at Price " + nodes[i]["price"].InnerXml.Trim();
                 }
                if (nodes[i]["petName"].InnerXml.Trim().Equals("Elephant"))
                {
                    catLbl.Content = "Elephant Amount " + nodes[i]["amount"].InnerXml.Trim() + "at Price " + nodes[i]["price"].InnerXml.Trim();
                }
                if (nodes[i]["petName"].InnerXml.Trim().Equals("Panther"))
                {
                    catLbl.Content = "Panther Amount " + nodes[i]["amount"].InnerXml.Trim() + "at Price " + nodes[i]["price"].InnerXml.Trim();
                }
                if (nodes[i]["petName"].InnerXml.Trim().Equals("Puppy"))
                {
                    catLbl.Content = "Puppy Amount " + nodes[i]["amount"].InnerXml.Trim() + "at Price " + nodes[i]["price"].InnerXml.Trim();
                }
            }
        }

        private void addToCartBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
