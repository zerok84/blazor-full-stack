using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assigmment.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItems_TicketSet_TicketId",
                        column: x => x.TicketId,
                        principalTable: "TicketSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TicketSet",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "Status", "Title" },
                values: new object[] { 1, new DateTime(2022, 8, 17, 15, 15, 19, 674, DateTimeKind.Local).AddTicks(5162), "anonymouse", "Description 1", "TODO", "Ticket 1" });

            migrationBuilder.InsertData(
                table: "TicketSet",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "Status", "Title" },
                values: new object[] { 2, new DateTime(2022, 8, 17, 15, 15, 19, 674, DateTimeKind.Local).AddTicks(5174), "anonymouse", "Description 2", "WORKDONE", "Ticket 2" });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "Id", "Created", "CreatedBy", "ItemType", "Quantity", "TicketId", "UnitPrice" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "anonymous", "LABOR", 0, 1, "USD" });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "Id", "Created", "CreatedBy", "ItemType", "Quantity", "TicketId", "UnitPrice" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "anonymous", "PART", 10, 2, "USD" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_TicketId",
                table: "WorkItems",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkItems");

            migrationBuilder.DropTable(
                name: "TicketSet");
        }
    }
}
