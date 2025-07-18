using Microsoft.EntityFrameworkCore.Migrations;

namespace p_proyect.Migrations
{
    public partial class Update_estudiante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Cantidad_De_Cursos_A_Los_Que_Esta_Inscrito",
                table: "Estudiantes",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad_De_Cursos_A_Los_Que_Esta_Inscrito",
                table: "Estudiantes");
        }
    }
}
