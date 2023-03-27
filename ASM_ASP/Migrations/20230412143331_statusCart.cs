using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_ASP.Migrations
{
    public partial class statusCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CartDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CartDetails");
        }
    }
}
