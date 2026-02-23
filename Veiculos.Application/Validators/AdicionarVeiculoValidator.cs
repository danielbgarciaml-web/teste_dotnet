using FluentValidation;
using Veiculos.Application.Commands;
using Veiculos.Application.Handlers;

namespace Veiculos.Application.Validators;

public class AdicionarVeiculoValidator : AbstractValidator<AdicionarVeiculoCommand>
{
    public AdicionarVeiculoValidator()
    {
        RuleFor(v => v.Descricao).NotEmpty().MaximumLength(100);
        RuleFor(v => v.Marca).IsInEnum().WithMessage("Marca inválida.");
        RuleFor(v => v.Modelo).NotEmpty().MaximumLength(30);

    }
}