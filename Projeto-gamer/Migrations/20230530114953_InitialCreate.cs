﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_gamer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    IdEquipe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.IdEquipe);
                });

            migrationBuilder.CreateTable(
                name: "jogador",
                columns: table => new
                {
                    IdJogador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEquipe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jogador", x => x.IdJogador);
                    table.ForeignKey(
                        name: "FK_jogador_Equipe_IdEquipe",
                        column: x => x.IdEquipe,
                        principalTable: "Equipe",
                        principalColumn: "IdEquipe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jogador_IdEquipe",
                table: "jogador",
                column: "IdEquipe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jogador");

            migrationBuilder.DropTable(
                name: "Equipe");
        }
    }
}
