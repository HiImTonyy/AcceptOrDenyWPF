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
    /// Interaction logic for WorkComputerScreen.xaml
    /// </summary>
    public partial class WorkComputerScreen : Page
    {
        private Bills bill;
        private NPC npc;
        private Player player;
        private Work work;

        public WorkComputerScreen(Bills bill, Player player, Work work)
        {
            InitializeComponent();

            this.bill = bill;
            this.player = player;
            this.work = work;

            Work.Working(bill, player, work);
        }
    }
}
