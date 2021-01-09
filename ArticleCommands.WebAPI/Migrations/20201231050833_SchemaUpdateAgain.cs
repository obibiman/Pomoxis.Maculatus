using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ArticleCommands.WebAPI.Migrations
{
    public partial class SchemaUpdateAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "Phone_Number");

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
                name: "EmailAddress",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "Email_Address");

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
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Occupation",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone_Number",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modified_By",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Middle_Name",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Citizenship_Status",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email_Address",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_of_Birth",
                schema: "b2c",
                table: "B2C_Customer",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Modified",
                schema: "b2c",
                table: "B2C_Customer",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Created",
                schema: "b2c",
                table: "B2C_Customer",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Created_By",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                schema: "b2c",
                table: "B2C_Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                schema: "b2c",
                table: "B2C_Customer");

            migrationBuilder.RenameColumn(
                name: "Phone_Number",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "PhoneNumber");

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
                name: "Email_Address",
                schema: "b2c",
                table: "B2C_Customer",
                newName: "EmailAddress");

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
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Occupation",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ImmigrationStatus",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                schema: "b2c",
                table: "B2C_Customer",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                schema: "b2c",
                table: "B2C_Customer",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                schema: "b2c",
                table: "B2C_Customer",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "b2c",
                table: "B2C_Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}