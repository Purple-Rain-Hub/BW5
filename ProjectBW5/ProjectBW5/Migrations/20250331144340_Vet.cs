using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBW5.Migrations
{
    /// <inheritdoc />
    public partial class Vet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoatColor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HasMicrochip = table.Column<bool>(type: "bit", nullable: false),
                    MicrochipNumber = table.Column<int>(type: "int", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamObjective = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExamTreatment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VetId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examinations_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examinations_AspNetUsers_VetId",
                        column: x => x.VetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HospitalObjective = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HospitalTreatment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VetId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitalizations_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospitalizations_AspNetUsers_VetId",
                        column: x => x.VetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_AnimalId",
                table: "Examinations",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_VetId",
                table: "Examinations",
                column: "VetId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_AnimalId",
                table: "Hospitalizations",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_VetId",
                table: "Hospitalizations",
                column: "VetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Hospitalizations");

            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
