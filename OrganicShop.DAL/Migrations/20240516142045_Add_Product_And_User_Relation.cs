using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_Product_And_User_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "BarCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Comments",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 16, 7, 20, 43, 984, DateTimeKind.Local).AddTicks(9184), new DateTime(2024, 5, 16, 7, 20, 43, 984, DateTimeKind.Local).AddTicks(9239) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8783), new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8828) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8835), new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8842) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8851), new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8855) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8859), new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8863) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8870), new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8874) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8879), new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8883) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8887), new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8907) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)8,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8911), new DateTime(2024, 5, 16, 7, 20, 43, 991, DateTimeKind.Local).AddTicks(8915) });

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 16, 7, 20, 43, 993, DateTimeKind.Local).AddTicks(2893), new DateTime(2024, 5, 16, 7, 20, 43, 993, DateTimeKind.Local).AddTicks(2927) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 16, 7, 20, 43, 999, DateTimeKind.Local).AddTicks(5486), new DateTime(2024, 5, 16, 7, 20, 43, 999, DateTimeKind.Local).AddTicks(5547) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 5, 16, 7, 20, 43, 999, DateTimeKind.Local).AddTicks(5739), new DateTime(2024, 5, 16, 7, 20, 43, 999, DateTimeKind.Local).AddTicks(5748) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BarCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Articles");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
