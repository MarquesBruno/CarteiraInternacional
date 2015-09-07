using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteiraInternacional.Entidade;


namespace CarteiraInternacional.Banco
{
    public class DataBase : DataContext
    {
        public static string DBConnectionString =
            "Data Source = 'isostore:carteiraDB.sdf'";
        public DataBase()
            : base(DBConnectionString)
        {
        }

        public Table<Classificacao> Classificacao
        {
            get { return this.GetTable<Classificacao>(); }
        }

    }
}
