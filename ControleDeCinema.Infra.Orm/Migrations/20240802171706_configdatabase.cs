using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeCinema.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class configdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbFilme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estreia = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbFilme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbFuncionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Login = table.Column<string>(type: "varchar(200)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbSala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbSessao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filme_Id = table.Column<int>(type: "int", nullable: false),
                    Sala_Id = table.Column<int>(type: "int", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IngressosDisponiveis = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSessao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbSessao_TbSala",
                        column: x => x.Sala_Id,
                        principalTable: "TbSala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_TbSessao_TbFilme",
                        column: x => x.Filme_Id,
                        principalTable: "TbFilme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TbIngresso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPoltrona = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    SessaoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    Sessao_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbIngresso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbIngresso_TbFuncionario",
                        column: x => x.FuncionarioId,
                        principalTable: "TbFuncionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbIngresso_TbSessao_SessaoId",
                        column: x => x.SessaoId,
                        principalTable: "TbSessao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbSessao_TbIngresso",
                        column: x => x.Sessao_Id,
                        principalTable: "TbSessao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbIngresso_FuncionarioId",
                table: "TbIngresso",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TbIngresso_Sessao_Id",
                table: "TbIngresso",
                column: "Sessao_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TbIngresso_SessaoId",
                table: "TbIngresso",
                column: "SessaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TbSessao_Filme_Id",
                table: "TbSessao",
                column: "Filme_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TbSessao_Sala_Id",
                table: "TbSessao",
                column: "Sala_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbIngresso");

            migrationBuilder.DropTable(
                name: "TbFuncionario");

            migrationBuilder.DropTable(
                name: "TbSessao");

            migrationBuilder.DropTable(
                name: "TbSala");

            migrationBuilder.DropTable(
                name: "TbFilme");
        }
    }
}
