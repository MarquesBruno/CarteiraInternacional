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
using Newtonsoft.Json.Linq;

namespace CarteiraInternacional
{
    public partial class Country : PhoneApplicationPage
    {
        Cota pagina;
        Origem ori;
        private int id = 0;
        public Country()
        {
            InitializeComponent();
            
            Refresh();
          
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            Refresh();
        }

       





        private void Refresh()
        {
            List<string> busca = Repositorio.OrigemRepositorio.GetOne();

            if (busca.Count == 0)
            {
                ParseJson();
                List<string> listaMoedas = Repositorio.OrigemRepositorio.GetOne();
                this.lpkMoedas.ItemsSource = listaMoedas;

               // List<Cota> listaFav = Repositorio.CotaRepositorio.Get(id);

                string apelido = lpkMoedas.SelectedItem.ToString();
                List<Cota> listaFav = Repositorio.CotaRepositorio.ListaNome(apelido);
                this.LstMoedas.ItemsSource = listaFav;
                
            }
            else
            {
                List<string> listaMoedas = Repositorio.OrigemRepositorio.GetOne();                
                this.lpkMoedas.ItemsSource = listaMoedas;

                //List<Cota> listaFav = Repositorio.CotaRepositorio.Get(id);
                string apelido = lpkMoedas.SelectedItem.ToString();
                List<Cota> listaFav = Repositorio.CotaRepositorio.ListaNome(apelido);
                this.LstMoedas.ItemsSource = listaFav;
                

            }

            //this.lpkMoedas.ItemsSource = listaMoedas;
        }

        private void lpkMoedas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object moedaSelect = (sender as ListPicker).SelectedItem as Classificacao;
        }

        private void Criacao(Origem moeda)
        {
            //List<Origem> listaMoedas = GetMoeda();

            OrigemRepositorio.Create(moeda);        
        }

        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            pagina = (sender as ListBox).SelectedItem as Cota;
        }



        //private List<Origem> GetMoeda()
        //{
        //   // string Json = Utils.Utils.ReadFile("Resources/Json/paises.json");
        //    return ParseJson(Json);
        //}

        private void ParseJson()
        {
            string Json = Utils.Utils.ReadFile("Resources/Json/paises.json");
            //criar objeto para lista do tipo carro
            //List<Origem> MoedasDoJson = new List<Origem>();

            if (Json != null)
            {
                //faz o parse para um tipo jobject
                JObject jobject = JObject.Parse(Json);

                //le a lista carros
                JObject jobjectMoedas = (JObject)jobject["moedas"];

                //captura o array carro
                JArray moedas = (JArray)jobjectMoedas["moeda"];

                //percorre o array e faz o parse para o nosso tipo "car"
                foreach (JObject item in moedas)
                {
                    int i = moedas.Count;
                    Origem moeda = new Origem
                    {                           
                        nome = (string)item["nome"],
                        pais = (string)item["pais"],
                        sigla = (string)item["sigla"]

                    };
                    //MoedasDoJson.Add(moeda);                   
                    Criacao(moeda);
                    
                   
                }


            };
            //return MoedasDoJson;
        }

        private void appBarCheck_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Navigate("/Moeda.xaml?nome=" + lpkMoedas.SelectedItem);
            }
            catch
            {
                MessageBox.Show("Selecione uma moeda para acessar");
                return;
            }
        }
        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));
        }

        private void appBarDelete(object sender, EventArgs e)
        {
            if (pagina != null)
            {
                if (MessageBox.Show("Excluir Favorito ?") == MessageBoxResult.OK)
                {
                    CotaRepositorio.Delete(pagina);
                    Refresh();
                    MessageBox.Show("Excluido com sucesso");
                    return;

                }

            }
            else
            {
                MessageBox.Show("Selecione para excluir");
                return;
            }
        }



        //private void Pivot_LoadedPivotItem(object sender, PivotItemEventArgs e)
        //{
        //    if (e.Item == esportivos)
        //        LstEsportivos.ItemsSource = GetCars("esportivos");
        //    else
        //        if (e.Item == classicos)
        //            LstClassicos.ItemsSource = GetCars("classicos");
        //        else

        //            LstLuxos.ItemsSource = GetCars("luxo");


        //}



    }
}