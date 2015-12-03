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
using CarteiraInternacional.Banco;
using Newtonsoft.Json.Linq;
using CarteiraInternacional.Repositorio;

namespace CarteiraInternacional
{
    public partial class GraficoSeletivoCopia : PhoneApplicationPage
    {
        private int id = 0;

        List<LineChart> MoedasDoJson = new List<LineChart>();
        List<PChart> PeriodosDoJson = new List<PChart>();
        List<PChart> EmPizza = new List<PChart>();
        List<PChart> EmPizzaZero = new List<PChart>();
        List<Aux> CompraAux = new List<Aux>();
        //Aux compras = null;
        //Classificacao classific = null;
        List<PChart> nulado = new List<PChart>();
        PChart DataSource = null;


        public GraficoSeletivoCopia()
        {
            InitializeComponent();
            RefreshListaMoedas();
            RefreshPieChart();
        }

        


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            RefreshListaMoedas();
            RefreshPieChart();
           
            
            chart1.DataSource = null;

            if(PC1.DataSource != null)
                PC1.DataSource = null;
            #region rascunho
//PC1.DataSource = nulado;
            
            //try
            //{
            //    PC1.DataSource = s;
                 
            //}
            //catch
            //{
            //    PC1.DataSource = EmPizza;
            //}
  



	#endregion
            PC1.DataSource = EmPizza;             
            chart1.DataSource = MoedasDoJson;
           
            
        }






        #region Grafico em linha


        private List<LineChart> RefreshListaMoedas()
        {
            MoedasDoJson.Clear();

            List<string> busca = Repositorio.OrigemRepositorio.GetOne();

            if (busca.Count == 0)
            {
                ParseJsonMoedas();
                List<string> listaMoedas = Repositorio.OrigemRepositorio.GetOne();
                this.lpkMoedas.ItemsSource = listaMoedas;

                // List<Cota> listaFav = Repositorio.CotaRepositorio.Get(id);

                string apelido = lpkMoedas.SelectedItem.ToString();
                List<Cota> lista = Repositorio.CotaRepositorio.ListaNome(apelido);
               // this.LstMoedas.ItemsSource = listaFav;

            }
            else
            {
                List<string> listaMoedas = Repositorio.OrigemRepositorio.GetOne();
                this.lpkMoedas.ItemsSource = listaMoedas;

                //List<Cota> listaFav = Repositorio.CotaRepositorio.Get(id);
                string apelido = lpkMoedas.SelectedItem.ToString();
                List<Cota> lista = Repositorio.CotaRepositorio.ListaNome(apelido);
             //   this.LstMoedas.ItemsSource = listaFav;




            //ORIGINAL
           // List<CompraEntidade> lista = Repositorio.CompraRepositorio.Get(id);
            // List<LineChart> CarrosDoJson = new List<LineChart>();

            foreach (var item in lista)
            {
                

                DateTime dt = Convert.ToDateTime(item.data_consulta);
                Console.WriteLine("Year: {0}, Month: {1}, Day: {2}", dt.Year, dt.Month, dt.Day);

                LineChart lineChart = new LineChart                
                {                    
                    label = Convert.ToString(dt.Day) + "/" + Convert.ToString(dt.Month),
                    val1 = Convert.ToDouble(item.indice.ToString("0.000"))

                    //meuNumeroDouble.ToString("0.00");
                    //val1 = item.indice
                };
                MoedasDoJson.Add(lineChart); 


                //  new LineChart() { label = item.Data, val1 = item.preco};

                // new LineChart() { label = "02/10", val1 = 3.953/10} 
            }

            }


            #region Rascunho lista

            //teste
            //List<Classificacao> listag = Repositorio.ClassificRepositorio.Get(id);
            //lstCompras.ItemsSource = listag;


            #endregion

            return MoedasDoJson;
        }

