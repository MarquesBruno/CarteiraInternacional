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
using CarteiraInternacional.Entidade;
using Newtonsoft.Json.Linq;
using CarteiraInternacional.Repositorio;

namespace CarteiraInternacional
{
    public partial class Moeda : PhoneApplicationPage
    {

        // Cota ObejtoCotacao = null;
        //Cep CepDoJson = null;
        //  string variavel = "Cotacao";
        Cota CotaDoJson = null;
        private string nome = null;
        string siglaAux = null;

        // Constructor
        public Moeda()
        {
            InitializeComponent();
        }

        #region Exemplo Baseado nos Carros  aula 14

        //////////////////////////////////////////////////////////////////

        //private List<Cota> GetCars(string pTipoCarro)
        //{
        //    //string Json = "http://www.livrowindows8.com.br/carros/carros_luxo.json";
        //   string Json = Utils.Utils.ReadFile("http://www.livrowindows8.com.br/carros/carros_luxo.json");

        //    return ParseJson(Json);
        //}


        private void GetCars()
        {


            WebClient rssClient = new WebClient();


            // rssClient.DownloadStringCompleted += rssClient_DownloadStringCompleted;
            rssClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(rssClient_DownloadStringCompleted);

            //rssClient.DownloadStringCompleted +=
            //    new DownloadStringCompletedEventHandler(rssClient_DownloadStringCompleted);


            //rssClient.DownloadStringAsync(new Uri(@"http://morpheu269.url.ph/" + variavel + ".json"));
            //rssClient.DownloadStringAsync(new Uri(@"http://developers.agenciaideias.com.br/cotacoes/json"));
             rssClient.DownloadStringAsync(new Uri(@"http://api.xgeek.com.br/taxa-cambio/currency?code="+siglaAux+""));
           


        }

        void rssClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            double aux = 0;
            double total = 0;
            titulo.Text = nome;

            try
            {
                // Cota cot = ParseJson(e.Result);
                List<Cota> cot = ParseJson(e.Result);
                CotaDoJson = cot.Last();
            }
            catch
            {
                MessageBox.Show("Sem Conexao com internet.");
                return;
            }
            // double valorDouble = Convert.ToDouble(CotaDoJson.indice);


            double valorDouble = CotaDoJson.indice;
          //  string moeda = CotaDoJson.moeda;
            string DataCompleta = CotaDoJson.data_consulta;

            string ano = DataCompleta.Substring(2,2);
            string mes = DataCompleta.Substring(5,2);
            string day = DataCompleta.Substring(8,2);



            //String d2 = d1.substring(0, 2) + "/" + d1.substring(2, 4) + "/" + d1.substring(4, 8); 

            string hora = DataCompleta.Substring(11, 3) + DataCompleta.Substring(14, 2);



            double aux2 = valorDouble;
            //try
            //{

            if (TxtDolar.Text == "")
                TxtDolar.Text = "1";
            aux = Convert.ToDouble(TxtDolar.Text);
            total = aux2 * aux;

            string resultado = string.Format("{0:0.##}", total);
            // string resultado = Convert.ToString(total);

            TxtResultado.Text = "R$ " + resultado;
            TxtAtual.Text = "Ultima Atualização " + day +"/"+ mes +"/"+ ano;
            TxtHora.Text = "Hora da atualização " + hora;
            TxtIndice.Text = "  US$ 1,00 = R$ " + valorDouble;
            //}
            //catch
            //{
            //    MessageBox.Show("Informe um valor");
            //    Navigate("/MainPage.xaml"); 

            //}


            //NavigationService.Navigate(new Uri("/Result.xaml", UriKind.Relative));

        }

        //#region Teste de conexao exemplo

        //public static boolean isOnline(Context context)
        //{
        //    ConnectivityManager cm = (ConnectivityManager)context.getSystemService(Context.CONNECTIVITY_SERVICE);
        //    NetworkInfo netInfo = cm.getActiveNetworkInfo();
        //    if (netInfo != null && netInfo.isConnected())
        //        return true;
        //    else
        //        return false;
        //}



        //#endregion









        ///////////////////////////////////////////////////////////








