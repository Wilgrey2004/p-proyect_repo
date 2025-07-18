using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace p_proyect.Migrations
{
    public partial class Cursos_Profesores_Relaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estudiantes_empleado_Admins_Id_Empleado",
                table: "estudiantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estudiantes",
                table: "estudiantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_empleado_Admins",
                table: "empleado_Admins");

            migrationBuilder.RenameTable(
                name: "estudiantes",
                newName: "Estudiantes");

            migrationBuilder.RenameTable(
                name: "empleado_Admins",
                newName: "Empleado_Admins");

            migrationBuilder.RenameIndex(
                name: "IX_estudiantes_Id_Empleado",
                table: "Estudiantes",
                newName: "IX_Estudiantes_Id_Empleado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleado_Admins",
                table: "Empleado_Admins",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Profesors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: true),
                    Numero_De_Telefono = table.Column<string>(nullable: true),
                    Comision = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Dia_Curso = table.Column<int>(nullable: false),
                    Hora_De_Inicio = table.Column<TimeSpan>(nullable: false),
                    Hora_De_Finalizacion = table.Column<TimeSpan>(nullable: false),
                    Profesor_Id = table.Column<long>(nullable: false),
                    Cantidad_De_Estudiantes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Profesors_Profesor_Id",
                        column: x => x.Profesor_Id,
                        principalTable: "Profesors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "R_Estudiantes_Cursos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Estudiante = table.Column<long>(nullable: false),
                    Estado_Estudiante = table.Column<int>(nullable: false),
                    Id_Curso = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_Estudiantes_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_R_Estudiantes_Cursos_Cursos_Id_Curso",
                        column: x => x.Id_Curso,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_R_Estudiantes_Cursos_Estudiantes_Id_Estudiante",
                        column: x => x.Id_Estudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_Profesor_Id",
                table: "Cursos",
                column: "Profesor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_R_Estudiantes_Cursos_Id_Curso",
                table: "R_Estudiantes_Cursos",
                column: "Id_Curso");

            migrationBuilder.CreateIndex(
                name: "IX_R_Estudiantes_Cursos_Id_Estudiante",
                table: "R_Estudiantes_Cursos",
                column: "Id_Estudiante");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Empleado_Admins_Id_Empleado",
                table: "Estudiantes",
                column: "Id_Empleado",
                principalTable: "Empleado_Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Empleado_Admins_Id_Empleado",
                table: "Estudiantes");

            migrationBuilder.DropTable(
                name: "R_Estudiantes_Cursos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Profesors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleado_Admins",
                table: "Empleado_Admins");

            migrationBuilder.RenameTable(
                name: "Estudiantes",
                newName: "estudiantes");

            migrationBuilder.RenameTable(
                name: "Empleado_Admins",
                newName: "empleado_Admins");

            migrationBuilder.RenameIndex(
                name: "IX_Estudiantes_Id_Empleado",
                table: "estudiantes",
                newName: "IX_estudiantes_Id_Empleado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estudiantes",
                table: "estudiantes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_empleado_Admins",
                table: "empleado_Admins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_estudiantes_empleado_Admins_Id_Empleado",
                table: "estudiantes",
                column: "Id_Empleado",
                principalTable: "empleado_Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
