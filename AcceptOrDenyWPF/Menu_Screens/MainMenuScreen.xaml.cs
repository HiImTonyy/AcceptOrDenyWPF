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
    /// Interaction logic for MainMenuScreen.xaml
    /// </summary>
    public partial class MainMenuScreen : Page
    {
        
        public MainMenuScreen()
        {
            InitializeComponent();
        }

        private void MainMenuButtonClick(object sender, RoutedEventArgs e)
        {
            var button_click = (Button)sender; 

            switch(button_click.Name)
            {
                case "NewGame":
                    NewGameScreen newGameScreen = new NewGameScreen();
                    MainWindowFrame.Navigate(newGameScreen);
                    break;
                case "GameInfo":
                    GameInfoScreen gameInfoScreen = new GameInfoScreen();
                    MainWindowFrame.Navigate(gameInfoScreen);
                    break;
            }
        }
    }
}
