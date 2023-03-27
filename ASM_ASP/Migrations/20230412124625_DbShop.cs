using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_ASP.Migrations
{
    public partial class DbShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill",
                table: "BillDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product",
                table: "BillDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Carts_UserId",
                table: "CartDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Products_IdProduct",
                table: "CartDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Color",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Material",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Size",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdColor",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdMaterial",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdSize",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_IdProduct",
                table: "CartDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillDetail_IdBill",
                table: "BillDetail");

            migrationBuilder.DropIndex(
                name: "IX_BillDetail_IdProduct",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdColor",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdMaterial",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdSize",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "CartDetails");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "IdBill",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BillDetail");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "AvailableQuantity");

            migrationBuilder.RenameColumn(
                name: "PayDate",
                table: "Bills",
                newName: "DateofCreation");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "varchar(500)",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CartDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "CartDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "BillDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<Guid>(
                name: "BillId",
                table: "BillDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "BillDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Name",
                table: "Users",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_ProductId",
                table: "CartDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_BillId",
                table: "BillDetail",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_ProductId",
                table: "BillDetail",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_Bills_BillId",
                table: "BillDetail",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetail_Products_ProductId",
                table: "BillDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Carts_UserId",
                table: "CartDetails",
                column: "UserId",
                principalTable: "Carts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Products_ProductId",
                table: "CartDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_Bills_BillId",
                table: "BillDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BillDetail_Products_ProductId",
                table: "BillDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Carts_UserId",
                table: "CartDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Products_ProductId",
                table: "CartDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Name",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_ProductId",
                table: "CartDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillDetail_BillId",
                table: "BillDetail");

            migrationBuilder.DropIndex(
                name: "IX_BillDetail_ProductId",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "varchar(500)",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CartDetails");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "BillDetail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "BillDetail");

            migrationBuilder.RenameColumn(
                name: "AvailableQuantity",
                table: "Products",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "DateofCreation",
                table: "Bills",
                newName: "PayDate");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "varchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddColumn<Guid>(
                name: "IdColor",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdMaterial",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdSize",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CartDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProduct",
                table: "CartDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "BillDetail",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "IdBill",
                table: "BillDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdProduct",
                table: "BillDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BillDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeOfShoe = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdColor",
                table: "Products",
                column: "IdColor");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdMaterial",
                table: "Products",
                column: "IdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdSize",
                table: "Products",
                column: "IdSize");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_IdProduct",
                table: "CartDetails",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_IdBill",
                table: "BillDetail",
                column: "IdBill");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_IdProduct",
                table: "BillDetail",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill",
                table: "BillDetail",
                column: "IdBill",
                principalTable: "Bills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product",
                table: "BillDetail",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Carts_UserId",
                table: "CartDetails",
                column: "UserId",
                principalTable: "Carts",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Products_IdProduct",
                table: "CartDetails",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Color",
                table: "Products",
                column: "IdColor",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Material",
                table: "Products",
                column: "IdMaterial",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Size",
                table: "Products",
                column: "IdSize",
                principalTable: "Sizes",
                principalColumn: "Id");
        }
    }
}
