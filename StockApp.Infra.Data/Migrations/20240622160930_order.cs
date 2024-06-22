using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApp.Infra.Data.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "PasswordHash",
                value: "$2a$10$5HUZ7J8X1OjTKdsTuKdwe.UKY071X1S7gQsUorqivZgNMO5MmFkf2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "PasswordHash",
                value: "$2a$10$R6m.uRIy2UJRNPKjmHjDE.Vx.TEGLKwOI1.2fmeRFxPzq3RcowXn6");
        }
    }
}
