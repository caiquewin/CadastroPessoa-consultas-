using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class DepartamentoForeingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Especialista_Departamento_DepartamentoId",
                table: "Especialista");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Especialista",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Especialista_Departamento_DepartamentoId",
                table: "Especialista",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Especialista_Departamento_DepartamentoId",
                table: "Especialista");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Especialista",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Especialista_Departamento_DepartamentoId",
                table: "Especialista",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
