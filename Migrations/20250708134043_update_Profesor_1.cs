using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace p_proyect.Migrations
{
    public partial class update_Profesor_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comision",
                table: "Profesors");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_De_Integracion_al_Sistema",
                table: "Profesors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_de_agregado_al_sistema",
                table: "Profesors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Pago_Total_De_Comision",
                table: "Profesors",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Porcentaje_De_Comision",
                table: "Profesors",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha_De_Integracion_al_Sistema",
                table: "Profesors");

            migrationBuilder.DropColumn(
                name: "Fecha_de_agregado_al_sistema",
                table: "Profesors");

            migrationBuilder.DropColumn(
                name: "Pago_Total_De_Comision",
                table: "Profesors");

            migrationBuilder.DropColumn(
                name: "Porcentaje_De_Comision",
                table: "Profesors");

            migrationBuilder.AddColumn<decimal>(
                name: "Comision",
                table: "Profesors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
