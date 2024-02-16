using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Users_Id",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_Id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_Id",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Instructors",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Applicants",
                newName: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Users_UserId",
                table: "Applicants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_UserId",
                table: "Instructors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Users_UserId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_UserId",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Instructors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Applicants",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Users_Id",
                table: "Applicants",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_Id",
                table: "Employees",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_Id",
                table: "Instructors",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
