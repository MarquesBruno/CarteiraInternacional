using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraInternacional.Entidade
{
    [Table(Name = "Compra")]
    public class CompraEntidade
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        //[Column(CanBeNull = true)]
        //public int referencia { get; set; }

        [Column(CanBeNull = true)]
        public string estabelecimento { get; set; }

        [Column(CanBeNull = true)]
        public string produto { get; set; }

        [Column(CanBeNull = true)]
        public string classificacao { get; set; }

        [Column(CanBeNull = true)]
        public double preco { get; set; }

        [Column(CanBeNull = true)]
        public double qtd { get; set; }

        [Column(CanBeNull = true)]
        public string Data { get; set; }

        [Column(CanBeNull = true)]
        public string periodo { get; set; }

    }
}
