using Microsoft.EntityFrameworkCore.Migrations;

namespace p_proyect.Migrations
{
    public partial class seeds_Empleado_admin_1_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Empleado_Admins",
                columns: new[] { "Id", "Apellido_del_Administrador", "Estado", "Nombre_del_Administrador", "Numero_de_Telefono", "Pass", "Pass_confirm" },
                values: new object[] { 1L, "admin", 1, "Administrador", "8494061420", "admin123", "admin123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empleado_Admins",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
