﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CarteiraInternacional.Resources;
using System.Windows.Media;
using System.Windows.Input;
using CarteiraInternacional.Entidade;
using CarteiraInternacional.Repositorio;
namespace CarteiraInternacional
{
    public partial class Compra : PhoneApplicationPage
    {

        Classificacao classificacao;
        Classificacao pagina;
        public Compra()
        {
            InitializeComponent();
            List<string> lista = Repositorio.ClassificRepositorio.GetOne();
            List<string> listaEstabelec = Repositorio.EstabelecRepositorio.GetOne();
            List<string> listaProduto = Repositorio.ProdutoRepositorio.GetOne();

            this.lpkCountry.ItemsSource = lista;
            this.lpkEstabelecimento.ItemsSource = listaEstabelec;
            this.lpkProduto.ItemsSource = listaProduto;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            List<String> classificacoes = Repositorio.ClassificRepositorio.GetOne();
            List<string> estabelecimentos = Repositorio.EstabelecRepositorio.GetOne();
            List<string> produtos = Repositorio.ProdutoRepositorio.GetOne();
            this.lpkCountry.ItemsSource = classificacoes;
            this.lpkEstabelecimento.ItemsSource = estabelecimentos;
            this.lpkProduto.ItemsSource = produtos;

        }




        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            String _Content = String.Format("Estabelecimento: {0}\n Produto: {1}\n Tipo: {2}\n Preço: R$ {3}", lpkEstabelecimento.SelectedItem, lpkProduto.SelectedItem, lpkCountry.SelectedItem, txtPreco.Text);
            MessageBox.Show(_Content);

        }

        private void btnClassificar_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroClassif.xaml");
        }

        
        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            pagina = (sender as ListBox).SelectedItem as Classificacao;
        }

        private void lpkCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           object pagina = (sender as ListPicker).SelectedItem as Classificacao;
        }

        private void lpkEstabelec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object pagina = (sender as ListPicker).SelectedItem as Estabelecimento;
        }

        private void lpkProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object pagina = (sender as ListPicker).SelectedItem as Produto;
        }





        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Excluir Classificação " + lpkCountry.SelectedItem + "?") == MessageBoxResult.OK)
                {

                    string nome = lpkCountry.SelectedItem.ToString();
                   ClassificRepositorio.Delete(nome);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione uma Classificação para excluir");
                return;
            }

        }

        private void btnAdd_Estabelec_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroEstabelec.xaml");
        }

        private void btnExcluir_Estabelec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Excluir Estabelecimento " + lpkEstabelecimento.SelectedItem + "?") == MessageBoxResult.OK)
                {

                    string nome = lpkCountry.SelectedItem.ToString();
                    ClassificRepositorio.Delete(nome);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione uma Estabelecimento para excluir");
                return;
            }

        }

        

        private void btnAdd_Prod_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroProd.xaml");
        }

        private void btnExcluir_Prod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Excluir Produto " + lpkProduto.SelectedItem + "?") == MessageBoxResult.OK)
                {

                    string nome = lpkProduto.SelectedItem.ToString();
                    ProdutoRepositorio.Delete(nome);
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione um Produto para excluir");
                return;
            }
        }


        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }

        private void btn_Inf_Click(object sender, RoutedEventArgs e)
        {
            String _Content = String.Format("Estabelecimento: {0}", lpkEstabelecimento.ItemsSource);
            MessageBox.Show(_Content);
        }
        

    }
}