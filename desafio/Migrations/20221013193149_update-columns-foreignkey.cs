using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace desafio.Migrations
{
    public partial class updatecolumnsforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Projects_managerId",
                table: "Projects",
                column: "managerId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_employeeId",
                table: "Members",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_projectId",
                table: "Members",
                column: "projectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Employees_employeeId",
                table: "Members",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Projects_projectId",
                table: "Members",
                column: "projectId",
                principalTable: "Projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_managerId",
                table: "Projects",
                column: "managerId",
                principalTable: "Employees",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Employees_employeeId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Projects_projectId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_managerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_managerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Members_employeeId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_projectId",
                table: "Members");
        }
    }
}
