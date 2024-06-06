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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsFixDiscount = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    FixValue = table.Column<int>(type: "int", nullable: true),
                    Percent = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeDelivery = table.Column<bool>(type: "bit", nullable: false),
                    MinPrice = table.Column<int>(type: "int", nullable: true),
                    MaxPrice = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Role = table.Column<int>(type: "int", nullable: false),
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
                name: "DiscountCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountCategories_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    DiscountPrice = table.Column<int>(type: "int", nullable: false),
                    FinalPrice = table.Column<int>(type: "int", nullable: false),
                    ShippingPrice = table.Column<int>(type: "int", nullable: false),
                    ShippingMethodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDateEstimated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    OrderAddress_AddressId = table.Column<long>(type: "bigint", nullable: false),
                    OrderAddress_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderAddress_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderAddress_Province = table.Column<int>(type: "int", nullable: false),
                    OrderAddress_ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderAddress_Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Stock = table.Column<int>(type: "int", nullable: false),
                    SoldCount = table.Column<int>(type: "int", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountedPrice = table.Column<int>(type: "int", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Status = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductVarientId = table.Column<long>(type: "bigint", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<long>(type: "bigint", nullable: true),
                    NextCartId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    IsOrdered = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "ProductVarient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        name: "FK_Properties_Properties_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Properties",
                        principalColumn: "Id");
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                values: new object[] { (byte)1, "Address", "Descriptions", "OrganicShop@gmail.com", null, "Tehran", null, null, "02134658899", null, null, "09121234455", null, null, "ShorDescriptions", new DateTime(2024, 6, 5, 23, 56, 50, 871, DateTimeKind.Local).AddTicks(1695), null, true, false, new DateTime(2024, 6, 5, 23, 56, 50, 871, DateTimeKind.Local).AddTicks(1939) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "EnTitle", "ParentId", "Title", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[] { (byte)1, "Main Admin", null, "مدیر سایت", new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3621), null, true, false, new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3689) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "PhoneNumber", "Role", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[,]
                {
                    { 1L, "mas1379as@gmail.com", "Mahdi Asadi", "123456", "09369753041", 2, new DateTime(2024, 6, 5, 23, 56, 50, 899, DateTimeKind.Local).AddTicks(5283), null, true, false, new DateTime(2024, 6, 5, 23, 56, 50, 899, DateTimeKind.Local).AddTicks(5345) },
                    { 2L, "TestEmail@gmail.com", "AmirAli", "1234", "09331234566", 3, new DateTime(2024, 6, 5, 23, 56, 50, 899, DateTimeKind.Local).AddTicks(5594), null, true, false, new DateTime(2024, 6, 5, 23, 56, 50, 899, DateTimeKind.Local).AddTicks(5604) }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "EnTitle", "ParentId", "Title", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[,]
                {
                    { (byte)2, "Users Admin", (byte)1, "مدیریت کاربران", new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3699), null, true, false, new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3710) },
                    { (byte)3, "Products Admin", (byte)1, "مدیریت محصولات", new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3722), null, true, false, new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3727) },
                    { (byte)4, "Permissions Admin", (byte)1, "مدیریت مجوز ها", new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3734), null, true, false, new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3739) },
                    { (byte)5, "Comments Admin", (byte)1, "مدیریت نظرات", new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3752), null, true, false, new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3757) },
                    { (byte)6, "Discounts Admin", (byte)1, "مدیریت تخفیف ها", new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3765), null, true, false, new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3770) },
                    { (byte)7, "Categories Admin", (byte)1, "مدیریت دسته ها", new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3775), null, true, false, new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3805) }
                });

            migrationBuilder.InsertData(
                table: "Picture",
                columns: new[] { "Id", "ArticleId", "CategoryId", "IsMain", "Name", "ProductId", "SellerId", "SizeMB", "Type", "UserId", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[] { 1L, null, null, true, "joker.png", null, null, 0.5f, 0, 1L, new DateTime(2024, 6, 5, 23, 56, 50, 886, DateTimeKind.Local).AddTicks(7596), null, true, false, new DateTime(2024, 6, 5, 23, 56, 50, 886, DateTimeKind.Local).AddTicks(7662) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "EnTitle", "ParentId", "Title", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[] { (byte)8, "Giving Permission", (byte)4, "صدور مجوز", new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3812), null, true, false, new DateTime(2024, 6, 5, 23, 56, 50, 883, DateTimeKind.Local).AddTicks(3817) });

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
                name: "IX_DiscountCategories_CategoryId",
                table: "DiscountCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCategories_DiscountId",
                table: "DiscountCategories",
                column: "DiscountId");

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
                name: "IX_ProductVarient_ProductId",
                table: "ProductVarient",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_BaseId",
                table: "Properties",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ProductId",
                table: "Properties",
                column: "ProductId");

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
                name: "DiscountCategories");

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
                name: "ProductVarient");

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
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "NextCarts");

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
