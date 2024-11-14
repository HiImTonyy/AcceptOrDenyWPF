using AcceptOrDenyLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for EndDayScreen.xaml
    /// </summary>
    public partial class EndDayScreen : Page
    {
        private Bills bill;
        private Player player;
        private Work work;
        public EndDayScreen(Bills bill, Player player, Work work)
        {
            this.bill = bill;
            this.player = player;
            this.work = work;
            Work.TallyUpMoney(player, work);

            InitializeComponent();
            // Workday Results
            dayWageLbl.Content = "$" + work.DayWage;
            correctJudgementsLbl.Content = work.TodaysCorrectJudgements;
            bonusMoneyLbl.Content = "$" + work.BonusPayTotal;
            incorrectJudgedmentsLbl.Content = work.TodaysIncorrectJudgements;
            moneyDockedLbl.Content = "$" + work.MoneyLost;
            moneyEarneddLbl.Content = "$" + work.MoneyGained;
            // Bills
            Bills.DecreaseBillDates(bill);
            foodBillLbl.Content = bill.FoodBillDate;
            electricBillLbl.Content = bill.ElectricityBillDate;
            rentBillLbl.Content = bill.RentBillDate;
            Bills.PayBills(player, bill);
            totalBillLbl.Content = "$" + bill.TotalBill;
            // Bottom Stuff
            totalBalanceLbl.Text = "Total Balance: $" + player.Money;
            bossMessageLbl.Text = bossMessageLbl.Text + Work.BossEndOfDayComment(player, work);

            //Reset some things to default
            bill.TotalBill = 0;
            work.AlltimeCorrectJudgements = work.AlltimeCorrectJudgements + work.todaysCorrectJudgements;
            work.AlltimeIncorrectJudgements = work.AlltimeIncorrectJudgements + work.todaysIncorrectJudgements;
            work.WeeksCorrectJudgements = work.WeeksCorrectJudgements + work.TodaysCorrectJudgements;
            work.WeeksIncorrectJudgements = work.WeeksIncorrectJudgements + work.TodaysIncorrectJudgements;
            work.TodaysCorrectJudgements = 0;
            work.TodaysIncorrectJudgements = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool failure = false;

            if (player.Money < 0) { failure = true; }
          
            if (failure == true)
            {
                workdayPanel.Visibility = Visibility.Hidden;
                billsPanel.Visibility = Visibility.Hidden;
                totalBalanceLbl.Visibility = Visibility.Hidden;
                regularButton.Visibility = Visibility.Hidden;

                bossMessageLbl.Foreground = new SolidColorBrush(Colors.Red);
                bossMessageLbl.FontSize = 30;
                bossMessageLbl.HorizontalAlignment = HorizontalAlignment.Center;
                bossMessageLbl.Text = ($"You went bankrupt! GAME OVER.");
            }

            else if (failure == false)
            {
                CheckForPromotion(player, work);
            }
        }

        public void CheckForPromotion(Player player, Work work)
        {
            int wageThen = work.DayWage;

            if (work.WeeksIncorrectJudgements == 0 && work.CurrentDay >= 7)
            {

                work.DayWage = work.DayWage + 10;

                bossMessageLbl.Text = ($"Boss: Congratulations {player.FirstName}, I'm promoting you. your daily wage is going from ${wageThen} to ${work.DayWage}");

                work.CurrentDay = 1;
                work.WeeksCorrectJudgements = 0;

                workdayPanel.Visibility = Visibility.Hidden;
                billsPanel.Visibility = Visibility.Hidden;
                totalBalanceLbl.Visibility = Visibility.Hidden;
                regularButton.Visibility = Visibility.Hidden;
                promotionButton.Visibility = Visibility.Visible;
            }
            else if (work.WeeksIncorrectJudgements >= 17 && work.CurrentDay == 7)
            {
                work.DayWage = work.DayWage - 10;

                bossMessageLbl.Text = ($" Boss: Hey fuck-nut, I'm demoting you. your daily wage is going from ${wageThen} to ${work.DayWage}!");

                work.CurrentDay = 1;
                work.WeeksIncorrectJudgements = 0;

                workdayPanel.Visibility = Visibility.Hidden;
                billsPanel.Visibility = Visibility.Hidden;
                totalBalanceLbl.Visibility = Visibility.Hidden;
                regularButton.Visibility = Visibility.Hidden;
                promotionButton.Visibility = Visibility.Visible;
            }
            else if (work.CurrentDay == 7)
            {
                work.CurrentDay = 1;
                work.WeeksCorrectJudgements = 0;
                work.WeeksIncorrectJudgements = 0;
                work.CurrentDay = work.CurrentDay + 1;
                NavigationService.Navigate(new HomeScreen(bill, player, work));
            }
            else
            {
                work.CurrentDay++;
                NavigationService.Navigate(new HomeScreen(bill, player, work));
            }
        }

        private void GoHomeButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomeScreen(bill, player, work));
        }
    }
}
