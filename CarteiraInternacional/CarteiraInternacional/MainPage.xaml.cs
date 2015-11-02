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

            //Lista o ultimo valor desponivel do credito
            List<double> lista = Repositorio.CreditoRepositorio.GetOne();            

            //Lista a soma das compras efetuadas
            List<double> listaCompra = Repositorio.CompraRepositorio.GetOne();


            if (lista.Count() == 0)
            {
                //double aux = 0;
                lista.Add(0.00);
                //lista[1] = aux;
            }
            if (listaCompra.Count() == 0)
            {
               // double aux = 0;
                //listaCompra[1] = aux;
                listaCompra.Add(0.00);
            }

           
                TxtValor.Text = "Saldo disponivel R$ " + (Convert.ToString(lista.First())) + " Ultimo valor comprado " + (Convert.ToString(listaCompra.First()));
            
            
                 
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            List<double> lista = Repositorio.CreditoRepositorio.GetOne();

            List<double> listaCompra = Repositorio.CompraRepositorio.GetOne();

           // TxtValor.Text = "Saldo disponivel R$ " + (Convert.ToString(lista.First()));


          //  double soma = (Convert.ToDouble(lista.First())) + (Convert.ToDouble(listaCompra.Sum()));
                //(lista.First() + listaCompra.Sum());


            if (lista.Count() == 0)
            {
                lista.Add(0.00);
            }
            if (listaCompra.Count() == 0)
            {
                listaCompra.Add(0.00);
            }
            

            double soma = (Convert.ToDouble(lista.Sum())) - (Convert.ToDouble(listaCompra.Sum()));
            TxtValor.Text = "Saldo disponivel R$ " + (Convert.ToString(lista.Sum()))
                + "\n Total Comprado " + (Convert.ToString(listaCompra.Sum()))
                + "\n Soma = " + (Convert.ToString(listaCompra.Count()));

            //"\n Soma = " + (Convert.ToString(soma))
           
            //TxtValor.Text = "Saldo disponivel R$ " + (Convert.ToString(lista.First())) + (Convert.ToString(listaCompra.Sum()));

            //TxtValor.Text = "Saldo disponivel R$ " + (Convert.ToString(soma));

               

        }



        private void Calculadora_Click(object sender, RoutedEventArgs e)
        {
            //Navigate("/Moeda.xaml");
            Navigate("/Country.xaml");
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
          //  Navigate("/GraficoLinha.xaml");
           // Navigate("/testeJson.xaml");
           Navigate("/GraficoPivot.xaml");
           // MessageBox.Show("Em desenvolvimento");
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