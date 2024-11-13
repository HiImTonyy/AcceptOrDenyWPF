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
    /// Interaction logic for EndDayScreen.xaml
    /// </summary>
    public partial class EndDayScreen : Page
    {
        private Bills bill;
        private Player player;
        private Work work;
        public EndDayScreen(Bills bill, Player player, Work work)
        {
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

        }
    }
}
