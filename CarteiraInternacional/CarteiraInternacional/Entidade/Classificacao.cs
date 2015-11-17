using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraInternacional.Entidade
{
    [Table(Name = "Classificacao")]
    public class Classificacao
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(CanBeNull = true)]
        public int referencia { get; set; }

        [Column(CanBeNull = true)]
        public string nome { get; set; }

        [Column(CanBeNull = true)]
        public double total { get; set; }

        //[Column(CanBeNull = true)]
        //public string periodo { get; set; }
    }
}
