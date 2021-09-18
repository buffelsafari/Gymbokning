using Microsoft.EntityFrameworkCore.Migrations;

namespace Gymbokning.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersGymClasses_AspNetUsers_ApplicationUserId",
                table: "ApplicationUsersGymClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersGymClasses_GymClasses_GymClassId",
                table: "ApplicationUsersGymClasses");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsersGymClasses_GymClassId",
                table: "ApplicationUsersGymClasses");

            migrationBuilder.CreateTable(
                name: "ApplicationUserGymClass",
                columns: table => new
                {
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    gymClassesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserGymClass", x => new { x.UsersId, x.gymClassesId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserGymClass_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserGymClass_GymClasses_gymClassesId",
                        column: x => x.gymClassesId,
                        principalTable: "GymClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGymClass_gymClassesId",
                table: "ApplicationUserGymClass",
                column: "gymClassesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserGymClass");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersGymClasses_GymClassId",
                table: "ApplicationUsersGymClasses",
                column: "GymClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersGymClasses_AspNetUsers_ApplicationUserId",
                table: "ApplicationUsersGymClasses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersGymClasses_GymClasses_GymClassId",
                table: "ApplicationUsersGymClasses",
                column: "GymClassId",
                principalTable: "GymClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
