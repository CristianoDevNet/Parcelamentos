using DomainCore.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCore.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        private readonly string produtoSemNome = "É necessário informar o nome do produto.";

        public ProdutoValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Não foi possível encontrar o objeto.");
                });

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(produtoSemNome)
                .NotNull().WithMessage(produtoSemNome);
        }
    }
}
