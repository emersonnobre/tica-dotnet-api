using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicaManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Email_IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    Cpf_IsValid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    Name_IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Action = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    EmployeeId = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Audit",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audit_EmployeeId",
                table: "Audit",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Cpf",
                table: "Employee",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Email",
                table: "Employee",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
