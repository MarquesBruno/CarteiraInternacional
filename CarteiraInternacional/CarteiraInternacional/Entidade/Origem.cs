using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarteiraInternacional.Entidade
{
    [Table(Name = "Origem")]
    public class Origem
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(CanBeNull = true)]
        public string nome { get; set; }

        [Column(CanBeNull = true)]
        public string sigla { get; set; }

        [Column(CanBeNull = true)]
        public string pais { get; set; }
    }
}
