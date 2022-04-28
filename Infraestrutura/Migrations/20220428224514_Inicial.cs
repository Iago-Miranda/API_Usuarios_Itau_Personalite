using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Usuarios",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nome = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
            //        Senha = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Usuarios", x => x.Id);
            //    });

            //migrationBuilder.InsertData(
            //    table: "Usuarios",
            //    columns: new[] { "Id", "Email", "Nome", "Senha" },
            //    values: new object[] { 1, "Administrador@itau.personalite.com.br", "Administrador", "JRSznD]8P<*R" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
