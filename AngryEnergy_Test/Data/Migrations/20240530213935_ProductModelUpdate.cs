using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngryEnergy_Test.Data.Migrations
{
    public partial class ProductModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FarmerModelID",
                table: "ProductsDbSet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDbSet_FarmerModelID",
                table: "ProductsDbSet",
                column: "FarmerModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDbSet_FarmersDbSet_FarmerModelID",
                table: "ProductsDbSet",
                column: "FarmerModelID",
                principalTable: "FarmersDbSet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDbSet_FarmersDbSet_FarmerModelID",
                table: "ProductsDbSet");

            migrationBuilder.DropIndex(
                name: "IX_ProductsDbSet_FarmerModelID",
                table: "ProductsDbSet");

            migrationBuilder.DropColumn(
                name: "FarmerModelID",
                table: "ProductsDbSet");
        }
    }
}
