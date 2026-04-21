namespace ExpenseTracker.Domain.Expenses;

public sealed class ExpenseCategory
{
    private ExpenseCategory()
    {
    }

    public ExpenseCategory(string code, string name, int displayOrder, string colorToken)
    {
        Code = ValidateRequired(code, nameof(code));
        Name = ValidateRequired(name, nameof(name));
        ColorToken = ValidateRequired(colorToken, nameof(colorToken));
        DisplayOrder = displayOrder;
    }

    public string Code { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public int DisplayOrder { get; private set; }

    public string ColorToken { get; private set; } = string.Empty;

    private static string ValidateRequired(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value is required.", parameterName);
        }

        return value.Trim();
    }
}
