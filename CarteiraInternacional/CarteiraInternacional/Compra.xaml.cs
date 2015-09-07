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
            this.lpkCountry.ItemsSource = lista;
            

           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            List<String> disciplinas = Repositorio.ClassificRepositorio.GetOne();
            this.lpkCountry.ItemsSource = disciplinas;



        }




        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            String _Content = String.Format("Estabelecimento: {0}\n Produto: {1}\n Tipo: {2}\n Preço: R$ {3}", txtName.Text, txtAges.Text, lpkCountry.SelectedItem, txtPreco.Text );

            
            MessageBox.Show(_Content);

        }

        private void btnClassificar_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroClassif.xaml");
        }

        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));           
        }
        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            pagina = (sender as ListBox).SelectedItem as Classificacao;
        }

        private void lpkCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           object pagina = (sender as ListPicker).SelectedItem as Classificacao;
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

        

    }
}