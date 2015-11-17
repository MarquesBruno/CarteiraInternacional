using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CarteiraInternacional.Banco;
using CarteiraInternacional.Entidade;

namespace CarteiraInternacional.Repositorio
{
    public class ClassificRepositorio
    {
        private static DataBase GetDataBase()
        {
            DataBase db = new DataBase();
            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }

        public static List<string> GetOne()
        {
            DataBase db = GetDataBase();
            var query = from clas in db.Classificacao orderby clas.nome ascending select clas.nome;

            List<string> lista = query.ToList<string>();
         //  List<Classificacao> lista = new List<Classificacao>(lista);

          //  List<Classificacao> lista = new List<Classificacao>(query.AsEnumerable());
            return lista;
        }

        public static List<Classificacao> Get(int pClassific)
        {
            DataBase db = GetDataBase();
            var query = from clas in db.Classificacao orderby clas.nome ascending select clas;

            List<Classificacao> lista = new List<Classificacao>(query.AsEnumerable());
            return lista;
        }

        public static List<Classificacao> Busca()
        {
            DataBase db = GetDataBase();
            var query = from clas in db.Classificacao orderby clas.nome ascending select clas;

            List<Classificacao> lista = new List<Classificacao>(query.AsEnumerable());
            return lista;
        }



        public static List<Classificacao> BuscaInteiro(int referencia)
        {
            DataBase db = GetDataBase();
            var query = from clas in db.Classificacao where clas.referencia == referencia select clas;
            //var query = from clas in db.Classificacao orderby clas.nome ascending select clas;

            List<Classificacao> lista = new List<Classificacao>(query.AsEnumerable());
            return lista;
        }






        //public static List<Classificacao> ListaNome(string pClassific)
        //{
        //    DataBase db = GetDataBase();
        //    // var query = from cot in db.Cotacoes orderby cot.data_consulta descending select cot;
        //    //  var query = from cot in db.Cotacoes orderby cot.id descending select cot;
        //    //   var query = from orig in db.Origem where orig.nome == pOrigem select orig.sigla;
        //    var query = from c in db.Classificacao where c.periodo == pClassific select c;

        //    List<Classificacao> lista = new List<Classificacao>(query.AsEnumerable());
        //    return lista;
        //}









        //Método recebe uma classificação no momento da inserção da classificação e retorna um preço do produto;
        //O preço servira para que cada classificação possa receber o total de compras que cada classificação possui;
        public static List<double> GetPreco(string pClassific)
        {
            DataBase db = GetDataBase();
            //var query = from orig in db.Origem orderby orig.nome ascending select orig.sigla;
            var query = from clas in db.Compra where clas.classificacao == pClassific select clas.preco;

            List<double> lista = new List<double>(query.AsEnumerable());
            return lista;
        }









        public static void Create(Classificacao pClassific)
        {
            int ponto = 0;
            
            DataBase db = GetDataBase();
            var query = from clas in db.Classificacao orderby clas.nome descending select clas;

            List<Classificacao> lista = new List<Classificacao>(query.AsEnumerable());

            
            foreach (var item in lista)
            {

               // if (item.nome.Equals(pClassific.nome))
                if(item.nome.Equals(pClassific.nome, StringComparison.OrdinalIgnoreCase))
                {
                    ponto = 1;
                    
                }
                
            }
            

            if (ponto == 0)
            {
                db.Classificacao.InsertOnSubmit(pClassific);
                db.SubmitChanges();
            }
            else
            {
                pClassific.referencia = 1;

            }
            

            
        }

        public static void Delete(string pClassific)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Classificacao
                        where c.nome == pClassific
                        select c;

            db.Classificacao.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void DeleteObject(Classificacao pClassific)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Classificacao
                        where c.id == pClassific.id
                        select c;

            db.Classificacao.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void Update(Classificacao pClassific)
        {
            DataBase db = GetDataBase();

            Classificacao cla = (from c in db.Classificacao
                           where c.id == pClassific.id
                           select c).First();

            cla.nome = pClassific.nome;
            cla.total = pClassific.total;
            cla.referencia = pClassific.referencia;

            db.SubmitChanges();
        }







    }
}
