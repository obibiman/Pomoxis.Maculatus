using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleCommands.WebAPI.Migrations
{
    public partial class SchemaUpdateAgainToImagedataTypeAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                schema: "b2c",
                table: "B2C_Customer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                schema: "b2c",
                table: "B2C_Customer",
                type: "decimal (18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                schema: "b2c",
                table: "B2C_Customer",
                type: "decimal",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal (18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                schema: "b2c",
                table: "B2C_Customer",
                type: "image",
                nullable: true);
        }
    }
}