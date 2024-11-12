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
using System.Windows.Shapes;

namespace AcceptOrDenyWPF
{
    /// <summary>
    /// Interaction logic for NpcIDWindow.xaml
    /// </summary>
    public partial class NpcIDWindow : Window
    {
        public NpcIDWindow(NPC npc)
        {
            InitializeComponent();

            UpdateNPCData(npc);
        }

        public void UpdateNPCData(NPC npc)
        {
            npcFirstNameLbl.Content = npc.FirstName;
            npcLastNameLbl.Content = npc.LastName;
            npcDateOfBirthLbl.Content = npc.FullBirthdate;
            npcGenderLbl.Content = npc.Gender;
            npcStreetAddressLbl.Content = npc.FullStreetAddress;
            npcIdExpirationLbl.Content = npc.FullExpirationDate;
        }
    }
}
