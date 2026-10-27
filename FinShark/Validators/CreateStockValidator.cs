using FinShark.Models.Dtos;
using FluentValidation;

namespace FinShark.Validators
{
    public class CreateStockValidator : AbstractValidator<StockRequestDto>
    {
        public CreateStockValidator()
        {
            RuleFor(x => x.Symbol)
                .NotEmpty().WithMessage("Symbol is requierd")
                .MaximumLength(10);
            RuleFor(x => x.Purchase)
                .GreaterThan(0).WithMessage("Purchase must be Positive");
        }

    }
}
