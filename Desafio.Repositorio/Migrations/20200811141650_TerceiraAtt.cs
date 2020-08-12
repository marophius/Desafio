using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Repositorio.Migrations
{
    public partial class TerceiraAtt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Colaboradores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "dateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Colaboradores",
                type: "dateTime",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
