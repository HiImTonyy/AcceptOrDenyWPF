using AcceptOrDenyLibrary;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AcceptOrDenyWPF.Menu_Screens
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Page
    {
        public HomeScreen(Bills bill, Player player, Work work)
        {
            InitializeComponent();

            currentDateLbl.Content = DateTime.Now.ToString("MM/dd/yyyy");
            playerFirstNameLbl.Content = player.FirstName;
            playerLastNameLbl.Content = player.LastName;
            playerMoneyLbl.Content = player.Money;
            playerMoneyLbl.Content = "$" + player.Money;
        }
    }
}
