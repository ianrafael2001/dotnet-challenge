using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace desafio.Migrations
{
    public partial class updatecolumnsforeignkey1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_managerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Members_employeeId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_projectId",
                table: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_managerId",
                table: "Projects",
                column: "managerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_employeeId",
                table: "Members",
                column: "employeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_projectId",
                table: "Members",
                column: "projectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_managerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Members_employeeId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_projectId",
                table: "Members");

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
        }
    }
}
