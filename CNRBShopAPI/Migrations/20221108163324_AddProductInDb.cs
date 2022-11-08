using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CNRBShopAPI.Migrations
{
    public partial class AddProductInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsProductOfTheWeek", "LongDescription", "Price", "ProductName", "ShortDescription" },
                values: new object[] { 1, 1, "", "", true, false, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", 25.25m, "Dry fit man", "Lorem Ipsum" });
        }
    }
}
