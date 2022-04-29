using System;
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
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
            //    values: new object[] { new Guid("a854755d-578b-4059-ad11-93d0674687db"), "Administrador@itau.personalite.com.br", "Administrador", "JRSznD]8P<*R" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Usuarios_Email",
            //    table: "Usuarios",
            //    column: "Email",
            //    unique: true,
            //    filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
