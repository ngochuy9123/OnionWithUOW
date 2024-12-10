using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_User_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_CartsDetail_Book_BookId",
                table: "CartsDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_CartsDetail_Carts_CartId",
                table: "CartsDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartsDetail",
                table: "CartsDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Catalogue",
                newName: "Catalogue",
                newSchema: "book");

            migrationBuilder.RenameTable(
                name: "BookCatalogue",
                newName: "BookCatalogue",
                newSchema: "book");

            migrationBuilder.RenameTable(
                name: "CartsDetail",
                newName: "CartDetail",
                newSchema: "book");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Cart",
                newSchema: "book");

            migrationBuilder.RenameIndex(
                name: "IX_CartsDetail_CartId",
                schema: "book",
                table: "CartDetail",
                newName: "IX_CartDetail_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartsDetail_BookId",
                schema: "book",
                table: "CartDetail",
                newName: "IX_CartDetail_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId",
                schema: "book",
                table: "Cart",
                newName: "IX_Cart_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartDetail",
                schema: "book",
                table: "CartDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                schema: "book",
                table: "Cart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_User_UserId",
                schema: "book",
                table: "Cart",
                column: "UserId",
                principalSchema: "book",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetail_Book_BookId",
                schema: "book",
                table: "CartDetail",
                column: "BookId",
                principalSchema: "book",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetail_Cart_CartId",
                schema: "book",
                table: "CartDetail",
                column: "CartId",
                principalSchema: "book",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_User_UserId",
                schema: "book",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDetail_Book_BookId",
                schema: "book",
                table: "CartDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDetail_Cart_CartId",
                schema: "book",
                table: "CartDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartDetail",
                schema: "book",
                table: "CartDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                schema: "book",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Catalogue",
                schema: "book",
                newName: "Catalogue");

            migrationBuilder.RenameTable(
                name: "BookCatalogue",
                schema: "book",
                newName: "BookCatalogue");

            migrationBuilder.RenameTable(
                name: "CartDetail",
                schema: "book",
                newName: "CartsDetail");

            migrationBuilder.RenameTable(
                name: "Cart",
                schema: "book",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetail_CartId",
                table: "CartsDetail",
                newName: "IX_CartsDetail_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetail_BookId",
                table: "CartsDetail",
                newName: "IX_CartsDetail_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_UserId",
                table: "Carts",
                newName: "IX_Carts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartsDetail",
                table: "CartsDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_User_UserId",
                table: "Carts",
                column: "UserId",
                principalSchema: "book",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartsDetail_Book_BookId",
                table: "CartsDetail",
                column: "BookId",
                principalSchema: "book",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartsDetail_Carts_CartId",
                table: "CartsDetail",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
