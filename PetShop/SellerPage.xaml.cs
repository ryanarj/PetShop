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
    /// Interaction logic for SellerPage.xaml
    /// </summary>
    public partial class SellerPage : Page
    {
        DirectoryInfo parentFolder;
        XmlNodeList nodes;
        public SellerPage()
        {
            string expath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            parentFolder = Directory.GetParent(expath);
            InitializeComponent();
        }

        private void addPet_Click(object sender, RoutedEventArgs e)
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Pets.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            nodes = doc.GetElementsByTagName("Pet");
            int currenAmount = 0;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i]["petName"].InnerText.Equals(petCB.Text))
                {
                    currenAmount = int.Parse(nodes[i]["amount"].InnerText) + 1;
                    nodes[i]["amount"].InnerText = currenAmount.ToString();
                    break;
                }
            }
            doc.Save(fileName);
            MessageBox.Show("Pet amount has been incremented.");

        }

        private void removePet_Click(object sender, RoutedEventArgs e)
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Pets.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            bool found = false;
            nodes = doc.GetElementsByTagName("Pet");
            int currenAmount = 0;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i]["petName"].InnerText.Equals(petCB.Text) && !nodes[i]["amount"].InnerText.Equals("0"))
                {
                    currenAmount = int.Parse(nodes[i]["amount"].InnerText) - 1;
                    nodes[i]["amount"].InnerText = currenAmount.ToString();
                    found = true;
                    break;
                } else
                {
                    found = false;
                }
            }
            if (!found)
            {
                MessageBox.Show("Cannot remove because already zero.");
            }

            doc.Save(fileName);
            MessageBox.Show("Pet amount has been decremented.");
        }

        private void UpdatePrice_Click(object sender, RoutedEventArgs e)
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Pets.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            bool found = false;
            nodes = doc.GetElementsByTagName("Pet");
            string newPrice = "";

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i]["petName"].InnerText.Equals(petCB.Text) && double.Parse(newPriceTB.Text.Trim()) > 0.0)
                {
                    newPrice = newPriceTB.Text.Trim();
                    nodes[i]["price"].InnerText = newPrice;
                    found = true;
                    break;
                }
                else
                {
                    found = false;
                }
            }
            if (!found)
            {
                MessageBox.Show("Cannot be zero or less");
            }
            newPriceTB.Clear();
            doc.Save(fileName);
            MessageBox.Show("New price for " + petCB.Text);
        }
    }
}
