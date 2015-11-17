using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CarteiraInternacional.Entidade;
using CarteiraInternacional.Repositorio;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CarteiraInternacional
{
    public partial class ListaCompras : PhoneApplicationPage
    {
        CompraEntidade pagina;

        //teste
        //Classificacao pag;


        private int id = 0;

        public ListaCompras()
        {
            InitializeComponent();
        }

        #region Metodos

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //Navigate("/MainPage.xaml");
            NavigationService.GoBack();

        }


        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));

        }


        private void RefreshListaCompras()
        {
            //ORIGINAL
            List<CompraEntidade> lista = Repositorio.CompraRepositorio.Get(id);
            lstCompras.ItemsSource = lista;
            
            #region Rascunho lista

            //teste
            //List<Classificacao> listag = Repositorio.ClassificRepositorio.Get(id);
            //lstCompras.ItemsSource = listag;


            #endregion          


        }

        //ORIGINAL
        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            pagina = (sender as ListBox).SelectedItem as CompraEntidade;
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
            if (pagina != null)
            {
                if (MessageBox.Show("Excluir Produto ?") == MessageBoxResult.OK)
                {



                    List<double> listaPreco = Repositorio.ClassificRepositorio.GetPreco(pagina.classificacao);
                    List<Classificacao> listaTudo = Repositorio.ClassificRepositorio.Busca();


                    if (listaPreco.Count() != 0)
                    {

                        foreach (var item in listaTudo)
                        {
                            if (item.nome == Convert.ToString(pagina.classificacao))
                            {
                                Classificacao classific = new Classificacao
                                {
                                    id = item.id,
                                    nome = item.nome,
                                    referencia = item.referencia,
                                    total = listaPreco.Sum() - pagina.preco
                                };
                                ClassificRepositorio.Update(classific);

                            }

                        }


                    }



                    //ORIGINAL
                    CompraRepositorio.DeleteObject(pagina);

                    //ClassificRepositorio.DeleteObject(pag);
                    RefreshListaCompras();

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
            RefreshListaCompras();
            //progress.Visibility = System.Windows.Visibility.Collapsed;
        }

        #endregion

        private void appBarAdd(object sender, EventArgs e)
        {
            Navigate("/Compra.xaml");
        }
    }
}