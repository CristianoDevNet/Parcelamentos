using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Entities
{
    public class Orcamento : BaseEntity
    {
        public int ProdutoId { get; set; }

        public decimal ValorBase { get; set; }

        public decimal JurosMes { get; set; }

        public Produto Produto { get; set; }

        public ICollection<Parcela> Parcelas { get; set; }
    }
}
