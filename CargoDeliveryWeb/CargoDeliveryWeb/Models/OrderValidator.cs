using FluentValidation;

namespace CargoDeliveryWeb.Models.Validatiion;

public class OrderValidator : AbstractValidator<OrderRequest>
{
    public OrderValidator()
    {
        RuleFor(o => o.SenderCity)
            .NotEmpty().WithMessage("Город отправителя обязателен")
            .MaximumLength(100).WithMessage("Максимальная длина 100 символов");

        RuleFor(o => o.SenderAddress)
            .NotEmpty().WithMessage("Адрес отправителя обязателен")
            .MaximumLength(100).WithMessage("Максимальная длина 100 символов");

        RuleFor(o => o.ReceiverCity)
            .NotEmpty().WithMessage("Город получателя обязателен")
            .MaximumLength(100).WithMessage("Максимальная длина 100 символов");

        RuleFor(o => o.ReceiverAddress)
            .NotEmpty().WithMessage("Адрес получателя обязателен")
            .MaximumLength(100).WithMessage("Максимальная длина 100 символов");

        RuleFor(o => o.Weight)
            .GreaterThan(0).WithMessage("Вес должен быть больше 0")
            .LessThan(1000).WithMessage("Максимальный вес 1000 кг");

        RuleFor(o => o.PickupDate)
            .NotEmpty().WithMessage("Дата обязательна")
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("Дата не может быть в прошлом");
    }
}

