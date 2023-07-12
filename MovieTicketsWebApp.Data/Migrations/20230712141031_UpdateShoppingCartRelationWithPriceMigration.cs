using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTicketsWebApp.Web.Data.Migrations
{
    public partial class UpdateShoppingCartRelationWithPriceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "MovieTicketShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "MovieTicketShoppingCarts");
        }
    }
}
