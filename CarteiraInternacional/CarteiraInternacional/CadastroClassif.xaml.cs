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
    public partial class CadastroClassif : PhoneApplicationPage
    {
        public Classificacao cla { get; set; }
        public CadastroClassif()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CadastroClassif page = e.Content as CadastroClassif;

            // if (est.referencia == 2)
            if (cla != null)
            {
                TxtId.Text = cla.id.ToString();
                TxtClassif.Text = cla.nome;                

                TxtId.IsEnabled = false;

            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (cla != null)
            {
                TxtTitulo.Text = "Editar Produto";
                TxtId.Text = cla.id.ToString();
                TxtClassif.Text = cla.nome;

                TxtId.IsEnabled = false;

            }

        }







        private void btnClassif_Click(object sender, RoutedEventArgs e)
        {
            if (TxtClassif.Text == string.Empty)
            {
                MessageBox.Show(" A Classificação deve ser preenchida");
                return;
            }

            if (cla != null)
            {
               
                cla.id = int.Parse(TxtId.Text);
                cla.nome = TxtClassif.Text;


                ClassificRepositorio.Update(cla);
                MessageBox.Show("Dados Alterados com sucesso.");
            }

            if (cla == null)
            {
                Classificacao classificacao = new Classificacao
                {
                    id = int.Parse(TxtId.Text),
                    nome = TxtClassif.Text

                };
                // Uri caminho = new Uri("/ProvaRepositorio.cs?parametro=" + TxtId.Text, UriKind.RelativeOrAbsolute); 
                ClassificRepositorio.Create(classificacao);
                MessageBox.Show("Categoria Cadastrada com Sucesso.");
            }







            
            
            //Classificacao classificacao = new Classificacao
            //{
            //    nome = TxtClassif.Text
            //};

            //ClassificRepositorio.Create(classificacao);

            //if (classificacao.referencia != 1)
            //{
            //    //Navigate("Compra.xaml");                
            //    MessageBox.Show("Cadastrada com Sucesso.");
            //}
            //else
            //{
            //    MessageBox.Show("Esta informação já consta no banco de dados");
            //}

            //ClassificRepositorio.Create(classificacao);
            //MessageBox.Show("Cadastrada com Sucesso.");

            
            NavigationService.GoBack();

           
        }

        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }
    }
}