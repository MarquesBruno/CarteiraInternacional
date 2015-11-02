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

       // Classificacao classificacao;
        Classificacao pagina;
       // Estabelecimento estabelec;
        
        public Compra()
        {
            InitializeComponent();

            List<string> listaEstabelec = Repositorio.EstabelecRepositorio.GetOne();
            List<string> listaProduto = Repositorio.ProdutoRepositorio.GetOne();
            List<string> lista = Repositorio.ClassificRepositorio.GetOne();
            
           

            #region teste de busca

            
            //List<Estabelecimento> listaEstabelec = Repositorio.EstabelecRepositorio.GetOne();

            //foreach (var item in listaEstabelec)
            //{
            //    //if (item.id.Equals(pagina.id))
            //    //    //(item.nome.Equals(pagina.nome)
            //    //{                   
            //    listaTest = item.nome;
            //    //}
            //}
            
            #endregion
           


            

            this.lpkClassific.ItemsSource = lista;

            this.lpkEstabelecimento.ItemsSource = listaEstabelec;
            //this.lpkEstabelecimento.ItemsSource = listaTest;

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


            #region teste de busca

            //List<Estabelecimento> estabelecimentos = Repositorio.EstabelecRepositorio.GetOne();

            //foreach (var item in estabelecimentos)
            //{
            //    if (item.id.Equals(1))
            //    //    //(item.nome.Equals(pagina.nome)
            //    {
            //        listaTest = item.nome;
            //    }
            //}
            
            #endregion

            List<string> produtos = Repositorio.ProdutoRepositorio.GetOne();
            this.lpkClassific.ItemsSource = classificacoes;
            this.lpkEstabelecimento.ItemsSource = estabelecimentos;
            this.lpkProduto.ItemsSource = produtos;


        }




        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //String _Content = String.Format("Estabelecimento: {0}\n Produto: {1}\n Tipo: {2}\n Preço: R$ {3}", txtName.Text, txtProduto.Text, lpkCountry.SelectedItem, txtPreco.Text);
            //MessageBox.Show(_Content);


            if (lpkEstabelecimento.SelectedItem == null)
            {
                MessageBox.Show(" A Estabelecimento deve ser preenchido");
                return;
            }

            if (lpkProduto.SelectedItem == null)
            {
                MessageBox.Show(" A Produto deve ser preenchido");
                return;
            }

            if (lpkClassific.SelectedItem == null)
            {
                MessageBox.Show(" A Classificação deve ser preenchida");
                return;
            }

            if (txtPreco.Text == string.Empty)
            {
                MessageBox.Show("O Preço deve ser preenchido");
                return;
            }

            if (txtQtd.Text == string.Empty)
            {
                MessageBox.Show("A Quantidade deve ser preenchida");
                return;
            }

            Double aux = (Convert.ToDouble(txtPreco.Text));
            string resultado = string.Format("{0:00.##}", aux);

            CompraEntidade compra = new CompraEntidade
            {
                estabelecimento = (Convert.ToString(lpkEstabelecimento.SelectedItem)),
                produto = (Convert.ToString(lpkProduto.SelectedItem)),
                classificacao = (Convert.ToString(lpkClassific.SelectedItem)),
                preco = (Convert.ToDouble(resultado)),
                Data = DateTime.Now.ToString("dd/MM/yyyy"),
                qtd = (Convert.ToDouble(txtQtd.Text))


            };

            CompraRepositorio.Create(compra);

            MessageBox.Show("Compra Cadastrada com Sucesso.");

            Navigate("/ListaCompras.xaml");






        }

        private void btnClassificar_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroClassif.xaml");
        }

        
        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            pagina = (sender as ListBox).SelectedItem as Classificacao;
        }



        private void lpkClassific_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           object classific = (sender as ListPicker).SelectedItem as Classificacao;
        }

        private void lpkEstabelec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object estabelec = (sender as ListPicker).SelectedItem as Estabelecimento;
        }

        private void lpkProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object pagiprodut = (sender as ListPicker).SelectedItem as Produto;
        }





        //private void btnExcluir_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("Excluir Classificação " + lpkClassific.SelectedItem + "?") == MessageBoxResult.OK)
        //        {

        //            string nome = lpkClassific.SelectedItem.ToString();
        //           ClassificRepositorio.Delete(nome);
        //            Refresh();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Selecione uma Classificação para excluir");
        //        return;
        //    }

        //}

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaClassific.xaml");
        }

        private void btnAdd_Estabelec_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroEstabelec.xaml");
        }

        //private void btnExcluir_Estabelec_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("Excluir Estabelecimento " + lpkEstabelecimento.SelectedItem + "?") == MessageBoxResult.OK)
        //        {

        //            string nome = lpkEstabelecimento.SelectedItem.ToString();
        //            EstabelecRepositorio.Delete(nome);
        //            Refresh();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Selecione uma Estabelecimento para excluir");
        //        return;
        //    }

        //}

        private void btnExcluir_Estabelec_Click(object sender, RoutedEventArgs e)
        {                 
            Navigate("/ListaEstabelecimento.xaml");
        }






















        

        private void btnAdd_Prod_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroProd.xaml");
        }

        //private void btnExcluir_Prod_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("Excluir Produto " + lpkProduto.SelectedItem + "?") == MessageBoxResult.OK)
        //        {

        //            string nome = lpkProduto.SelectedItem.ToString();
        //            ProdutoRepositorio.Delete(nome);
        //            Refresh();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Selecione um Produto para excluir");
        //        return;
        //    }
        //}

        private void btnExcluir_Prod_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaProduto.xaml");
        }

        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }

        private void btn_Inf_Click(object sender, RoutedEventArgs e)
        {
          //object extra = EstabelecRepositorio.Get(pagina.id);
          //  String _Content = String.Format("Estabelecimento: {0}", lpkEstabelecimento.SelectedItem);
          //      //lpkEstabelecimento.ItemsSource);
          //  MessageBox.Show(_Content);






        }

        
        

    }
}