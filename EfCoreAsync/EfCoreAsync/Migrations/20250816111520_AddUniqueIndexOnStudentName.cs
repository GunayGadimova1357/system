﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreAsync.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexOnStudentName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_Name",
                table: "Students",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_Name",
                table: "Students");
        }
    }
}
