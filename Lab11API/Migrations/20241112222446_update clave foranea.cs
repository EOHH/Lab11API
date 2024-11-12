using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab11API.Migrations
{
    /// <inheritdoc />
    public partial class updateclaveforanea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "InvoiceNumber",
                table: "Invoices",
                newName: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Invoices",
                newName: "InvoiceNumber");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
