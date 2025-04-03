using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBW5.Migrations
{
    /// <inheritdoc />
    public partial class StrayHospitals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StrayHospitals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoatColor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HasMicrochip = table.Column<bool>(type: "bit", nullable: false),
                    MicrochipNumber = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VetId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrayHospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrayHospitals_AspNetUsers_VetId",
                        column: x => x.VetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_MicrochipNumber",
                table: "Animals",
                column: "MicrochipNumber",
                unique: true,
                filter: "[MicrochipNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StrayHospitals_MicrochipNumber",
                table: "StrayHospitals",
                column: "MicrochipNumber",
                unique: true,
                filter: "[MicrochipNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StrayHospitals_VetId",
                table: "StrayHospitals",
                column: "VetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrayHospitals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_MicrochipNumber",
                table: "Animals");
        }
    }
}
