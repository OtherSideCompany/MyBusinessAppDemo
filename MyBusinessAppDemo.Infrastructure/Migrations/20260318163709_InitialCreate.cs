using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBusinessAppDemo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessPartners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryInfo_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_CreatedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryInfo_LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_LastModifiedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_LastModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VatNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ClientNumber = table.Column<int>(type: "int", nullable: true),
                    ProviderNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPartners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPartnerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryInfo_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_CreatedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryInfo_LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_LastModifiedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_LastModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SystemCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPartnerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryInfo_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_CreatedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryInfo_LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_LastModifiedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_LastModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VatNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LogoContentType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryInfo_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_CreatedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryInfo_LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_LastModifiedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_LastModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alpha2Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Alpha3Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NumericCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryInfo_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_CreatedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryInfo_LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_LastModifiedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_LastModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ByteSize = table.Column<long>(type: "bigint", nullable: false),
                    StorageKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryInfo_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_CreatedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryInfo_LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_LastModifiedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_LastModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    BusinessPartnerId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryInfo_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_CreatedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryInfo_LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_LastModifiedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_LastModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BusinessPartnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_BusinessPartners_BusinessPartnerId",
                        column: x => x.BusinessPartnerId,
                        principalTable: "BusinessPartners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPartnerBusinessPartnerType",
                columns: table => new
                {
                    BusinessPartnerId = table.Column<int>(type: "int", nullable: false),
                    BusinessPartnerTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPartnerBusinessPartnerType", x => new { x.BusinessPartnerId, x.BusinessPartnerTypesId });
                    table.ForeignKey(
                        name: "FK_BusinessPartnerBusinessPartnerType_BusinessPartnerTypes_BusinessPartnerTypesId",
                        column: x => x.BusinessPartnerTypesId,
                        principalTable: "BusinessPartnerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessPartnerBusinessPartnerType_BusinessPartners_BusinessPartnerId",
                        column: x => x.BusinessPartnerId,
                        principalTable: "BusinessPartners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostalCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryInfo_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_CreatedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryInfo_LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_LastModifiedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_LastModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostalCodes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryInfo_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_CreatedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryInfo_LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoryInfo_LastModifiedById = table.Column<int>(type: "int", nullable: true),
                    HistoryInfo_LastModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AdressDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PostalCodeId = table.Column<int>(type: "int", nullable: true),
                    BusinessPartnerId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_BusinessPartners_BusinessPartnerId",
                        column: x => x.BusinessPartnerId,
                        principalTable: "BusinessPartners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adresses_PostalCodes_PostalCodeId",
                        column: x => x.PostalCodeId,
                        principalTable: "PostalCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_BusinessPartnerId",
                table: "Adresses",
                column: "BusinessPartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_CompanyId",
                table: "Adresses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_PostalCodeId",
                table: "Adresses",
                column: "PostalCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPartnerBusinessPartnerType_BusinessPartnerTypesId",
                table: "BusinessPartnerBusinessPartnerType",
                column: "BusinessPartnerTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_BusinessPartnerId",
                table: "Contacts",
                column: "BusinessPartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCodes_CountryId",
                table: "PostalCodes",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "BusinessPartnerBusinessPartnerType");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "PostalCodes");

            migrationBuilder.DropTable(
                name: "BusinessPartnerTypes");

            migrationBuilder.DropTable(
                name: "BusinessPartners");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
