using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StuffType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StuffType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stuff",
                columns: table => new
                {
                    StuffTypeId = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stuff", x => new { x.StuffTypeId, x.Brand, x.PurchaseDate });
                    table.UniqueConstraint("AK_Stuff_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stuff_StuffType_StuffTypeId",
                        column: x => x.StuffTypeId,
                        principalTable: "StuffType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StuffId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<byte>(type: "tinyint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_Stuff_StuffId",
                        column: x => x.StuffId,
                        principalTable: "Stuff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_StuffId",
                table: "History",
                column: "StuffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Stuff");

            migrationBuilder.DropTable(
                name: "StuffType");
        }
    }
}
