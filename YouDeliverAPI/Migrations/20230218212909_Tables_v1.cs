using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace YouDeliverAPI.Migrations
{
    /// <inheritdoc />
    public partial class Tables_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    AccountType = table.Column<string>(type: "longtext", nullable: true),
                    IsVerified = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true),
                    IsSuspended = table.Column<int>(type: "int", nullable: true),
                    IsVip = table.Column<int>(type: "int", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUsers", x => x.UserId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBusiness",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BusinessName = table.Column<string>(type: "longtext", nullable: true),
                    BusinessPhone = table.Column<string>(type: "longtext", nullable: true),
                    BusinessAddress = table.Column<string>(type: "longtext", nullable: true),
                    BusinessCity = table.Column<string>(type: "longtext", nullable: true),
                    BusinessBarangay = table.Column<string>(type: "longtext", nullable: true),
                    DateRegistered = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBusiness", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_TBusiness_TUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TUserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    MiddleName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: true),
                    City = table.Column<string>(type: "longtext", nullable: true),
                    Barangay = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    Avatar = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TUserInfo_TUsers_userId",
                        column: x => x.userId,
                        principalTable: "TUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "longtext", nullable: true),
                    Image = table.Column<string>(type: "longtext", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    ProductDescription = table.Column<string>(type: "longtext", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProducts", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_TProducts_TBusiness_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "TBusiness",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TCart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_TCart_TBusiness_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "TBusiness",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TCart_TProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TProducts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TCart_TUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TPurchase",
                columns: table => new
                {
                    PurhcaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: true),
                    ReferenceId = table.Column<string>(type: "longtext", nullable: true),
                    DateofPurchase = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPurchase", x => x.PurhcaseId);
                    table.ForeignKey(
                        name: "FK_TPurchase_TBusiness_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "TBusiness",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TPurchase_TProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TProducts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TPurchase_TUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TDelivery",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DUserId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: true),
                    DateAccepted = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDelivery", x => x.DeliveryId);
                    table.ForeignKey(
                        name: "FK_TDelivery_TPurchase_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "TPurchase",
                        principalColumn: "PurhcaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TDelivery_TUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TUsers",
                        principalColumn: "UserId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TBusiness_UserId",
                table: "TBusiness",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TCart_BusinessId",
                table: "TCart",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_TCart_ProductId",
                table: "TCart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TCart_UserId",
                table: "TCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TDelivery_ReferenceId",
                table: "TDelivery",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_TDelivery_UserId",
                table: "TDelivery",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TProducts_BusinessId",
                table: "TProducts",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_TPurchase_BusinessId",
                table: "TPurchase",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_TPurchase_ProductId",
                table: "TPurchase",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TPurchase_UserId",
                table: "TPurchase",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TUserInfo_userId",
                table: "TUserInfo",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TCart");

            migrationBuilder.DropTable(
                name: "TDelivery");

            migrationBuilder.DropTable(
                name: "TUserInfo");

            migrationBuilder.DropTable(
                name: "TPurchase");

            migrationBuilder.DropTable(
                name: "TProducts");

            migrationBuilder.DropTable(
                name: "TBusiness");

            migrationBuilder.DropTable(
                name: "TUsers");
        }
    }
}
