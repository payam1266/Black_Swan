using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Black_Swan.Persistence.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cardItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productcount = table.Column<int>(type: "int", nullable: false),
                    productprice = table.Column<float>(type: "real", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cardItems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paymentmethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postalcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalPrice = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    CreatedDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productCategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvalaible = table.Column<bool>(type: "bit", nullable: false),
                    sellerid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brandId = table.Column<int>(type: "int", nullable: false),
                    cityId = table.Column<int>(type: "int", nullable: false),
                    img = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    productCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_brands_brandId",
                        column: x => x.brandId,
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_cities_cityId",
                        column: x => x.cityId,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_productCategories_productCategoryId",
                        column: x => x.productCategoryId,
                        principalTable: "productCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productPrice = table.Column<float>(type: "real", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    subtotal = table.Column<float>(type: "real", nullable: false),
                    CreatedDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_orders_orderId",
                        column: x => x.orderId,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "brands",
                columns: new[] { "id", "CreatedDay", "LastModifiedDate", "description", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1275), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1284), "wow", "anahita" },
                    { 2, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1285), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1286), "amazing", "mitra" }
                });

            migrationBuilder.InsertData(
                table: "cardItems",
                columns: new[] { "id", "CreatedDay", "LastModifiedDate", "productcount", "productid", "productname", "productprice", "userid" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1444), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1445), 5, 1, "sekiro", 50f, null },
                    { 2, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1447), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1447), 5, 1, "santa", 50f, null }
                });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "id", "CreatedDay", "LastModifiedDate", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1578), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1579), "shiraz" },
                    { 2, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1580), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1580), "Tehran" }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "id", "CreatedDay", "LastModifiedDate", "address", "city", "customerid", "paymentmethod", "phone", "postalcode", "status", "totalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1667), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1668), "shiraz", "shiraz", null, "pay in place", "09364154728", "1234567891", 1, 500f },
                    { 2, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1670), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1671), "boshehr", "shiraz", null, "pay in place", "09364154728", "1234567891", 0, 1000f }
                });

            migrationBuilder.InsertData(
                table: "productCategories",
                columns: new[] { "id", "CreatedDay", "LastModifiedDate", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1835), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1836), "shoe" },
                    { 2, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1837), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1837), "dress" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "CreatedDay", "IsAvalaible", "LastModifiedDate", "brandId", "cityId", "color", "count", "description", "img", "name", "price", "productCategoryId", "sellerid", "size" },
                values: new object[] { 1, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1919), true, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1920), 1, 1, "black", 20, "jj", null, "payam", 250f, 1, "", "larg" });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "id", "CreatedDay", "LastModifiedDate", "orderId", "productId", "productName", "productPrice", "quantity", "subtotal" },
                values: new object[] { 1, new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1751), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1752), 1, 1, "jackob", 100f, 5, 500f });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_orderId",
                table: "OrderDetails",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_productId",
                table: "OrderDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_products_brandId",
                table: "products",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_products_cityId",
                table: "products",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_products_productCategoryId",
                table: "products",
                column: "productCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cardItems");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "productCategories");
        }
    }
}
