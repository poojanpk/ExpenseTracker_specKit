namespace ExpenseTracker.Application.Categories.ListCategories;

public sealed record ListCategoriesQuery;

public sealed record ExpenseCategoryDto(string Code, string Name, int DisplayOrder, string ColorToken);
