using ExpenseTracker.Domain.Expenses;

namespace ExpenseTracker.Infrastructure.Persistence.Seed;

public static class CategorySeedData
{
    public static readonly ExpenseCategory[] All =
    [
        new("housing", "Housing", 1, "rose"),
        new("food", "Food", 2, "amber"),
        new("transport", "Transport", 3, "sky"),
        new("utilities", "Utilities", 4, "emerald"),
        new("health", "Health", 5, "violet"),
        new("shopping", "Shopping", 6, "fuchsia"),
        new("entertainment", "Entertainment", 7, "orange"),
        new("other", "Other", 8, "slate")
    ];
}
