using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CarteiraInternacional.Resources;

namespace CarteiraInternacional
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();            
        }

        private void Euro_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Em desenvolvimento");
        }

        private void Dollar_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/DollarPage.xaml");
        }
       

        private void Informacoes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Em desenvolvimento");
        }
         
        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }

       


    }
}