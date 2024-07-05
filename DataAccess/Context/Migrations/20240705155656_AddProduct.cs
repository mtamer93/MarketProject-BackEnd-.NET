using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 5, 18, 56, 56, 349, DateTimeKind.Local).AddTicks(3293));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 5, 18, 56, 56, 349, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 5, 18, 56, 56, 349, DateTimeKind.Local).AddTicks(3305));

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Name", "Price", "Quantity", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 5, 18, 56, 56, 349, DateTimeKind.Local).AddTicks(3471), null, "Elma", 20.0, 500, 1, null },
                    { 2, 1, new DateTime(2024, 7, 5, 18, 56, 56, 349, DateTimeKind.Local).AddTicks(3474), null, "Karpuz", 100.0, 75, 1, null },
                    { 3, 1, new DateTime(2024, 7, 5, 18, 56, 56, 349, DateTimeKind.Local).AddTicks(3475), null, "Muz", 50.0, 60, 1, null },
                    { 4, 2, new DateTime(2024, 7, 5, 18, 56, 56, 349, DateTimeKind.Local).AddTicks(3476), null, "IPhone 14", 50000.0, 20, 1, null },
                    { 5, 2, new DateTime(2024, 7, 5, 18, 56, 56, 349, DateTimeKind.Local).AddTicks(3477), null, "Samsung Galaxy S24", 45000.0, 35, 1, null },
                    { 6, 2, new DateTime(2024, 7, 5, 18, 56, 56, 349, DateTimeKind.Local).AddTicks(3478), null, "Huawei Mate 50 Pro", 40000.0, 30, 1, null },
                    { 7, 3, new DateTime(2024, 7, 5, 18, 56, 56, 349, DateTimeKind.Local).AddTicks(3479), null, "Beyaz Peynir", 340.0, 100, 1, null },
                    { 8, 3, new DateTime(2024, 7, 5, 18, 56, 56, 349, DateTimeKind.Local).AddTicks(3479), null, "Tereyağ", 270.0, 60, 1, null },
                    { 9, 3, new DateTime(2024, 7, 5, 18, 56, 56, 349, DateTimeKind.Local).AddTicks(3480), null, "Kangal Sucuk", 750.0, 50, 1, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 4, 13, 12, 47, 291, DateTimeKind.Local).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 4, 13, 12, 47, 291, DateTimeKind.Local).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 4, 13, 12, 47, 291, DateTimeKind.Local).AddTicks(9867));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
