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
        private Bills bill;
        private Player player;
        private Work work;
        public HomeScreen(Bills bill, Player player, Work work)
        {
            InitializeComponent();

            this.bill = bill;
            this.player = player;
            this.work = work;

            playerNameLbl.Text = "Name: " + player.FirstName + " " + player.LastName;
            playerMoneyLbl.Text = "Balance: " + "$" +  player.Money;
            currentDateLbl.Text = "Current Date: " + DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void HomeMenuButtonClick(object sender, RoutedEventArgs e)
        {
            var button_click = (Button)sender;

            switch (button_click.Name)
            {
                case "goToWork":
                    NavigationService.Navigate(new WorkComputerScreen(bill, player, work));
                    break;
                case "showStats":
                    NavigationService.Navigate(new PlayerStatsScreen(bill, player, work));
                    break;
                case "saveGame":
                    //Save Game
                    break;
            }
        }
    }
}
