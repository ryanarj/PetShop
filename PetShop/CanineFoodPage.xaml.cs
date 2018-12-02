using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml;

namespace PetShop
{
    /// <summary>
    /// Interaction logic for CanineFoodPage.xaml
    /// </summary>
    public partial class CanineFoodPage : Page
    {
        DirectoryInfo parentFolder;
        Dictionary<string, int> petSupplies = new Dictionary<string, int>();
        string UName;
        public CanineFoodPage(string name, Dictionary<string, int> petSupplies)
        {
            UName = name;
            string expath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            parentFolder = Directory.GetParent(expath);
            InitializeComponent();
            SetupData();

        }

        private void SetupData()
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Supplies.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            List<CanineSupplies> canineSupList = new List<CanineSupplies>();
            XmlNodeList nodes = doc.GetElementsByTagName("Supplies");
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i]["petType"].InnerXml.Trim().Equals("Canine"))
                {
                    if (nodes[i]["petName"].InnerXml.Trim().Equals("WolfFood"))
                    {
                        CanineSupplies c = new CanineSupplies();
                        c.Name = nodes[i]["petName"].InnerXml.Trim();
                        c.Amount = nodes[i]["amount"].InnerXml.Trim();
                        c.Price = nodes[i]["price"].InnerXml.Trim();
                        canineSupList.Add(c);
                    }
                    if (nodes[i]["petName"].InnerXml.Trim().Equals("PuppyFood"))
                    {
                        CanineSupplies c = new CanineSupplies();
                        c.Name = nodes[i]["petName"].InnerXml.Trim();
                        c.Amount = nodes[i]["amount"].InnerXml.Trim();
                        c.Price = nodes[i]["price"].InnerXml.Trim();
                        canineSupList.Add(c);
                    }

                }
            }

            foreach (var supply in canineSupList)
            {
                if (supply.Name.Equals("WolfFood"))
                {
                    wolfFoodLbl.Content = "Wolf Amount " + supply.Amount + Environment.NewLine + "at Price " + supply.Price;
                }
                else if (supply.Name.Equals("PuppyFood"))
                {
                    puppyFoodLbl.Content = "Puppy Amount " + supply.Amount + Environment.NewLine + "at Price " + supply.Price;
                }
            }

            var flattenList = petSupplies.Values;
            int total = 0;
            foreach (int c in flattenList)
            {
                total += c;
            }
            menubarCartTotal.Content = " You have " + total + " in your cart";
            canineSupList.Clear();

        }
        private void addToCartCBtn_Click(object sender, RoutedEventArgs e)
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Supplies.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNodeList nodes = doc.GetElementsByTagName("Supplies");
            Dictionary<string, int> currSupplies = new Dictionary<string, int>();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i]["petName"].InnerText.Equals("PuppyFood"))
                {
                    currSupplies["PuppyFood"] = int.Parse(nodes[i]["amount"].InnerText);
                }
                if (nodes[i]["petName"].InnerText.Equals("WolfFood"))
                {
                    currSupplies["WolfFood"] = int.Parse(nodes[i]["amount"].InnerText);
                }
            }
            if (wolfFoodCB.IsChecked.Value == true)
            {
                if (currSupplies["WolfFood"] != 0)
                {
                    petSupplies["WolfFood"] = 1;
                    currSupplies["WolfFood"]--;
                }
                else
                {
                    MessageBox.Show("Wolf food are sold out");
                }
            }

            if (puppyFoodCB.IsChecked.Value == true)
            {
                if (currSupplies["PuppyFood"] != 0)
                {
                    petSupplies["PuppyFood"] = 1;
                    currSupplies["PuppyFood"]--;
                }
                else
                {
                    MessageBox.Show("Puppy food are sold out");
                }
            }

            var flattenList = petSupplies.Values;
            int total = 0;
            foreach (int c in flattenList)
            {
                total += c;
            }
            menubarCartTotal.Content = " You have " + total + " supplies in your cart";
            MessageBox.Show(" You have " + total + " supplies in your cart");
        }

        private void placeOrderCBtn_Click(object sender, RoutedEventArgs e)
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Supplies.xml";
            string str = "";
            double total = 0;
            string price = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            int transaction_id = 0;
            using (RNGCryptoServiceProvider RCSP = new RNGCryptoServiceProvider())
            {
                byte[] random = new byte[5];
                RCSP.GetBytes(random);
                transaction_id = Math.Abs(BitConverter.ToInt32(random, 0));
            }
            string receipt = path.Substring(0, path.Length - 3) + transaction_id + ".txt";

            XmlNodeList nodes = doc.GetElementsByTagName("Supplies");
            foreach (var item in petSupplies)
            {
                if (item.Value != 0)
                {

                    var node = nodes.Cast<XmlNode>()
                       .Where(n => n["petName"].InnerText == item.Key)
                       .Select(x => x["price"].InnerText);
                    price = string.Join("", node.ToArray());
                    str += item.Key + " at " + price + Environment.NewLine;
                    total += double.Parse(price);

                }
            }
            int q = 0;
            for (int i = 0; i < nodes.Count; i++)
            {

                if (petSupplies.ContainsKey(nodes[i]["petName"].InnerText) && petSupplies[nodes[i]["petName"].InnerText] != 0)
                {
                    q = int.Parse(nodes[i]["amount"].InnerText) - 1;
                    nodes[i]["amount"].InnerText = q.ToString();
                }
            }
            doc.Save(fileName);
            str += "The total is " + total;
            string[] strReceipt = str.Split();
            System.IO.File.WriteAllLines(receipt, strReceipt);
            MessageBox.Show(str + " Your receipt has been saved to transaction number: " + transaction_id + " Located at file path " + receipt);

            petSupplies["WolfFood"] = 0;
            petSupplies["PuppyFood"] = 0;
        }

        private void backCBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CaninePage(UName, petSupplies));
        }
    }
}
