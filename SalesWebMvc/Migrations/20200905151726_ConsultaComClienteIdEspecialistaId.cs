using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class ConsultaComClienteIdEspecialistaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Cliente_ClienteId",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Especialista_EspecialistaId",
                table: "Consulta");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Especialista",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CroEstado",
                table: "Especialista",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Departamento",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EspecialistaId",
                table: "Consulta",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Consulta",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Cliente_ClienteId",
                table: "Consulta",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Especialista_EspecialistaId",
                table: "Consulta",
                column: "EspecialistaId",
                principalTable: "Especialista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Cliente_ClienteId",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Especialista_EspecialistaId",
                table: "Consulta");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Especialista",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CroEstado",
                table: "Especialista",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Departamento",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "EspecialistaId",
                table: "Consulta",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Consulta",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Cliente_ClienteId",
                table: "Consulta",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Especialista_EspecialistaId",
                table: "Consulta",
                column: "EspecialistaId",
                principalTable: "Especialista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
