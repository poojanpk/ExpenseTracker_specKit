using ExpenseTracker.Application.Abstractions;

namespace ExpenseTracker.Application.Categories.ListCategories;

public sealed class ListCategoriesHandler(IExpenseTrackerDbContext dbContext)
{
    public async Task<IReadOnlyList<ExpenseCategoryDto>> HandleAsync(ListCategoriesQuery query, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return dbContext.Categories
            .OrderBy(category => category.DisplayOrder)
            .Select(category => new ExpenseCategoryDto(category.Code, category.Name, category.DisplayOrder, category.ColorToken))
            .ToList();
    }
}
