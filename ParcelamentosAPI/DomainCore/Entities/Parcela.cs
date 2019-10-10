using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Entities
{
    public class Parcela : BaseEntity
    {
        public int OrcamentoId { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }
    }
}
