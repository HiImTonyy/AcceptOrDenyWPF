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
    public partial class NewGameScreen : Page
    {
        Bills bill = new Bills();
        Player player = new Player();
        Work work = new Work();

        public NewGameScreen()
        {
            InitializeComponent();
        }

        private void StartNewGame(object sender, MouseButtonEventArgs e)
        {
            if (firstNameText.Text == "" || lastNameText.Text == "")
            {
                errorMessageText.Visibility = Visibility.Visible;
            }
            else
            {
                player.FirstName = firstNameText.Text;
                player.LastName = lastNameText.Text;
                NavigationService.Navigate(new HomeScreen(bill, player, work));
            }     
        }
    }
}
