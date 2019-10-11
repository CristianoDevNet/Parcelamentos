using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }

        public ICollection<Orcamento> Orcamentos { get; set; }
    }
}
