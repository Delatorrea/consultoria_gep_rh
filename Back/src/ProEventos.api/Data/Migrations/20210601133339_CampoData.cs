using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.api.Data.Migrations
{
    public partial class CampoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemURL",
                table: "Eventos");

            migrationBuilder.AlterColumn<string>(
                name: "Tema",
                table: "Eventos",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QtdPessoas",
                table: "Eventos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Lote",
                table: "Eventos",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Eventos",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DataEvento",
                table: "Eventos",
                type: "date",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tema",
                table: "Eventos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<int>(
                name: "QtdPessoas",
                table: "Eventos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Lote",
                table: "Eventos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Eventos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "DataEvento",
                table: "Eventos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "ImagemURL",
                table: "Eventos",
                type: "TEXT",
                nullable: true);
        }
    }
}
