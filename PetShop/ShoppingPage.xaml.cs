using System;
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
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {

            if (categoryCB.SelectedItem.Equals(cbiFeline))
            {
                NavigationService.Navigate(new FelinePage(name, petD));
            }
            if (categoryCB.SelectedItem.Equals(cbiCanine))
            {
                NavigationService.Navigate(new CaninePage(name, petD));
            }

        }
    }
}
