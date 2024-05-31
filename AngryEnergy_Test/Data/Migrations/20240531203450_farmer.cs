using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngryEnergy_Test.Data.Migrations
{
    public partial class farmer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDbSet_FarmersDbSet_FarmerModelID",
                table: "ProductsDbSet");

            migrationBuilder.AlterColumn<Guid>(
                name: "FarmerModelID",
                table: "ProductsDbSet",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDbSet_FarmersDbSet_FarmerModelID",
                table: "ProductsDbSet",
                column: "FarmerModelID",
                principalTable: "FarmersDbSet",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDbSet_FarmersDbSet_FarmerModelID",
                table: "ProductsDbSet");

            migrationBuilder.AlterColumn<Guid>(
                name: "FarmerModelID",
                table: "ProductsDbSet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDbSet_FarmersDbSet_FarmerModelID",
                table: "ProductsDbSet",
                column: "FarmerModelID",
                principalTable: "FarmersDbSet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
