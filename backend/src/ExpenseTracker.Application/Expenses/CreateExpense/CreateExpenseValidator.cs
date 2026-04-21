using FluentValidation;

namespace ExpenseTracker.Application.Expenses.CreateExpense;

public sealed class CreateExpenseValidator : AbstractValidator<CreateExpenseCommand>
{
    public CreateExpenseValidator()
    {
        RuleFor(command => command.ExpenseDate).NotEmpty();
        RuleFor(command => command.Amount).GreaterThan(0);
        RuleFor(command => command.CategoryCode).NotEmpty().MaximumLength(50);
        RuleFor(command => command.Note).MaximumLength(250);
    }
}
