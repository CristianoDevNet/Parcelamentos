using DomainCore.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCore.Validators
{
    public class OrcamentoValidator : AbstractValidator<Orcamento>
    {
        private readonly string semProdutoId = "É necessário informar o Id do produto";

        private readonly string semValorBase = "É necessário informar o valor do produto";

        private readonly string semjurosMes = "É necessário informar o Juros/mês";

        private readonly string qtdParcelasVazias = "É necessário informar a quantidade de parcelas.";

        public OrcamentoValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Não foi possível encontrar o objeto.");
                });

            RuleFor(c => c.ProdutoId)
                .NotEmpty().WithMessage(semProdutoId)
                .NotNull().WithMessage(semProdutoId);

            RuleFor(c => c.ValorBase)
                .NotEmpty().WithMessage(semValorBase)
                .NotNull().WithMessage(semValorBase);

            RuleFor(c => c.JurosMes)
                .NotEmpty().WithMessage(semjurosMes)
                .NotNull().WithMessage(semjurosMes);

            RuleFor(c => c.QtdParcelas)
                .NotEmpty().WithMessage(qtdParcelasVazias)
                .NotNull().WithMessage(qtdParcelasVazias);
        }
    }
}
