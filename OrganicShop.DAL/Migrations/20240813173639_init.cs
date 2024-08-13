using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrganicShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Office1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Office2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Office3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Percent = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    UsedCount = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaxCost = table.Column<int>(type: "int", nullable: true),
                    MinCost = table.Column<int>(type: "int", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Percent = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    UsedCount = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsLetters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextHtml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<byte>(type: "tinyint", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Permissions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Permissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethods",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Privacy_IsProfileImageVisible = table.Column<bool>(type: "bit", nullable: false),
                    Privacy_IsEmailVisible = table.Column<bool>(type: "bit", nullable: false),
                    Privacy_DeleteAccountAfterLogOut = table.Column<bool>(type: "bit", nullable: false),
                    EmailVerificationSendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CouponCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponCategories_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cvv2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankCards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsLetterMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetterMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsLetterMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NextCarts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NextCarts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EntityTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityOldData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityNewData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    CouponAmount = table.Column<int>(type: "int", nullable: false),
                    FinalPrice = table.Column<int>(type: "int", nullable: false),
                    ShippingPrice = table.Column<int>(type: "int", nullable: false),
                    ShippingMethodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDateEstimated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderAddress_AddressId = table.Column<long>(type: "bigint", nullable: false),
                    OrderAddress_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderAddress_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderAddress_Province = table.Column<int>(type: "int", nullable: false),
                    OrderAddress_ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderAddress_Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PermissionUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionId = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionUsers_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMessages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TagArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagArticles_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackingDescriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackingDescriptions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackingStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoneStatus = table.Column<int>(type: "int", nullable: false),
                    DoneDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Step = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackingStatuses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoldCount = table.Column<int>(type: "int", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountedPrice = table.Column<int>(type: "int", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<long>(type: "bigint", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFeedback = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    ArticleId = table.Column<int>(type: "int", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiscountProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountProducts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeMB = table.Column<float>(type: "real", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ArticleId = table.Column<int>(type: "int", nullable: true),
                    SellerId = table.Column<int>(type: "int", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Picture_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Picture_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Picture_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Picture_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PurchasedPrice = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<long>(type: "bigint", nullable: true),
                    NextCartId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    IsOrdered = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductItems_NextCarts_NextCartId",
                        column: x => x.NextCartId,
                        principalTable: "NextCarts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_PropertyTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagProducts_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WhishItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhishItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhishItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WhishItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContactUs",
                columns: new[] { "Id", "Address", "Description", "Email1", "Email2", "Office1", "Office2", "Office3", "Phone1", "Phone2", "Phone3", "PhoneNumber1", "PhoneNumber2", "PhoneNumber3", "ShortDescription", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[] { (byte)1, "Address", "Descriptions", "OrganicShop@gmail.com", null, "Tehran", null, null, "02134658899", null, null, "09121234455", null, null, "ShorDescriptions", new DateTime(2024, 8, 13, 10, 36, 38, 96, DateTimeKind.Local).AddTicks(4082), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 96, DateTimeKind.Local).AddTicks(4134) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "EnTitle", "ParentId", "Title", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[] { (byte)1, "Main Admin", null, "مدیر سایت", new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(705), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(760) });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "Id", "Name", "Price", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[,]
                {
                    { (byte)1, "پست پیشتاز", 30000, new DateTime(2024, 8, 13, 10, 36, 38, 195, DateTimeKind.Local).AddTicks(334), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 195, DateTimeKind.Local).AddTicks(386) },
                    { (byte)2, "پست سفارشی", 50000, new DateTime(2024, 8, 13, 10, 36, 38, 195, DateTimeKind.Local).AddTicks(887), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 195, DateTimeKind.Local).AddTicks(896) },
                    { (byte)3, "تیپاکس", 100000, new DateTime(2024, 8, 13, 10, 36, 38, 195, DateTimeKind.Local).AddTicks(1098), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 195, DateTimeKind.Local).AddTicks(1105) },
                    { (byte)4, "پیک موتوری", 120000, new DateTime(2024, 8, 13, 10, 36, 38, 195, DateTimeKind.Local).AddTicks(1273), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 195, DateTimeKind.Local).AddTicks(1287) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Privacy_DeleteAccountAfterLogOut", "Privacy_IsEmailVisible", "Privacy_IsProfileImageVisible", "BirthDate", "Email", "EmailVerificationSendDate", "Gender", "IsEmailVerified", "Name", "Password", "PhoneNumber", "Role", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[,]
                {
                    { 1L, false, false, false, null, "mas1379as@gmail.com", null, 1, true, "Mahdi Asadi", "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92", "09369753041", 1, new DateTime(2024, 8, 13, 10, 36, 38, 215, DateTimeKind.Local).AddTicks(8869), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 215, DateTimeKind.Local).AddTicks(8914) },
                    { 2L, false, true, true, null, "TestEmail@gmail.com", null, 1, false, "AmirAli", "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92", "09331234566", 2, new DateTime(2024, 8, 13, 10, 36, 38, 215, DateTimeKind.Local).AddTicks(9587), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 215, DateTimeKind.Local).AddTicks(9596) }
                });

            migrationBuilder.InsertData(
                table: "PermissionUsers",
                columns: new[] { "Id", "PermissionId", "UserId", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[] { 1, (byte)1, 1L, new DateTime(2024, 8, 13, 10, 36, 38, 152, DateTimeKind.Local).AddTicks(6159), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 152, DateTimeKind.Local).AddTicks(6211) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "EnTitle", "ParentId", "Title", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[,]
                {
                    { (byte)2, "Users Admin", (byte)1, "مدیریت کاربران", new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(764), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(776) },
                    { (byte)3, "Products Admin", (byte)1, "مدیریت محصولات", new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(786), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(788) },
                    { (byte)4, "Permissions Admin", (byte)1, "مدیریت مجوز ها", new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(791), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(793) },
                    { (byte)5, "Comments Admin", (byte)1, "مدیریت نظرات", new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(801), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(803) },
                    { (byte)6, "Discounts Admin", (byte)1, "مدیریت تخفیف ها", new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(808), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(810) },
                    { (byte)7, "Categories Admin", (byte)1, "مدیریت دسته ها", new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(813), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(838) }
                });

            migrationBuilder.InsertData(
                table: "Picture",
                columns: new[] { "Id", "ArticleId", "CategoryId", "IsMain", "Name", "ProductId", "SellerId", "SizeMB", "Type", "UserId", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[] { 1L, null, null, true, "joker.png", null, null, 0.5f, 0, 1L, new DateTime(2024, 8, 13, 10, 36, 38, 176, DateTimeKind.Local).AddTicks(3718), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 176, DateTimeKind.Local).AddTicks(3773) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "EnTitle", "ParentId", "Title", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[] { (byte)8, "Giving Permission", (byte)4, "صدور مجوز", new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(841), null, true, false, new DateTime(2024, 8, 13, 10, 36, 38, 107, DateTimeKind.Local).AddTicks(844) });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_SellerId",
                table: "Addresses",
                column: "SellerId",
                unique: true,
                filter: "[SellerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_UserId",
                table: "BankCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SellerId",
                table: "Comments",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponCategories_CategoryId",
                table: "CouponCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponCategories_CouponId",
                table: "CouponCategories",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProducts_DiscountId",
                table: "DiscountProducts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProducts_ProductId",
                table: "DiscountProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsLetterMembers_UserId",
                table: "NewsLetterMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NextCarts_UserId",
                table: "NextCarts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operations_UserId",
                table: "Operations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentId",
                table: "Permissions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUsers_PermissionId",
                table: "PermissionUsers",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUsers_UserId",
                table: "PermissionUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ArticleId",
                table: "Picture",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_CategoryId",
                table: "Picture",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ProductId",
                table: "Picture",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_SellerId",
                table: "Picture",
                column: "SellerId",
                unique: true,
                filter: "[SellerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_UserId",
                table: "Picture",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_CartId",
                table: "ProductItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_NextCartId",
                table: "ProductItems",
                column: "NextCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_OrderId",
                table: "ProductItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ProductId",
                table: "ProductItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ProductId",
                table: "Properties",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_TypeId",
                table: "Properties",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_UserId",
                table: "Sellers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagArticles_ArticleId",
                table: "TagArticles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_TagArticles_TagId",
                table: "TagArticles",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagProducts_ProductId",
                table: "TagProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TagProducts_TagId",
                table: "TagProducts",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingDescriptions_OrderId",
                table: "TrackingDescriptions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingStatuses_OrderId",
                table: "TrackingStatuses",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_UserId",
                table: "UserMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WhishItems_ProductId",
                table: "WhishItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WhishItems_UserId",
                table: "WhishItems",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "CouponCategories");

            migrationBuilder.DropTable(
                name: "DiscountProducts");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "NewsLetterMembers");

            migrationBuilder.DropTable(
                name: "NewsLetters");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "PermissionUsers");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "ProductItems");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "ShippingMethods");

            migrationBuilder.DropTable(
                name: "TagArticles");

            migrationBuilder.DropTable(
                name: "TagProducts");

            migrationBuilder.DropTable(
                name: "TrackingDescriptions");

            migrationBuilder.DropTable(
                name: "TrackingStatuses");

            migrationBuilder.DropTable(
                name: "UserMessages");

            migrationBuilder.DropTable(
                name: "WhishItems");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "NextCarts");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