        private void lpkMoedas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object moedaSelect = (sender as ListPicker).SelectedItem as Classificacao;
        }
        private void lpkPeriodos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object peridoSelect = (sender as ListPicker).SelectedItem as Classificacao;
        }
        
        #endregion




        #region Grafico Pizza





        private List<PChart> RefreshPieChart()
        {

            EmPizza.Clear();
            

            List<string> busca = Repositorio.PeriodoRepositorio.GetOne();

            if (busca.Count == 0)
            {
                
                ParseJsonPeriodos();
                List<string> listaPeriodos = Repositorio.PeriodoRepositorio.GetOne();
                this.lpkPeriodos.ItemsSource = listaPeriodos;

                // List<Cota> listaFav = Repositorio.CotaRepositorio.Get(id);

                string mes = lpkPeriodos.SelectedItem.ToString();

                List<string> periodo = Repositorio.PeriodoRepositorio.BuscaPeriodo(mes);
                string per = Convert.ToString(periodo);
                //List<Classificacao> lista = Repositorio.ClassificRepositorio.ListaNome(per);
                // this.LstMoedas.ItemsSource = listaFav;

            }
            else
            {

                //PC1.DataSource = EmPizza;

                List<string> listaPeriodos = Repositorio.PeriodoRepositorio.GetOne();
                this.lpkPeriodos.ItemsSource = listaPeriodos;

                // List<Cota> listaFav = Repositorio.CotaRepositorio.Get(id);

                string mes = lpkPeriodos.SelectedItem.ToString();

                List<string> periodo = Repositorio.PeriodoRepositorio.BuscaPeriodo(mes);
                string per = periodo[0];
                
               // List<Classificacao> lista = Repositorio.ClassificRepositorio.ListaNome(per);
                List<Classificacao> listaTudo = Repositorio.ClassificRepositorio.Busca();

               List<double> listaPreco = Repositorio.CompraRepositorio.GetPreco(per);

                List<CompraEntidade> listaPeriodo = Repositorio.CompraRepositorio.GetPeriodo(per);

                




                if (listaPeriodo.Count != 0)
                {         


                    //Resetar Classificação
                foreach (var item in listaTudo)
                {
                    Classificacao classific = new Classificacao
                        {
                            id = item.id,
                            nome = item.nome,
                            referencia = 0,
                            //total = listaPreco.Sum()
                            total = 0

                        };

                    ClassificRepositorio.Update(classific);
                }













                //Aux CompraAux;
                foreach (var item in listaPeriodo)
                {
                    foreach (var itemClassific in listaTudo)
                    {
                        if (item.classificacao == itemClassific.nome && itemClassific.referencia == 0)
                        {
                            //List<double> listaTotal = Repositorio.PeriodoRepositorio.buscaTotal(com);
                            Aux compras = new Aux
                            {
                                id = item.id,
                                preco = item.preco,
                                classificacao = item.classificacao,
                                periodo = item.periodo,
                                


                            };
                           List<double> listaTotal = Repositorio.PeriodoRepositorio.buscaTotal(compras);


                            Classificacao classific = new Classificacao
                                {
                                    id = itemClassific.id,
                                    nome = itemClassific.nome,
                                    referencia = 1,
                                  total = listaTotal.Sum()                                    

                                };
                            

                            ClassificRepositorio.Update(classific);
                            listaTudo = Repositorio.ClassificRepositorio.Busca();
                        }
                        else
                        {
                            if (listaPeriodo.Count == 0)
                            {

                                //Resetar Classificação
                                Classificacao classific = new Classificacao
                                {
                                    id = itemClassific.id,
                                    nome = itemClassific.nome,
                                    referencia = 0,
                                    //total = listaPreco.Sum()                                    
                                    total = 0
                                };
                                ClassificRepositorio.Update(classific);
                            }
                        }
                        



                    //EmPizza.Add(pieChart);
                    //ClassificRepositorio.Update(classific);





                    }
                    
                }

            }
                else
                {
                    //EmPizza.Add(null);
                    //PC1.DataSource = null;

                    //Resetar Classificação
                    foreach (var item in listaTudo)
                    {
                        Classificacao classific = new Classificacao
                        {
                            id = item.id,
                            nome = item.nome,
                            referencia = 0,
                            //total = listaPreco.Sum()
                            total = 0

                        };

                        ClassificRepositorio.Update(classific);
                    }





                }

                //List<double> listaTotal = Repositorio.PeriodoRepositorio.buscaTotal(CompraAux);


                
                
                
                
                
                
                
                
                

                //foreach (var item in listaPeriodo)
                //{

                //    double totalizando = item.Sum();




                //    foreach (var itemClas in listaTudo)
                //    {

                //        if (item.classificacao == itemClas.nome)
                //        {
                            

                //            Classificacao classific = new Classificacao
                //                {
                //                    id = itemClas.id,
                //                    nome = itemClas.nome,
                //                    referencia = itemClas.referencia,
                //                    //total = listaPreco.Sum()
                //                    total = listaPeriodo.

                //                };

                //            ClassificRepositorio.Update(classific);

                //        }
                //    }
                //}




































               










                //tentei concatenar mas parece que nao deu muito certo continuar tentando

                //foreach (var itemCompra in listaPeriodo)
                //{
                //    foreach (var item in listaTudo)
                //    {
                //        if (item.nome == itemCompra.classificacao)
                //        {
                            
                //            Classificacao classific = new Classificacao
                //            {
                //                id = item.id,
                //                nome = item.nome,
                //                referencia = item.referencia,
                //                //total = listaPreco.Sum()
                //                total = itemCompra.preco 

                //            };

                //            ClassificRepositorio.Update(classific);

                //        }

                //    }


                //}















              
                // this.LstMoedas.ItemsSource = listaFav;



                //string apelido = lpkMoedas.SelectedItem.ToString();
                 List<Classificacao> listaAux = Repositorio.ClassificRepositorio.Busca();

                // List<Classificacao> listaInteiro = Repositorio.ClassificRepositorio.BuscaInteiro(1);

                // this.LstMoedas.ItemsSource = listaFav;
                //double contador = (Convert.ToDouble(lista.Sum()));
                //    List<CompraEntidade> lista = Repositorio.CompraRepositorio.Get(id);

                 //if (EmPizza[0] != null)
                 //{
                 foreach (var item2 in listaAux)
                     {
                         // DateTime dtt = Convert.ToDateTime(item2.Data);
                         //Console.WriteLine("Year: {0}, Month: {1}, Day: {2}", dtt.Year, dtt.Month, dtt.Day);
                         //double total = (Convert.ToDouble(item2.Sum()));
                         //EmPizza.Clear();
                         if (item2.total != 0)
                         {

                             PChart pieChart = new PChart
                             {
                                 title = item2.nome,
                                 //Convert.ToString(dtt.Day) + "/" + Convert.ToString(dtt.Month),
                                 value = item2.total
                             };
                             EmPizza.Add(pieChart);
                         }
                         else
                         {
                              EmPizza = EmPizzaZero;
                             //PChart pieChart = new PChart
                             //{
                             //    title = "",
                             //    //Convert.ToString(dtt.Day) + "/" + Convert.ToString(dtt.Month),
                             //    value = 0
                             //};
                             //EmPizza.Add(pieChart);
                         }
                         
                     }
                    //else
                    //{
                    //    EmPizza= null;


                    //}

                //}
            }
            //if (EmPizza.Count != 0)
            //{
          
                return EmPizza;




            //}
            //else
            //{
                
            //    return EmPizzaZero;
            //}
        }

        





        
        #endregion





      
        public class LineChart
        {
            public string label { get; set; }
            public double val1 { get; set; }
        }
        public class PChart
        {
            public string title { get; set; }
            public double value { get; set; }
        }

        public class Aux
        {
            public int id { get; set; }
            public double preco { get; set; }
            public string classificacao { get; set; }
            public string periodo { get; set; }
            public int referencia { get; set; }

        }



        private void ParseJsonMoedas()
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


        private void ParseJsonPeriodos()
        {
            string Json = Utils.Utils.ReadFile("Resources/Json/periodos.json");
            //criar objeto para lista do tipo carro
            //List<Origem> MoedasDoJson = new List<Origem>();

            if (Json != null)
            {
                //faz o parse para um tipo jobject
                JObject jobject = JObject.Parse(Json);

                //le a lista carros
                JObject jobjectPeridos = (JObject)jobject["periodos"];

                //captura o array carro
                JArray periodos = (JArray)jobjectPeridos["periodo"];

                //percorre o array e faz o parse para o nosso tipo "car"
                foreach (JObject item in periodos)
                {
                    int i = periodos.Count;
                    PeriodoEntidade periodo = new PeriodoEntidade
                    {
                        nome = (string)item["nome"],
                        perido = (string)item["periodo"]


                    };
                    //MoedasDoJson.Add(moeda);                   
                    CriacaoPeriodo(periodo);


                }


            };
            //return MoedasDoJson;
        }




        private void Criacao(Origem moeda)
        {
            //List<Origem> listaMoedas = GetMoeda();

            OrigemRepositorio.Create(moeda);
        }
        private void CriacaoPeriodo(PeriodoEntidade periodo)
        {
            //List<Origem> listaMoedas = GetMoeda();

            PeriodoRepositorio.Create(periodo);
        }

        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }




    }
}