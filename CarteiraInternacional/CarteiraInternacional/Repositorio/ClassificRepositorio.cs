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
            var query = from clas in db.Classificacao orderby clas.id descending select clas.nome;

            List<string> lista = query.ToList<string>();
         //  List<Classificacao> lista = new List<Classificacao>(lista);

          //  List<Classificacao> lista = new List<Classificacao>(query.AsEnumerable());
            return lista;
        }

        public static List<Classificacao> Get(int pClassific)
        {
            DataBase db = GetDataBase();
            var query = from clas in db.Classificacao orderby clas.id descending select clas;

            List<Classificacao> lista = new List<Classificacao>(query.AsEnumerable());
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
                if (item.nome.Equals(pClassific.nome))
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
    }
}
