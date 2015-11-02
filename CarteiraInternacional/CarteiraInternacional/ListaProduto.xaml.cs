using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CarteiraInternacional.Resources;
using CarteiraInternacional.Entidade;
using CarteiraInternacional.Repositorio;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CarteiraInternacional
{
    public partial class ListaProduto : PhoneApplicationPage
    {
        Produto prod;

        //teste
        //Classificacao pag;


        private int id = 0;

        public ListaProduto()
        {
            InitializeComponent();
        }

        #region Metodos

        //protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        //{
        //    Navigate("/MainPage.xaml");

        //}


        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));

        }


        private void RefreshListaProd()
        {
            //ORIGINAL
            List<Produto> lista = Repositorio.ProdutoRepositorio.Get(id);
            lstProduto.ItemsSource = lista;

            #region Rascunho lista

            //teste
            //List<Classificacao> listag = Repositorio.ClassificRepositorio.Get(id);
            //lstCompras.ItemsSource = listag;


            #endregion


        }

        //ORIGINAL
        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            prod = (sender as ListBox).SelectedItem as Produto;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CadastroProd page = e.Content as CadastroProd;
            if (page != null)
                page.pro = prod;

        }

        #region Rascunho OnselectChange

        //private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        //{
        //    pag = (sender as ListBox).SelectedItem as Classificacao;
        //}


        #endregion



        #endregion

        #region Eventos

        private void appBarDelete(object sender, EventArgs e)
        {

            if (prod != null)
            {
                if (MessageBox.Show("Excluir Produto?") == MessageBoxResult.OK)
                {
                    //ORIGINAL
                    ProdutoRepositorio.DeleteObject(prod);

                    //ClassificRepositorio.DeleteObject(pag);
                    RefreshListaProd();

                }

            }
            else
            {
                MessageBox.Show("Selecione para excluir");
                return;
            }



        }

        private void appBarSobre_Click(object sender, EventArgs e)
        {
            //Navigate("/Sobre.xaml");
            Navigate("/MainPage.xaml");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshListaProd();
            //progress.Visibility = System.Windows.Visibility.Collapsed;
        }

        #endregion

        private void appBarEdit(object sender, EventArgs e)
        {

            if (prod != null)
            {
                Navigate("/CadastroProd.xaml");
            }
            else
            {
                if (MessageBox.Show("Selecione para Editar")
                    == MessageBoxResult.OK)
                { }
            }


        }
    }
}