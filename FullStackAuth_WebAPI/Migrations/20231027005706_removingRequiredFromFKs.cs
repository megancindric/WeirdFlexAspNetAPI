using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class removingRequiredFromFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lifts_AspNetUsers_UserId",
                table: "Lifts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37c579b3-7197-4318-8e27-55f26019d476");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cfbf6b1-9c1f-4533-95b2-b1da38125a4c");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Lifts",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13bdb8d3-e279-429b-bfdd-872e39627d39", null, "Admin", "ADMIN" },
                    { "aa320ce0-9154-4b85-91e6-882228b8cf0b", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Lifts_AspNetUsers_UserId",
                table: "Lifts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lifts_AspNetUsers_UserId",
                table: "Lifts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13bdb8d3-e279-429b-bfdd-872e39627d39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa320ce0-9154-4b85-91e6-882228b8cf0b");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Lifts",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37c579b3-7197-4318-8e27-55f26019d476", null, "Admin", "ADMIN" },
                    { "8cfbf6b1-9c1f-4533-95b2-b1da38125a4c", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Lifts_AspNetUsers_UserId",
                table: "Lifts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
