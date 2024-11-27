using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab11API.Migrations
{
    /// <inheritdoc />
    public partial class addtotaltoinvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");
        }
    }
}
