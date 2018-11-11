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
        string name;
        Dictionary<string, int> petD = new Dictionary<string, int>();
        public ShoppingPage(string uname, Dictionary<string, int> currOrder)
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
            for (int i = 0; i < nodes.Count; i++)
            {

                if (nodes[i]["petName"].InnerXml.Trim().Equals("Cat"))
                {
                    catLbl.Content = "Cat Amount " + nodes[i]["amount"].InnerXml.Trim() + Environment.NewLine + " at Price " + nodes[i]["price"].InnerXml.Trim();
                }
                if (nodes[i]["petName"].InnerXml.Trim().Equals("Elephant"))
                {
                    EleLbl.Content = "Elephant Amount " + nodes[i]["amount"].InnerXml.Trim() + Environment.NewLine + "at Price " + nodes[i]["price"].InnerXml.Trim();
                }
                if (nodes[i]["petName"].InnerXml.Trim().Equals("Panther"))
                {
                    panLbl.Content = "Panther Amount " + nodes[i]["amount"].InnerXml.Trim() + Environment.NewLine + "at Price " + nodes[i]["price"].InnerXml.Trim();
                }
                if (nodes[i]["petName"].InnerXml.Trim().Equals("Puppy"))
                {
                    pupLbl.Content = "Puppy Amount " + nodes[i]["amount"].InnerXml.Trim() + Environment.NewLine + "at Price " + nodes[i]["price"].InnerXml.Trim();
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
                if(nodes[i]["petName"].InnerText.Equals("Cat")){
                    currPets["Cat"] = int.Parse(nodes[i]["amount"].InnerText);
                }
                if (nodes[i]["petName"].InnerText.Equals("Elephant"))
                {
                    currPets["Elephant"] = int.Parse(nodes[i]["amount"].InnerText);
                }
                if (nodes[i]["petName"].InnerText.Equals("Panther"))
                {
                    currPets["Panther"] = int.Parse(nodes[i]["amount"].InnerText);
                }
                if (nodes[i]["petName"].InnerText.Equals("Puppy"))
                {
                    currPets["Puppy"] = int.Parse(nodes[i]["amount"].InnerText);
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
            if (elphantCB.IsChecked.Value == true)
            {
                if (currPets["Elephant"] != 0)
                {
                    petD["Elephant"] = 1;
                    currPets["Elephant"]--;
                }
                else
                {
                    MessageBox.Show("Elephants are sold out");
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

            if (puppyCB.IsChecked.Value == true)
            {
                if (currPets["Puppy"] != 0)
                {
                    petD["Puppy"] = 1;
                    currPets["Puppy"]--;
                }
                else
                {
                    MessageBox.Show("Puppies are sold out");
                }
            }

            var flattenList = petD.Values;
            int total = 0;
            foreach(int c in flattenList)
            {
                total += c;
            }
            menubarCartTotal.Content = " You have " + total + " in your cart"; 
        }

        private void reviewOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new reviewOrderPage(name, petD));
        }
    }
}
