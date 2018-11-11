using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PetShop
{
    /// <summary>
    /// Interaction logic for shopperScreen.xaml
    /// </summary>
    public partial class shopperScreen : Window
    {
        public shopperScreen(string username)
        {
            Dictionary<string, int> cOrder = new Dictionary<string, int>();
            InitializeComponent();
            frame.NavigationService.Navigate(new ShoppingPage(username, cOrder));
        }
    }
}
