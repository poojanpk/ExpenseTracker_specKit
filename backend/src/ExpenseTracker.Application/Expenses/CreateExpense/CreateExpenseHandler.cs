using ExpenseTracker.Application.Abstractions;
using ExpenseTracker.Domain.Expenses;
using FluentValidation;

namespace ExpenseTracker.Application.Expenses.CreateExpense;

public sealed class CreateExpenseHandler(IExpenseTrackerDbContext dbContext, IValidator<CreateExpenseCommand> validator)
{
    public async Task<ExpenseEntryDto> HandleAsync(CreateExpenseCommand command, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(command, cancellationToken);

        var categoryExists = dbContext.Categories.Any(category => category.Code == command.CategoryCode);
        if (!categoryExists)
        {
            throw new ValidationException("Expense category does not exist.");
        }

        var expense = ExpenseEntry.Create(command.ExpenseDate, command.Amount, command.CategoryCode, command.Note);
        dbContext.AddExpense(expense);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new ExpenseEntryDto(expense.Id, expense.ExpenseDate, expense.MonthKey, expense.Amount, expense.CategoryCode, expense.Note, expense.CreatedAt);
    }
}