        private List<Cota> ParseJson(string pJson)
        {
            //criar objeto para lista do tipo carro
            List<Cota> CarrosDoJson = new List<Cota>();

            if (pJson != null)
            {
                //faz o parse para um tipo jobject
                JObject jobject = JObject.Parse(pJson);

                //le a lista carros
                //JObject jobjectCotas = (JObject)jobject["dolar"];
                double valor = (double)jobject["buying_rate"];


                //JObject jobjectData = (JObject)jobject["atualizacao"];

                //JObject jobjectData = (JObject)jobject[Data];
                string Data = (string)jobject["last_update"];

                //DateTime day =  Convert.ToDateTime(Data);
                //captura o array carro
                // JArray lista = (JArray)jobjectCotas["cotacao"];

                //percorre o array e faz o parse para o nosso tipo "car"
                //foreach (JObject item in lista)
                //{


                Cota money = new Cota
                {
                    indice = valor,
                    data_consulta = Data,
                    moeda = nome,

                    // data_consulta = (DateTime)jobjectData["atualizacao"],
                    //data_consulta = DateTime.Parse(Data),
                    //data_consulta = Convert.ToDateTime(Data),
                    //(DateTime)jobjectData,
                    //Descricao = (string)item["desc"],
                    //Imagem = (string)item["url_foto"]
                };
                CarrosDoJson.Add(money);
                //}

            }
            return CarrosDoJson;
        }

        //private void Pivot_LoadedPivotItem(object sender, PivotItemEventArgs e)
        //{



        //    //if (e.Item == esportivos)
        //    //    LstEsportivos.ItemsSource = GetCars("esportivos");
        //    //else
        //    //    if (e.Item == classicos)
        //    //        LstClassicos.ItemsSource = GetCars("classicos");
        //    //    else

        //            //LstLuxos.ItemsSource = GetCars("luxo");RequisicaoHTTP()
        //    LstLuxos.ItemsSource = GetCars();

        //}










        #endregion



        #region Exemplo baseado no Cep

        //private void ConsultarCep()
        //{
        //    WebClient rssClient = new WebClient();

        //    rssClient.DownloadStringCompleted += rssClient_DownloadStringCompleted;

        //    rssClient.DownloadStringCompleted +=
        //        new DownloadStringCompletedEventHandler(rssClient_DownloadStringCompleted);


        //    rssClient.DownloadStringAsync(new Uri(@"http://morpheu269.url.ph/Cotacao.json"));

        //}
        //void rssClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        //{
        //    Cep cep = ParseJson(e.Result);
        //    double valorDouble = Convert.ToDouble(CepDoJson.Localidade);
        //    double aux = Convert.ToDouble(TxtDolar.Text);

        //    valorDouble = valorDouble * aux;
        //    TxtLocalidade.Text = "R$ " + Convert.ToString(valorDouble);
        //    TxtAtual.Text = "Ultima Atualização " + CepDoJson.UF;


        //    //NavigationService.Navigate(new Uri("/Result.xaml", UriKind.Relative));

        //}
        //private Cep ParseJson(string pJson)
        //{


        //    if (pJson != null)
        //    {
        //        //faz o parse para um tipo jobject
        //        JObject jobject = JObject.Parse(pJson);

        //        CepDoJson = new Cep
        //        {
        //            Bairro = (string)jobject["bairro"],
        //            Localidade = (string)jobject["indice"],
        //            NumeroCep = (string)jobject["cep"],
        //            Logradouro = (string)jobject["logradouro"],
        //            UF = (string)jobject["atual"]
        //        };


        //    }
        //    return CepDoJson;
        //}

        #endregion





        #region Eventos




        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
           // RefreshOpcao();
            GetCars();
            //vamos acessar o web service
            // ConsultarCep();
        }



        #endregion

        private void appBarFavoritos_Click(object sender, EventArgs e)
        {
            Navigate("/Country.xaml");
        }

        private void appBarAddFavoritos_Click(object sender, EventArgs e)
        {
            if (CotaDoJson != null)
            {


                CotaRepositorio.Create(CotaDoJson);

                if (CotaDoJson.resultado != 1)
                {
                    Navigate("/Country.xaml");
                    MessageBox.Show("Favorito salvo com Sucesso.");
                }
                else
                {
                    MessageBox.Show("Esta informação já consta no banco de dados.");
                }


            }
            else
            {
                MessageBox.Show("Consulte para carregar os dados");
            }

        }

       

        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));
        }

       

        private void RefreshOpcao()
        {
            List<string> escolha = Repositorio.OrigemRepositorio.Get(nome);

            siglaAux = escolha[0];

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string nomeParametro = "";

            if (NavigationContext.QueryString.TryGetValue("nome", out nomeParametro))
            {
                nome = nomeParametro;
                //OrigemRepositorio.Get(nome);
            }
            RefreshOpcao();
        }






    }
}