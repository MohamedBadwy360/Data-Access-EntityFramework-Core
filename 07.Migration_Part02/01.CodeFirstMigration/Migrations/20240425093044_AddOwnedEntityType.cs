using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01.CodeFirstMigration.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnedEntityType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Sections",
                type: "TIME",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Sections",
                type: "TIME",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Sections",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "TIME");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Sections",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "TIME");
        }
    }
}
