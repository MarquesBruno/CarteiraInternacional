﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CarteiraInternacional
{
    public partial class DollarPage : PhoneApplicationPage
    {
        public DollarPage()
        {
            InitializeComponent();
        }

        private void Calculadora_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Em desenvolvimento");
        }

        private void Creditar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Em desenvolvimento");
        }

        private void Compras_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaCompras.xaml");
        }

       
        private void Relatorio_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Em desenvolvimento");
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