using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraInternacional.Entidade
{
    [Table(Name = "Cotacoes")]
    public class Cota
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(CanBeNull = true)]
        public string data_consulta { get; set; }

        [Column(CanBeNull = true)]
        public string moeda { get; set; }

        [Column(CanBeNull = true)]
        public double resultado { get; set; }

        [Column(CanBeNull = true)]
        public double indice { get; set; }
    }
}
