
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace PetShop
{
    /// <summary>
    /// Interaction logic for reviewOrderPage.xaml
    /// </summary>
    public partial class reviewOrderPage : Page
    {
        Dictionary<string, int> currOrder = new Dictionary<string, int>();
        DirectoryInfo parentFolder;
        string username;
        string lastP;
        public reviewOrderPage(string user, string lastPage, Dictionary<string, int> petD)
        {
            username = user;
            lastP = lastPage;
            string expath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            parentFolder = Directory.GetParent(expath);
            currOrder = petD;
            InitializeComponent();
            SetupData();
        }

        private void SetupData()
        {
            petLB.Items.Clear();
            string path = parentFolder.FullName;
            string fileName = path.Substring(0, path.Length - 3) + "Pets.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNodeList nodes = doc.GetElementsByTagName("Pet");
            foreach (var item in currOrder)
            {
                if (item.Value != 0)
                {
                    var node = nodes.Cast<XmlNode>()
                       .Where(n => n["petName"].InnerText == item.Key)
                       .Select(x => x["price"].InnerText);
                    petLB.Items.Add(item.Key + " at " + string.Join("", node.ToArray()));
                }
            }
        }

        private void cancelOrderBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (petLB.Items.Count == 0)
            {
                MessageBox.Show("No items available");
            }
            else if (petLB.SelectedIndex == -1)
            {
                MessageBox.Show("An item must be selected.");
            }
            else
            {
                string[] clist = petLB.Items.OfType<string>().ToArray();
                int index = petLB.Items.IndexOf(petLB.SelectedItem);
                string[] str = clist[index].Split();
                currOrder[str[0]] = 0;
                MessageBox.Show("Order had been canceled");
            }
        }

        private void backBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (lastP.Equals("Feline")){
                this.NavigationService.Navigate(new FelinePage(username, currOrder));
            } else if (lastP.Equals("Canine"))
            {
                this.NavigationService.Navigate(new CaninePage(username, currOrder));
            }
                
        }
    }
}
