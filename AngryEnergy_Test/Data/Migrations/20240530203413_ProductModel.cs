using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngryEnergy_Test.Data.Migrations
{
    public partial class ProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "ProductsDbSet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDbSet_UserID",
                table: "ProductsDbSet",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDbSet_AspNetUsers_UserID",
                table: "ProductsDbSet",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDbSet_AspNetUsers_UserID",
                table: "ProductsDbSet");

            migrationBuilder.DropIndex(
                name: "IX_ProductsDbSet_UserID",
                table: "ProductsDbSet");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "ProductsDbSet");
        }
    }
}
