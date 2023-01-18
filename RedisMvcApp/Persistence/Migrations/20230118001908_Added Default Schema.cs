using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedisMvcApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Products");

            migrationBuilder.RenameTable(
                name: "ProductSeller",
                newName: "ProductSeller",
                newSchema: "Products");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "ProductCategories",
                newSchema: "Products");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Product",
                newSchema: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ProductSeller",
                schema: "Products",
                newName: "ProductSeller");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                schema: "Products",
                newName: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "Products",
                newName: "Product");
        }
    }
}
