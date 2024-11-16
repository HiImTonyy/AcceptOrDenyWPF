using AcceptOrDenyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for PlayerStatsScreen.xaml
    /// </summary>
    public partial class PlayerStatsScreen : Page
    {
        private Bills bill;
        private Player player;
        private Work work;

        public PlayerStatsScreen(Bills bill, Player player, Work work)
        {
            InitializeComponent();

            this.bill = bill;
            this.player = player;
            this.work = work;

            // Player Stats
            playerFirstNameLbl.Content = player.FirstName;
            playerLastNameLbl.Content = player.LastName;
            dailyPlayerWageLbl.Content = work.DayWage;
            daysEmployedLbl.Content = player.DaysEmployed;

            // Work Stats
            totalCorrectJudgementsLbl.Content = work.AlltimeCorrectJudgements;
            totalIncorrectJudgementsLbl.Content = work.AlltimeIncorrectJudgements;
            correctJudgementStreakLbl.Content = work.HighestPerfectCorrectStreak;
            incorrectJudgementStreakLbl.Content = work.HighestPerfectIncorrectStreak;
            totalMoneyMadeLbl.Content = work.TotalMoneyMade;

            // Bill Stats
            foodBillCostLbl.Content = bill.FoodCost;
            electricBillCostLbl.Content = bill.ElectricityCost;
            rentBillCostLbl.Content = bill.RentCost;
        }

        private void BackToMenu(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new HomeScreen(bill, player, work));
        }
    }
}
