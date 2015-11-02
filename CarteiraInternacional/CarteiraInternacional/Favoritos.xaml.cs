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
    public partial class Favoritos : PhoneApplicationPage
    {
        Cota pagina;
        private int id = 0;

        public Favoritos()
        {
            InitializeComponent();
        }

        #region Metodos



        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));

        }


        private void RefreshFavoritos()
        {
            List<Cota> listaFav = Repositorio.CotaRepositorio.Get(id);
            lstFavoritos.ItemsSource = listaFav;

        }

        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            pagina = (sender as ListBox).SelectedItem as Cota;
        }










        #endregion

        #region Eventos

        private void appBarDelete(object sender, EventArgs e)
        {

            if (pagina != null)
            {
                if (MessageBox.Show("Excluir Favorito ?") == MessageBoxResult.OK)
                {
                    CotaRepositorio.Delete(pagina);
                    RefreshFavoritos();

                }

            }
            else
            {
                MessageBox.Show("Selecione para excluir");
                return;
            }



        }

       

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshFavoritos();
            //progress.Visibility = System.Windows.Visibility.Collapsed;
        }

        #endregion
    }
}