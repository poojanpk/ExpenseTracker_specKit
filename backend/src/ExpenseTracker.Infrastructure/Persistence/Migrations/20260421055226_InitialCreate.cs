using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpenseTracker.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    ColorToken = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExpenseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    MonthKey = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    CategoryCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseEntries_ExpenseCategories_CategoryCode",
                        column: x => x.CategoryCode,
                        principalTable: "ExpenseCategories",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Code", "ColorToken", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { "entertainment", "orange", 7, "Entertainment" },
                    { "food", "amber", 2, "Food" },
                    { "health", "violet", 5, "Health" },
                    { "housing", "rose", 1, "Housing" },
                    { "other", "slate", 8, "Other" },
                    { "shopping", "fuchsia", 6, "Shopping" },
                    { "transport", "sky", 3, "Transport" },
                    { "utilities", "emerald", 4, "Utilities" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseEntries_CategoryCode",
                table: "ExpenseEntries",
                column: "CategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseEntries_MonthKey",
                table: "ExpenseEntries",
                column: "MonthKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseEntries");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");
        }
    }
}
