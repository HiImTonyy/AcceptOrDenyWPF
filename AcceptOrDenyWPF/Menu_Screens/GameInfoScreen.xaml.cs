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
    /// Interaction logic for GameInfoScreen.xaml
    /// </summary>
    public partial class GameInfoScreen : Page
    {
        public MainMenuScreen MainMenuScreen;
        public GameInfoScreen()
        {
            InitializeComponent();
        }

        private void BackToMenu(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainMenuScreen());
        }
    }
}
