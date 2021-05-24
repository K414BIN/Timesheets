using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Timesheets.Migrations
{
    public partial class InintialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    User = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    DateStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "sheets",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ContractID = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceID = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sheets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_sheets_contracts_ContractID",
                        column: x => x.ContractID,
                        principalTable: "contracts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sheets_employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sheets_services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sheets_ContractID",
                table: "sheets",
                column: "ContractID");

            migrationBuilder.CreateIndex(
                name: "IX_sheets_EmployeeID",
                table: "sheets",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_sheets_ServiceID",
                table: "sheets",
                column: "ServiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "sheets");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "services");
        }
    }
}
