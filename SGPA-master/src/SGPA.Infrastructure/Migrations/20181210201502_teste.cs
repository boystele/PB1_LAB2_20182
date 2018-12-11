using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGPA.Infrastructure.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(30)", nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    GrupoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.GrupoId);
                });

            migrationBuilder.CreateTable(
                name: "Voos",
                columns: table => new
                {
                    VooId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(30)", nullable: true),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voos", x => x.VooId);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: true),
                    CEP = table.Column<string>(type: "varchar(8)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(4)", nullable: true),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passagens",
                columns: table => new
                {
                    PassagemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataEmissao = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    VooId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagens", x => x.PassagemId);
                    table.ForeignKey(
                        name: "FK_Passagens_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passagens_Voos_VooId",
                        column: x => x.VooId,
                        principalTable: "Voos",
                        principalColumn: "VooId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PassagensAereas",
                columns: table => new
                {
                    PassagemId = table.Column<int>(nullable: false),
                    GrupoId = table.Column<int>(nullable: false),
                    PassagemAereaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassagensAereas", x => new { x.PassagemId, x.GrupoId });
                    table.ForeignKey(
                        name: "FK_PassagensAereas_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "GrupoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassagensAereas_Passagens_PassagemId",
                        column: x => x.PassagemId,
                        principalTable: "Passagens",
                        principalColumn: "PassagemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Descricao", "Email" },
                values: new object[,]
                {
                    { 1, "Robson", "Robsonrodrigues_12@hotmail.com" },
                    { 2, "Neemias", "NeemiasFernandes@hotmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Grupos",
                columns: new[] { "GrupoId", "Descricao" },
                values: new object[,]
                {
                    { 1, "Sei la" },
                    { 2, "Eu Adoro" }
                });

            migrationBuilder.InsertData(
                table: "Voos",
                columns: new[] { "VooId", "Descricao", "Numero" },
                values: new object[,]
                {
                    { 1, "Rio Janeiro", 10 },
                    { 2, "Sao Paulo", 24 }
                });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "EnderecoId", "Bairro", "CEP", "ClienteId", "Logradouro", "Numero" },
                values: new object[,]
                {
                    { 1, "Dr Fabio", "55555555", 1, "Cuiaba", "1896" },
                    { 2, "Jardim Itália", "88888888", 2, "Cuiaba-Alphaville", "2424" }
                });

            migrationBuilder.InsertData(
                table: "Passagens",
                columns: new[] { "PassagemId", "ClienteId", "DataEmissao", "Valor", "VooId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2018, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), 100.0, null },
                    { 2, 2, new DateTime(2018, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), 500.0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passagens_ClienteId",
                table: "Passagens",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Passagens_VooId",
                table: "Passagens",
                column: "VooId");

            migrationBuilder.CreateIndex(
                name: "IX_PassagensAereas_GrupoId",
                table: "PassagensAereas",
                column: "GrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "PassagensAereas");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Passagens");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Voos");
        }
    }
}
