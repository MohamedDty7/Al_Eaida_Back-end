using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AL_Eaida_Infrastructure__Layer.Migrations
{
    /// <inheritdoc />
    public partial class addednotification1 : Migration
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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    WorkingHoursStart = table.Column<TimeSpan>(type: "time", nullable: true),
                    WorkingHoursEnd = table.Column<TimeSpan>(type: "time", nullable: true),
                    DefaultAppointmentDuration = table.Column<int>(type: "int", nullable: true),
                    MaxAppointmentsPerDay = table.Column<int>(type: "int", nullable: true),
                    AllowOnlineBooking = table.Column<bool>(type: "bit", nullable: false),
                    RequireAppointmentConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConsultationFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MedicationSales = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherServices = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAppointments = table.Column<int>(type: "int", nullable: true),
                    CompletedAppointments = table.Column<int>(type: "int", nullable: true),
                    CancelledAppointments = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GroupNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GenericName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DosageForm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Strength = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SideEffects = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Contraindications = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    StockQuantity = table.Column<int>(type: "int", nullable: true),
                    MinStockLevel = table.Column<int>(type: "int", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiresPrescription = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.Id);
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
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TableName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecordId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MedicalSchool = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    MaxPatientsPerDay = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receptionists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptionists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    GeneratedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GeneratedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_AspNetUsers_GeneratedByUserId",
                        column: x => x.GeneratedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GovernorateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationCategory_Medicines_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSchedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSpecializations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpecializations_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GovernorateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CityId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId1",
                        column: x => x.CityId1,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmergencyContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsuranceInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Patients_EmergencyContacts_EmergencyContactId",
                        column: x => x.EmergencyContactId,
                        principalTable: "EmergencyContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_InsuranceInfos_InsuranceInfoId",
                        column: x => x.InsuranceInfoId,
                        principalTable: "InsuranceInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceptionistId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Receptionists_ReceptionistId",
                        column: x => x.ReceptionistId,
                        principalTable: "Receptionists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PaymentNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalVisits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalVisits_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalVisits_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalVisits_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ItemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PrescribedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    MedicalVisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescriptions_MedicalVisits_MedicalVisitId",
                        column: x => x.MedicalVisitId,
                        principalTable: "MedicalVisits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prescriptions_Medicines_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Dosage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionItems_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionItems_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ecb10a6-d9c8-41ec-8577-8256e3d38608", null, "Doctor", "DOCTOR" },
                    { "7626c860-20d2-4402-bb4b-c8a0d067201e", null, "Receptionist", "RECEPTIONIST" },
                    { "f2d14089-a797-4493-be63-4a9c80570235", null, "Admin", "ADMIN" },
                    { "f5cea4e7-e825-4663-9586-bfb7a68a58d0", null, "Accountant ", "ACCOUNTANT " }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "IsActive", "LastLoginAt", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "14b85371-c6a3-43cc-97ec-585c6e09e623", 0, "", "4adfa0f2-3318-42bf-a35b-ab96347da884", new DateTime(2025, 10, 7, 17, 39, 52, 219, DateTimeKind.Utc).AddTicks(1713), "admin@al-eaida.com", true, true, null, true, null, "ADMIN@AL-EAIDA.COM", "ADMIN@AL-EAIDA.COM", "AQAAAAIAAYagAAAAEPS0kJmuZt+I0SqhnRktMN1zwWdL9JYv11PeyIfzpzIyRdYbNNXldirDow9nNC8Gug==", "", "+20 100 000 0000", true, "5b392572-34ca-4189-9e07-53eeb53ee810", false, "admin@al-eaida.com" },
                    { "875631f9-20c3-4306-ab43-a12de3e258e2", 0, "", "09cd505a-4248-437c-8792-aee0677561c4", new DateTime(2025, 10, 7, 17, 39, 52, 219, DateTimeKind.Utc).AddTicks(1820), "nour.mohamed@al-eaida.com", true, true, null, true, null, "NOUR.MOHAMED@AL-EAIDA.COM", "NOUR.MOHAMED@AL-EAIDA.COM", "AQAAAAIAAYagAAAAELHRNc6zcqCzH3YjFGYTS29fTzfeWrEte/aF0iVHHTlF53VkihjvOl1eOBo8KN4PWA==", "", "+20 100 555 5555", true, "b8ac2d2a-4561-43e9-8d4c-c80fd878a383", false, "nour.mohamed@al-eaida.com" },
                    { "a1b2c3d4-e5f6-7890-abcd-ef1234567890", 0, "", "7296ffce-4ff8-42c6-8168-4c08c6796350", new DateTime(2025, 10, 7, 17, 39, 52, 219, DateTimeKind.Utc).AddTicks(1830), "receptionist@al-eaida.com", true, true, null, true, null, "RECEPTIONIST@AL-EAIDA.COM", "RECEPTIONIST@AL-EAIDA.COM", "AQAAAAIAAYagAAAAENds/1cXbOtmuX19X7NdsLunKXAaFfvjeZBSHWPydeeueim83kpZFhI5iMKLvvQfqA==", "", "+20 100 666 6666", true, "be11276e-eb60-4f89-91d2-86f5e6060b89", false, "receptionist@al-eaida.com" },
                    { "b2c3d4e5-f6g7-8901-bcde-f23456789012", 0, "", "970ce5b2-f101-4451-8ab5-617f050b59d7", new DateTime(2025, 10, 7, 17, 39, 52, 219, DateTimeKind.Utc).AddTicks(1939), "accountant@al-eaida.com", true, true, null, true, null, "ACCOUNTANT@AL-EAIDA.COM", "ACCOUNTANT@AL-EAIDA.COM", "AQAAAAIAAYagAAAAEIRqTww7cZHKR/SZ+7S/w9hlTMTF7rXkK42RAPTDURzdJh55FvgW79dilhIfHA/a1w==", "", "+20 100 777 7777", true, "019e1023-5c3d-4fa9-9592-9bfa2a796419", false, "accountant@al-eaida.com" },
                    { "eeca4a29-b77e-4001-8880-bc962863fbc4", 0, "", "96edbf61-0447-40a0-8584-e843c0b46b69", new DateTime(2025, 10, 7, 17, 39, 52, 219, DateTimeKind.Utc).AddTicks(1789), "fatma.ali@al-eaida.com", true, true, null, true, null, "FATMA.ALI@AL-EAIDA.COM", "FATMA.ALI@AL-EAIDA.COM", "AQAAAAIAAYagAAAAEDCZ160hHEU1L89ToB330yk2ru28r9wEpdnbRBdgx5kbLG3XYPXD4o/nmVH1QAN1oA==", "", "+20 100 222 2222", true, "8a32c65c-8f84-4184-8d09-b02428b7523f", false, "fatma.ali@al-eaida.com" },
                    { "f757d17b-6565-47a5-8236-fa1435202704", 0, "", "4138111f-79a4-4714-afd8-984e5933ce3e", new DateTime(2025, 10, 7, 17, 39, 52, 219, DateTimeKind.Utc).AddTicks(1803), "mariam.hassan@al-eaida.com", true, true, null, true, null, "MARIAM.HASSAN@AL-EAIDA.COM", "MARIAM.HASSAN@AL-EAIDA.COM", "AQAAAAIAAYagAAAAEMVeqI6oDW4F3n2H+8gmPd2mDZz1b4dYZDx0iTQGQ2+zWCHUhtTQPLDFF+X4hilddg==", "", "+20 100 333 3333", true, "f1781aa6-fbc1-493c-a1c5-e393e3db0ec2", false, "mariam.hassan@al-eaida.com" },
                    { "fef8f13b-e461-411f-b288-e1a3b536f5e5", 0, "", "d93f8c40-8815-4eb1-bb20-e8de9bf6fd3f", new DateTime(2025, 10, 7, 17, 39, 52, 219, DateTimeKind.Utc).AddTicks(1813), "khaled.ahmed@al-eaida.com", true, true, null, true, null, "KHALED.AHMED@AL-EAIDA.COM", "KHALED.AHMED@AL-EAIDA.COM", "AQAAAAIAAYagAAAAEOea/s9/jRo+1692GXuICSoIwpuPkYmy5PTSiBP10zlE2UQvzsMcz+JlJjKTMjeLuA==", "", "+20 100 444 4444", true, "6fe2fed2-661b-4c5d-b470-51fcedf296b6", false, "khaled.ahmed@al-eaida.com" }
                });

            migrationBuilder.InsertData(
                table: "ClinicSettings",
                columns: new[] { "Id", "Address", "AllowOnlineBooking", "ClinicName", "CreatedAt", "DefaultAppointmentDuration", "Email", "LicenseNumber", "LogoPath", "MaxAppointmentsPerDay", "Phone", "RequireAppointmentConfirmation", "UpdatedAt", "Website", "WorkingHoursEnd", "WorkingHoursStart" },
                values: new object[] { new Guid("0b14e720-e448-48ba-a61d-f94131177130"), "شارع التحرير، القاهرة، مصر", true, "عيادة العائدة الطبية", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2641), 30, "info@al-eaida-clinic.com", "MED-2024-001", null, 50, "+20 2 1234 5678", true, new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2641), "www.al-eaida-clinic.com", new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "EmergencyContacts",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Phone", "Relationship" },
                values: new object[,]
                {
                    { new Guid("64d134ad-cf75-4c84-a5ce-bfe57fa9f9a0"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2939), "nour.hassan@email.com", "نورا حسن", "+20 100 666 6666", "زوجة" },
                    { new Guid("69df6b94-75f4-4215-b715-0f74660c2446"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2934), "fatma.mohamed@email.com", "فاطمة محمد", "+20 100 222 2222", "زوجة" },
                    { new Guid("c8946c42-c7ec-4d4f-8060-d4fb1420033c"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2936), "khaled.ali@email.com", "خالد علي", "+20 100 444 4444", "أخ" },
                    { new Guid("f7c9aa16-dd11-4420-b16a-3676390eb737"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2943), "mohamed.ahmed@email.com", "محمد أحمد", "+20 100 888 8888", "أب" },
                    { new Guid("fe71fd12-5280-49e9-ae9a-ce9542d3968b"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2946), "amira.mohamed@email.com", "أميرة محمد", "+20 100 000 0000", "زوجة" }
                });

            migrationBuilder.InsertData(
                table: "Governorates",
                columns: new[] { "Id", "CreatedAt", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("02791f62-3e4f-4beb-bb9c-d36a2b5f5486"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1527), "الفيوم", "Fayoum" },
                    { new Guid("0dfe319d-de1a-4650-9365-0862933cbd66"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1533), "المنيا", "Minya" },
                    { new Guid("1bb5a834-9bdf-4949-9d3d-edf13fab3725"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1525), "البحيرة", "Beheira" },
                    { new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1570), "سوهاج", "Sohag" },
                    { new Guid("38ecf431-44e1-4a58-a05a-af8ac4c057d7"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1519), "الدقهلية", "Dakahlia" },
                    { new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1515), "الجيزة", "Giza" },
                    { new Guid("5af068b3-1eb7-40c1-b1a2-23184af3eac8"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1542), "القليوبية", "Qaliubiya" },
                    { new Guid("6721681d-d5b6-4484-a92d-a5fc406dc2b8"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1520), "البحر الأحمر", "Red Sea" },
                    { new Guid("6c53e322-e081-4df7-acc7-952aaa07c327"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1562), "كفر الشيخ", "Kafr Al sheikh" },
                    { new Guid("6db77d7f-6d51-4bd4-9d99-344fc7c7c94e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1549), "اسوان", "Aswan" },
                    { new Guid("7297db33-8ab2-4421-ad3d-d8cf812fcdc6"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1530), "الإسماعلية", "Ismailia" },
                    { new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1478), "القاهرة", "Cairo" },
                    { new Guid("80ed16de-2582-4f03-81fe-98b89e75ec42"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1564), "مطروح", "Matrouh" },
                    { new Guid("83772c42-7f34-4d08-b482-0282b33dee12"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1551), "اسيوط", "Assiut" },
                    { new Guid("8dd79782-b1f3-44d1-926d-b2e4b3f8b204"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1556), "دمياط", "Damietta" },
                    { new Guid("9215b237-8948-4029-a74f-63c811e5c1ce"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1528), "الغربية", "Gharbiya" },
                    { new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1557), "الشرقية", "Sharkia" },
                    { new Guid("99417f37-3ae7-40e1-8eaa-85d9829b53c6"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1531), "المنوفية", "Menofia" },
                    { new Guid("a561a81d-23ce-4ab7-9b90-50c225a49f3f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1544), "الوادي الجديد", "New Valley" },
                    { new Guid("aa0c69cb-0203-4218-9133-673bf9c2d280"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1547), "السويس", "Suez" },
                    { new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1517), "الأسكندرية", "Alexandria" },
                    { new Guid("b913b530-d32e-465f-b18e-74bdfd3808e3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1553), "بني سويف", "Beni Suef" },
                    { new Guid("c0ed12d9-3bad-40ec-a608-39a27bfe1aa8"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1565), "الأقصر", "Luxor" },
                    { new Guid("c2e18ac3-3435-411b-9146-af0216927d57"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1567), "قنا", "Qena" },
                    { new Guid("d7204dc1-b79c-42dd-8b68-574a86651b68"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1558), "جنوب سيناء", "South Sinai" },
                    { new Guid("e32362b4-750b-4dc8-8a7f-1a0a2f228ff4"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1554), "بورسعيد", "Port Said" },
                    { new Guid("fe37bf3d-7f1b-4bf3-83f0-de6e6121b575"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1568), "شمال سيناء", "North Sinai" }
                });

            migrationBuilder.InsertData(
                table: "InsuranceInfos",
                columns: new[] { "Id", "CreatedAt", "GroupNumber", "PolicyNumber", "Provider", "ValidUntil" },
                values: new object[,]
                {
                    { new Guid("2f8c17b9-771b-4c77-9b5c-df7ed98ebaa9"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(3039), "GRP-004", "POL-004-2024", "شركة التأمين الطبي", new DateTime(2026, 8, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(3038) },
                    { new Guid("4ac49f45-1abf-42ff-93c9-5b682d179e44"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(3041), "GRP-005", "POL-005-2024", "شركة التأمين المتقدم", new DateTime(2026, 2, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(3041) },
                    { new Guid("8474527a-ee75-4135-8c39-a95e8007343e"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(3036), "GRP-003", "POL-003-2024", "شركة التأمين الشامل", new DateTime(2026, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(3035) },
                    { new Guid("a95b298a-850c-4f70-984a-9f0172ec8281"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(3020), "GRP-002", "POL-002-2024", "شركة التأمين الوطني", new DateTime(2026, 6, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(3019) },
                    { new Guid("c09be4ec-daab-4776-bc67-3157319ec66a"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(3017), "GRP-001", "POL-001-2024", "شركة التأمين الصحي", new DateTime(2026, 4, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(3014) }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Barcode", "Contraindications", "CreatedAt", "Description", "DosageForm", "ExpiryDate", "GenericName", "Instructions", "IsActive", "Manufacturer", "MinStockLevel", "Name", "Price", "RequiresPrescription", "SideEffects", "StockQuantity", "Strength", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5b5e3fb1-32f0-4b9a-b08e-627a345972e5"), null, "أمراض الكلى", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2733), "دواء لعلاج مرض السكري من النوع الثاني", "Tablet", new DateTime(2027, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2732), "Metformin", "يؤخذ مع الطعام", true, "شركة الأدوية المتخصصة", 40, "ميتفورمين", 18.50m, true, "قد يسبب اضطراب في المعدة", 400, "500mg", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2733) },
                    { new Guid("5e059efa-f7cf-4ba3-bfef-207133849327"), null, "لا يستخدم مع مرضى الكبد", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2706), "مسكن للآلام وخافض للحرارة", "Tablet", new DateTime(2027, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2692), "Paracetamol", "يؤخذ مع الطعام", true, "شركة الأدوية المصرية", 100, "باراسيتامول", 5.50m, false, "نادراً ما يسبب حساسية", 1000, "500mg", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2706) },
                    { new Guid("69d3f151-8548-4ae5-9f5c-5e6a3fc3dfce"), null, "قرحة المعدة", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2722), "مضاد للالتهاب ومسكن للآلام", "Tablet", new DateTime(2027, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2721), "Ibuprofen", "يؤخذ مع الطعام", true, "شركة الأدوية المتقدمة", 75, "إيبوبروفين", 8.25m, false, "قد يسبب اضطراب في المعدة", 750, "400mg", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2722) },
                    { new Guid("b363d61f-b5ef-4122-a9fa-ab3bc334b3b6"), null, "لا توجد موانع معروفة", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2727), "مثبط لمضخة البروتون لعلاج قرحة المعدة", "Capsule", new DateTime(2028, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2726), "Omeprazole", "يؤخذ على معدة فارغة", true, "شركة الأدوية الحديثة", 30, "أوميبرازول", 12.00m, true, "نادراً ما يسبب صداع", 300, "20mg", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2727) },
                    { new Guid("b98043c2-e9c6-49dd-bcaa-b09816a59148"), null, "حساسية من البنسلين", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2715), "مضاد حيوي واسع الطيف", "Capsule", new DateTime(2028, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2714), "Amoxicillin", "يؤخذ قبل الطعام", true, "شركة الأدوية العالمية", 50, "أموكسيسيلين", 15.75m, true, "قد يسبب اضطراب في المعدة", 500, "250mg", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2716) }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "AddressId", "CreatedAt", "DateOfBirth", "Email", "EmergencyContactId", "FirstName", "FullName", "Gender", "InsuranceInfoId", "IsActive", "LastName", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("6c7634b4-168a-4447-9482-fcaf7e61f84a"), null, new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2865), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed.mohamed@email.com", null, "أحمد", "أحمد محمد", "Male", null, true, "محمد", "+20 100 111 1111", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2866) },
                    { new Guid("cecee327-d554-407a-b28f-3f2880ded9a0"), null, new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2885), new DateTime(1982, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abdullah.mohamed@email.com", null, "عبدالله", "عبدالله محمد", "Male", null, true, "محمد", "+20 100 999 9999", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2885) },
                    { new Guid("d9212d32-f207-415b-9eb9-144fb06a29df"), null, new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2871), new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariam.ali@email.com", null, "مريم", "مريم علي", "Female", null, true, "علي", "+20 100 333 3333", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2871) },
                    { new Guid("f15ddfaf-5a32-40ac-a827-779958a78bbb"), null, new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2875), new DateTime(1978, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.hassan@email.com", null, "يوسف", "يوسف حسن", "Male", null, true, "حسن", "+20 100 555 5555", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2875) },
                    { new Guid("f4c0bf2f-fef6-42a6-af49-a80f7deff24d"), null, new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2879), new DateTime(1995, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.ahmed@email.com", null, "سارة", "سارة أحمد", "Female", null, true, "أحمد", "+20 100 777 7777", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2879) }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("32a49a3f-3865-4fe9-b74e-6d19670c9d94"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2400), "تخصص في علاج أمراض الأنف والأذن والحنجرة", true, "طب الأنف والأذن والحنجرة" },
                    { new Guid("6d9465c1-9f9c-4460-b3ea-91ca8e321d17"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2409), "تخصص في علاج أمراض الجهاز الهضمي", true, "طب الجهاز الهضمي" },
                    { new Guid("93f7e29d-c448-4811-8010-d048733e2c0f"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2381), "تخصص في علاج الأطفال", true, "طب الأطفال" },
                    { new Guid("97ab0c5c-5c80-46d0-9ff6-ed1f9bb826e2"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2377), "تخصص في أمراض القلب والأوعية الدموية", true, "طب القلب" },
                    { new Guid("a09979c0-f1f8-4e08-8981-9634a4786799"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2397), "تخصص في علاج أمراض العيون", true, "طب العيون" },
                    { new Guid("c5aac97b-9d3e-4ed2-8185-0aedc6793851"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2407), "تخصص في علاج أمراض الجهاز العصبي", true, "طب الأعصاب" },
                    { new Guid("c5e56c96-1389-4dca-a199-644203f07607"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2392), "تخصص في صحة المرأة والحمل والولادة", true, "طب النساء والولادة" },
                    { new Guid("c6b41956-bdce-4a0d-94e7-2afb0420cb89"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2404), "تخصص في علاج أمراض الجلد", true, "طب الجلدية" },
                    { new Guid("d9ac35ff-ee75-4a64-856e-b515ddb0af94"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2411), "تخصص في علاج أمراض المسالك البولية", true, "طب المسالك البولية" },
                    { new Guid("dc927246-79d6-487e-85aa-4ba261e2be94"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2395), "تخصص في علاج العظام والمفاصل", true, "طب العظام" }
                });

            migrationBuilder.InsertData(
                table: "SystemSettings",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Key", "Type", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { new Guid("076a96cb-8f59-4b03-bfce-034ff74cd88d"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2475), "اسم العيادة", true, "ClinicName", "String", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2475), "عيادة العائدة الطبية" },
                    { new Guid("138ec3fe-b7b2-45ef-a819-6c870b634178"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2486), "رقم هاتف العيادة", true, "ClinicPhone", "String", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2486), "+20 2 1234 5678" },
                    { new Guid("3d5502e7-33fe-4481-a072-ac82d46c9e66"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2514), "رسوم الاستشارة الافتراضية", true, "DefaultConsultationFee", "Decimal", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2515), "200" },
                    { new Guid("8b6963e8-6218-49ed-935f-eb9a23666343"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2500), "مدة الموعد الافتراضية بالدقائق", true, "DefaultAppointmentDuration", "Integer", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2500), "30" },
                    { new Guid("9c2d2654-9e09-4f85-9ac3-42af84549d3c"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2576), "تفعيل إشعارات البريد الإلكتروني", true, "EnableEmailNotifications", "Boolean", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2577), "true" },
                    { new Guid("9e83bfc3-f6f7-41d8-809c-999cf499ee3d"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2478), "عنوان العيادة", true, "ClinicAddress", "String", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2479), "شارع التحرير، القاهرة، مصر" },
                    { new Guid("a11da53a-8391-40cb-8f8f-db57cd5784d2"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2506), "العملة الافتراضية", true, "DefaultCurrency", "String", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2506), "EGP" },
                    { new Guid("a4eb30e9-69d8-4f61-a271-255b23a5731d"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2489), "بريد العيادة الإلكتروني", true, "ClinicEmail", "String", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2489), "info@al-eaida-clinic.com" },
                    { new Guid("b57fa2c7-43c9-4946-b0aa-31d812a20c56"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2503), "الحد الأقصى للمواعيد في اليوم", true, "MaxAppointmentsPerDay", "Integer", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2503), "50" },
                    { new Guid("baa1b750-9be7-4203-b5ba-89530f366c0a"), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2509), "معدل الضريبة المضافة", true, "TaxRate", "Decimal", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2509), "14" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f2d14089-a797-4493-be63-4a9c80570235", "14b85371-c6a3-43cc-97ec-585c6e09e623" },
                    { "4ecb10a6-d9c8-41ec-8577-8256e3d38608", "875631f9-20c3-4306-ab43-a12de3e258e2" },
                    { "7626c860-20d2-4402-bb4b-c8a0d067201e", "a1b2c3d4-e5f6-7890-abcd-ef1234567890" },
                    { "f5cea4e7-e825-4663-9586-bfb7a68a58d0", "b2c3d4e5-f6g7-8901-bcde-f23456789012" },
                    { "4ecb10a6-d9c8-41ec-8577-8256e3d38608", "eeca4a29-b77e-4001-8880-bc962863fbc4" },
                    { "4ecb10a6-d9c8-41ec-8577-8256e3d38608", "f757d17b-6565-47a5-8236-fa1435202704" },
                    { "4ecb10a6-d9c8-41ec-8577-8256e3d38608", "fef8f13b-e461-411f-b288-e1a3b536f5e5" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "GovernorateId", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("01cce9df-3896-431b-968d-9c3f2672f167"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2415), new Guid("83772c42-7f34-4d08-b482-0282b33dee12"), "ساحل سليم", "Sahil Selim" },
                    { new Guid("0233e78c-4f33-4bb2-b6c7-a1c8a0ad53f7"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2048), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "سموحة", "Smouha" },
                    { new Guid("0437f087-1332-4110-a71b-19fd71807df2"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2656), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "سوهاج الجديدة", "New Sohag" },
                    { new Guid("0442f0ed-391e-48ae-8593-f1b0b982d427"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2637), new Guid("fe37bf3d-7f1b-4bf3-83f0-de6e6121b575"), "العريش", "El Arish" },
                    { new Guid("048b1b20-9d85-4152-97b7-fb8048fbdb28"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2659), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "أخميم", "Akhmeem" },
                    { new Guid("058e9107-0f65-41e0-a05a-4bead32eefb9"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2627), new Guid("c2e18ac3-3435-411b-9146-af0216927d57"), "قفط", "Qift" },
                    { new Guid("059c3525-d6d6-4c18-959e-7ef211f92e6c"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2509), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "ههيا", "Hihya" },
                    { new Guid("0611fa88-fbdf-4230-9a05-e77837d470cb"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2435), new Guid("b913b530-d32e-465f-b18e-74bdfd3808e3"), "ببا", "Biba" },
                    { new Guid("0625733e-b54b-4496-a30f-d417fe638eaa"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2285), new Guid("7297db33-8ab2-4421-ad3d-d8cf812fcdc6"), "فايد", "Fayed" },
                    { new Guid("063f2d7c-117e-40f6-a3b5-06af8fde985d"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1876), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "منشأة القناطر", "ManshiyetAl Qanater" },
                    { new Guid("06b85942-2996-45f9-b013-dfa86e087b08"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1762), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الزمالك", "Zamalek" },
                    { new Guid("08632164-9853-44d0-bc7e-30adb1fea5b0"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2290), new Guid("7297db33-8ab2-4421-ad3d-d8cf812fcdc6"), "القنطرة غرب", "Qantara West" },
                    { new Guid("08dc3d3c-07e9-4aae-88d5-b0af53bb1eef"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2641), new Guid("fe37bf3d-7f1b-4bf3-83f0-de6e6121b575"), "نخل", "Nakhl" },
                    { new Guid("09346925-4843-4ce5-a57d-3dd38b9bf349"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1698), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "المقطم", "Mokattam" },
                    { new Guid("09cb46d0-3b58-42b7-8cf1-970d97e4d869"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1878), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "أوسيم", "Oaseem" },
                    { new Guid("0aee56dd-25ea-4e07-bea1-631a99c0b618"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2711), new Guid("a561a81d-23ce-4ab7-9b90-50c225a49f3f"), "الواحات البحرية", "El Wahat El Bahariya" },
                    { new Guid("0b0e4ec3-99c6-4b3b-a0b0-2329a254f148"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2566), new Guid("6c53e322-e081-4df7-acc7-952aaa07c327"), "سيدي سالم", "Sidi Salem" },
                    { new Guid("0bf7ae7a-dee4-451c-9688-b84cbfce992b"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1696), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "المعصرة", "Maasara" },
                    { new Guid("0cedb888-5170-4124-a927-28ad1918e48d"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2670), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "المنشأة", "El Mansha" },
                    { new Guid("0def2fd7-dca9-4507-81e3-670039b944af"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1899), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "الوراق", "Warraq" },
                    { new Guid("0ea03a99-748a-4d04-a348-72833059796b"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2666), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "البلينا", "El Balina" },
                    { new Guid("0f5c09ab-5926-430d-97ca-b47367e4cfd3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1750), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "مدينة العبور", "Obour City" },
                    { new Guid("101dca1a-c78f-4a73-ad97-74ce484e1352"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1678), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الظاهر", "El Daher" },
                    { new Guid("1048cf8d-a54f-4fa8-8e84-206e24f4f2bc"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1662), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الزيتون", "El-Zaytoun" },
                    { new Guid("140cbf4a-0260-49b9-8ed0-90333f636a21"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1870), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "العياط", "Al Ayat" },
                    { new Guid("141fc16d-253a-4186-ab22-a42de621d6de"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2295), new Guid("7297db33-8ab2-4421-ad3d-d8cf812fcdc6"), "أبو صوير", "Abu Suwir" },
                    { new Guid("176068a4-fd34-41db-942e-d9053d30769b"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2352), new Guid("5af068b3-1eb7-40c1-b1a2-23184af3eac8"), "قليوب", "Qalyub" },
                    { new Guid("177aa85e-935e-4d87-a48e-a0dee1594bbd"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2307), new Guid("99417f37-3ae7-40e1-8eaa-85d9829b53c6"), "أشمون", "Ashmun" },
                    { new Guid("17e5db19-b170-4dff-8640-d4562f462b44"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2305), new Guid("99417f37-3ae7-40e1-8eaa-85d9829b53c6"), "سرس الليان", "Sers El Layan" },
                    { new Guid("1890b7a8-ca00-4ca3-aef9-09f2aba4befd"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2046), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "سيدي جابر", "Sidi Gaber" },
                    { new Guid("1915fd14-a733-44cf-af29-efdace874d08"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2108), new Guid("38ecf431-44e1-4a58-a05a-af8ac4c057d7"), "المنزلة", "Manzala" },
                    { new Guid("199c0a0e-0e2e-4bbe-8f6d-124ebd8460ed"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1670), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "السيدة زينب", "Sayeda Zeinab" },
                    { new Guid("1a021932-3cbd-4252-b56d-9b80e1c1f87a"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1874), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "الباويطي", "Al-Bawaiti" },
                    { new Guid("1a96b6b5-db0c-48b5-b323-eec67266a0b0"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1937), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "القرية الذكية", "Smart Village" },
                    { new Guid("1b6cfc19-8b18-4375-919e-f4d3efa31fc9"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2499), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "الإبراهيمية", "El Ibrahimiya" },
                    { new Guid("1bf9b182-2f28-431c-97ab-777a38b67aef"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1783), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "العاشر من رمضان", "10th of Ramadan City" },
                    { new Guid("1cdfa41b-80da-462b-8d06-151b1939d646"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1736), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "عين شمس", "Ain Shms" },
                    { new Guid("1d3d9951-ff3c-45cf-b0ba-ae83aa5afff6"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2672), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "جرجا", "Gerga" },
                    { new Guid("1dce380d-3b0c-4419-8653-85e6b638cc75"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2473), new Guid("8dd79782-b1f3-44d1-926d-b2e4b3f8b204"), "السرو", "El Sarou" },
                    { new Guid("1dd75baf-dada-49dc-84f6-31c93fab6eaf"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1766), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الرحاب", "Rehab" },
                    { new Guid("1e618395-22a4-4f6d-bf52-bbe1f365da1f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1785), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الحلمية", "Helmeyat Alzaytoun" },
                    { new Guid("1e90e81d-3efa-41c2-b1d6-9e7829d0a15d"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2503), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "كفر صقر", "Kafr Saqr" },
                    { new Guid("1e928dd7-9865-4ce6-996b-6524fbdf68f8"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1676), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "مدينة الشروق", "Shorouk" },
                    { new Guid("1f44fe38-a7e9-4b17-a2cd-7dbe281d5e06"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2015), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "الدخيلة", "Dekheila" },
                    { new Guid("1f91a0fb-082a-49c8-a21b-486366bf76d5"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2706), new Guid("a561a81d-23ce-4ab7-9b90-50c225a49f3f"), "موط", "Mut" },
                    { new Guid("2028da0b-e808-434c-a3f5-54f08b828908"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1692), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "المعادى", "Maadi" },
                    { new Guid("224ad81e-f913-43d4-a53b-0cbdc2fd451a"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2299), new Guid("99417f37-3ae7-40e1-8eaa-85d9829b53c6"), "شبين الكوم", "Shibin El Kom" },
                    { new Guid("237adde7-211e-4220-896a-60d90bd1b478"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1886), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "كفر غطاطي", "Kafr Ghati" },
                    { new Guid("2476f339-f4b7-47b3-9fc0-a35ae14d8e8b"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1857), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "الشيخ زايد", "Cheikh Zayed" },
                    { new Guid("24b16beb-597e-4b75-a6f2-63f37034f0e1"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2513), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "القرين", "El Qurein" },
                    { new Guid("24c51ac5-37b3-451b-a6f7-ac1a246c0443"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1647), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "التبين", "Tebin" },
                    { new Guid("26966092-b980-48cc-9660-b674c71cc9c3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1645), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "البساتين", "Al Basatin" },
                    { new Guid("28d66c0e-8cbc-4e0b-a17b-01a0bb0e8616"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2496), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "فاقوس", "Faqous" },
                    { new Guid("29794457-2401-407c-862c-11b5a91e7636"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2361), new Guid("5af068b3-1eb7-40c1-b1a2-23184af3eac8"), "كفر شكر", "Kafr Shukr" },
                    { new Guid("29deab87-e38f-4ac3-b3ae-f96baf3e17c9"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2154), new Guid("6721681d-d5b6-4484-a92d-a5fc406dc2b8"), "رأس غارب", "Ras Gharib" },
                    { new Guid("2ab7a135-c8f4-4fd3-b439-16cb21e87635"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2036), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "المندرة", "Mandara" },
                    { new Guid("2b236527-06e1-47fa-b1fc-0ce49e9a22b5"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1905), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "بولاق الدكرور", "Boulaq Dakrour" },
                    { new Guid("2dad352a-f1d4-402a-b05b-ec454cd4d584"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2050), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "ستانلي", "Stanley" },
                    { new Guid("2e126a97-ccca-4ce1-9561-31906873fd47"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2327), new Guid("0dfe319d-de1a-4650-9365-0862933cbd66"), "العدوة", "El Adwa" },
                    { new Guid("2f43febe-1162-4717-a244-813362fe63b0"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2680), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "طما", "Tama" },
                    { new Guid("2f48b0a3-a76e-4dc6-8bb5-192783b378f0"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2429), new Guid("b913b530-d32e-465f-b18e-74bdfd3808e3"), "الواسطى", "El Wasta" },
                    { new Guid("315811b6-f0ad-4a9b-8508-286016808713"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2528), new Guid("d7204dc1-b79c-42dd-8b68-574a86651b68"), "دهب", "Dahab" },
                    { new Guid("32318b08-a182-4177-93ff-4077eba1b6e6"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2535), new Guid("d7204dc1-b79c-42dd-8b68-574a86651b68"), "طابا", "Taba" },
                    { new Guid("32ab4b37-d2c5-439e-af37-fdcb5cde3f8b"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2702), new Guid("a561a81d-23ce-4ab7-9b90-50c225a49f3f"), "بلاط", "Balat" },
                    { new Guid("34e23384-c3d1-4bbe-9a69-6c6fbaaea35f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2605), new Guid("c0ed12d9-3bad-40ec-a608-39a27bfe1aa8"), "الطود", "El Tod" },
                    { new Guid("35319b0f-4864-4eec-8da6-1c6007e1874d"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2293), new Guid("7297db33-8ab2-4421-ad3d-d8cf812fcdc6"), "التل الكبير", "El Tal El Kabir" },
                    { new Guid("35d7a4e3-3656-435a-95c7-3d70e0e74cd0"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2687), new Guid("a561a81d-23ce-4ab7-9b90-50c225a49f3f"), "الخارجة", "El Kharga" },
                    { new Guid("35d9c604-c348-41f0-8b36-132b9fa89712"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2668), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "المراغة", "El Maragha" },
                    { new Guid("365d43cd-4d5c-4b36-8e17-05ed7035eda7"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2621), new Guid("c2e18ac3-3435-411b-9146-af0216927d57"), "دشنا", "Deshna" },
                    { new Guid("37722a9b-e668-4619-9652-213b8926b226"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1706), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "النزهة", "Nozha" },
                    { new Guid("3790c982-ea7c-4cd6-bc3d-75a9724a3424"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1863), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "البدرشين", "Al Badrasheen" },
                    { new Guid("3a720c03-5cfb-45a4-8d1f-822c3a34faa3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2631), new Guid("c2e18ac3-3435-411b-9146-af0216927d57"), "فرشوط", "Farshout" },
                    { new Guid("3afce07b-6c60-49c9-9868-1708fd145f4a"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2058), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "الزيتون", "Zaytoun" },
                    { new Guid("3b962597-34ba-4d85-86c1-1487bcb3a3d4"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2358), new Guid("5af068b3-1eb7-40c1-b1a2-23184af3eac8"), "الخانكة", "El Khanka" },
                    { new Guid("3ca395df-e1bb-4a20-9e8a-ffb165a1fef1"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2556), new Guid("6c53e322-e081-4df7-acc7-952aaa07c327"), "البرلس", "El Borollos" },
                    { new Guid("3e149521-4d83-4bbc-b2e0-fc5c832af541"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2501), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "ديرب نجم", "Deirb Negm" },
                    { new Guid("3e25acd3-8bbb-4463-b54d-7e5afdc8663f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2329), new Guid("0dfe319d-de1a-4650-9365-0862933cbd66"), "مغاغة", "Maghagha" },
                    { new Guid("3efdf6d8-7ba0-4148-ab6d-6bbf96222007"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2054), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "سيدي كرير", "Sidi Kerir" },
                    { new Guid("402838eb-2fd5-4822-8878-e3d09f05e18e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2400), new Guid("83772c42-7f34-4d08-b482-0282b33dee12"), "أسيوط الجديدة", "New Assiut" },
                    { new Guid("40d1b554-1b52-4d30-8647-a7ca2af0babe"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2323), new Guid("0dfe319d-de1a-4650-9365-0862933cbd66"), "المنيا", "Minya" },
                    { new Guid("411d4556-0999-4e86-bd2b-9a9f1fbdaaa6"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1787), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "النزهة الجديدة", "New Nozha" },
                    { new Guid("41a24d93-5d05-4c11-9738-28c92397bf6d"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2172), new Guid("6721681d-d5b6-4484-a92d-a5fc406dc2b8"), "حلايب", "Halayeb" },
                    { new Guid("4214efcd-7aaf-4692-87b8-2145d36c1737"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1908), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "الواحات البحرية", "Al Wahat Al Baharia" },
                    { new Guid("43ebb836-43b4-4aac-93a2-39c14539ea7a"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1940), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "ارض اللواء", "Ard Ellwaa" },
                    { new Guid("460a9bbb-6d5b-47fe-a3a2-3d2bf013de5b"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2044), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "سيدي بشر", "Sidi Bishr" },
                    { new Guid("463a0034-f33b-43db-8c96-9daf59288400"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2537), new Guid("d7204dc1-b79c-42dd-8b68-574a86651b68"), "سانت كاترين", "Saint Catherine" },
                    { new Guid("47958097-133f-4bab-b786-ac8ff2957fa3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2585), new Guid("80ed16de-2582-4f03-81fe-98b89e75ec42"), "سيدي براني", "Sidi Barrani" },
                    { new Guid("47fcce21-e733-4c85-82c2-1e720fab213a"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2104), new Guid("38ecf431-44e1-4a58-a05a-af8ac4c057d7"), "أجا", "Aga" },
                    { new Guid("49c85f77-20b2-454c-8204-1e34c589407f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2411), new Guid("83772c42-7f34-4d08-b482-0282b33dee12"), "أبو تيج", "Abu Tig" },
                    { new Guid("4a40ca1c-449d-47ee-9788-19e420bdecbb"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2539), new Guid("d7204dc1-b79c-42dd-8b68-574a86651b68"), "أبو رديس", "Abu Redis" },
                    { new Guid("4b164f16-7001-42a2-8692-10f5b3beba55"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2373), new Guid("aa0c69cb-0203-4218-9133-673bf9c2d280"), "الأربعين", "El Arba'in" },
                    { new Guid("4be8f3ab-573e-4eaa-8f27-20712c2753e7"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2548), new Guid("6c53e322-e081-4df7-acc7-952aaa07c327"), "دسوق", "Desouk" },
                    { new Guid("4ca58de7-d30d-41ee-b109-fe029e9faebb"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1688), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "عزبة النخل", "Ezbet el Nakhl" },
                    { new Guid("4cfb2912-dbea-4d47-b5bd-c4fca9d0f289"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2439), new Guid("b913b530-d32e-465f-b18e-74bdfd3808e3"), "الفشن", "El Fashn" },
                    { new Guid("4d6a3bdf-db70-4f54-afa0-eb78339f7073"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2409), new Guid("83772c42-7f34-4d08-b482-0282b33dee12"), "القوصية", "El Qusiya" },
                    { new Guid("4dd0c3ff-3edd-49ae-9dca-e16578e83fde"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2209), new Guid("1bb5a834-9bdf-4949-9d3d-edf13fab3725"), "أبو المطامير", "Abu El Matamir" },
                    { new Guid("4defe172-5420-457d-a468-99139af42a7d"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1703), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الموسكى", "Mosky" },
                    { new Guid("4ec5ccc7-8814-4489-a051-c44a76f4e41e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2122), new Guid("38ecf431-44e1-4a58-a05a-af8ac4c057d7"), "ميت سلسيل", "Mit Salsil" },
                    { new Guid("512cf3e3-91f8-4c0c-b9ac-929b3321d2ab"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2611), new Guid("c2e18ac3-3435-411b-9146-af0216927d57"), "قنا", "Qena" },
                    { new Guid("5253371b-e7c7-4ea9-862b-1e2dc5385bc5"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2639), new Guid("fe37bf3d-7f1b-4bf3-83f0-de6e6121b575"), "الشيخ زويد", "Sheikh Zuweid" },
                    { new Guid("52fe6cd0-2b12-4925-b1c7-aeb5f640c6c3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1925), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "أبو رواش", "Abu Rawash" },
                    { new Guid("53e565cf-5cc1-4e6f-a76b-cba531b1d09c"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2335), new Guid("0dfe319d-de1a-4650-9365-0862933cbd66"), "مطاي", "Matai" },
                    { new Guid("5586b640-06e0-425f-94eb-1215dcb36332"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2597), new Guid("c0ed12d9-3bad-40ec-a608-39a27bfe1aa8"), "القرنة", "El Qurna" },
                    { new Guid("55a7b36d-b649-484c-a4f8-dc836ca3f3a2"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2034), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "المكس", "Maks" },
                    { new Guid("5620b904-9be2-49ab-aff8-3d470040a995"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1920), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "المهندسين", "Mohandessin" },
                    { new Guid("5908920a-e6c9-4e6c-aab8-aff3357fdecd"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2581), new Guid("80ed16de-2582-4f03-81fe-98b89e75ec42"), "النجيلة", "El Negila" },
                    { new Guid("5926c230-35f6-4b3e-9e48-5b4221e140bf"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1930), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "الحرانية", "Haraneya" },
                    { new Guid("59ba53af-3a1a-4ef0-a535-aa6dedc5e862"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2406), new Guid("83772c42-7f34-4d08-b482-0282b33dee12"), "منفلوط", "Manfalut" },
                    { new Guid("5ab0a972-afc2-43dc-a653-7b4d931aad18"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1918), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "الكيت كات", "Kit Kat" },
                    { new Guid("5b4b24eb-8442-4f3d-80ee-64ae097cd7eb"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2577), new Guid("80ed16de-2582-4f03-81fe-98b89e75ec42"), "العلمين", "El Alamein" },
                    { new Guid("5b96d366-6e6a-429f-8236-a5376671056e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2363), new Guid("5af068b3-1eb7-40c1-b1a2-23184af3eac8"), "طوخ", "Toukh" },
                    { new Guid("5bb4cc6d-a2c4-44f0-98c3-dd5de21199d4"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2309), new Guid("99417f37-3ae7-40e1-8eaa-85d9829b53c6"), "الباجور", "El Bagour" },
                    { new Guid("5c3505b6-b788-45a3-b405-1f95f8705f20"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2056), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "سيدي كرير الجديدة", "New Sidi Kerir" },
                    { new Guid("5eacdd6e-bf17-44bb-8261-20376c5e0aa1"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2337), new Guid("0dfe319d-de1a-4650-9365-0862933cbd66"), "سمالوط", "Samalut" },
                    { new Guid("5ef44518-90dd-44cd-b523-1363c53991af"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2546), new Guid("6c53e322-e081-4df7-acc7-952aaa07c327"), "كفر الشيخ الجديدة", "New Kafr El Sheikh" },
                    { new Guid("602847b5-efb8-4418-9fb2-2b502e43b8cd"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2111), new Guid("38ecf431-44e1-4a58-a05a-af8ac4c057d7"), "ميت غمر", "Mit Ghamr" },
                    { new Guid("60ff501f-2727-4931-b0e1-b32a3b1b71d1"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2255), new Guid("02791f62-3e4f-4beb-bb9c-d36a2b5f5486"), "إبشواي", "Ibshway" },
                    { new Guid("625c1d40-31a9-4cf0-b50c-03a6ea41589e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2317), new Guid("99417f37-3ae7-40e1-8eaa-85d9829b53c6"), "تلا", "Tala" },
                    { new Guid("62c8807f-2cc8-437f-bf0a-57dc3f2eb58d"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2456), new Guid("e32362b4-750b-4dc8-8a7f-1a0a2f228ff4"), "الشرقية", "El Sharqiya" },
                    { new Guid("62f4c90f-aaaa-4f31-9bb7-80da340ee8a7"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1768), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "القطامية", "Katameya" },
                    { new Guid("641e6fb9-1ad4-4a86-8fbb-2bab0533ffd7"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1990), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "برج العرب", "Borg El Arab" },
                    { new Guid("643cd4cf-721b-4a94-b65e-2123be64a2f2"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2315), new Guid("99417f37-3ae7-40e1-8eaa-85d9829b53c6"), "بركة السبع", "Berkat El Saba" },
                    { new Guid("64b85ad0-8df9-48a1-952d-7ce52483f285"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2451), new Guid("e32362b4-750b-4dc8-8a7f-1a0a2f228ff4"), "المناخ", "El Manakh" },
                    { new Guid("64fe7973-37eb-4f9b-990d-54111b5758d7"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2675), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "جهينة", "Jahina" },
                    { new Guid("6567da4b-2caa-4a76-a06a-698ee52e0b13"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1740), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "مصر الجديدة", "New Heliopolis" },
                    { new Guid("66439646-6aa7-49a5-818d-d610a40a8a2f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1623), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "15 مايو", "15 May" },
                    { new Guid("671dd171-8e5a-48c5-ab08-51891b2df4a3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2213), new Guid("1bb5a834-9bdf-4949-9d3d-edf13fab3725"), "وادي النطرون", "Wadi El Natrun" },
                    { new Guid("6790c207-ec57-4306-abeb-649944f45728"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2609), new Guid("c0ed12d9-3bad-40ec-a608-39a27bfe1aa8"), "أرمنت", "Armant" },
                    { new Guid("686a7236-15fd-4401-a125-8af888f04dd2"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2007), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "باكوس", "Bakos" },
                    { new Guid("689016e1-c434-4796-9161-3f62470825c2"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2038), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "محرم بك", "Moharam Bek" },
                    { new Guid("68ecefb2-86c6-4f78-9659-404fff1d25a4"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2492), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "بلبيس", "Belbeis" },
                    { new Guid("6b1f7a38-b072-450b-80e9-e3997654f2dc"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2201), new Guid("1bb5a834-9bdf-4949-9d3d-edf13fab3725"), "كفر الدوار", "Kafr El Dawwar" },
                    { new Guid("6b2b35aa-ecdb-41db-978b-ecfa1b84381f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1772), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "مدينتي", "Madinty" },
                    { new Guid("6bab781c-c085-4b85-bbd9-0196f5dd7321"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1764), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "قصر النيل", "Kasr El Nile" },
                    { new Guid("6bcf5664-93f6-4879-a304-fb7be526d482"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1686), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "المرج", "El Marg" },
                    { new Guid("6c65ca46-f6f5-4bf7-ac95-9d9f241c7cee"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1738), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "مدينة نصر", "Nasr City" },
                    { new Guid("6cc3177b-f7fa-4637-988b-9639a951bbf4"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2441), new Guid("b913b530-d32e-465f-b18e-74bdfd3808e3"), "سمسطا", "Somasta" },
                    { new Guid("6d6911df-3284-400a-8416-b56bc08cb264"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2607), new Guid("c0ed12d9-3bad-40ec-a608-39a27bfe1aa8"), "إسنا", "Esna" },
                    { new Guid("6dc70805-4506-4d35-aee0-e1b23f2cc134"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2421), new Guid("83772c42-7f34-4d08-b482-0282b33dee12"), "صدفا", "Sidfa" },
                    { new Guid("70745be4-c91a-416a-8d7a-49e81dd4ed79"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2494), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "أبو كبير", "Abu Kabir" },
                    { new Guid("7181e13e-4a88-42ee-882f-d56f2f50c452"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2404), new Guid("83772c42-7f34-4d08-b482-0282b33dee12"), "ديروط", "Deirout" },
                    { new Guid("7355115a-6c22-4e12-b8fc-db00335d8e30"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2165), new Guid("6721681d-d5b6-4484-a92d-a5fc406dc2b8"), "القصير", "Quseir" },
                    { new Guid("7389a8de-d40d-4fe3-a95f-07663f31e543"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2449), new Guid("e32362b4-750b-4dc8-8a7f-1a0a2f228ff4"), "الضاحية", "El Dahiya" },
                    { new Guid("74f9f557-edb1-4bac-8c1e-65b71a4b4a1f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1718), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "حدائق القبة", "Hadayek El-Kobba" },
                    { new Guid("75709e57-9771-4973-9695-43183ae78e59"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2369), new Guid("5af068b3-1eb7-40c1-b1a2-23184af3eac8"), "العبور", "El Obour" },
                    { new Guid("75921483-506d-4a06-a600-33f463d2eca6"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2010), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "بولكلي", "Bolkly" },
                    { new Guid("7747cba1-e3e1-4a63-a1da-56fecd3c1b3e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1722), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "دار السلام", "Dar Al Salam" },
                    { new Guid("77b79c2a-d4e0-4f4b-a7bd-019ff8817fb3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2651), new Guid("fe37bf3d-7f1b-4bf3-83f0-de6e6121b575"), "الطور", "El Tor" },
                    { new Guid("77cb5d52-7e71-46d5-b83a-773985b25ac8"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2003), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "العطارين", "Attarin" },
                    { new Guid("77e13721-b56f-4f05-8b1a-e35caf320535"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2685), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "الكوثر", "El Kawther" },
                    { new Guid("77f09d11-1ebc-442d-b578-20ee1c056b68"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2106), new Guid("38ecf431-44e1-4a58-a05a-af8ac4c057d7"), "السنبلاوين", "Sinbillawin" },
                    { new Guid("7a78e60c-db7b-47b4-960e-ba0fc023296f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2398), new Guid("83772c42-7f34-4d08-b482-0282b33dee12"), "أسيوط", "Assiut" },
                    { new Guid("7b5d300a-868b-44ab-9af0-6464b3c2ff62"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2591), new Guid("c0ed12d9-3bad-40ec-a608-39a27bfe1aa8"), "الأقصر", "Luxor" },
                    { new Guid("7c9dd957-7e57-4b0a-9f69-1acf8e7ec120"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2381), new Guid("aa0c69cb-0203-4218-9133-673bf9c2d280"), "عتاقة", "Ataka" },
                    { new Guid("7d27c5ff-b8c6-4f69-81c8-403d0f10af51"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1910), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "العمرانية", "Omraneya" },
                    { new Guid("7d945eb7-3a00-43cc-a8c2-5eb132e0268f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2251), new Guid("02791f62-3e4f-4beb-bb9c-d36a2b5f5486"), "سنورس", "Senuors" },
                    { new Guid("7d9d5bab-22ab-4fe2-a2eb-7110b708289e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2678), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "ساقلتة", "Saqilta" },
                    { new Guid("7e2d8935-05c5-4015-95fb-091388320e51"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2481), new Guid("8dd79782-b1f3-44d1-926d-b2e4b3f8b204"), "الزرقا", "El Zarqa" },
                    { new Guid("7f0e4876-7132-4eb3-81a1-df60b51dc924"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2662), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "أخميم الجديدة", "New Akhmeem" },
                    { new Guid("7ffeb2dc-a4ab-4f13-bb61-d05ad06898f0"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1888), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "منشأة البكاري", "Manshiyet Al Bakari" },
                    { new Guid("80c45e12-64ad-4dde-a50a-31d7723b7c01"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2692), new Guid("a561a81d-23ce-4ab7-9b90-50c225a49f3f"), "باريس", "Paris" },
                    { new Guid("81964f97-4cc6-4ecc-8512-e4f8c2415534"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2579), new Guid("80ed16de-2582-4f03-81fe-98b89e75ec42"), "الضبعة", "El Dabaa" },
                    { new Guid("81f996c7-d67c-4cf8-b939-7d3f9cbb96fd"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1789), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "العاصمة الإدارية", "Capital New" },
                    { new Guid("82346f5e-7c64-4d1a-aeb4-5c9bca1128c2"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2587), new Guid("80ed16de-2582-4f03-81fe-98b89e75ec42"), "السلوم", "El Salloum" },
                    { new Guid("82b0b1ff-0cc5-42b9-8da6-11ff16f79430"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2125), new Guid("38ecf431-44e1-4a58-a05a-af8ac4c057d7"), "المنصورة القديمة", "Old Mansoura" },
                    { new Guid("83382d67-eb96-41ec-97c6-45867b8629fb"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2541), new Guid("d7204dc1-b79c-42dd-8b68-574a86651b68"), "أبو زنيمة", "Abu Zenima" },
                    { new Guid("84828aaa-8bdd-4292-b717-e7f2692d07e1"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2614), new Guid("c2e18ac3-3435-411b-9146-af0216927d57"), "قنا الجديدة", "New Qena" },
                    { new Guid("84f2a1a5-68fb-48fb-a42b-734a8281294b"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1746), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "منشية ناصر", "Mansheya Nasir" },
                    { new Guid("867726e3-6b95-42bc-ac91-cbecd12c8f27"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2278), new Guid("9215b237-8948-4029-a74f-63c811e5c1ce"), "سمنود", "Samannoud" },
                    { new Guid("8777c363-b102-4462-8960-2d6fdd6ec277"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2371), new Guid("aa0c69cb-0203-4218-9133-673bf9c2d280"), "السويس", "Suez" },
                    { new Guid("87c44d2e-033d-4464-a797-6adf4f07ccdd"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1985), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "الإسكندرية", "Alexandria" },
                    { new Guid("87ddda6c-341c-4f55-a59a-94cac1d55ce1"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2564), new Guid("6c53e322-e081-4df7-acc7-952aaa07c327"), "الرياض", "El Riyad" },
                    { new Guid("8992923d-c323-4370-828a-7f94dc3b31ec"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1682), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "القاهرة الجديدة", "New Cairo" },
                    { new Guid("8b3eeb80-5bee-4f9a-a434-9d45c6dbfdb6"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2645), new Guid("fe37bf3d-7f1b-4bf3-83f0-de6e6121b575"), "رفح", "Rafah" },
                    { new Guid("8bd9a6d8-69d1-44bc-9fdb-f9f1e4ee3d57"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1680), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "العتبة", "Ataba" },
                    { new Guid("8bde4ce5-1979-4b9f-8e33-958bca692436"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2167), new Guid("6721681d-d5b6-4484-a92d-a5fc406dc2b8"), "مرسى علم", "Marsa Alam" },
                    { new Guid("8e42ca8f-8762-4276-a10d-6a3c3760a1f0"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2601), new Guid("c0ed12d9-3bad-40ec-a608-39a27bfe1aa8"), "بياضة", "Bayada" },
                    { new Guid("8f5efa41-bf87-44dd-ab75-370c628f7bac"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2151), new Guid("6721681d-d5b6-4484-a92d-a5fc406dc2b8"), "الغردقة", "Hurghada" },
                    { new Guid("8f8e3278-4c53-471c-8f1c-a7ab6281f629"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2619), new Guid("c2e18ac3-3435-411b-9146-af0216927d57"), "نجع حمادي", "Nag Hammadi" },
                    { new Guid("8fd00cd2-5796-443f-b565-0dd6b4abe0f3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2115), new Guid("38ecf431-44e1-4a58-a05a-af8ac4c057d7"), "دكرنس", "Dekernes" },
                    { new Guid("9101a1a4-684a-4487-a2e8-a0771a46d053"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2020), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "فلمنج", "Fleming" },
                    { new Guid("91622c8e-f241-48bb-af5c-824c32cb3e45"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2005), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "أبو قير", "Abu Qir" },
                    { new Guid("92636c93-e77a-4229-977e-66aac3272c1d"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1708), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الوايلى", "Waily" },
                    { new Guid("93dcaf56-fccc-47b8-be45-42f74c98b70f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2511), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "أبو حماد", "Abu Hammad" },
                    { new Guid("94c82d45-f990-416d-b565-0563cb958b00"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2265), new Guid("9215b237-8948-4029-a74f-63c811e5c1ce"), "كفر الزيات", "Kafr El Zayat" },
                    { new Guid("9670af39-88f5-44ed-928b-a4fd6518a884"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2350), new Guid("5af068b3-1eb7-40c1-b1a2-23184af3eac8"), "بنها", "Benha" },
                    { new Guid("97195feb-36ee-4372-ad30-15e390bcfa67"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2197), new Guid("1bb5a834-9bdf-4949-9d3d-edf13fab3725"), "دمنهور", "Damanhur" },
                    { new Guid("985f94bc-14dd-430e-b2bb-72cfed04ca60"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2560), new Guid("6c53e322-e081-4df7-acc7-952aaa07c327"), "بيلا", "Bella" },
                    { new Guid("98e83058-3ff5-4ab4-9671-729ee3c0bd17"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2297), new Guid("7297db33-8ab2-4421-ad3d-d8cf812fcdc6"), "القصاصين", "Qassasin" },
                    { new Guid("9a00b1c1-a199-4f4d-a607-979b57c30ffa"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2030), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "المنتزه", "Montaza" },
                    { new Guid("9baaddd9-8f99-4105-b690-3e05710115e7"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1884), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "أبو النمرس", "Abu Nomros" },
                    { new Guid("9c1e86a6-5338-4590-ae49-e66c946d9b75"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1672), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الشرابية", "El Sharabeya" },
                    { new Guid("9d7cf7b3-2606-44e1-82bd-f69776e1a07e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1935), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "صفط اللبن", "Saft Allaban" },
                    { new Guid("9dab8131-3533-4aab-966e-bc6f5c922967"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1894), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "العجوزة", "Agouza" },
                    { new Guid("9eb46d44-9586-477e-95bc-d5eff5bf5e42"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2383), new Guid("6db77d7f-6d51-4bd4-9d99-344fc7c7c94e"), "أسوان", "Aswan" },
                    { new Guid("9f9332bb-af2c-445f-8452-8557c74f9495"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2649), new Guid("fe37bf3d-7f1b-4bf3-83f0-de6e6121b575"), "الحسنة", "El Hasana" },
                    { new Guid("9ffd9606-f060-42cd-8596-127f005fc470"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2490), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "العاشر من رمضان", "10th of Ramadan" },
                    { new Guid("a33970e8-bb05-4956-b59a-29029108526c"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2211), new Guid("1bb5a834-9bdf-4949-9d3d-edf13fab3725"), "النوبارية الجديدة", "New Nubaria" },
                    { new Guid("a52639b7-5249-4a05-b6e0-7db2ae657540"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2388), new Guid("6db77d7f-6d51-4bd4-9d99-344fc7c7c94e"), "دراو", "Daraw" },
                    { new Guid("a597a66b-0e1b-4429-ad06-fe103f6d3e07"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2282), new Guid("7297db33-8ab2-4421-ad3d-d8cf812fcdc6"), "الإسماعيلية", "Ismailia" },
                    { new Guid("a87f5cb8-7f62-46df-ab8a-07a174f8a5ea"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2471), new Guid("8dd79782-b1f3-44d1-926d-b2e4b3f8b204"), "زرقون", "Zarqoun" },
                    { new Guid("aa83d4bd-aa9c-44b2-958a-0d043d9dded2"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2247), new Guid("02791f62-3e4f-4beb-bb9c-d36a2b5f5486"), "طامية", "Tamiya" },
                    { new Guid("aae3dc0e-c44e-4da9-9194-51f09e4beef8"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1891), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "الدقى", "Dokki" },
                    { new Guid("ab0e9098-4ff7-4333-8aee-a5386950b9f5"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1660), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الزاوية الحمراء", "Zawya al-Hamra" },
                    { new Guid("ab28d7f3-fe11-4be7-a0a8-71436f35ce60"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1774), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "روض الفرج", "Rod Alfarag" },
                    { new Guid("abaf4a4e-1972-49b7-b9ea-a107fe85cf6e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1897), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "الهرم", "Haram" },
                    { new Guid("abf7a5c3-4822-487d-9ecb-bce96b153b0c"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2258), new Guid("02791f62-3e4f-4beb-bb9c-d36a2b5f5486"), "يوسف الصديق", "Yusuf El Sadiq" },
                    { new Guid("ac5b37a4-aee9-4f62-bf11-784cc69a2dbd"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1654), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الدراسة", "El darrasa" },
                    { new Guid("ad69045d-197c-420c-945d-0fa2172afb6a"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2117), new Guid("38ecf431-44e1-4a58-a05a-af8ac4c057d7"), "المنصورة الجديدة", "New Mansoura" },
                    { new Guid("ada48c30-02ff-4e45-853d-7a0ff177fc91"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2617), new Guid("c2e18ac3-3435-411b-9146-af0216927d57"), "أبو تشت", "Abu Tesht" },
                    { new Guid("adc4c596-f89a-403e-9b13-ca3c5fe0814f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2287), new Guid("7297db33-8ab2-4421-ad3d-d8cf812fcdc6"), "القنطرة شرق", "Qantara East" },
                    { new Guid("aeba2b4c-2d61-4b12-ba6e-e7e99da296b1"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2119), new Guid("38ecf431-44e1-4a58-a05a-af8ac4c057d7"), "طلخا", "Talkha" },
                    { new Guid("aeceb47b-2f07-4552-9e93-795ee0556c97"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2156), new Guid("6721681d-d5b6-4484-a92d-a5fc406dc2b8"), "سفاجا", "Safaga" },
                    { new Guid("aef2439d-83c0-48db-a0be-9bab2949c6f8"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1742), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "مصر القديمة", "Masr Al Qadima" },
                    { new Guid("af97304b-dcb9-4dd9-90e1-12e735a95b91"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2385), new Guid("6db77d7f-6d51-4bd4-9d99-344fc7c7c94e"), "كوم أمبو", "Kom Ombo" },
                    { new Guid("b01dcd5e-3cf1-498a-bd6d-a1a35fb49c36"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2530), new Guid("d7204dc1-b79c-42dd-8b68-574a86651b68"), "نويبع", "Nuweiba" },
                    { new Guid("b04db5bd-7385-43e2-b5ed-cba146845802"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2446), new Guid("e32362b4-750b-4dc8-8a7f-1a0a2f228ff4"), "بورفؤاد", "Port Fuad" },
                    { new Guid("b05e5d94-2c0e-4e7a-a8d7-700e2d142b53"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1776), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "شيراتون", "Sheraton" },
                    { new Guid("b20ac8e4-385b-4756-a584-272e6e34067e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1748), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "مدينة بدر", "Badr City" },
                    { new Guid("b28f9b5e-e91c-42a7-876f-279315670945"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1690), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "المطرية", "Matareya" },
                    { new Guid("b390fd50-b34b-42d5-a5f4-768bda18191c"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2647), new Guid("fe37bf3d-7f1b-4bf3-83f0-de6e6121b575"), "بئر العبد", "Bir El Abd" },
                    { new Guid("b48587b2-0185-4683-9388-93fb102472f1"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2219), new Guid("1bb5a834-9bdf-4949-9d3d-edf13fab3725"), "كوم حمادة", "Kom Hamada" },
                    { new Guid("b59ee525-fd58-4299-a1ad-1ced2c66f826"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1880), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "كرداسة", "Kerdasa" },
                    { new Guid("b6d48ef9-ddf9-4736-9261-e150fb12b2e3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2629), new Guid("c2e18ac3-3435-411b-9146-af0216927d57"), "نقادة", "Naqada" },
                    { new Guid("b74f66dd-a2cd-4cdf-971d-97c61881f1b0"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2001), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "العصافرة", "Asafra" },
                    { new Guid("b7923829-ceaf-41ec-82fc-eb36dbbc3f16"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2267), new Guid("9215b237-8948-4029-a74f-63c811e5c1ce"), "زفتى", "Zefta" },
                    { new Guid("ba23daff-b7a7-4357-ad2f-f8898f88aab4"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2365), new Guid("5af068b3-1eb7-40c1-b1a2-23184af3eac8"), "القناطر الخيرية", "Qanater El Khayreya" },
                    { new Guid("ba8a9d1e-8f04-4936-9d7c-5752587f0af2"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2319), new Guid("99417f37-3ae7-40e1-8eaa-85d9829b53c6"), "الشهداء", "El Shohada" },
                    { new Guid("bae2db06-93f8-41c2-903a-961b4e3b0309"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2519), new Guid("d7204dc1-b79c-42dd-8b68-574a86651b68"), "الطور", "El Tor" },
                    { new Guid("bb6db997-ce5d-41b9-b339-8a55eea64728"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2413), new Guid("83772c42-7f34-4d08-b482-0282b33dee12"), "الغنايم", "El Ghanaim" },
                    { new Guid("bb903f77-0a9a-4474-b453-8c99fab2adee"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2431), new Guid("b913b530-d32e-465f-b18e-74bdfd3808e3"), "ناصر", "Naser" },
                    { new Guid("bb928341-83dc-4e29-855f-6680c804db24"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1712), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "بولاق", "Bolaq" },
                    { new Guid("bb9f7a54-9aeb-4754-a179-fc7db4f05db5"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2550), new Guid("6c53e322-e081-4df7-acc7-952aaa07c327"), "فوه", "Fuwa" },
                    { new Guid("bcadb211-272b-446d-8266-6ea33a17511e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2479), new Guid("8dd79782-b1f3-44d1-926d-b2e4b3f8b204"), "فارسكور", "Fareskour" },
                    { new Guid("bcba9c1f-abfd-4b6e-87c8-b3e9cc7fdad0"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2635), new Guid("c2e18ac3-3435-411b-9146-af0216927d57"), "قوص", "Qus" },
                    { new Guid("bcbd6eaf-eaa2-4337-85be-d4731d1e86ac"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2433), new Guid("b913b530-d32e-465f-b18e-74bdfd3808e3"), "إهناسيا", "Ehnasia" },
                    { new Guid("bd0689a6-ab84-4490-bc38-a6eeef7e43a7"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2475), new Guid("8dd79782-b1f3-44d1-926d-b2e4b3f8b204"), "الرحمانية", "El Rahmaniya" },
                    { new Guid("bd58b6ff-5850-4fdd-b3a4-ac953528da19"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2199), new Guid("1bb5a834-9bdf-4949-9d3d-edf13fab3725"), "رشيد", "Rashid" },
                    { new Guid("bd5d051b-f2e6-4062-8c1b-c0f82a00d9ec"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2375), new Guid("aa0c69cb-0203-4218-9133-673bf9c2d280"), "فايد", "Fayed" },
                    { new Guid("bedb6607-7f1c-45e1-a87c-22a47cd1c67d"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1716), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "جاردن سيتى", "Garden City" },
                    { new Guid("bf3d0732-2359-454d-9f14-8a35c367df9c"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2599), new Guid("c0ed12d9-3bad-40ec-a608-39a27bfe1aa8"), "الزينية", "El Ziniya" },
                    { new Guid("c0047ddc-e120-4ca7-ab63-1d1976bd4e5a"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2443), new Guid("e32362b4-750b-4dc8-8a7f-1a0a2f228ff4"), "بورسعيد", "Port Said" },
                    { new Guid("c07978aa-44db-4491-9d63-b08a88c824c2"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2425), new Guid("b913b530-d32e-465f-b18e-74bdfd3808e3"), "بني سويف الجديدة", "New Beni Suef" },
                    { new Guid("c0d25a43-8de2-4449-8fac-8d2002405d41"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1732), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "عباسية", "Abaseya" },
                    { new Guid("c0f5426b-f0d7-4b1b-a824-d51b7d336c76"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2589), new Guid("80ed16de-2582-4f03-81fe-98b89e75ec42"), "سيوة", "Siwa" },
                    { new Guid("c16ba371-4c80-469b-9796-b9f0056fa17a"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2099), new Guid("38ecf431-44e1-4a58-a05a-af8ac4c057d7"), "المنصورة", "Mansoura" },
                    { new Guid("c19c9c92-a58e-4415-9571-82677b70b422"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2483), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "الزقازيق", "Zagazig" },
                    { new Guid("c1b2c7ce-5c2d-42d2-9702-b6bab7ec83c7"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1997), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "الأنفوشي", "Anfoushi" },
                    { new Guid("c1b5dee6-a691-4bf2-8df8-d0bdfb948d85"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1728), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "طره", "Tura" },
                    { new Guid("c360ff54-1a17-424a-8170-eaa03d6c6e66"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1852), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "الجيزة", "Giza" },
                    { new Guid("c3a585a7-81c6-4359-b472-51b0c51385db"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2274), new Guid("9215b237-8948-4029-a74f-63c811e5c1ce"), "قطور", "Qutur" },
                    { new Guid("c3c7c638-220d-46be-9d6e-a24e334e5360"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2205), new Guid("1bb5a834-9bdf-4949-9d3d-edf13fab3725"), "إدكو", "Edku" },
                    { new Guid("c53255c8-2c04-4301-a758-5f927d6fc032"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2574), new Guid("80ed16de-2582-4f03-81fe-98b89e75ec42"), "الحمام", "El Hamam" },
                    { new Guid("c57730e7-4443-4d16-8512-836d863e39d5"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2485), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "الزقازيق الجديدة", "New Zagazig" },
                    { new Guid("c75399a0-301e-484e-8630-737ed5830ca3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2423), new Guid("b913b530-d32e-465f-b18e-74bdfd3808e3"), "بني سويف", "Beni Suef" },
                    { new Guid("c7bfc385-7e14-488e-a7eb-3ca221830fd3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2419), new Guid("83772c42-7f34-4d08-b482-0282b33dee12"), "البداري", "El Badari" },
                    { new Guid("c971cc9c-e901-450b-876a-a7b806feac71"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2017), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "الرمل", "El Raml" },
                    { new Guid("c9f93cca-bb42-4b16-814f-f85093276aca"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2704), new Guid("a561a81d-23ce-4ab7-9b90-50c225a49f3f"), "الداخلة", "El Dakhla" },
                    { new Guid("cc074c83-98fa-408b-8c41-66a18b0c6441"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1901), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "امبابة", "Imbaba" },
                    { new Guid("cd188f10-67e5-468c-9c8e-d3ddf6c846f0"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2625), new Guid("c2e18ac3-3435-411b-9146-af0216927d57"), "الوقف", "El Waqf" },
                    { new Guid("cdff6038-8916-4ba9-9e04-62d63347f912"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1720), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "حلوان", "Helwan" },
                    { new Guid("ce8a2172-bc03-43a0-b8b4-c250482171c2"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2013), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "كليوباترا", "Cleopatra" },
                    { new Guid("cef309c7-31cb-4716-af84-45c2409701e9"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2393), new Guid("6db77d7f-6d51-4bd4-9d99-344fc7c7c94e"), "نصر النوبة", "Nasr El Nuba" },
                    { new Guid("cf5b0297-0205-4e05-ba7b-102b4f1dd8fc"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2303), new Guid("99417f37-3ae7-40e1-8eaa-85d9829b53c6"), "منوف", "Menouf" },
                    { new Guid("cfca7da5-68ba-456f-888a-f04de379d056"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2024), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "جليم", "Gleem" },
                    { new Guid("d08a27b4-783d-467c-9833-b248ab970f29"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2325), new Guid("0dfe319d-de1a-4650-9365-0862933cbd66"), "المنيا الجديدة", "New Minya" },
                    { new Guid("d0b04045-1789-41bb-a362-e272b33f5c24"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2568), new Guid("6c53e322-e081-4df7-acc7-952aaa07c327"), "قلين", "Qallin" },
                    { new Guid("d0bdd33e-4dc9-449b-b5f4-48317397af06"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1650), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الخليفة", "El-Khalifa" },
                    { new Guid("d2c7535b-e825-46e1-bc4c-ccf450ec0834"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1859), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "الحوامدية", "Hawamdiyah" },
                    { new Guid("d43c2e4d-ba7c-4252-aab0-977d9687ebd1"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2170), new Guid("6721681d-d5b6-4484-a92d-a5fc406dc2b8"), "شلاتين", "Shalateen" },
                    { new Guid("d4502461-80b7-4df6-b974-44e7d859f5ea"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2464), new Guid("8dd79782-b1f3-44d1-926d-b2e4b3f8b204"), "دمياط الجديدة", "New Damietta" },
                    { new Guid("d4847803-0f9a-4e7d-8a78-f7f64c80478d"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2654), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "سوهاج", "Sohag" },
                    { new Guid("d7939ca2-34bd-4213-8fce-60593ee19f24"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2459), new Guid("e32362b4-750b-4dc8-8a7f-1a0a2f228ff4"), "الغربية", "El Gharbiya" },
                    { new Guid("d7a6e136-330b-435f-a952-364979b2592e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2461), new Guid("8dd79782-b1f3-44d1-926d-b2e4b3f8b204"), "دمياط", "Damietta" },
                    { new Guid("d88c75a8-d2ea-4340-87d5-398b4fe7a71a"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1666), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الساحل", "Sahel" },
                    { new Guid("d9293789-fe6e-45f7-9f82-cb33fd7e0ddd"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1730), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "عابدين", "Abdeen" },
                    { new Guid("da1502af-1838-4b91-8f54-9e756c4223a9"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2244), new Guid("02791f62-3e4f-4beb-bb9c-d36a2b5f5486"), "الفيوم", "Fayoum" },
                    { new Guid("da4a22b4-c569-4f45-8f16-17c5c0d432e8"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2253), new Guid("02791f62-3e4f-4beb-bb9c-d36a2b5f5486"), "إطسا", "Itsa" },
                    { new Guid("db67c108-503f-428b-8daf-cf3b9c710f71"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1855), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "السادس من أكتوبر", "Sixth of October" },
                    { new Guid("db7c6a49-db07-46a4-bff6-8c736265376b"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2378), new Guid("aa0c69cb-0203-4218-9133-673bf9c2d280"), "الجناين", "El Ganayen" },
                    { new Guid("dbced288-3037-4710-83a4-233f38ef9446"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2595), new Guid("c0ed12d9-3bad-40ec-a608-39a27bfe1aa8"), "الأقصر الجديدة", "New Luxor" },
                    { new Guid("dcb7e8cb-7f47-4e6d-b92a-f61ef11fbc90"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2570), new Guid("80ed16de-2582-4f03-81fe-98b89e75ec42"), "مرسى مطروح", "Marsa Matrouh" },
                    { new Guid("dcdf05ae-6abb-485c-b1b5-c8a40227dfd6"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1865), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "الصف", "Saf" },
                    { new Guid("dd216a69-e204-4eb2-99d7-26856f225cd1"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1868), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "أطفيح", "Atfih" },
                    { new Guid("dd806e9a-9a36-49a7-b104-78930af9a7e6"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1726), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "شبرا", "Shubra" },
                    { new Guid("dd8dd3cf-b705-4493-8dd4-c3540d07b601"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2313), new Guid("99417f37-3ae7-40e1-8eaa-85d9829b53c6"), "قويسنا", "Quesna" },
                    { new Guid("ddd9e3fa-8c74-4ede-ad99-1148d978e9a6"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2469), new Guid("8dd79782-b1f3-44d1-926d-b2e4b3f8b204"), "كفر سعد", "Kafr Saad" },
                    { new Guid("de187251-2e18-4a0b-908c-1111bb705544"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2515), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "هيئة قناة السويس", "Suez Canal Authority" },
                    { new Guid("de75b480-002c-4553-b310-d3f38c7b628c"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2453), new Guid("e32362b4-750b-4dc8-8a7f-1a0a2f228ff4"), "الزهور", "El Zohour" },
                    { new Guid("e00b5ae6-9ff9-44dc-ab17-6b121c90e8de"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2354), new Guid("5af068b3-1eb7-40c1-b1a2-23184af3eac8"), "شبرا الخيمة", "Shubra El Kheima" },
                    { new Guid("e19dc520-d72d-42f9-93db-324d5672fa0b"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2695), new Guid("a561a81d-23ce-4ab7-9b90-50c225a49f3f"), "الفرافرة", "El Farafra" },
                    { new Guid("e1cc20db-64cd-49ec-84ce-d1bc31f796a9"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2333), new Guid("0dfe319d-de1a-4650-9365-0862933cbd66"), "بني مزار", "Bani Mazar" },
                    { new Guid("e2d3138e-69c1-45b7-80e0-0d2b6c231a70"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2215), new Guid("1bb5a834-9bdf-4949-9d3d-edf13fab3725"), "الحمام", "El Hamam" },
                    { new Guid("e3dc85bd-a37a-4ae2-95ef-cc7e8981a716"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1993), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "برج العرب الجديدة", "New Borg El Arab" },
                    { new Guid("e3fa64aa-54ee-4e86-ba40-aff4c0cdfd75"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1912), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "المنيب", "Moneeb" },
                    { new Guid("e45ef624-2a30-4dca-96a5-3aea2fe10699"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2272), new Guid("9215b237-8948-4029-a74f-63c811e5c1ce"), "السنطة", "Santan" },
                    { new Guid("e45f0368-d5be-4bbd-809e-2fbbabbec312"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2558), new Guid("6c53e322-e081-4df7-acc7-952aaa07c327"), "الحامول", "El Hamool" },
                    { new Guid("e517db53-9b67-409b-9065-81dc336acb25"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2505), new Guid("9873a03e-a7c9-4fcf-a9a3-97875845cfe8"), "أولاد صقر", "Awlad Saqr" },
                    { new Guid("e59e85ee-d783-401b-8adc-e9f59b1c960e"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2263), new Guid("9215b237-8948-4029-a74f-63c811e5c1ce"), "المحلة الكبرى", "Mahalla El Kubra" },
                    { new Guid("e5ba3fd7-bd13-4f1d-9b1a-5faf09149b7a"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2395), new Guid("6db77d7f-6d51-4bd4-9d99-344fc7c7c94e"), "كلابشة", "Kalabsha" },
                    { new Guid("e66d512e-5655-40eb-b61d-e1ae8aaeaff6"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2339), new Guid("0dfe319d-de1a-4650-9365-0862933cbd66"), "ملوي", "Mallawi" },
                    { new Guid("e886d5b0-ecf1-4664-9c92-9a45bf1f8b66"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2261), new Guid("9215b237-8948-4029-a74f-63c811e5c1ce"), "طنطا", "Tanta" },
                    { new Guid("e912c737-9325-4bb0-bbe0-2769eb45766d"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1710), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "باب الشعرية", "Bab al-Shereia" },
                    { new Guid("ea847836-f318-476b-a6e6-dd728ff5888f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2221), new Guid("1bb5a834-9bdf-4949-9d3d-edf13fab3725"), "الدلنجات", "Delengat" },
                    { new Guid("eb4037e3-152a-4bee-8711-6030247f3ae9"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1643), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الازبكية", "Al Azbakeyah" },
                    { new Guid("edb51dda-06ec-4182-900b-5ed405c4c613"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1928), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "حدائق الأهرام", "Hadayek Alahram" },
                    { new Guid("eef723bb-6807-4519-a233-d884b77744ef"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1778), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الجمالية", "El-Gamaleya" },
                    { new Guid("efd72258-24b5-470c-a753-774269db481b"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2682), new Guid("1c6119ce-6fa5-464b-b8eb-4824d09aeef4"), "طهطا", "Tahta" },
                    { new Guid("f02d070f-c878-49da-aade-c89f5b9a53e1"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1758), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "وسط البلد", "Cairo Downtown" },
                    { new Guid("f3ce1c54-b43f-4e00-ab2d-5d9d4fb4d96f"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1656), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "الدرب الاحمر", "Aldarb Alahmar" },
                    { new Guid("f79d6d3b-a9dc-4943-a4c4-865066beeb22"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2554), new Guid("6c53e322-e081-4df7-acc7-952aaa07c327"), "مطوبس", "Metoubes" },
                    { new Guid("f7f7bcef-3e37-4d80-8afa-b607a8392822"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2544), new Guid("6c53e322-e081-4df7-acc7-952aaa07c327"), "كفر الشيخ", "Kafr El Sheikh" },
                    { new Guid("f999c580-3661-4255-b6e7-38810e347897"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1932), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "حدائق اكتوبر", "Hadayek October" },
                    { new Guid("f99fcab7-41aa-44a4-b0d5-4a02f34d9f3d"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2276), new Guid("9215b237-8948-4029-a74f-63c811e5c1ce"), "بسيون", "Basyoun" },
                    { new Guid("f9f704c7-2db9-4ced-acfa-d92d009887b9"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2040), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "الورديان", "Wardian" },
                    { new Guid("fa58a3c8-e05f-4c54-b067-db14ad8b03c3"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2690), new Guid("a561a81d-23ce-4ab7-9b90-50c225a49f3f"), "الخارجة الجديدة", "New El Kharga" },
                    { new Guid("fb0606b0-09e4-4b4f-a8a4-85bee0785630"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1668), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "السلام", "El Salam" },
                    { new Guid("fb5e7798-b325-4344-a49d-af2594b78efa"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1916), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "بين السرايات", "Bin Alsarayat" },
                    { new Guid("fbaab47f-bbd5-4dfd-8f17-93e742b84156"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2391), new Guid("6db77d7f-6d51-4bd4-9d99-344fc7c7c94e"), "إدفو", "Edfu" },
                    { new Guid("fdb97dfb-5ea0-4015-a61b-379f958b7d80"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1995), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "العامرية", "Amreya" },
                    { new Guid("fdcf42c0-ea2a-499f-9c0d-7db48a5a342c"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2526), new Guid("d7204dc1-b79c-42dd-8b68-574a86651b68"), "شرم الشيخ", "Sharm El Sheikh" },
                    { new Guid("fdd8f0d9-9060-4419-9188-d9e0b2361161"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1922), new Guid("4b5b39cd-59e1-4df1-b1b3-a9e72b081490"), "فيصل", "Faisal" },
                    { new Guid("fdf5bc0e-86d7-4609-8ff4-c951a43a7f29"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(1700), new Guid("74e9a16a-a28a-458d-abab-5bcdfddc8671"), "المنيل", "Manyal" },
                    { new Guid("fe7fe83d-6c4d-4b8b-abd3-9a39c35d97c1"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2466), new Guid("8dd79782-b1f3-44d1-926d-b2e4b3f8b204"), "الروضة", "El Rawda" },
                    { new Guid("ff0f87b3-3a9e-46d7-aa91-bd4bb8e3efd9"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2348), new Guid("0dfe319d-de1a-4650-9365-0862933cbd66"), "أبو قرقاص", "Abu Qurqas" },
                    { new Guid("ffb59f9b-ae09-4ca5-a152-4a2b6631afb6"), new DateTime(2025, 10, 7, 17, 39, 52, 218, DateTimeKind.Utc).AddTicks(2022), new Guid("b86dda5c-c4fc-4563-8303-43e838c6d6db"), "جناكليس", "Gianaclis" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Bio", "CreatedAt", "Email", "EndTime", "FirstName", "IsActive", "LastName", "LicenseNumber", "MaxPatientsPerDay", "MedicalSchool", "Phone", "ProfileImage", "Specialization", "StartTime", "UpdatedAt", "UserId", "YearsOfExperience" },
                values: new object[,]
                {
                    { new Guid("3d2f2a26-ea45-492d-b26f-b4260c58095b"), "طبيبة نساء وولادة متخصصة في الولادة الطبيعية والقيصرية", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2791), "mariam.hassan@al-eaida.com", new TimeSpan(0, 17, 0, 0, 0), "مريم", true, "حسن", "MED-2024-003", 15, "جامعة الإسكندرية", "+20 100 333 3333", null, "Obstetrics and Gynecology", new TimeSpan(0, 9, 0, 0, 0), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2791), "f757d17b-6565-47a5-8236-fa1435202704", 18 },
                    { new Guid("637a58ff-08f8-454c-ad71-1169c73b02e0"), "طبيب عظام متخصص في جراحة المفاصل والكسور المعقدة", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2796), "khaled.ahmed@al-eaida.com", new TimeSpan(0, 18, 0, 0, 0), "خالد", true, "أحمد", "MED-2024-004", 18, "جامعة القاهرة", "+20 100 444 4444", null, "Orthopedics", new TimeSpan(0, 8, 0, 0, 0), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2796), "fef8f13b-e461-411f-b288-e1a3b536f5e5", 20 },
                    { new Guid("966e0d95-ead9-482a-9b81-275da246ff59"), "طبيب قلب متخصص في جراحة القلب المفتوح والقسطرة القلبية", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2785), "ahmed.mohamed@al-eaida.com", new TimeSpan(0, 17, 0, 0, 0), "أحمد", true, "محمد", "MED-2024-001", 20, "جامعة القاهرة", "+20 100 111 1111", null, "Cardiology", new TimeSpan(0, 9, 0, 0, 0), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2785), "14b85371-c6a3-43cc-97ec-585c6e09e623", 15 },
                    { new Guid("a6f18096-1773-4ff8-9117-91498f525908"), "طبيبة عيون متخصصة في جراحة الشبكية والليزر", new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2802), "nour.mohamed@al-eaida.com", new TimeSpan(0, 16, 0, 0, 0), "نورا", true, "محمد", "MED-2024-005", 22, "جامعة الأزهر", "+20 100 555 5555", null, "Ophthalmology", new TimeSpan(0, 9, 0, 0, 0), new DateTime(2025, 10, 7, 17, 39, 52, 662, DateTimeKind.Utc).AddTicks(2802), "875631f9-20c3-4306-ab43-a12de3e258e2", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId1",
                table: "Addresses",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_GovernorateId",
                table: "Addresses",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentDate",
                table: "Appointments",
                column: "AppointmentDate");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId_AppointmentDate_Time",
                table: "Appointments",
                columns: new[] { "DoctorId", "AppointmentDate", "Time" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ReceptionistId",
                table: "Appointments",
                column: "ReceptionistId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserID",
                table: "Appointments",
                column: "UserID");

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
                name: "IX_AuditLogs_UserId",
                table: "AuditLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_GovernorateId",
                table: "Cities",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                table: "Doctors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_LicenseNumber",
                table: "Doctors",
                column: "LicenseNumber",
                unique: true,
                filter: "[LicenseNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Phone",
                table: "Doctors",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_DoctorId",
                table: "DoctorSchedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecializations_DoctorId",
                table: "DoctorSpecializations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecializations_SpecializationId",
                table: "DoctorSpecializations",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CreatedAt",
                table: "Invoices",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CreatedBy",
                table: "Invoices",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceNumber",
                table: "Invoices",
                column: "InvoiceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PatientId",
                table: "Invoices",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_DoctorId",
                table: "MedicalRecords",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalVisits_DoctorID",
                table: "MedicalVisits",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalVisits_PatientId",
                table: "MedicalVisits",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalVisits_UserID",
                table: "MedicalVisits",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalVisits_VisitDate",
                table: "MedicalVisits",
                column: "VisitDate");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationCategory_CategoryId",
                table: "MedicationCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationCategory_MedicationId",
                table: "MedicationCategory",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AppointmentId",
                table: "Notifications",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DoctorId",
                table: "Notifications",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PatientId",
                table: "Notifications",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email",
                table: "Patients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_EmergencyContactId",
                table: "Patients",
                column: "EmergencyContactId",
                unique: true,
                filter: "[EmergencyContactId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_InsuranceInfoId",
                table: "Patients",
                column: "InsuranceInfoId",
                unique: true,
                filter: "[InsuranceInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Phone",
                table: "Patients",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionItems_MedicineId",
                table: "PrescriptionItems",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionItems_PrescriptionId",
                table: "PrescriptionItems",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicalVisitId",
                table: "Prescriptions",
                column: "MedicalVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicationId",
                table: "Prescriptions",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_UserId",
                table: "Receptionists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_GeneratedByUserId",
                table: "Reports",
                column: "GeneratedByUserId");
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
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "ClinicSettings");

            migrationBuilder.DropTable(
                name: "DoctorSchedules");

            migrationBuilder.DropTable(
                name: "DoctorSpecializations");

            migrationBuilder.DropTable(
                name: "FinancialReports");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "MedicationCategory");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PrescriptionItems");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Receptionists");

            migrationBuilder.DropTable(
                name: "MedicalVisits");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "EmergencyContacts");

            migrationBuilder.DropTable(
                name: "InsuranceInfos");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Governorates");
        }
    }
}
