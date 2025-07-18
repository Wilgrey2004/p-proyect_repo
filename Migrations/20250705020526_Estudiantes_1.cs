using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace p_proyect.Migrations
{
    public partial class Estudiantes_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estudiantes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Apodo = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Municipio = table.Column<string>(nullable: true),
                    Sector = table.Column<string>(nullable: true),
                    Nombre_del_tutor = table.Column<string>(nullable: false),
                    Telefono_del_tutor = table.Column<string>(nullable: false),
                    Estudia_En_La_Actualidad = table.Column<int>(nullable: false),
                    Nivel_De_Educacion = table.Column<int>(nullable: false),
                    Fecha_De_Inscripcion = table.Column<DateTime>(nullable: false),
                    Fecha_De_insercion_al_sistema = table.Column<DateTime>(nullable: false),
                    Id_Empleado = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estudiantes_empleado_Admins_Id_Empleado",
                        column: x => x.Id_Empleado,
                        principalTable: "empleado_Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_Id_Empleado",
                table: "estudiantes",
                column: "Id_Empleado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estudiantes");
        }
    }
}
