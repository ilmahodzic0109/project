using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesDAL.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    brandId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Brand__06B772993BFC65BF", x => x.brandId);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    colorId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Color__70A64FDDEA7A9062", x => x.colorId);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    conditionId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Conditio__A29757BCA37FCE50", x => x.conditionId);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    genderId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Gender__306E22405653D339", x => x.genderId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    productCategoryId = table.Column<int>(type: "int", nullable: false),
                    category = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductC__A944253B33C4D4B3", x => x.productCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    createdAt = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateOnly>(type: "date", nullable: true),
                    modifiedAt = table.Column<DateOnly>(type: "date", nullable: true),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    isLogged = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__CB9A1CFF54393212", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datePublished = table.Column<DateOnly>(type: "date", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deliveryTime = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    shippingPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    colorId = table.Column<int>(type: "int", nullable: false),
                    conditionId = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    productCategory = table.Column<int>(type: "int", nullable: false),
                    brandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__2D10D16AE5565B2C", x => x.productId);
                    table.ForeignKey(
                        name: "FK__Products__brandI__59FA5E80",
                        column: x => x.brandId,
                        principalTable: "Brand",
                        principalColumn: "brandId");
                    table.ForeignKey(
                        name: "FK__Products__colorI__5629CD9C",
                        column: x => x.colorId,
                        principalTable: "Color",
                        principalColumn: "colorId");
                    table.ForeignKey(
                        name: "FK__Products__condit__571DF1D5",
                        column: x => x.conditionId,
                        principalTable: "Condition",
                        principalColumn: "conditionId");
                    table.ForeignKey(
                        name: "FK__Products__gender__5812160E",
                        column: x => x.gender,
                        principalTable: "Gender",
                        principalColumn: "genderId");
                    table.ForeignKey(
                        name: "FK__Products__produc__59063A47",
                        column: x => x.productCategory,
                        principalTable: "ProductCategory",
                        principalColumn: "productCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    totalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    postalCode = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__0809335D62E633A0", x => x.orderId);
                    table.ForeignKey(
                        name: "FK__Order__userId__6C190EBB",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    cartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    addedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__415B03B82766E2AA", x => x.cartId);
                    table.ForeignKey(
                        name: "FK__Cart__productId__60A75C0F",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                columns: table => new
                {
                    productInventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantityInStock = table.Column<int>(type: "int", nullable: false),
                    itemSold = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductI__5F0EFFD7CB1F083E", x => x.productInventoryId);
                    table.ForeignKey(
                        name: "FK__ProductIn__produ__5CD6CB2B",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateTable(
                name: "ProductVersions",
                columns: table => new
                {
                    versionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datePublished = table.Column<DateOnly>(type: "date", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    modifiedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductV__E772A490E8A5327B", x => x.versionId);
                    table.ForeignKey(
                        name: "FK__ProductVe__produ__72C60C4A",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    paymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__A0D9EFC6BDDC99DE", x => x.paymentId);
                    table.ForeignKey(
                        name: "FK__Payment__orderId__6EF57B66",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "orderId");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    orderDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    priceAtPurchase = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    versionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__5EEE5273DA02BB73", x => x.orderDetailsId);
                    table.ForeignKey(
                        name: "FK__OrderDeta__order__778AC167",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "orderId");
                    table.ForeignKey(
                        name: "FK__OrderDeta__produ__787EE5A0",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId");
                    table.ForeignKey(
                        name: "FK__OrderDeta__versi__797309D9",
                        column: x => x.versionId,
                        principalTable: "ProductVersions",
                        principalColumn: "versionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_productId",
                table: "Cart",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_userId",
                table: "Order",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_orderId",
                table: "OrderDetails",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_productId",
                table: "OrderDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_versionId",
                table: "OrderDetails",
                column: "versionId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_orderId",
                table: "Payment",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_productId",
                table: "ProductInventory",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_brandId",
                table: "Products",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_colorId",
                table: "Products",
                column: "colorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_conditionId",
                table: "Products",
                column: "conditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_gender",
                table: "Products",
                column: "gender");

            migrationBuilder.CreateIndex(
                name: "IX_Products_productCategory",
                table: "Products",
                column: "productCategory");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVersions_productId",
                table: "ProductVersions",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "UQ__User__AB6E6164A178E0CE",
                table: "User",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "ProductInventory");

            migrationBuilder.DropTable(
                name: "ProductVersions");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
