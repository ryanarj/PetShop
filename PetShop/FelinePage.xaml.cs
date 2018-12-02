using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace PetShop
{
    /// <summary>
    /// Interaction logic for FelinePage.xaml
    /// </summary>
    public partial class FelinePage : Page
    {
        DirectoryInfo parentFolder;
        string name;
        string pageName = "Feline";
        Dictionary<string, int> petD = new Dictionary<string, int>();
        public FelinePage(string uname, Dictionary<string, int> currOrder)
        {
            petD = currOrder;
            name = uname;
            string expath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            parentFolder = Directory.GetParent(expath);
            InitializeComponent();
            SetupData();
        }

        private void SetupData()
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Pets.xml";
            menubarUsername.Content = "Hi, " + name;
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNodeList nodes = doc.GetElementsByTagName("Pet");
            List<Feline> felineList = new List<Feline>();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i]["petType"].InnerXml.Trim().Equals("Feline"))
                {
                    
                    if (nodes[i]["petName"].InnerXml.Trim().Equals("Cat"))
                    {
                        Feline f = new Feline();
                        f.Name = nodes[i]["petName"].InnerXml.Trim();
                        f.Price = nodes[i]["price"].InnerXml.Trim();
                        f.Amount = nodes[i]["amount"].InnerXml.Trim();
                        felineList.Add(f);
                    }

                    if (nodes[i]["petName"].InnerXml.Trim().Equals("Panther"))
                    {
                        Feline f = new Feline();
                        panLbl.Content = "Panther Amount " + nodes[i]["amount"].InnerXml.Trim() + Environment.NewLine + "at Price " + nodes[i]["price"].InnerXml.Trim();
                        f.Name = nodes[i]["petName"].InnerXml.Trim();
                        f.Price = nodes[i]["price"].InnerXml.Trim();
                        f.Amount = nodes[i]["amount"].InnerXml.Trim();
                        felineList.Add(f);
                    }
                }
            }

            foreach (var pet in felineList)
            {
                if (pet.Name.Equals("Panther"))
                {
                    panLbl.Content = "Panther Amount " + pet.Amount + Environment.NewLine + "at Price " + pet.Price;
                } else if (pet.Name.Equals("Cat"))
                {
                    catLbl.Content = "Cat Amount " + pet.Amount + Environment.NewLine + "at Price " + pet.Price;
                }
            }

            var flattenList = petD.Values;
            int total = 0;
            foreach (int c in flattenList)
            {
                total += c;
            }
            menubarCartTotal.Content = " You have " + total + " in your cart";
        }

        private void addToCartBtn_Click(object sender, RoutedEventArgs e)
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Pets.xml";
            menubarUsername.Content = "Hi, " + name;
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNodeList nodes = doc.GetElementsByTagName("Pet");
            Dictionary<string, int> currPets = new Dictionary<string, int>();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i]["petName"].InnerText.Equals("Cat"))
                {
                    currPets["Cat"] = int.Parse(nodes[i]["amount"].InnerText);
                }
                if (nodes[i]["petName"].InnerText.Equals("Panther"))
                {
                    currPets["Panther"] = int.Parse(nodes[i]["amount"].InnerText);
                }
            }
            if (catCB.IsChecked.Value == true)
            {
                if (currPets["Cat"] != 0)
                {
                    petD["Cat"] = 1;
                    currPets["Cat"]--;
                }
                else
                {
                    MessageBox.Show("Cats are sold out");
                }
            }
            if (pantherCB.IsChecked.Value == true)
            {
                if (currPets["Panther"] != 0)
                {
                    petD["Panther"] = 1;
                    currPets["Panther"]--;
                }
                else
                {
                    MessageBox.Show("Panthers are sold out");
                }
            }

            var flattenList = petD.Values;
            int total = 0;
            foreach (int c in flattenList)
            {
                total += c;
            }
            menubarCartTotal.Content = " You have " + total + " pet in your cart";
            MessageBox.Show(" You have " + total + " pet in your cart");
        }

        private void reviewOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new reviewOrderPage(name, pageName, petD));
        }

        private void placeOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Pets.xml";
            menubarUsername.Content = "Hi, " + name;
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
            XmlNodeList nodes = doc.GetElementsByTagName("Pet");
            foreach (var item in petD)
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

                if (petD.ContainsKey(nodes[i]["petName"].InnerText) && petD[nodes[i]["petName"].InnerText] != 0)
                {
                    q = int.Parse(nodes[i]["amount"].InnerText) - 1;
                    nodes[i]["amount"].InnerText = q.ToString();
                }
            }
            doc.Save(fileName);
            str += " The total is " + total;
            MessageBox.Show(str);
            string[] strReceipt = str.Split();
            System.IO.File.WriteAllLines(receipt, strReceipt);
            MessageBox.Show(str + " Your receipt has been saved to transaction number: " + transaction_id + " Located at file path " + receipt);
            petD["Cat"] = 0;
            petD["Panther"] = 0;
            SetupData();
        }

        private void viewFelineSupplies_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FelineFoodPage(name, petD));
        }
    }
}
