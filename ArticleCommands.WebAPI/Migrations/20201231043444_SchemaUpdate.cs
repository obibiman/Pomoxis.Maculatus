using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ArticleCommands.WebAPI.Migrations
{
    public partial class SchemaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modified_By",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Middle_Name",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "Loyalty_Member",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "LoyaltyEnrolled");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Citizenship_Status",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "ImmigrationStatus");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Date_of_Birth",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "Date_Modified",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "Date_Created",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "Credit_Score",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "CreditRating");

            migrationBuilder.RenameColumn(
                name: "Created_By",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "CreatedBy");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Occupation",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ImmigrationStatus",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                schema: "b2c",
                table: "B2C_Customer");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "b2c",
                table: "B2C_Customer");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "Modified_By");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "Middle_Name");

            migrationBuilder.RenameColumn(
                name: "LoyaltyEnrolled",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "Loyalty_Member");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "ImmigrationStatus",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "Citizenship_Status");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "First_Name");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "Date_of_Birth");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "Date_Modified");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "Date_Created");

            migrationBuilder.RenameColumn(
                name: "CreditRating",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "Credit_Score");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "Created_By");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                schema: "b2c",
                table: "B2C_Customer",
                type: "decimal",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Occupation",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modified_By",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Middle_Name",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Citizenship_Status",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_of_Birth",
                schema: "b2c",
                table: "B2C_Customer",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Modified",
                schema: "b2c",
                table: "B2C_Customer",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Created",
                schema: "b2c",
                table: "B2C_Customer",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Created_By",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}