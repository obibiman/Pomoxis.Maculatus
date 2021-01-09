using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleCommands.WebAPI.Migrations
{
    public partial class SchemaUpdateAgainToImagedataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                schema: "b2c",
                table: "B2C_Customer",
                type: "image",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                schema: "b2c",
                table: "B2C_Customer",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image",
                oldNullable: true);
        }
    }
}