using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoBye.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Blocked = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false),
                    AveragePrice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(max)", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "varchar(max)", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationNumber = table.Column<int>(type: "int", nullable: false),
                    MessageTitle = table.Column<string>(type: "varchar(max)", nullable: false),
                    MessageContent = table.Column<string>(type: "varchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    CurrentBranch = table.Column<string>(type: "varchar(max)", nullable: false),
                    Model = table.Column<string>(type: "varchar(max)", nullable: false),
                    Year = table.Column<string>(type: "varchar(max)", nullable: false),
                    BusClassId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buses_AspNetUsers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buses_BusClasses_BusClassId",
                        column: x => x.BusClassId,
                        principalTable: "BusClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusClassId = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassImages_BusClasses_BusClassId",
                        column: x => x.BusClassId,
                        principalTable: "BusClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EndBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false),
                    Address = table.Column<string>(type: "varchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(max)", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EndBranches_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "varchar(max)", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: false),
                    DestinationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicActivities_Destinations_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StartBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false),
                    Address = table.Column<string>(type: "varchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(max)", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StartBranches_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    StartBranchId = table.Column<int>(type: "int", nullable: false),
                    EndBranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_EndBranches_EndBranchId",
                        column: x => x.EndBranchId,
                        principalTable: "EndBranches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trips_StartBranches_StartBranchId",
                        column: x => x.StartBranchId,
                        principalTable: "StartBranches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    ClientSecret = table.Column<string>(type: "varchar(max)", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1837ae0a-7274-4acc-8165-65aced540cd2", null, "User", null },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", null, "Driver", null },
                    { "b79f5098-1212-492e-853b-0ea294f0ec2d", null, "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Blocked", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06c4fa4f-f281-4375-a5a5-25f4aaa5fa09", 0, false, "92d5e338-c602-4e02-a21c-f2563c5303c2", "Driver40@gmail.com", false, "Mohamed", "Bayoumi40", false, null, null, null, "Sm612147?", "01093996245", false, "10d2dd24-22eb-4fc3-8566-1cd8184b0487", false, "Driver40" },
                    { "10ebb4a2-4078-4d38-9c1d-b71731e51813", 0, false, "ee2ba8e8-6b5d-4d5a-b30d-9819dab98457", "Driver2@gmail.com", false, "Mohamed", "Bayoumi2", false, null, null, null, "Sm612147?", "01093996245", false, "a3b54feb-d031-44e3-8214-e86b5743e2fc", false, "Driver2" },
                    { "1305c3a4-d78d-4698-9767-fb6f0be09c0b", 0, false, "cf4ffb52-5b50-45b7-82ca-4d18968f7d6d", "Driver21@gmail.com", false, "Mohamed", "Bayoumi21", false, null, null, null, "Sm612147?", "01093996245", false, "cf3dc847-63fd-411e-82a2-47653bd322c4", false, "Driver21" },
                    { "1947e428-e7f7-4b72-8333-259683d51737", 0, false, "d1b3aca9-adbd-4009-b24a-aaae5fc6cc6a", "Driver17@gmail.com", false, "Mohamed", "Bayoumi17", false, null, null, null, "Sm612147?", "01093996245", false, "9d9a301c-6324-4c08-9946-5562cea6ed38", false, "Driver17" },
                    { "20260240-d81d-4eb5-9efa-6750cd5efd78", 0, false, "0a35f892-c75e-42d7-a218-3cdf8358f4c7", "Driver19@gmail.com", false, "Mohamed", "Bayoumi19", false, null, null, null, "Sm612147?", "01093996245", false, "7be7cc37-9393-4ed9-b682-b8aa9deb6ed9", false, "Driver19" },
                    { "2ccb170d-598b-4202-86d0-2e30da515914", 0, false, "0dfb70a8-380c-4b64-bc31-c7e72d41eee0", "Driver22@gmail.com", false, "Mohamed", "Bayoumi22", false, null, null, null, "Sm612147?", "01093996245", false, "b53e4e88-63ac-4e11-a0c9-300438a98d8d", false, "Driver22" },
                    { "2fcd9e91-89f7-48a9-8f0f-33c4af7e8d80", 0, false, "19c819a2-34f6-462b-b804-32294815e264", "Driver24@gmail.com", false, "Mohamed", "Bayoumi24", false, null, null, null, "Sm612147?", "01093996245", false, "bb41c5b4-f0d4-4dcc-96f8-2e5aafd1ac0b", false, "Driver24" },
                    { "38e2719d-2c73-4451-b386-32673b9798f4", 0, false, "740c4b6c-8f29-4b00-91ee-671f2c3ed00d", "mbayoumi151@gmail.com", false, "Mohamed", "Bayoumi", false, null, null, null, "Sm612147?", "01093996245", false, "3af77d9c-7c9e-49f7-b053-4085d3cf7ca7", false, "mbayoumi151" },
                    { "3ac4283c-46f2-412b-848d-abbef6f8f96d", 0, false, "627f9131-01b6-4651-8c1d-4e9cd8ce41cf", "Driver23@gmail.com", false, "Mohamed", "Bayoumi23", false, null, null, null, "Sm612147?", "01093996245", false, "cffb97e3-39f3-483e-bc96-62ae6a6968b4", false, "Driver23" },
                    { "43f816d6-81e7-4ec8-9e7e-a90eb27c60c6", 0, false, "6efc4046-b2f2-4ed4-957a-e3c94a22c255", "Driver35@gmail.com", false, "Mohamed", "Bayoumi35", false, null, null, null, "Sm612147?", "01093996245", false, "240a7986-f166-4757-b779-737624628b7e", false, "Driver35" },
                    { "45289333-f686-4cc5-a2ed-20d3cb48901b", 0, false, "41794826-30d9-46e9-aa93-20b6c9bd86b9", "Driver25@gmail.com", false, "Mohamed", "Bayoumi25", false, null, null, null, "Sm612147?", "01093996245", false, "cfb9755b-042d-4a84-aab7-2d1d737777cc", false, "Driver25" },
                    { "4b47560f-1a8e-451d-8088-e2d96df2deca", 0, false, "e14b51dd-338e-4749-9244-adbf3b6ddaae", "Driver12@gmail.com", false, "Mohamed", "Bayoumi12", false, null, null, null, "Sm612147?", "01093996245", false, "8baad009-49d6-4d41-a0bb-0c16b9ca09fd", false, "Driver12" },
                    { "58efc192-1af9-4b71-ab9c-165c96593240", 0, false, "8be25aa6-dccc-417d-9146-882e4698fbbe", "Driver29@gmail.com", false, "Mohamed", "Bayoumi29", false, null, null, null, "Sm612147?", "01093996245", false, "f983dbf0-bec6-46e2-a654-2c5da4e896dd", false, "Driver29" },
                    { "5aa2d999-f820-46f7-a9bc-d16da40263f9", 0, false, "b225b1fd-f807-49d2-8207-405116b314f8", "Driver39@gmail.com", false, "Mohamed", "Bayoumi39", false, null, null, null, "Sm612147?", "01093996245", false, "152b59c5-849d-495f-b8fe-f9d24fb2cd4b", false, "Driver39" },
                    { "61db600d-6a31-4c49-9e4f-eff9621218d7", 0, false, "c901858f-1c99-4c01-b558-91bb4c28d94f", "Driver15@gmail.com", false, "Mohamed", "Bayoumi15", false, null, null, null, "Sm612147?", "01093996245", false, "2d8b5170-a142-4070-9ec9-27c4909cf7e9", false, "Driver15" },
                    { "6304764a-9691-4fc9-8070-4b5f464c16dd", 0, false, "fadbb173-b727-4720-849e-11c01ef0adcd", "Driver33@gmail.com", false, "Mohamed", "Bayoumi33", false, null, null, null, "Sm612147?", "01093996245", false, "5791f037-d372-43e9-94f2-94ab659f0a2a", false, "Driver33" },
                    { "69fab494-f64b-4e36-8202-43c8659d6942", 0, false, "11e587dc-794d-478d-8bc7-6c0604d76093", "Driver4@gmail.com", false, "Mohamed", "Bayoumi4", false, null, null, null, "Sm612147?", "01093996245", false, "8a2facbf-9c07-4690-bfbf-41d32a61c889", false, "Driver4" },
                    { "6ab33b1e-42a6-46c0-adf8-dc572a3a4d36", 0, false, "78d06648-6209-4fa9-8f06-5ef82b76b77c", "Driver18@gmail.com", false, "Mohamed", "Bayoumi18", false, null, null, null, "Sm612147?", "01093996245", false, "c425f32f-aeaf-4c9b-be36-8459a233d0ce", false, "Driver18" },
                    { "7119d1ad-6f54-421c-99ed-bd1ed7ff3a28", 0, false, "fefadaf0-455f-47cb-9554-c53c222bdc65", "Driver26@gmail.com", false, "Mohamed", "Bayoumi26", false, null, null, null, "Sm612147?", "01093996245", false, "51207f03-05fd-4e60-8b96-54a2eb3e6296", false, "Driver26" },
                    { "733ec01e-c84f-4c95-ab8f-d3f73d6b3661", 0, false, "4c7e4737-3492-4032-9e8f-8c44c0af6e66", "Driver8@gmail.com", false, "Mohamed", "Bayoumi8", false, null, null, null, "Sm612147?", "01093996245", false, "6ba5279a-858d-4cb9-87ed-9d8328ae24d8", false, "Driver8" },
                    { "74a47e09-f97c-4e4b-ad51-3eed7fd6ea0d", 0, false, "63f221bb-b3ef-4fc0-ad4f-0c18333c2824", "Driver38@gmail.com", false, "Mohamed", "Bayoumi38", false, null, null, null, "Sm612147?", "01093996245", false, "5663b306-e419-4712-9ac1-aa4408500cfb", false, "Driver38" },
                    { "829c0f3d-5cc9-470e-a7da-e6f1186a7216", 0, false, "a61bed6f-65ab-4217-b86d-7e132e810d2a", "Driver36@gmail.com", false, "Mohamed", "Bayoumi36", false, null, null, null, "Sm612147?", "01093996245", false, "136bf767-98c1-44f6-8b6b-39869a817ea3", false, "Driver36" },
                    { "8341a302-6b87-431b-a252-2ffcd90948a1", 0, false, "c57a68e5-9eab-413d-8e90-249b704fa08d", "Driver5@gmail.com", false, "Mohamed", "Bayoumi5", false, null, null, null, "Sm612147?", "01093996245", false, "96505681-e943-4312-a85b-9a6b00f09883", false, "Driver5" },
                    { "8361dfdf-f686-45f4-a45c-7d83a347792d", 0, false, "ab92db72-8b09-42ca-bce4-289c61aa2124", "Driver28@gmail.com", false, "Mohamed", "Bayoumi28", false, null, null, null, "Sm612147?", "01093996245", false, "a0f04457-bd01-4240-95f2-2faf0bc1b376", false, "Driver28" },
                    { "8e449921-33a6-494a-ae62-3de5b2d1f41c", 0, false, "68746dcd-4931-410b-86c4-4c1dfb4dfb8d", "Driver31@gmail.com", false, "Mohamed", "Bayoumi31", false, null, null, null, "Sm612147?", "01093996245", false, "0e0f6084-6866-4a50-bfb6-e863f069cf64", false, "Driver31" },
                    { "9a0f9ad5-2f92-4955-9275-d136728b51a7", 0, false, "6884aff6-7a67-4dcf-b4ea-b33dd48c1d85", "Driver37@gmail.com", false, "Mohamed", "Bayoumi37", false, null, null, null, "Sm612147?", "01093996245", false, "271db130-2ab0-459b-9074-e3d9aa49f5f6", false, "Driver37" },
                    { "9b915f3e-8ff0-40e1-af96-ed02561ba2b5", 0, false, "1d5bb3bd-31c5-4256-8bd8-177f721fe44b", "Driver14@gmail.com", false, "Mohamed", "Bayoumi14", false, null, null, null, "Sm612147?", "01093996245", false, "87874884-6fc1-4c38-a731-6e20eac28460", false, "Driver14" },
                    { "a079a3f1-ddb0-4f6a-a3fb-952fa92c8951", 0, false, "b58cfaa4-930b-457c-bb71-c7245aae546b", "Driver3@gmail.com", false, "Mohamed", "Bayoumi3", false, null, null, null, "Sm612147?", "01093996245", false, "7425babd-e2f3-43c6-94db-5b40addff966", false, "Driver3" },
                    { "a0ee769b-5470-44a5-8529-2fa87d254f4a", 0, false, "39ff5a3a-7f0a-426d-9a6c-aaf0e9102086", "Driver10@gmail.com", false, "Mohamed", "Bayoumi10", false, null, null, null, "Sm612147?", "01093996245", false, "4f2b76c9-05f3-440d-89a1-97f341729a07", false, "Driver10" },
                    { "a31eabb3-ff8f-4d89-8750-d7d9a2431149", 0, false, "8ccac488-0f0e-44c2-a4da-c03c6bf38b60", "Driver16@gmail.com", false, "Mohamed", "Bayoumi16", false, null, null, null, "Sm612147?", "01093996245", false, "320f78c0-5f73-4f24-9756-2da4753255eb", false, "Driver16" },
                    { "a83eeaef-cacf-4848-81c2-a1d5746dc2c8", 0, false, "d0c93d27-a3ae-4b12-be74-be59672876ee", "Driver32@gmail.com", false, "Mohamed", "Bayoumi32", false, null, null, null, "Sm612147?", "01093996245", false, "6e2888f8-4209-46b1-8008-888dc6737c4d", false, "Driver32" },
                    { "b96da449-a77f-49b0-bc3e-01ce46dd991c", 0, false, "45153e6a-573d-4445-ab96-50902e2d8726", "Driver9@gmail.com", false, "Mohamed", "Bayoumi9", false, null, null, null, "Sm612147?", "01093996245", false, "49c0de5a-3809-4c9b-8397-62f9f66c463c", false, "Driver9" },
                    { "bcd0a627-1e73-4d60-99bb-5fa4359d1c0d", 0, false, "3bd89b07-d7fc-42d1-89f5-931910f79ce2", "Driver34@gmail.com", false, "Mohamed", "Bayoumi34", false, null, null, null, "Sm612147?", "01093996245", false, "5997260e-4e5b-49da-bc97-8a0dc8c3716e", false, "Driver34" },
                    { "c60ffa8f-57cb-4821-b0a0-5178d12bda71", 0, false, "ad240990-504b-4041-9c50-0a84a40e5a76", "Driver13@gmail.com", false, "Mohamed", "Bayoumi13", false, null, null, null, "Sm612147?", "01093996245", false, "1726f0e1-abd9-4001-b820-50e09ac27bdf", false, "Driver13" },
                    { "c6cdde60-f783-4542-8f36-443c00cdf41f", 0, false, "f79ea561-c691-4e4f-a8e7-93707e34b333", "Driver20@gmail.com", false, "Mohamed", "Bayoumi20", false, null, null, null, "Sm612147?", "01093996245", false, "c64d8947-cd3a-4c3f-9c39-f717fc437c5e", false, "Driver20" },
                    { "cc6c9526-f50c-4769-91b1-2b0b5bf73acf", 0, false, "ed09de88-e5ef-413f-9be8-25de9d62792c", "Driver7@gmail.com", false, "Mohamed", "Bayoumi7", false, null, null, null, "Sm612147?", "01093996245", false, "1246ba06-6364-453e-8def-ea4a52ddb8ce", false, "Driver7" },
                    { "db413fd2-ed42-4eb3-81cb-af1d0f5d34c1", 0, false, "c5b6f27e-9f96-4142-9db9-932b3cbbef1e", "Driver11@gmail.com", false, "Mohamed", "Bayoumi11", false, null, null, null, "Sm612147?", "01093996245", false, "103bbc7c-8c97-446e-9cf1-9b1feffaba3d", false, "Driver11" },
                    { "e6d0209c-c4f2-4e25-891c-a653e14a21dd", 0, false, "b9c0570f-8f59-4268-877f-6db17f329ad2", "Driver27@gmail.com", false, "Mohamed", "Bayoumi27", false, null, null, null, "Sm612147?", "01093996245", false, "b6cc6fd4-fbc8-4f79-9baf-7bf183fa3a1e", false, "Driver27" },
                    { "ed62cea4-f01a-4283-b098-642299b04776", 0, false, "27109f2a-925e-4da9-8132-49434d2d700e", "Driver30@gmail.com", false, "Mohamed", "Bayoumi30", false, null, null, null, "Sm612147?", "01093996245", false, "92876532-1d81-44a8-8322-7bd7606eef97", false, "Driver30" },
                    { "f0fd67a7-a8f6-42d1-924b-4ef2cbfbe7dd", 0, false, "e76c4722-438d-43ee-ab1b-70b3ecf037e2", "Driver1@gmail.com", false, "Mohamed", "Bayoumi1", false, null, null, null, "Sm612147?", "01093996245", false, "479ca753-3c59-4f3e-8cdf-677e75433b22", false, "Driver1" },
                    { "f95361be-330d-4e79-b667-4981fd7503c7", 0, false, "757c596f-ab58-4695-b17a-af68b4e17837", "Driver6@gmail.com", false, "Mohamed", "Bayoumi6", false, null, null, null, "Sm612147?", "01093996245", false, "15514f5d-6c01-45b0-a395-84c3ee86bab7", false, "Driver6" }
                });

            migrationBuilder.InsertData(
                table: "BusClasses",
                columns: new[] { "Id", "AveragePrice", "Name" },
                values: new object[,]
                {
                    { 1, "180 EGP - 265 EGP", "Super Go D" },
                    { 2, "165 EGP - 445 EGP", "Business Class DD" },
                    { 3, "385 EGP - 385 EGP", "Elite Business Class M" },
                    { 4, "225 EGP - 265 EGP", "New Deluxe" },
                    { 5, "100 EGP - 180 EGP", "Economy" },
                    { 6, "130 EGP - 440 EGP", "Elite Business Class V" },
                    { 7, "500 EGP - 545 EGP", "Aero First Class" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "ImageURL", "Name" },
                values: new object[,]
                {
                    { 1, "https://lp-cms-production.imgix.net/news/2019/02/Cairo-market.jpg", "Cairo" },
                    { 2, "https://go-bus.com:8181/wp-content/uploads/2019/04/Sharm-hero.jpg", "Red Sea" },
                    { 3, "https://go-bus.com:8181/wp-content/uploads/2019/04/sokhna-hero-1.jpg", "South Sinai" },
                    { 4, "https://go-bus.com:8181/wp-content/uploads/2018/05/Alex-hero.jpg", "Alexandria" },
                    { 5, "https://www.carolsbeaurivage.com/medias/slide/big/5/img-9257.jpg", "North Coast" },
                    { 6, "https://planetofhotels.com/guide/sites/default/files/styles/paragraph__live_banner__lb_image__1880bp/public/live_banner/Suez.jpg", "Suez" },
                    { 7, "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/19/7d/c0/f6/qena.jpg?w=500&h=300&s=1", "Qena" },
                    { 8, "https://media.odyfolio.com/pho/145/uae-uae-al-gharbia-liwa-desert-qasr-al-sarab-hotel_m-1-169.jpeg", "Gharbia" },
                    { 9, "https://cdn.britannica.com/10/126710-050-8E814ED9/building-Suez-Canal-Authority-Port-Said-Egypt.jpg", "Port Said" },
                    { 10, "https://upload.wikimedia.org/wikipedia/commons/4/4d/AsyutUniversityMainBldg.jpg", "Assiut" },
                    { 11, "https://facts.net/wp-content/uploads/2023/07/40-facts-about-menia-1689735034.jpeg", "Menia" },
                    { 12, "https://www.introducingegypt.com/f/egipto/egipto/guia/luxor-m.jpg", "Luxor" },
                    { 13, "https://t3.ftcdn.net/jpg/03/63/61/66/360_F_363616600_zenx3HVCXEVDAYhBYhYglFYU9xTRYKMO.jpg", "Dakahlia" },
                    { 14, "https://mercure.accor.com/local-stories/media/ismailia_desk.jpg", "Ismailia" }
                });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "By using our website, you hereby consent to our Privacy Policy and agree to its terms.", "Consent" },
                    { 2, "The personal information that you are asked to provide, and the reasons why you are asked to provide it, will be made clear to you at the point we ask you to provide your personal information.If you contact us directly, we may receive additional information about you such as your name, email address, phone number, the contents of the message and or attachments you may send us, and any other information you may choose to provide.When you register for an Account, we may ask for your contact information, including items such as name, company name, address, email address, and telephone number.", "Information we collect" },
                    { 3, "Go Bus follows a standard procedure of using log files. These files log visitors when they visit websites. All hosting companies do this and a part of hosting services’ analytics. The information collected by log files include internet protocol (IP) addresses, browser type, Internet Service Provider (ISP), date and time stamp, referring/exit pages, and possibly the number of clicks. These are not linked to any information that is personally identifiable. The purpose of the information is for analyzing trends, administering the site, tracking users’ movement on the website, and gathering demographic information.", "Log Files" },
                    { 4, "Like any other website, Go Bus uses ‘cookies’. These cookies are used to store information including visitors’ preferences, and the pages on the website that the visitor accessed or visited. The information is used to optimize the users’ experience by customizing our web page content based on visitors’ browser type and/or other information.For more general information on cookies, please read “What Are Cookies”.", "Cookies and Web Beacons" },
                    { 5, "You may consult this list to find the Privacy Policy for each of the advertising partners of Go Bus.Third-party ad servers or ad networks use technologies like cookies, JavaScript, or Web Beacons that are used in their respective advertisements and links that appear on Go Bus, which are sent directly to users’ browsers. They automatically receive your IP address when this occurs. These technologies are used to measure the effectiveness of their advertising campaigns and/or to personalize the advertising content that you see on websites that you visit.Note that Go Bus has no access to or control over these cookies that are used by third-party advertisers.", "Advertising Partners Privacy Policies" },
                    { 6, "Go Bus’s Privacy Policy does not apply to other advertisers or websites. Thus, we are advising you to consult the respective Privacy Policies of these third-party ad servers for more detailed information. It may include their practices and instructions about how to opt-out of certain options.You can choose to disable cookies through your individual browser options. To know more detailed information about cookie management with specific web browsers, it can be found at the browsers’ respective websites.", "Third Party Privacy Policies" },
                    { 7, "Under the CCPA, among other rights, California consumers have the right to:Request that a business that collects a consumer’s personal data disclose the categories and specific pieces of personal data that a business has collected about consumers.Request that a business delete any personal data about the consumer that a business has collected.Request that a business that sells a consumer’s personal data, not sell the consumer’s personal data.If you make a request, we have one month to respond to you.If you would like to exercise any of these rights, please contact us.", "CCPA Privacy Rights (Do Not Sell My Personal Information)" },
                    { 8, "Another part of our priority is adding protection for children while using the internet. We encourage parents and guardians to observe, participate in, and/or monitor and guide their online activity.Go Bus does not knowingly collect any Personal Identifiable Information from children under the age of 13. If you think that your child provided this kind of information on our website, we strongly encourage you to contact us immediately and we will do our best efforts to promptly remove such information from our records.", "Children’s Information" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Answer", "Title" },
                values: new object[,]
                {
                    { 1, "The system automatically resends the e-ticket that has not been successfully delivered to the client. E-tickets can also be found in “my tickets” tab once you are logged on to your account.", "I didn’t receive my mTicket. Can you re-send it?" },
                    { 2, "Go Bus abides by safety protocols and security standards, under the auspices of the Ministry of Transportation. We depend on a modern fleet of buses, whose speed is electronically controlled by the agency without drivers’ intervention. We have a whole staff of highly-trained drivers to maintain these protocols and standards.", "Does the company stipulate a maximum speed for divers?" },
                    { 3, "You can easily browse the different trip times and dates, however, in order to book a ticket, you need to be registered with Go Bus.", "Do I need to register to use Go Bus?" },
                    { 4, "Go Bus is keen on its staff skills and capacity development. The company always seeks to enhance the skills of drivers and employees. Therefore, we have recently inked a protocol with the Egyptian Road Safety Training Centre to train 80% of our drivers, which is a testament of our vision to develop drivers’ skills and ensure our customers’ safety and satisfaction.", "What are Go Bus driver skill enhancement program and customer safety and satisfaction strategy?" },
                    { 5, "Go Bus’s strategy considering the customer on the top of our priorities and our endeavor towards offering high-quality services are manifested in the difference Go Bus continues to make in Egypt’s transportation system in general through its peerless control room, which monitors its fleet across Egypt 24/7. The purpose of this room is to offer real-time monitoring system for drivers and passengers’ safety, and records drivers’ traffic offences, ensuring rapid crisis response and management.", "Earlier you announced that Go Bus owns a central control room, what is its value for the company?" },
                    { 6, "Once you have entered your mobile number while booking it can’t be changed for that particular transaction. You can however, go back and change your mobile number for further transactions. To board the bus, your name has to match the name on the e-ticket.", "I entered the wrong mobile number while booking. Can I get my mTicket on a different number?" },
                    { 7, "You can easily access “my tickets” tab once you are logged onto the website, to view your history of tickets. You can use this history to view your e-ticket and board the bus.", "I’ve lost my ticket. What should I do now?" },
                    { 8, "No, it is not mandatory to take a printout of the ticket, however, you need to have a copy of the ticket with your name on it on your device, or have the e-ticket to board the bus.", "Is it mandatory to take a printout of the ticket?" },
                    { 9, "Go Bus’ fleet is very distinctive and is not found in any other transportation company. When booking online, it is quick and easy with no need to go to the station to make a booking.", "What are the advantages of purchasing a bus ticket with Go Bus?" },
                    { 10, "Booking online does not cost you more, to the contrary, it is time effective and quick.", "Does booking online cost me more?" }
                });

            migrationBuilder.InsertData(
                table: "Terms",
                columns: new[] { "Id", "Description", "SubTitle", "Title" },
                values: new object[,]
                {
                    { 1, "– No more than eight seats can be booked per trip, making a total of 16 seats for the round trip. If more seats are needed, please pay for the 16 tickets, and then make another booking.– The booked ticket can’t be modified through the website. The booking through the website is the responsibility of the customer.– The booked tickets paid by credit card can be canceled through the website before trip time by 4 hours, for a fee of 10% of the ticket price approximated to the nearest 5 pounds.– Children above six years must buy a full ticket. We don’t sell half tickets.– Points are added every 24 hours with each reservation.– Points are added to each seat.", "Booking Conditions", "Online payment" },
                    { 2, "– Customers who book through Fawry have 3 hours to pay their tickets; otherwise, the reservation will be canceled.– No more than eight seats can be booked per trip, making a total of 16 seats for the round trip. If more seats are needed, please pay for the 16 tickets, and then make another booking.– Payment has to be done before trip time by 2 hours.– The original receipt has to be presented to the agent in any of our stations to receive the booked tickets.– If the original receipt is lost, a copy of the national ID and order number has to be presented to receive tickets.– Children above six years must buy a full ticket. We don’t sell half tickets.– The round-trip discount is not applied to the GoMini trips.– Points don’t be added to the account in the case of the Fawry reservation.", "Booking Conditions", "Fawry" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "06c4fa4f-f281-4375-a5a5-25f4aaa5fa09", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "10ebb4a2-4078-4d38-9c1d-b71731e51813", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "1305c3a4-d78d-4698-9767-fb6f0be09c0b", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "1947e428-e7f7-4b72-8333-259683d51737", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "20260240-d81d-4eb5-9efa-6750cd5efd78", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "2ccb170d-598b-4202-86d0-2e30da515914", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "2fcd9e91-89f7-48a9-8f0f-33c4af7e8d80", "ApplicationUserRole" },
                    { "b79f5098-1212-492e-853b-0ea294f0ec2d", "38e2719d-2c73-4451-b386-32673b9798f4", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "3ac4283c-46f2-412b-848d-abbef6f8f96d", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "43f816d6-81e7-4ec8-9e7e-a90eb27c60c6", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "45289333-f686-4cc5-a2ed-20d3cb48901b", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "4b47560f-1a8e-451d-8088-e2d96df2deca", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "58efc192-1af9-4b71-ab9c-165c96593240", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "5aa2d999-f820-46f7-a9bc-d16da40263f9", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "61db600d-6a31-4c49-9e4f-eff9621218d7", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "6304764a-9691-4fc9-8070-4b5f464c16dd", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "69fab494-f64b-4e36-8202-43c8659d6942", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "6ab33b1e-42a6-46c0-adf8-dc572a3a4d36", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "7119d1ad-6f54-421c-99ed-bd1ed7ff3a28", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "733ec01e-c84f-4c95-ab8f-d3f73d6b3661", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "74a47e09-f97c-4e4b-ad51-3eed7fd6ea0d", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "829c0f3d-5cc9-470e-a7da-e6f1186a7216", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "8341a302-6b87-431b-a252-2ffcd90948a1", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "8361dfdf-f686-45f4-a45c-7d83a347792d", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "8e449921-33a6-494a-ae62-3de5b2d1f41c", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "9a0f9ad5-2f92-4955-9275-d136728b51a7", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "9b915f3e-8ff0-40e1-af96-ed02561ba2b5", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "a079a3f1-ddb0-4f6a-a3fb-952fa92c8951", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "a0ee769b-5470-44a5-8529-2fa87d254f4a", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "a31eabb3-ff8f-4d89-8750-d7d9a2431149", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "a83eeaef-cacf-4848-81c2-a1d5746dc2c8", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "b96da449-a77f-49b0-bc3e-01ce46dd991c", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "bcd0a627-1e73-4d60-99bb-5fa4359d1c0d", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "c60ffa8f-57cb-4821-b0a0-5178d12bda71", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "c6cdde60-f783-4542-8f36-443c00cdf41f", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "cc6c9526-f50c-4769-91b1-2b0b5bf73acf", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "db413fd2-ed42-4eb3-81cb-af1d0f5d34c1", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "e6d0209c-c4f2-4e25-891c-a653e14a21dd", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "ed62cea4-f01a-4283-b098-642299b04776", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "f0fd67a7-a8f6-42d1-924b-4ef2cbfbe7dd", "ApplicationUserRole" },
                    { "491c779b-92be-4a0c-a1bf-91c28fc20e1e", "f95361be-330d-4e79-b667-4981fd7503c7", "ApplicationUserRole" }
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "Available", "BusClassId", "Capacity", "CurrentBranch", "DriverId", "Model", "Number", "Year" },
                values: new object[,]
                {
                    { 1, true, 1, 49, "", "f0fd67a7-a8f6-42d1-924b-4ef2cbfbe7dd", "Mercedes", 101, "2023" },
                    { 2, true, 1, 49, "", "10ebb4a2-4078-4d38-9c1d-b71731e51813", "Mercedes", 102, "2023" },
                    { 3, true, 1, 49, "", "a079a3f1-ddb0-4f6a-a3fb-952fa92c8951", "Mercedes", 103, "2023" },
                    { 4, true, 1, 49, "", "69fab494-f64b-4e36-8202-43c8659d6942", "Mercedes", 104, "2023" },
                    { 5, true, 1, 49, "", "8341a302-6b87-431b-a252-2ffcd90948a1", "Mercedes", 105, "2023" },
                    { 6, true, 2, 49, "", "f95361be-330d-4e79-b667-4981fd7503c7", "Mercedes", 201, "2023" },
                    { 7, true, 2, 49, "", "cc6c9526-f50c-4769-91b1-2b0b5bf73acf", "Mercedes", 202, "2023" },
                    { 8, true, 2, 49, "", "733ec01e-c84f-4c95-ab8f-d3f73d6b3661", "Mercedes", 203, "2023" },
                    { 9, true, 2, 49, "", "b96da449-a77f-49b0-bc3e-01ce46dd991c", "Mercedes", 204, "2023" },
                    { 10, true, 2, 49, "", "a0ee769b-5470-44a5-8529-2fa87d254f4a", "Mercedes", 205, "2023" },
                    { 11, true, 3, 49, "", "db413fd2-ed42-4eb3-81cb-af1d0f5d34c1", "Mercedes", 301, "2023" },
                    { 12, true, 3, 49, "", "4b47560f-1a8e-451d-8088-e2d96df2deca", "Mercedes", 302, "2023" },
                    { 13, true, 3, 49, "", "c60ffa8f-57cb-4821-b0a0-5178d12bda71", "Mercedes", 303, "2023" },
                    { 14, true, 3, 49, "", "9b915f3e-8ff0-40e1-af96-ed02561ba2b5", "Mercedes", 304, "2023" },
                    { 15, true, 3, 49, "", "61db600d-6a31-4c49-9e4f-eff9621218d7", "Mercedes", 305, "2023" },
                    { 16, true, 4, 49, "", "1305c3a4-d78d-4698-9767-fb6f0be09c0b", "Mercedes", 501, "2023" },
                    { 17, true, 4, 49, "", "2ccb170d-598b-4202-86d0-2e30da515914", "Mercedes", 502, "2023" },
                    { 18, true, 4, 49, "", "3ac4283c-46f2-412b-848d-abbef6f8f96d", "Mercedes", 503, "2023" },
                    { 19, true, 4, 49, "", "2fcd9e91-89f7-48a9-8f0f-33c4af7e8d80", "Mercedes", 504, "2023" },
                    { 20, true, 4, 49, "", "45289333-f686-4cc5-a2ed-20d3cb48901b", "Mercedes", 505, "2023" },
                    { 21, true, 5, 49, "", "7119d1ad-6f54-421c-99ed-bd1ed7ff3a28", "Mercedes", 601, "2023" },
                    { 22, true, 5, 49, "", "e6d0209c-c4f2-4e25-891c-a653e14a21dd", "Mercedes", 602, "2023" },
                    { 23, true, 5, 49, "", "8361dfdf-f686-45f4-a45c-7d83a347792d", "Mercedes", 603, "2023" },
                    { 24, true, 5, 49, "", "58efc192-1af9-4b71-ab9c-165c96593240", "Mercedes", 604, "2023" },
                    { 25, true, 5, 49, "", "ed62cea4-f01a-4283-b098-642299b04776", "Mercedes", 605, "2023" },
                    { 26, true, 6, 49, "", "8e449921-33a6-494a-ae62-3de5b2d1f41c", "Mercedes", 701, "2023" },
                    { 27, true, 6, 49, "", "a83eeaef-cacf-4848-81c2-a1d5746dc2c8", "Mercedes", 702, "2023" },
                    { 28, true, 6, 49, "", "6304764a-9691-4fc9-8070-4b5f464c16dd", "Mercedes", 703, "2023" },
                    { 29, true, 6, 49, "", "bcd0a627-1e73-4d60-99bb-5fa4359d1c0d", "Mercedes", 704, "2023" },
                    { 30, true, 6, 49, "", "43f816d6-81e7-4ec8-9e7e-a90eb27c60c6", "Mercedes", 705, "2023" },
                    { 31, true, 7, 49, "", "829c0f3d-5cc9-470e-a7da-e6f1186a7216", "Mercedes", 801, "2023" },
                    { 32, true, 7, 49, "", "9a0f9ad5-2f92-4955-9275-d136728b51a7", "Mercedes", 802, "2023" },
                    { 33, true, 7, 49, "", "74a47e09-f97c-4e4b-ad51-3eed7fd6ea0d", "Mercedes", 803, "2023" },
                    { 34, true, 7, 49, "", "5aa2d999-f820-46f7-a9bc-d16da40263f9", "Mercedes", 804, "2023" },
                    { 35, true, 7, 49, "", "06c4fa4f-f281-4375-a5a5-25f4aaa5fa09", "Mercedes", 805, "2023" }
                });

            migrationBuilder.InsertData(
                table: "ClassImages",
                columns: new[] { "Id", "BusClassId", "ImageURL" },
                values: new object[,]
                {
                    { 1, 1, "https://go-bus.com/images/new-bus-classes/deluxe-plus/4.png" },
                    { 2, 1, "https://go-bus.com/images/new-bus-classes/deluxe-plus/3.jpg" },
                    { 3, 1, "https://go-bus.com/images/new-bus-classes/deluxe-plus/2.jpg" },
                    { 4, 2, "https://go-bus.com/images/new-bus-classes/elite-DD/4.png" },
                    { 5, 2, "https://go-bus.com/images/new-bus-classes/elite-DD/3.jpg" },
                    { 6, 2, "https://go-bus.com/images/new-bus-classes/elite-DD/2.jpg" },
                    { 7, 3, "https://go-bus.com/images/new-bus-classes/elite-plus/4.png" },
                    { 8, 3, "https://go-bus.com/images/new-bus-classes/elite-plus/3.jpg" },
                    { 9, 3, "https://go-bus.com/images/new-bus-classes/elite-plus/2.jpg" },
                    { 10, 4, "https://go-bus.com/images/new-bus-classes/new-deluxe/4.png" },
                    { 11, 4, "https://go-bus.com/images/new-bus-classes/new-deluxe/3.jpg" },
                    { 12, 4, "https://go-bus.com/images/new-bus-classes/new-deluxe/2.jpg" },
                    { 13, 5, "https://go-bus.com/images/new-bus-classes/economic/4.png" },
                    { 14, 5, "https://go-bus.com/images/new-bus-classes/economic/3.jpg" },
                    { 15, 5, "https://go-bus.com/images/new-bus-classes/economic/2.jpg" },
                    { 16, 6, "https://go-bus.com/images/new-bus-classes/elite-plus-plus/4.png" },
                    { 17, 6, "https://go-bus.com/images/new-bus-classes/elite-plus-plus/3.jpg" },
                    { 18, 6, "https://go-bus.com/images/new-bus-classes/elite-plus-plus/2.jpg" },
                    { 19, 7, "https://go-bus.com/images/new-bus-classes/aero-class/4.png" },
                    { 20, 7, "https://go-bus.com/images/new-bus-classes/aero-class/3.jpg" },
                    { 21, 7, "https://go-bus.com/images/new-bus-classes/aero-class/2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "EndBranches",
                columns: new[] { "Id", "Address", "DestinationId", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "9 Ramses St. (Railroad Company) in front of Ramses Train station", 1, "Ramses", "01093996245" },
                    { 2, "The Tourist walkway west of Somid, the central axis in front of 6 october City Hall", 1, "6 october", "01093996245" },
                    { 3, "Madinaty Gate 1", 1, "Madinaty", "01093996245" },
                    { 4, "4 El Galaa St. AbdelMoneim Riyad square next to Ramses Hilton Hotel Maspero Mall.", 1, "AbdelMoneim Riyad", "01093996245" },
                    { 5, "Next to Safaga Port Open from 7 am to 12 am", 2, "Safaga", "01093996245" },
                    { 6, "Next to CIB, 68 El Souq St. - In front of El Gamee Bank . Open from 8 am to 8 pm", 2, "Marsa Alam", "01093996245" },
                    { 7, "Bike and in front of El Gouna School Open from 8.30 am to 12.30 am", 2, "El Gouna", "01093996245" },
                    { 8, "Inside of Orascom Mall Makadi. Open from 9 am to 7 pm", 2, "Makadi", "01093996245" },
                    { 9, "Downtown next to Best Way Market beside the cinema. Getting on and off of the bus from the parking at the waiting hall of Pizatzza Village not from in front of the office. Open from 9 am to 9 pm.", 2, "Sahl Hasheesh", "01093996245" },
                    { 10, "ElNasr St. next to The Red Sea Hospital and ElHadidy Market and the old Fire station. Open 24 hrs.", 2, "Main Hurghada Office", "01093996245" },
                    { 11, "Located at Adam Abu Sawira Cafeteria is located directly on the road", 3, "Ras Sader Station", "01093996245" },
                    { 12, "La Hacienda", 3, "La Hacienda", "01093996245" },
                    { 13, "El Mashraba St. beside Dahab Plaza Hotel next to Maabar ElSeel Bride. Open from 7 am to 2 am", 3, "Dahab", "01093996245" },
                    { 14, "Shams Mall in front of Elwataneya Gas station - before Sharm ElSheikh International Hospital (International Haram Hospital)", 3, "Sharm", "01093996245" },
                    { 15, "45 St. Miami Corniche - Next to ElKataa Fish Open from 10 am to 1 am", 4, "Miami", "01093996245" },
                    { 16, "Inside of of the New Station , there are two offices in the building - Bus station is at platform 6 Open 24 hrs.", 4, "Moharam Bek", "01093996245" },
                    { 17, "Marina 7 : Before Marina 7 gate with 200 m - next to El Ahly Bank and Allam Auto Motors - the office is on the opposite side of the gate", 5, "Marina 7", "01093996245" },
                    { 18, "Stella Sidi Abdelrahman ; Infront of Stella Walk mall Sidi Abdelrahman", 5, "Sidi Abdelrahman", "01093996245" },
                    { 19, "Marassi : After the traffic point of Sidi Abdelrahman with 300 m in the direction of Alexandria next to ElGezira Coach", 5, "Marassi", "01093996245" },
                    { 20, "At km 2 - next to West Delta Travel station", 5, "Marsa Matruh", "01093996245" },
                    { 21, "In Front of El Mahmal Supermarket at Porto Sokhna Entrance Getting on and off of the bus from Gate 2 of Porto EL Sokhna beneath the pedestrian bridge in front of Ragab Sons Supermarket. Go Mini station is in front of Mcdonalds near the office. Open from 6 am to 11 pm", 6, "Porto EL Sokhna", "01093996245" },
                    { 22, "Next to Sidi Abdelraheem Mosque and El Soltan store. Open 24 hrs", 7, "Qena Sidi Abdelraheem", "01093996245" },
                    { 23, "6 Abdel el hay shahin Mansheya El-Bakry El Mahalla 1st Police Department", 8, "Mahalla", "01093996245" },
                    { 24, "1 Abdel wahab St. with el fateh infront of wholesale market position", 8, "Tanta", "01093996245" },
                    { 25, "Downtown mall -next to the fish market - in front of (Gawaher El Bon)", 9, "Port Said Downtown", "01093996245" },
                    { 26, "El Helaly St.at the beginning of El Helaly bridge next to the Syndicate Of Applicators", 10, "El Helaly", "01093996245" },
                    { 27, "Shahin neighberhood, 23 Cairo - Aswan agriculture road", 11, "Minya", "01093996245" },
                    { 28, "17 Ramses St. Next to the train station. Open 24 hrs", 12, "Luxor", "01093996245" },
                    { 29, "El Geish St. next to Cairo bank infront of East Delta Travel", 13, "El Mansoura", "01093996245" },
                    { 30, "Drop off and pick up at El Gomhoria St.", 14, "Ismailia", "01093996245" }
                });

            migrationBuilder.InsertData(
                table: "PublicActivities",
                columns: new[] { "Id", "Description", "DestinationID", "ImageURL", "Title" },
                values: new object[,]
                {
                    { 1, "Naga is located 40 km from Hurghada, and is a must visit place. The calmness of its waves and the serenity of its sky make this spot the most suitable place for recreation and relaxation. You will have a very beautiful day in the enchanting nature; never miss a chance to do diving, or snorkeling in its water rich in the beautiful coral reefs that are so close to the beach.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/04/hurghada-01.jpg", "Sharm Al-Nagaa Beach" },
                    { 2, "Giftun Island is located 10 km away from Hurghada. They don't exaggerate when some say that it's Egypt's Maldives, as nature in its beach is like no other. The scenery there really fascinates everyone who visits it. The white sands, the clear blue sea that makes you see the undersea; will make your cruise the most enjoyable experience ever.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/04/hurghada-02.jpg", "Mahmya Beach in Giftun Island" },
                    { 3, "Hurghada Marina is located next to Sayadeen Village in Sekala Area and is considered and is an integrated entertainment area. This place is suitable to spend beautiful nights with the family, and to enjoy the beautiful view of the charming yachts, the marina is considered the largest yacht marina in Hurghada. So whether you will go in the evening to enjoy the restaurants, and the cafes, or you will go in the morning for diving and fishing, you will definitely have a great time.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/04/hurghada-03.jpg", "Hurghada Marina" },
                    { 4, "Makadi Bay is located between Safaga and Hurghada, 35 km south of Hurghada. It is characterized by the presence of approximately 15 resorts and hotels overlooking the red sea through the beautiful tourist Promenade. You can go for a walk or stroll through the exquisite nature and refreshing atmosphere.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/04/hurghada-02.jpg", "Makadi Bay" },
                    { 5, "You can see the most beautiful and most famous landmarks of Egypt in a miniature grouped in one place. The reduction ratio of the models is 1:25, between the Library of Alexandria, the Cairo Tower, the Pyramids of Giza, Tahrir Square, Maspero and the Temple of Abu Simbel, and others. As if you are taking a quick tour of the cities and landmarks of Egypt. Some still do not know about the monuments and entertainment in the coastal cities.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/05/miniegypt.jpg", "Mini Egypt" },
                    { 6, "Makadi Water World, which is located just outside Hurghada, is one of the largest amusement parks in Egypt. This place is very suitable for spending a day with family full of fun. You can enjoy swimming pools and play in the amusement parks and water games, which number up to fifty games and are suitable for all ages. You will also find what you want from restaurants and cafes.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/05/waterworld.jpg", "Makadi Water World" },
                    { 7, "It's nice to see a fun, unusual show, accompanied by dance music and amazing acrobatics, but imagine that this show features a group of dolphins? It will definitely be more beautiful and fun. Such is the case at Dolphin World, the most popular place for entertaining dolphin shows. She presents her talents in front of the audience who are happy with her. The offers are amazing for both kids and adults.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/05/dolphinworld.jpg", "Dolphin World" },
                    { 8, "If you want to spend a special day, you should go on a cruise inside the beautiful waters of Makadi. You can also practice different sports and water activities. Do not miss the experience of diving there and exploring the enchanting nature under the water's surface.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/04/hurghada-02.jpg", "Cruises and Water Sports" },
                    { 9, "One of the most famous charming attractions and must-see places is Qalaan Beach, where the mangrove tree is located. This tree is considered one of the most beautiful and oldest trees, as it reaches a thousand years old and grows beautifully in salt water. Your visit will definitely be amazing and unforgettable.    Qalaan Beach is characterized by the presence of different types of birds and forms of migratory birds.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/05/Mangrof-tree.jpg", "Mangrove tree" },
                    { 10, "Surely you have heard about dolphins in Marsa Alam and wished to swim alongside them. You can do this and more at Hankorab Beach, known as “Sharm El Louli”, which is considered one of the most beautiful beaches in the world. The beach is located 55 km from the city, within the Bedouin village of Abu Ghosoun, and the beach attracts many tourists every year.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/05/sharm-el-loly.jpg", "Hankorab Beach - Sharm El Luli" },
                    { 11, "It is not only dolphins that you can swim alongside in Marsa Alam, but you can also sail with turtles in the waters of Marsa Mubarak. Marsa Mubarak Bay is located 7 km from Marsa Alam International Airport. It is characterized by its charming aquatic nature, which contains the most beautiful creatures.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/05/Marsa-Mubarek.jpg", "Marsa Mubarak" },
                    { 12, "Night and night in Marsa Alam also has its own magic; After a long day of various activities, you can head out in Porto Ghalib. There you will find everything you want from restaurants and cafes and enjoy the beautiful sea view.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/05/Porto-ghaleb.jpg", "Porto Ghalib" },
                    { 13, "You can find in it what you want from different chains of restaurants and cafes. It is characterized by the presence of the walkway, where you will find various markets, shows and entertaining songs, in addition to children's competitions. The most important thing that distinguishes Porto Sokhna is also the cable car trips, which are the first of their kind in Egypt. It covers a distance of about a kilometer, during which you can fly to the top of the mountain in Ain Sukhna, then you will see an unparalleled view of splendor and beauty.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/04/sokhna-01.jpg", "Walkway in Porto Sokhna" },
                    { 14, "If you want to spend a beautiful day with friends and family, you should rent a yacht and take a cruise inside the waters of the Red Sea. There are boats that can accommodate up to 30 people, all equipped with everything you will need for food and water sports. You will spend a fun day between fishing and taking the most beautiful pictures. You can also sail to the best places for snorkeling and swimming with dolphins.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/04/sokhna-02.jpg", "Cruises" },
                    { 15, "If you are going to spend more than a day or even one day, in the resorts of Cancun and South Beach you will find what you desire in terms of beautiful beach, recreation and comfort. You will be able to enjoy the swimming pools and relax on the sea with animation shows and fun parties.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/04/sokhna-03.jpg", "Cancun and Porto South Beach Resorts" },
                    { 16, "One of the most important natural landmarks in Ain Sukhna is the Galala Mountain Range. Its height is 1200 meters and it is located south of Ain Sokhna. His great position is due to the fact that many believe that Moses passed over it to the Red Sea. Among the natural attractions are the sulfur eyes, which are famous for their role in healing many skin diseases and attract many tourists for treatment.", 2, "https://go-bus.com:8181/wp-content/uploads/2019/04/sokhna-04.jpg", "Mountains and Water Springs" },
                    { 17, "If you want to see beautiful nature like no other and charming water views, Ras Muhammed National park is the perfect place for you. Diving in this national park is a unique experience you should never miss. The underwater view is a real pleasure that takes you to another world where you find yourself in the midst of colorful fish and coral reefs and where you see strange creatures and marine fossils from thousands of years.", 3, "https://go-bus.com:8181/wp-content/uploads/2019/04/Sharm-01.jpg", "Ras Muhammed National park" },
                    { 18, "Nabq protected area is located between Sharm El Sheikh and Dahab, about 35 km from Sharm El Sheikh. This protected area is characterized by its mountain, desert and marine nature. Where you can find the beauty of the land and the sweetness of the land together. There you can see the most beautiful wildlife of reptiles and rodents, Also there are different types of animals and birds. Also you can enjoy the experience of watching beautiful marine organisms and rare fish. In this protected area you spend a special time between camping and diving.", 3, "https://go-bus.com:8181/wp-content/uploads/2019/04/Sharm-02.jpg", "Nabq Protected area" },
                    { 19, "Naama Bay is considered the main destination for outings and excursions. It has made a special character for Sharm El Sheikh nightlife. You can walk in its streets or sit in the beautiful cafes that is full of life. In Naama Bay you can find what you want from restaurants and cafes that extend along the Gulf and offer the most enjoyable offers and evenings. You will also find excellent shops for shopping with good prices and perfect goods.", 3, "https://go-bus.com:8181/wp-content/uploads/2019/04/Sharm-03.jpg", "Naama Bay" },
                    { 20, "If you want an unforgettable experience among the tall mountains, you have to climb Mount St. Catherine. The journey starts from the early mornings and lasts all day. You can climb halfway on a camel, and the other half on your foot as the road has stairs. The view of the sunset over the clouds is truly enchanting and worth the adventure. You can camp and wake up to watch the sunrise as well.", 3, "https://go-bus.com:8181/wp-content/uploads/2019/04/Sharm-04.jpg", "Mount St. Catherine" },
                    { 21, "One of the most beautiful and amazing places is Wadi Al-Wushwashi, which is still unknown to many. Wadi Al-Washwashi is located in Nuweiba and is distinguished by combining enjoying the mountainous nature and the beauty of the water together. The journey begins with climbing and hiking the mountains until you reach the green lake. That spot, which was formed by the gathering of torrential water in the winter, was embraced by the turquoise and granite mountains in a charming landscape. Only when you see this scene, you can only jump and throw yourself in that lake to enjoy its warm water.", 3, "https://go-bus.com:8181/wp-content/uploads/2019/04/Dahab-01.jpg", "Washwashi Valley" },
                    { 22, "Adventure lovers and those who wish to see unparalleled beauty in the depths of the sea never miss the opportunity to dive in the Blue Hole. It is a patch of water in the Red Sea that reaches a depth of 130 meters. The Blue Hole is one of the most amazing diving places in the world and attracts many tourists every year; It contains colors of coral reefs and marine creatures that you have to enjoy seeing, whether through diving or snorkeling. Equipment can be rented on the beach. You can also have a unique Bedouin food while relaxing in front of the beautiful sea scenery.", 3, "https://go-bus.com:8181/wp-content/uploads/2019/04/Dahab-02.jpg", "Blue Hole" },
                    { 23, "The charming sands of Abu Galum Beach and the purity and beauty of the water make it the best place to spend a quiet day amidst the picturesque nature. The name Abu Galumis due to the presence of the Qalum plant, whose name was later changed to Galum. The beach is also characterized by different types of birds and exotic plants; It includes 165 species of ordinary plants and 44 species that you can only find in this region.", 3, "https://go-bus.com:8181/wp-content/uploads/2019/04/Dahab-03.jpg", "Abu Galum" },
                    { 24, "If you want to spend the evening in a more lively place, you should head to the tourist walkway, where there are cafes and restaurants, including some that offer special musical performances that you will enjoy a lot. You can also shop in bazaars and stores and buy clothes and hand-made products at reasonable prices.", 3, "https://go-bus.com:8181/wp-content/uploads/2019/04/Dahab-04.jpg", "Walkway" },
                    { 25, "Today, the Qaitbay Citadel is different from any other archaeological site. Where you can learn about the greatness of history and the beauty of the architecture in the construction of that castle and its forts. You can also enjoy the view of the sea that surrounds it from three sides. The castle is also beautiful from the outside, where you can wander around the castle's corniche and sit in the various cafes.", 4, "https://go-bus.com:8181/wp-content/uploads/2018/05/Alex-01.jpg", "Citadel of Qaitbay" },
                    { 26, "Of course, you should never miss the opportunity to visit the Bibliotheca Alexandrina, which houses about 8 million books and three museums. In addition to the planetarium. We recommend that you review the library’s cultural program before traveling to learn about the concerts and activities offered by the library and that you can attend.", 4, "https://go-bus.com:8181/wp-content/uploads/2018/05/Alex-02.jpg", "Library of Alexandria" },
                    { 27, "When you think of a beautiful landscape, you imagine beautiful gardens, clear skies, and a wonderful view of the sea. Imagine all of this in one place. This is actually found in the Montazah Gardens, in addition to the beautiful architecture of the Montazah Palace. There you can spend a special day with family or friends and enjoy this special place.", 4, "https://go-bus.com:8181/wp-content/uploads/2018/05/Alex-03.jpg", "Al Montazah Garden\r\n" },
                    { 28, "Alexandria Corniche has an atmosphere that distinguishes it from any other place; Whether you are hiking on the Stanley Bridge or drinking a cup of coffee in one of the cafes overlooking the sea. You can also rent a boat with your friends and enjoy a cruise in the waters of the Mediterranean Sea, according to the time you want.", 4, "https://go-bus.com:8181/wp-content/uploads/2018/05/Alex-04.jpg", "Walking on the Corniche" },
                    { 29, "The water of the Mediterranean Sea with the fresh air in the northern coast make this area a special beauty. You can enjoy a beautiful day with family or friends in front of the enchanting sea view. You can also add some enthusiasm and vitality to your day, the atmosphere there is excellent for practicing all the exciting water sports, water skiing, windsurfing, as well as banana boats.", 5, "https://go-bus.com:8181/wp-content/uploads/2019/04/northcoast-activities.jpg", "Activities on the seashore" },
                    { 30, "Your vacation in the coast should not be without enjoying the exciting games and water parks offered by some places there. Between artificial waves, slides and multiple swimming pools, you will have a lot of fun and spend a time full of laughter and fun. You can also have meals there and listen to beautiful songs.", 5, "https://go-bus.com:8181/wp-content/uploads/2019/04/northcoast-aqua.jpg", "Fun parks and water games" },
                    { 31, "Porto Marina promenade is one of the most famous recreational places on the North Coast. This place is suitable for the outings of the whole family; It is characterized by multiple restaurants, as well as entertainment games for children and adults. But if you want to shop and buy some of your needs of clothes, appliances and others, you will also find what you want from different stores and international brands.", 5, "https://go-bus.com:8181/wp-content/uploads/2019/04/northcoast-portogolf.jpg", "Porto Golf Walk and Shopping" },
                    { 32, "Nightlife on the North Coast is one of the most important features that distinguish it from other places. If you have spent time relaxing in the morning and want to renew in the evening, you will always find the right place for you. The North Coast includes a wide range of restaurants, cafes and cafes that always offer the best offers. Be sure to check out the activities and parties so you can book in advance.", 5, "https://go-bus.com:8181/wp-content/uploads/2019/04/northcoast-nightlife.jpg", "Nightlife" },
                    { 33, "Hiking on the tourist promenade of the Suez Canal is one of the distinctive experiences that allows you to see a truly unique view. An experience you could never have lived before.", 9, "https://go-bus.com:8181/wp-content/uploads/2020/03/01-mamsha.jpg", "Tourist Promenade" },
                    { 34, "If you hear that Port Said is the valiant city, this is the right time to learn the reason behind this title, and of course the Military Museum is the best place that tells the history of the wars that took place on the city’s land in different periods of time through creatively drawn paintings and exhibits of weapons used in wars and other weapons and exhibits that were issued From different missions you tried to assault the city.", 9, "https://go-bus.com:8181/wp-content/uploads/2020/03/02-mat7af-7arby.jpg", "Military Museum" },
                    { 35, "The Victory Museum is located in one of the most prestigious areas of Port Said below the memorial to the martyrs of the war of 56, which is designed in the form of a pharaonic obelisk. The museum includes 150 works of art by the great artists in Egypt in the field of plastic art from sculpture, photography, drawing and crawl on various topics in which modern plastic art merges with historical topics that take interested On a different journey to learn things.", 9, "https://go-bus.com:8181/wp-content/uploads/2020/03/03-Elnasr-museum.jpg", "Victory Museum of Modern Art" },
                    { 36, "Tarh El Bahr Street extends over a large area in Port Said. It is a distinctive tourist street that includes a large number of free rest houses and gardens, in addition to a number of restaurants, cafes and side streets that put you on the sea road to find there the famous fish restaurants and some cafes that offer a unique experience near the seashore full of snails and the For visitors to swim in it and use the seats and parasols provided there.", 9, "https://go-bus.com:8181/wp-content/uploads/2020/03/04-tarh-el-bahr.jpg", "Tarh Al Bahar Street" },
                    { 37, "Your presence in Port Said is an irreplaceable opportunity to shop at low prices for the most famous international brands available for sale in Egypt and from authorized distributors, as Port Said is fully famous for the presence of many attractive markets for shoppers, but if you are interested in the best experience, El Gomhouria Street will be your first way and then you can tour the city in general And you will find in every inch a convenient place to buy what you need.", 9, "https://go-bus.com:8181/wp-content/uploads/2020/03/05-shopping.jpg", "Shopping in Port Said" },
                    { 38, "Port Fouad is reached through ferries that operate throughout the day, which is part of the experience of serenity, calmness and splendor located there, as it gives you a view of the ships in the Suez Canal amid the seagulls flying around you, waiting for the commuters to throw them to and from the suburb of food before you reach Port Fouad itself and enjoy With the green spaces and the beauty of the beaches, you will definitely miss a lot if you do not visit it.", 9, "https://go-bus.com:8181/wp-content/uploads/2020/03/07-port-fouaad.jpg", "Suburb of Port Fouad" },
                    { 39, "Tenis Island is located in the southwest of the city of Port Said, 9 km from the northeast of Lake Manzala. Easy (in half an hour) and fun (by a \"launch\" boat).", 9, "https://go-bus.com:8181/wp-content/uploads/2020/03/08-Tenis-island.jpg", "Tenis Island" }
                });

            migrationBuilder.InsertData(
                table: "StartBranches",
                columns: new[] { "Id", "Address", "DestinationId", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "9 Ramses St. (Railroad Company) in front of Ramses Train station", 1, "Ramses", "01093996245" },
                    { 2, "The Tourist walkway west of Somid, the central axis in front of 6 october City Hall", 1, "6 october", "01093996245" },
                    { 3, "Madinaty Gate 1", 1, "Madinaty", "01093996245" },
                    { 4, "4 El Galaa St. AbdelMoneim Riyad square next to Ramses Hilton Hotel Maspero Mall.", 1, "AbdelMoneim Riyad", "01093996245" },
                    { 5, "Next to Safaga Port Open from 7 am to 12 am", 2, "Safaga", "01093996245" },
                    { 6, "Next to CIB, 68 El Souq St. - In front of El Gamee Bank . Open from 8 am to 8 pm", 2, "Marsa Alam", "01093996245" },
                    { 7, "Bike and in front of El Gouna School Open from 8.30 am to 12.30 am", 2, "El Gouna", "01093996245" },
                    { 8, "Inside of Orascom Mall Makadi. Open from 9 am to 7 pm", 2, "Makadi", "01093996245" },
                    { 9, "Downtown next to Best Way Market beside the cinema. Getting on and off of the bus from the parking at the waiting hall of Pizatzza Village not from in front of the office. Open from 9 am to 9 pm.", 2, "Sahl Hasheesh", "01093996245" },
                    { 10, "ElNasr St. next to The Red Sea Hospital and ElHadidy Market and the old Fire station. Open 24 hrs.", 2, "Main Hurghada Office", "01093996245" },
                    { 11, "Located at Adam Abu Sawira Cafeteria is located directly on the road", 3, "Ras Sader Station", "01093996245" },
                    { 12, "La Hacienda", 3, "La Hacienda", "01093996245" },
                    { 13, "El Mashraba St. beside Dahab Plaza Hotel next to Maabar ElSeel Bride. Open from 7 am to 2 am", 3, "Dahab", "01093996245" },
                    { 14, "Shams Mall in front of Elwataneya Gas station - before Sharm ElSheikh International Hospital (International Haram Hospital)", 3, "Sharm", "01093996245" },
                    { 15, "45 St. Miami Corniche - Next to ElKataa Fish Open from 10 am to 1 am", 4, "Miami", "01093996245" },
                    { 16, "Inside of of the New Station , there are two offices in the building - Bus station is at platform 6 Open 24 hrs.", 4, "Moharam Bek", "01093996245" },
                    { 17, "Marina 7 : Before Marina 7 gate with 200 m - next to El Ahly Bank and Allam Auto Motors - the office is on the opposite side of the gate", 5, "Marina 7", "01093996245" },
                    { 18, "Stella Sidi Abdelrahman ; Infront of Stella Walk mall Sidi Abdelrahman", 5, "Sidi Abdelrahman", "01093996245" },
                    { 19, "Marassi : After the traffic point of Sidi Abdelrahman with 300 m in the direction of Alexandria next to ElGezira Coach", 5, "Marassi", "01093996245" },
                    { 20, "At km 2 - next to West Delta Travel station", 5, "Marsa Matruh", "01093996245" },
                    { 21, "In Front of El Mahmal Supermarket at Porto Sokhna Entrance Getting on and off of the bus from Gate 2 of Porto EL Sokhna beneath the pedestrian bridge in front of Ragab Sons Supermarket. Go Mini station is in front of Mcdonalds near the office. Open from 6 am to 11 pm", 6, "Porto EL Sokhna", "01093996245" },
                    { 22, "Next to Sidi Abdelraheem Mosque and El Soltan store. Open 24 hrs", 7, "Qena Sidi Abdelraheem", "01093996245" },
                    { 23, "6 Abdel el hay shahin Mansheya El-Bakry El Mahalla 1st Police Department", 8, "Mahalla", "01093996245" },
                    { 24, "1 Abdel wahab St. with el fateh infront of wholesale market position", 8, "Tanta", "01093996245" },
                    { 25, "Downtown mall -next to the fish market - in front of (Gawaher El Bon)", 9, "Port Said Downtown", "01093996245" },
                    { 26, "El Helaly St.at the beginning of El Helaly bridge next to the Syndicate Of Applicators", 10, "El Helaly", "01093996245" },
                    { 27, "Shahin neighberhood, 23 Cairo - Aswan agriculture road", 11, "Minya", "01093996245" },
                    { 28, "17 Ramses St. Next to the train station. Open 24 hrs", 12, "Luxor", "01093996245" },
                    { 29, "El Geish St. next to Cairo bank infront of East Delta Travel", 13, "El Mansoura", "01093996245" },
                    { 30, "Drop off and pick up at El Gomhoria St.", 14, "Ismailia", "01093996245" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BusClassId",
                table: "Buses",
                column: "BusClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_DriverId",
                table: "Buses",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassImages_BusClassId",
                table: "ClassImages",
                column: "BusClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EndBranches_DestinationId",
                table: "EndBranches",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicActivities_DestinationID",
                table: "PublicActivities",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TripId",
                table: "Reservations",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StartBranches_DestinationId",
                table: "StartBranches",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReservationId",
                table: "Tickets",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_BusId",
                table: "Trips",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_EndBranchId",
                table: "Trips",
                column: "EndBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_StartBranchId",
                table: "Trips",
                column: "StartBranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClassImages");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "PublicActivities");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "EndBranches");

            migrationBuilder.DropTable(
                name: "StartBranches");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BusClasses");

            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
