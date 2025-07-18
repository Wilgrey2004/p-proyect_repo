using Microsoft.EntityFrameworkCore.Migrations;

namespace p_proyect.Migrations
{
    public partial class Adeudo_Add_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adeudos_Cursos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Curso = table.Column<long>(nullable: false),
                    Id_Estudiante = table.Column<long>(nullable: false),
                    Total_Pagado = table.Column<decimal>(nullable: false),
                    Restante_A_Pagar = table.Column<decimal>(nullable: false),
                    Adeudo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adeudos_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adeudos_Cursos_Cursos_Id_Curso",
                        column: x => x.Id_Curso,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adeudos_Cursos_Estudiantes_Id_Estudiante",
                        column: x => x.Id_Estudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adeudos_Cursos_Id_Curso",
                table: "Adeudos_Cursos",
                column: "Id_Curso");

            migrationBuilder.CreateIndex(
                name: "IX_Adeudos_Cursos_Id_Estudiante",
                table: "Adeudos_Cursos",
                column: "Id_Estudiante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adeudos_Cursos");
        }
    }
}
