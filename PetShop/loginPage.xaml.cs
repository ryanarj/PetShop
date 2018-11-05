
using System.Windows;
using System.Windows.Controls;

namespace PetShop
{
    /// <summary>
    /// Interaction logic for loginPage.xaml
    /// </summary>
    public partial class loginPage : Page
    {
        public loginPage()
        {
            InitializeComponent();
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new registerPage();

        }
    }
}
