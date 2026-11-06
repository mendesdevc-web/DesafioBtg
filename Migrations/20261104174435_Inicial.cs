using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DesafioBTG.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fundos",
                columns: table => new
                {
                    IdFundo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundos", x => x.IdFundo);
                });

            migrationBuilder.CreateTable(
                name: "Aplicacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FundoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aplicacoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aplicacoes_Fundos_FundoId",
                        column: x => x.FundoId,
                        principalTable: "Fundos",
                        principalColumn: "IdFundo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resgates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorResgate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImpostoDeRenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataResgate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FundoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resgates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resgates_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resgates_Fundos_FundoId",
                        column: x => x.FundoId,
                        principalTable: "Fundos",
                        principalColumn: "IdFundo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Mendes" },
                    { 2, "Matheus" },
                    { 3, "Marlyson" }
                });

            migrationBuilder.InsertData(
                table: "Fundos",
                columns: new[] { "IdFundo", "Nome" },
                values: new object[,]
                {
                    { 1, "Fundo de investimento A" },
                    { 2, "Fundo de investimento A" },
                    { 3, "Fundo de investimento A" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_ClienteId",
                table: "Aplicacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Aplicacoes_FundoId",
                table: "Aplicacoes",
                column: "FundoId");

            migrationBuilder.CreateIndex(
                name: "IX_Resgates_ClienteId",
                table: "Resgates",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Resgates_FundoId",
                table: "Resgates",
                column: "FundoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacoes");

            migrationBuilder.DropTable(
                name: "Resgates");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fundos");
        }
    }
}
