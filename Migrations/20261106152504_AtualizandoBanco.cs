using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBTG.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorLiquido",
                table: "Resgates",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorLiquido",
                table: "Resgates");
        }
    }
}
