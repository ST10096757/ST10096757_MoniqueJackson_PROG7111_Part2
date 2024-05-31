using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngryEnergy_Test.Data.Migrations
{
    public partial class foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "FarmersDbSet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FarmersDbSet_UserID",
                table: "FarmersDbSet",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FarmersDbSet_AspNetUsers_UserID",
                table: "FarmersDbSet",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmersDbSet_AspNetUsers_UserID",
                table: "FarmersDbSet");

            migrationBuilder.DropIndex(
                name: "IX_FarmersDbSet_UserID",
                table: "FarmersDbSet");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "FarmersDbSet");
        }
    }
}
