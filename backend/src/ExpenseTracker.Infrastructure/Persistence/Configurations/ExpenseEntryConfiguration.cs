using ExpenseTracker.Domain.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseTracker.Infrastructure.Persistence.Configurations;

public sealed class ExpenseEntryConfiguration : IEntityTypeConfiguration<ExpenseEntry>
{
    public void Configure(EntityTypeBuilder<ExpenseEntry> builder)
    {
        builder.ToTable("ExpenseEntries");
        builder.HasKey(expense => expense.Id);
        builder.Property(expense => expense.MonthKey).HasMaxLength(7).IsRequired();
        builder.Property(expense => expense.CategoryCode).HasMaxLength(50).IsRequired();
        builder.Property(expense => expense.Note).HasMaxLength(250);
        builder.Property(expense => expense.Amount).HasPrecision(18, 2);

        builder.HasIndex(expense => expense.MonthKey);
        builder.HasOne<ExpenseCategory>()
            .WithMany()
            .HasForeignKey(expense => expense.CategoryCode)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
