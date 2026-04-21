using ExpenseTracker.Domain.Expenses;
using ExpenseTracker.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseTracker.Infrastructure.Persistence.Configurations;

public sealed class ExpenseCategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
{
    public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
    {
        builder.ToTable("ExpenseCategories");
        builder.HasKey(category => category.Code);
        builder.Property(category => category.Code).HasMaxLength(50);
        builder.Property(category => category.Name).HasMaxLength(100).IsRequired();
        builder.Property(category => category.ColorToken).HasMaxLength(50).IsRequired();

        builder.HasData(CategorySeedData.All);
    }
}
