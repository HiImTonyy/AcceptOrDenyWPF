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

        public WorkComputerScreen(Bills bill, Player player, Work work)
        {
            InitializeComponent();
            this.bill = bill;
            this.player = player;
            this.work = work;

            npc = new NPC().GenerateNPC();
            NPC npcComputerInfo = new NPC(npc);

            if (npc.IsIllegal) { NPC.SelectIDError(npc); }
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
                wrongAnswerLbl.Content = wrongAnswerLbl.Content + " " + npc.ErrorTypeString;
                wrongAnswerLbl.Visibility = Visibility.Visible;
                nextPersonLbl.Visibility = Visibility.Visible;
                acceptButton.Visibility = Visibility.Hidden;
                denyButton.Visibility = Visibility.Hidden;
            }
        }

        private void NextPersonButtonClick(object sender, MouseButtonEventArgs e)
        {
            npc = new NPC().GenerateNPC();
            NPC npcComputerInfo = new NPC(npc);

            if (npc.ErrorType == (int)Logic.IDErrorType.ExpirationDate)
            {
                npcComputerInfo = new NPC(npc);
            }

            UpdateNPCData(npc, npcComputerInfo);


            if (npcIDWindow != null && npcIDWindow.IsVisible)
            {
                npcIDWindow.UpdateNPCData(npc);
            }
            nextPersonLbl.Visibility = Visibility.Hidden;
            wrongAnswerLbl.Visibility = Visibility.Hidden;
            wrongAnswerLbl.Content = "Incorrect! the error was their";
            acceptButton.Visibility = Visibility.Visible;
            denyButton.Visibility = Visibility.Visible;
        }

        public void UpdateNPCData(NPC npc, NPC npcComputerInfo)
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
    }
}
