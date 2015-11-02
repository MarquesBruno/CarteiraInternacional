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
    public class OrigemRepositorio
    {
        private static DataBase GetDataBase()
        {
            DataBase db = new DataBase();
            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }

        //Listagem de valores das compras o qual sera somado e subtraido do valor de credito
        public static List<string> GetOne()
        {
            DataBase db = GetDataBase();

            //var query = from comp in db.Compra orderby comp.id descending select comp.produto;
            var query = from orig in db.Origem orderby orig.nome ascending select orig.nome;


            //List<string> lista = query.ToList<string>();
            List<string> lista = query.ToList<string>();

            return lista;
        }



        //Listagem da tela principal de lista de compras
        public static List<string> Get(string pOrigem)
        {
            DataBase db = GetDataBase();
            //var query = from orig in db.Origem orderby orig.nome ascending select orig.sigla;
              var query = from orig in db.Origem where orig.nome == pOrigem  select orig.sigla;

            List<string> lista = new List<string>(query.AsEnumerable());
            return lista;
        }

        public static void Create(Origem pOrigem)
        {
            int ponto = 0;

            DataBase db = GetDataBase();
            var query = from orig in db.Origem orderby orig.id descending select orig;

            List<Origem> lista = new List<Origem>(query.AsEnumerable());

            db.Origem.InsertOnSubmit(pOrigem);
            db.SubmitChanges();

        }

        public static void Delete(int pOrigem)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Origem
                        where c.id == pOrigem
                        select c;

            db.Origem.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }


        public static void DeleteObject(Origem pOrigem)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Origem
                        where c.id == pOrigem.id
                        select c;

            db.Origem.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }


    }
}
