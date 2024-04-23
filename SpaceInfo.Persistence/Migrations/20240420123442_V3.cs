using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceInfo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DailyInfo",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "NearEarthObjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NeoReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NasaJplUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbsoluteMagnitudeH = table.Column<double>(type: "float", nullable: false),
                    IsPotentiallyHazardous = table.Column<bool>(type: "bit", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NearEarthObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CloseApproachData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NearEarthObjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CloseApproachDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseApproachDateFull = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpochDateCloseApproach = table.Column<double>(type: "float", nullable: false),
                    OrbitingBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloseApproachData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CloseApproachData_NearEarthObjects_NearEarthObjectId",
                        column: x => x.NearEarthObjectId,
                        principalTable: "NearEarthObjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Diameter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NearEarthObjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diameter_NearEarthObjects_NearEarthObjectId",
                        column: x => x.NearEarthObjectId,
                        principalTable: "NearEarthObjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NearEarthObjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Previous = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Next = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Self = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_NearEarthObjects_NearEarthObjectId",
                        column: x => x.NearEarthObjectId,
                        principalTable: "NearEarthObjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MissDistances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CloseApproachDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Astronomical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lunar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kilometers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissDistances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissDistances_CloseApproachData_CloseApproachDataId",
                        column: x => x.CloseApproachDataId,
                        principalTable: "CloseApproachData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RelativeVelocity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CloseApproachDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KilometersPerSecond = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KilometersPerHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MilesPerHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelativeVelocity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelativeVelocity_CloseApproachData_CloseApproachDataId",
                        column: x => x.CloseApproachDataId,
                        principalTable: "CloseApproachData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstimatedDiameterMin = table.Column<double>(type: "float", nullable: false),
                    EstimatedDiameterMax = table.Column<double>(type: "float", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feet_Diameter_DiameterId",
                        column: x => x.DiameterId,
                        principalTable: "Diameter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kilometer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstimatedDiameterMin = table.Column<double>(type: "float", nullable: false),
                    EstimatedDiameterMax = table.Column<double>(type: "float", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kilometer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kilometer_Diameter_DiameterId",
                        column: x => x.DiameterId,
                        principalTable: "Diameter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Meter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstimatedDiameterMin = table.Column<double>(type: "float", nullable: false),
                    EstimatedDiameterMax = table.Column<double>(type: "float", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meter_Diameter_DiameterId",
                        column: x => x.DiameterId,
                        principalTable: "Diameter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstimatedDiameterMin = table.Column<double>(type: "float", nullable: false),
                    EstimatedDiameterMax = table.Column<double>(type: "float", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mile_Diameter_DiameterId",
                        column: x => x.DiameterId,
                        principalTable: "Diameter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CloseApproachData_NearEarthObjectId",
                table: "CloseApproachData",
                column: "NearEarthObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Diameter_NearEarthObjectId",
                table: "Diameter",
                column: "NearEarthObjectId",
                unique: true,
                filter: "[NearEarthObjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Feet_DiameterId",
                table: "Feet",
                column: "DiameterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kilometer_DiameterId",
                table: "Kilometer",
                column: "DiameterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Links_NearEarthObjectId",
                table: "Links",
                column: "NearEarthObjectId",
                unique: true,
                filter: "[NearEarthObjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Meter_DiameterId",
                table: "Meter",
                column: "DiameterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mile_DiameterId",
                table: "Mile",
                column: "DiameterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MissDistances_CloseApproachDataId",
                table: "MissDistances",
                column: "CloseApproachDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RelativeVelocity_CloseApproachDataId",
                table: "RelativeVelocity",
                column: "CloseApproachDataId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feet");

            migrationBuilder.DropTable(
                name: "Kilometer");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Meter");

            migrationBuilder.DropTable(
                name: "Mile");

            migrationBuilder.DropTable(
                name: "MissDistances");

            migrationBuilder.DropTable(
                name: "RelativeVelocity");

            migrationBuilder.DropTable(
                name: "Diameter");

            migrationBuilder.DropTable(
                name: "CloseApproachData");

            migrationBuilder.DropTable(
                name: "NearEarthObjects");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DailyInfo",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
