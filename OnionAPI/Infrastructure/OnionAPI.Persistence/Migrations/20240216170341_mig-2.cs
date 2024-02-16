using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 3, 41, 262, DateTimeKind.Local).AddTicks(5444), "Beauty" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 3, 41, 262, DateTimeKind.Local).AddTicks(6786), "Baby, Industrial & Games" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 3, 41, 262, DateTimeKind.Local).AddTicks(6826), "Games, Health & Computers" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 20, 3, 41, 262, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 20, 3, 41, 262, DateTimeKind.Local).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 20, 3, 41, 262, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 16, 20, 3, 41, 262, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 3, 41, 264, DateTimeKind.Local).AddTicks(8685), "Qui iure voluptas nostrum rem.", "Sapiente." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 3, 41, 264, DateTimeKind.Local).AddTicks(8718), "Quia occaecati voluptatum dolor dolorem.", "Magni soluta." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 3, 41, 264, DateTimeKind.Local).AddTicks(8748), "Eos quo totam vel et.", "Unde occaecati." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 3, 41, 267, DateTimeKind.Local).AddTicks(1934), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 6.881618349336270m, 241.11m, "Unbranded Frozen Hat" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 3, 41, 267, DateTimeKind.Local).AddTicks(1989), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 7.715230677289770m, 885.61m, "Small Fresh Chips" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 2, 15, 21, 4, 2, 265, DateTimeKind.Local).AddTicks(4410), "Kids, Beauty & Industrial" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 2, 15, 21, 4, 2, 265, DateTimeKind.Local).AddTicks(4425), "Baby & Shoes" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 2, 15, 21, 4, 2, 265, DateTimeKind.Local).AddTicks(4435), "Grocery & Computers" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 15, 21, 4, 2, 265, DateTimeKind.Local).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 15, 21, 4, 2, 265, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 15, 21, 4, 2, 265, DateTimeKind.Local).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 15, 21, 4, 2, 265, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 15, 21, 4, 2, 267, DateTimeKind.Local).AddTicks(1735), "Blanditiis exercitationem soluta hic ut.", "Id." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 15, 21, 4, 2, 267, DateTimeKind.Local).AddTicks(1771), "Officia rerum velit modi voluptatem.", "Adipisci voluptatibus." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 2, 15, 21, 4, 2, 267, DateTimeKind.Local).AddTicks(1802), "Eius est quidem dignissimos officiis.", "Ducimus provident." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 2, 15, 21, 4, 2, 268, DateTimeKind.Local).AddTicks(7075), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 7.863505882046690m, 944.79m, "Sleek Plastic Pants" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 2, 15, 21, 4, 2, 268, DateTimeKind.Local).AddTicks(7102), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 5.906992819444720m, 940.28m, "Awesome Rubber Keyboard" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
