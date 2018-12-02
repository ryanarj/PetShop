using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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
                    nodes[i]["price"].InnerText = Convert.ToDouble(newPrice).ToString();
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
                MessageBox.Show("Cannot be zero or less and cannot be decimal");
            }
            else
            {
                newPriceTB.Clear();
                doc.Save(fileName);
                MessageBox.Show("New price for " + petCB.Text);
            }

        }

        private void addSupply_Click(object sender, RoutedEventArgs e)
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Supplies.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            nodes = doc.GetElementsByTagName("Supplies");
            int currenAmount = 0;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i]["petName"].InnerText.Equals(petSupplyCB.Text))
                {
                    currenAmount = int.Parse(nodes[i]["amount"].InnerText) + 1;
                    nodes[i]["amount"].InnerText = currenAmount.ToString();
                    break;
                }
            }
            doc.Save(fileName);
            MessageBox.Show("Pet supply amount has been incremented.");
        }

        private void removeSupply_Click(object sender, RoutedEventArgs e)
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Supplies.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            bool found = false;
            nodes = doc.GetElementsByTagName("Supplies");
            int currenAmount = 0;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i]["petName"].InnerText.Equals(petSupplyCB.Text) && !nodes[i]["amount"].InnerText.Equals("0"))
                {
                    currenAmount = int.Parse(nodes[i]["amount"].InnerText) - 1;
                    nodes[i]["amount"].InnerText = currenAmount.ToString();
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
                MessageBox.Show("Cannot remove because already zero.");
            }

            doc.Save(fileName);
            MessageBox.Show("Pet Supply amount has been decremented.");
        }

        private void UpdateSupplyBtn_Click(object sender, RoutedEventArgs e)
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Supplies.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            bool found = false;
            nodes = doc.GetElementsByTagName("Supplies");
            string newPrice = "";

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i]["petName"].InnerText.Equals(petSupplyCB.Text) && double.Parse(newSupplyPrintTB.Text.Trim()) > 0.0)
                {
                    newPrice = newSupplyPrintTB.Text.Trim();
                    nodes[i]["price"].InnerText = Convert.ToDouble(newPrice).ToString("0.##");
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
                MessageBox.Show("Cannot be zero or less and must be decimal");
            }
            else
            {
                newSupplyPrintTB.Clear();
                doc.Save(fileName);
                MessageBox.Show("New price for supply " + petSupplyCB.Text);
            }

        }
    }
}
