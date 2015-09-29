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
        public Produto prod { get; set; }
        public CadastroProd()
        {
            InitializeComponent();
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
            


            Produto produto = new Produto
            {
                NomeProduto = TxtNomeProd.Text,
                marca = TxtMarca.Text
                
            };

            ProdutoRepositorio.Create(produto);

            if (produto.referencia != 1)
            {
                MessageBox.Show("Cadastrado com Sucesso.");
            }
            else
            {
                MessageBox.Show("Esta informação já consta no banco de dados");
            }

            NavigationService.GoBack();

        }

        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }
    }
}