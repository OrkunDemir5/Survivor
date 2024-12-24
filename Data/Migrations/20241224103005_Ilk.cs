using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Survivor.Data.Migrations
{
    /// <inheritdoc />
    public partial class Ilk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitors_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6821), false, new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6830), "Ünlüler" },
                    { 2, new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6832), false, new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6832), "Gönüllüler" }
                });

            migrationBuilder.InsertData(
                table: "Competitors",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "FirstName", "IsDeleted", "LastName", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6896), "Acun", false, "Ilıcalı", new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6897) },
                    { 2, 1, new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6898), "Aleyna", false, "Avcı", new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6898) },
                    { 3, 1, new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6899), "Hadise", false, "Açıkgöz", new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6900) },
                    { 4, 2, new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6901), "Ahmet", false, "Yılmaz", new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6901) },
                    { 5, 2, new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6902), "Elif", false, "Demirtaş", new DateTime(2024, 12, 24, 13, 30, 5, 113, DateTimeKind.Local).AddTicks(6902) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_CategoryId",
                table: "Competitors",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competitors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
