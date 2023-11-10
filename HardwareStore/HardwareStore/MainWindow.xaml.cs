using HardwareStore.Components;
using HardwareStore.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HardwareStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigation.mainWindow = this;
            Navigation.NextPage(new PageComponents(new ProductPage()));


        }
        private void AdmBTN_Click(object sender, RoutedEventArgs e)
        {
            if (passTB.Password == "0000")
            {
                App.IsAdm = true;
                AdmExitBtn.Visibility = Visibility.Visible;
                Navigation.ClearHistory();
                Navigation.NextPage(new PageComponents(new ProductPage()));
            }
        }

        private void AdmExitBtn_Click(object sender, RoutedEventArgs e)
        {
            App.IsAdm = false;
                AdmExitBtn.Visibility = Visibility.Collapsed;
                Navigation.BackPage();
                passTB.Password = "";
                Navigation.ClearHistory();
        }

        private void BackBTn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }


        //private void AdmExitBtn_Click_1(object sender, RoutedEventArgs e)
        //{
        //    App.IsAdm = false;
        //    {
        //        AdmExitBtn.Visibility = Visibility.Collapsed;
        //        Navigation.BackPage();
        //        passTB.Password = "";
        //        Navigation.ClearHistory();
        //    }
        //}
    }
}
