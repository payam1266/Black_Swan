using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Black_Swan.Persistence.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3029), new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3029) });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2504), new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2512) });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2514), new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2514) });

            migrationBuilder.UpdateData(
                table: "cardItems",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2757), new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2759) });

            migrationBuilder.UpdateData(
                table: "cardItems",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2761), new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2761) });

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2854), new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2855) });

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2856), new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2856) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2935), new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2936) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2938), new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(2938) });

            migrationBuilder.UpdateData(
                table: "productCategories",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3110), new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3111) });

            migrationBuilder.UpdateData(
                table: "productCategories",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3112), new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3113) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate", "count", "description", "name", "price", "size" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3192), new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3193), 50, "its nice", "Jackob", 120f, "large" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "CreatedDay", "IsAvalaible", "LastModifiedDate", "brandId", "cityId", "color", "count", "description", "img", "name", "price", "productCategoryId", "sellerid", "size" },
                values: new object[] { 2, new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3195), true, new DateTime(2024, 1, 31, 11, 59, 2, 551, DateTimeKind.Local).AddTicks(3195), 2, 2, "brown", 20, "its nice", null, "mitra", 200f, 2, "", "small" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1751), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1752) });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1275), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1284) });

            migrationBuilder.UpdateData(
                table: "brands",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1285), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1286) });

            migrationBuilder.UpdateData(
                table: "cardItems",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1444), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1445) });

            migrationBuilder.UpdateData(
                table: "cardItems",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1447), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1447) });

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1578), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1579) });

            migrationBuilder.UpdateData(
                table: "cities",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1580), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1580) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1667), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1668) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1670), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1671) });

            migrationBuilder.UpdateData(
                table: "productCategories",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1835), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1836) });

            migrationBuilder.UpdateData(
                table: "productCategories",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDay", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1837), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1837) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDay", "LastModifiedDate", "count", "description", "name", "price", "size" },
                values: new object[] { new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1919), new DateTime(2024, 1, 31, 11, 51, 17, 605, DateTimeKind.Local).AddTicks(1920), 20, "jj", "payam", 250f, "larg" });
        }
    }
}
