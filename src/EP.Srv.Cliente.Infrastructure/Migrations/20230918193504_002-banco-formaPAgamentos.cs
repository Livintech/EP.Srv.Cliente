using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EP.Srv.Cliente.Infrastructure.Migrations
{
    public partial class _002bancoformaPAgamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bancos_Clientes_ClienteId",
                table: "Bancos");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Bancos",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Bancos_ClienteId",
                table: "Bancos",
                newName: "IX_Bancos_EmpresaId");

            migrationBuilder.CreateTable(
                name: "FormasPagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoEmpresa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormasPagamentos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FormasPagamentos_EmpresaId",
                table: "FormasPagamentos",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bancos_Empresas_EmpresaId",
                table: "Bancos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bancos_Empresas_EmpresaId",
                table: "Bancos");

            migrationBuilder.DropTable(
                name: "FormasPagamentos");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Bancos",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Bancos_EmpresaId",
                table: "Bancos",
                newName: "IX_Bancos_ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bancos_Clientes_ClienteId",
                table: "Bancos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
