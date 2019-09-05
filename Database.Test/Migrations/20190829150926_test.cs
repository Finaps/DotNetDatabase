using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Test.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "testEfObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CoolString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testEfObjects", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "testEfObjects");
        }
    }
}
