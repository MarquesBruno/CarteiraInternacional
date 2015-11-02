using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CarteiraInternacional.Entidade;
using CarteiraInternacional.Repositorio;

namespace CarteiraInternacional
{
    public partial class CadastroProd : PhoneApplicationPage
    {
        public Produto pro { get; set; }
        public CadastroProd()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CadastroProd page = e.Content as CadastroProd;

            // if (est.referencia == 2)
            if (pro != null)
            {
                TxtId.Text = pro.id.ToString();
                TxtNomeProd.Text = pro.NomeProduto;
                TxtMarca.Text = pro.marca;

                TxtId.IsEnabled = false;

            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (pro != null)
            {
                TxtTitulo.Text = "Editar Produto";
                TxtId.Text = pro.id.ToString();
                TxtNomeProd.Text = pro.NomeProduto;
                TxtMarca.Text = pro.marca;

                TxtId.IsEnabled = false;

            }

        }













        private void btnProd_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNomeProd.Text == string.Empty)
            {
                MessageBox.Show(" O Nome deve ser preenchido");
                return;
            }

            if (TxtMarca.Text == string.Empty)
            {
                MessageBox.Show(" A Marca deve ser preenchida");
                return;
            }


            if (pro != null)
            {
                pro.id = int.Parse(TxtId.Text);
                pro.NomeProduto = TxtNomeProd.Text;
                pro.marca = TxtMarca.Text;


                ProdutoRepositorio.Update(pro);
                MessageBox.Show("Dados Alterados com sucesso.");
            }

            if (pro == null)
            {
                Produto produto = new Produto
                {
                    id = int.Parse(TxtId.Text),
                    NomeProduto = TxtNomeProd.Text,
                    marca = TxtMarca.Text

                };
                // Uri caminho = new Uri("/ProvaRepositorio.cs?parametro=" + TxtId.Text, UriKind.RelativeOrAbsolute); 
                ProdutoRepositorio.Create(produto);
                MessageBox.Show("Produto Cadastrado com Sucesso.");
            }









            


            //Produto produto = new Produto
            //{
            //    NomeProduto = TxtNomeProd.Text,
            //    marca = TxtMarca.Text
                
            //};

            //ProdutoRepositorio.Create(produto);

            //if (produto.referencia != 1)
            //{
            //    MessageBox.Show("Cadastrado com Sucesso.");
            //}
            //else
            //{
            //    MessageBox.Show("Esta informação já consta no banco de dados");
            //}

            NavigationService.GoBack();

        }

        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }
    }
}