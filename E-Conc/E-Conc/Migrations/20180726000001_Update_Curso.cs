using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace E_Conc.Migrations
{
    public partial class Update_Curso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cursos_CursoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Cursos_CursoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CursoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CursoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Curso",
                table: "Produtos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Curso",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Produtos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CursoId",
                table: "Produtos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CursoId",
                table: "AspNetUsers",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cursos_CursoId",
                table: "AspNetUsers",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Cursos_CursoId",
                table: "Produtos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
