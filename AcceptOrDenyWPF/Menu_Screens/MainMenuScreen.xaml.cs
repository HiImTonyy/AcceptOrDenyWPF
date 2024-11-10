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
    /// Interaction logic for MainMenuScreen.xaml
    /// </summary>
    public partial class MainMenuScreen : Page
    {
        public MainMenuScreen()
        {
            InitializeComponent();
        }

        private void GameInfo_Click(object sender, RoutedEventArgs e)
        {
            GameInfoScreen gameInfoScreen = new GameInfoScreen();
            MainWindowFrame.Navigate(gameInfoScreen);
        }
    }
}
