using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_ProductVarient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.CreateTable(
                name: "ProductVarient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVarient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVarient_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 11, 6, 54, 14, 654, DateTimeKind.Local).AddTicks(9620), new DateTime(2024, 5, 11, 6, 54, 14, 654, DateTimeKind.Local).AddTicks(9673) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4038), new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4105), new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4113) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4123), new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4125) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4128), new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4135), new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4142), new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4147), new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4169) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)8,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4172), new DateTime(2024, 5, 11, 6, 54, 14, 661, DateTimeKind.Local).AddTicks(4174) });

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 11, 6, 54, 14, 662, DateTimeKind.Local).AddTicks(8652), new DateTime(2024, 5, 11, 6, 54, 14, 662, DateTimeKind.Local).AddTicks(8679) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 11, 6, 54, 14, 668, DateTimeKind.Local).AddTicks(1564), new DateTime(2024, 5, 11, 6, 54, 14, 668, DateTimeKind.Local).AddTicks(1616) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 11, 6, 54, 14, 668, DateTimeKind.Local).AddTicks(1813), new DateTime(2024, 5, 11, 6, 54, 14, 668, DateTimeKind.Local).AddTicks(1821) });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVarient_ProductId",
                table: "ProductVarient",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVarient");

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    UnitType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 9, 17, 24, 826, DateTimeKind.Local).AddTicks(900), new DateTime(2024, 5, 8, 9, 17, 24, 826, DateTimeKind.Local).AddTicks(952) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1222), new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1283) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1288), new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1296) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1306), new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1314), new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1325) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1332), new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1336) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1341), new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1344) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1348), new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1368) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)8,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1371), new DateTime(2024, 5, 8, 9, 17, 24, 833, DateTimeKind.Local).AddTicks(1374) });

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 9, 17, 24, 834, DateTimeKind.Local).AddTicks(7294), new DateTime(2024, 5, 8, 9, 17, 24, 834, DateTimeKind.Local).AddTicks(7336) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 9, 17, 24, 840, DateTimeKind.Local).AddTicks(2368), new DateTime(2024, 5, 8, 9, 17, 24, 840, DateTimeKind.Local).AddTicks(2412) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 9, 17, 24, 840, DateTimeKind.Local).AddTicks(2630), new DateTime(2024, 5, 8, 9, 17, 24, 840, DateTimeKind.Local).AddTicks(2639) });

            migrationBuilder.CreateIndex(
                name: "IX_Units_ProductId",
                table: "Units",
                column: "ProductId");
        }
    }
}
