using DomainCore.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCore.Validators
{
    public class ParcelaValidator : AbstractValidator<Parcela>
    {
        private readonly string parcelaSemOrcamentoId = "É necessário informar o Id do orçamento.";

        private readonly string parcelaSemValor = "É necessário informar o valor da parcela.";

        private readonly string parcelaSemData = "É necessário informar a data de vencimento da parcela.";

        public ParcelaValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Não foi possível encontrar o objeto.");
                });

            RuleFor(c => c.OrcamentoId)
                .NotEmpty().WithMessage(parcelaSemOrcamentoId)
                .NotNull().WithMessage(parcelaSemOrcamentoId);

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage(parcelaSemValor)
                .NotNull().WithMessage(parcelaSemValor);

            RuleFor(c => c.Data)
                .NotEmpty().WithMessage(parcelaSemData)
                .NotNull().WithMessage(parcelaSemData);
        }
    }
}
