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
    /// Interaction logic for WorkComputerScreen.xaml
    /// </summary>
    public partial class WorkComputerScreen : Page
    {
        private Bills bill;
        private Player player;
        private Work work;
        private NpcIDWindow npcIDWindow;
        private NPC npc;
        public bool checkedEndScreen = false;

        public WorkComputerScreen(Bills bill, Player player, Work work)
        {
            InitializeComponent();
            this.bill = bill;
            this.player = player;
            this.work = work;

            EndDay();
            bool isEven = false;
            int evenNumber = 5378008;


            // This is so that the lineup is always even for the boss to make a decent comment... you need half correct judgements and half incorrect judgements.
            do
            {
                evenNumber = Logic.RollRandomNumber(6, 17);

                if (evenNumber % 2 == 0)
                {
                    isEven = true;
                }
            } while (!isEven);


            work.CurrentLineup = evenNumber;
            work.TotalLineup = work.CurrentLineup;
            player.DaysEmployed++;

            npc = new NPC().GenerateNPC();
            NPC npcComputerInfo = new NPC(npc);

            if (npc.IsIllegal) 
            { 
                NPC.SelectIDError(npc); 
            }

            if (npc.ErrorType == (int)Logic.IDErrorType.ExpirationDate)
            {
                npcComputerInfo = new NPC(npc);
            }

            npcIDWindow = new NpcIDWindow(npc);
            npcIDWindow.Show();

            npcFirstNameLbl.Content = npcComputerInfo.FirstName;
            npcLastNameLbl.Content = npcComputerInfo.LastName;
            npcDateOfBirthLbl.Content = npcComputerInfo.FullBirthdate;
            npcGenderLbl.Content = npcComputerInfo.Gender;
            npcStreetAddressLbl.Content = npcComputerInfo.FullStreetAddress;
            npcIdExpirationLbl.Content = npcComputerInfo.FullExpirationDate;
            peopleInLineLbl.Content = work.CurrentLineup;
        }

        private void MakeChoiceButton(object sender, RoutedEventArgs e)
        {
            string choice = "null";

            Label button_click = (Label)sender;

            if (button_click.Name == "acceptButton") { choice = "accept"; }
            else if (button_click.Name == "denyButton") { choice = "deny"; }

            bool isWrongJudgement = Work.MakeChoice(choice, npc, work);
            if (isWrongJudgement)
            {
                choiceAnswerLbl.Foreground = Brushes.Crimson;
                choiceAnswerLbl.Content = choiceAnswerLbl.Content + " " + npc.ErrorTypeString;
                choiceAnswerLbl.Visibility = Visibility.Visible;
                nextPersonLbl.Visibility = Visibility.Visible;
                acceptButton.Visibility = Visibility.Hidden;
                denyButton.Visibility = Visibility.Hidden;
            }
            else
            {
                choiceAnswerLbl.Foreground = Brushes.ForestGreen;
                choiceAnswerLbl.Content = "Correct!";
                choiceAnswerLbl.Visibility = Visibility.Visible;
                nextPersonLbl.Visibility = Visibility.Visible;
                acceptButton.Visibility = Visibility.Hidden;
                denyButton.Visibility = Visibility.Hidden;
            }
        }

        private void NextPersonButtonClick(object sender, MouseButtonEventArgs e)
        {
            npc = new NPC().GenerateNPC();
            NPC npcComputerInfo = new NPC(npc);

            if (npc.IsIllegal) { NPC.SelectIDError(npc); }

            if (npc.ErrorType == (int)Logic.IDErrorType.ExpirationDate)
            {
                npcComputerInfo = new NPC(npc);
            }

            UpdateNPCData(npcComputerInfo);


            if (npcIDWindow != null && npcIDWindow.IsVisible)
            {
                npcIDWindow.UpdateNPCData(npc);
            }
            nextPersonLbl.Visibility = Visibility.Hidden;
            choiceAnswerLbl.Visibility = Visibility.Hidden;
            choiceAnswerLbl.Content = "Incorrect! the error was their";
            acceptButton.Visibility = Visibility.Visible;
            denyButton.Visibility = Visibility.Visible;
        }

        public void UpdateNPCData(NPC npcComputerInfo)
        {
            work.CurrentLineup--;

            npcFirstNameLbl.Content = npcComputerInfo.FirstName;
            npcLastNameLbl.Content = npcComputerInfo.LastName;
            npcDateOfBirthLbl.Content = npcComputerInfo.FullBirthdate;
            npcGenderLbl.Content = npcComputerInfo.Gender;
            npcStreetAddressLbl.Content = npcComputerInfo.FullStreetAddress;
            npcIdExpirationLbl.Content = npcComputerInfo.FullExpirationDate;
            peopleInLineLbl.Content = work.CurrentLineup;
        }

        // CHECK IF CURRENT LINEUP IS 0

        CancellationTokenSource cancel = new CancellationTokenSource();

        private void EndDay()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    if (work.CurrentLineup == 0)
                    {
                        Application.Current.Dispatcher.Invoke(GoToEndDayScreen);
                        cancel.Cancel();
                    }

                    await Task.Delay(10); 
                }
            });
        }

        private void GoToEndDayScreen()
        {
            npcIDWindow.Close();
            if (checkedEndScreen == true) {; }
            else if (checkedEndScreen == false)
            {
                checkedEndScreen = true;
                NavigationService.Navigate(new EndDayScreen(bill, player, work));
            }
        }
    }
}