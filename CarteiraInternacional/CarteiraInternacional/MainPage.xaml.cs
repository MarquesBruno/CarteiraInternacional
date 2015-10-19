using System;
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
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            //List<string> lista = Repositorio.ClassificRepositorio.GetOne();
            List<double> lista = Repositorio.CreditoRepositorio.GetOne();
            TxtValor.Text = "Saldo disponivel R$ " + (Convert.ToString(lista.First()));
                 
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            List<double> lista = Repositorio.CreditoRepositorio.GetOne();
            TxtValor.Text = "Saldo disponivel R$ " + (Convert.ToString(lista.First()));          

        }



        private void Calculadora_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Em desenvolvimento");
        }

        private void Creditar_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaCredito.xaml");            
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