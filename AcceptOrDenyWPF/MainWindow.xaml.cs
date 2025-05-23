﻿using AcceptOrDenyLibrary;
using AcceptOrDenyWPF.Menu_Screens;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AcceptOrDenyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Bills bill = new Bills();
            Player player = new Player();
            Work work = new Work();
            MainWindowFrame.Navigate(new MainMenuScreen());
        }
    }
}