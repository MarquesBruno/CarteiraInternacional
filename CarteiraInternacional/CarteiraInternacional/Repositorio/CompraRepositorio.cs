﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CarteiraInternacional.Banco;
using CarteiraInternacional.Entidade;


namespace CarteiraInternacional.Repositorio
{
    public class CompraRepositorio
    {
        private static DataBase GetDataBase()
        {
            DataBase db = new DataBase();
            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }

        //Listagem de valores das compras o qual sera somado e subtraido do valor de credito
        public static List<double> GetOne()
        {
            DataBase db = GetDataBase();

            //var query = from comp in db.Compra orderby comp.id descending select comp.produto;
            var query = from comp in db.Compra orderby comp.id descending select comp.preco;


            //List<string> lista = query.ToList<string>();
            List<double> lista = query.ToList<double>();

            return lista;
        }



        //Listagem da tela principal de lista de compras
        public static List<CompraEntidade> Get(int pCompra)
        {
            DataBase db = GetDataBase();
            var query = from comp in db.Compra orderby comp.estabelecimento ascending select comp;

            List<CompraEntidade> lista = new List<CompraEntidade>(query.AsEnumerable());
            return lista;
        }

        public static void Create(CompraEntidade pCompra)
        {
            int ponto = 0;

            DataBase db = GetDataBase();
            var query = from comp in db.Compra orderby comp.id descending select comp;

            List<CompraEntidade> lista = new List<CompraEntidade>(query.AsEnumerable());

            db.Compra.InsertOnSubmit(pCompra);
            db.SubmitChanges();

        }

        public static void Delete(int pCompra)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Compra
                        where c.id == pCompra
                        select c;

            db.Compra.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }


        public static void DeleteObject(CompraEntidade pCompra)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Compra
                        where c.id == pCompra.id
                        select c;

            db.Compra.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }


    }
}
