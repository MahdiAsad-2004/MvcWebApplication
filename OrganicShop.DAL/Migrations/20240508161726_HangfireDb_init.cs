using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HangfireDb_init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 4, 30, 20, 750, DateTimeKind.Local).AddTicks(1700), new DateTime(2024, 5, 8, 4, 30, 20, 750, DateTimeKind.Local).AddTicks(1761) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3053), new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3110) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3115), new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3121) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3135), new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3137) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3140), new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3142) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3148), new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3151) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3155), new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3158) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3162), new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)8,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3183), new DateTime(2024, 5, 8, 4, 30, 20, 758, DateTimeKind.Local).AddTicks(3186) });

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 4, 30, 20, 759, DateTimeKind.Local).AddTicks(9450), new DateTime(2024, 5, 8, 4, 30, 20, 759, DateTimeKind.Local).AddTicks(9505) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 4, 30, 20, 767, DateTimeKind.Local).AddTicks(6008), new DateTime(2024, 5, 8, 4, 30, 20, 767, DateTimeKind.Local).AddTicks(6063) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 8, 4, 30, 20, 767, DateTimeKind.Local).AddTicks(6280), new DateTime(2024, 5, 8, 4, 30, 20, 767, DateTimeKind.Local).AddTicks(6290) });
        }
    }
}
