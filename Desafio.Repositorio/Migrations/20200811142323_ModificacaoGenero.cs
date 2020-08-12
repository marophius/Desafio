using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Repositorio.Migrations
{
    public partial class ModificacaoGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Colaboradores",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Colaboradores",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
