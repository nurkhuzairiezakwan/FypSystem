﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADStarter.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccTypes",
                columns: table => new
                {
                    atype_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    atype_desc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccTypes", x => x.atype_ID);
                });

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
                name: "Parents",
                columns: table => new
                {
                    parent_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f_ID = table.Column<int>(type: "int", nullable: false),
                    m_ID = table.Column<int>(type: "int", nullable: false),
                    f_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    f_phoneNum = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    f_race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    f_address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    f_Waddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    f_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    f_occupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    f_status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    m_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    m_phoneNum = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    m_race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    m_address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    m_Waddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    m_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    m_status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fm_income = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.parent_ID);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    prog_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prog_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    prog_desc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    prog_summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prog_price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.prog_ID);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    slot_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    slot_time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.slot_ID);
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
                name: "Accounts",
                columns: table => new
                {
                    acc_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    acc_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    acc_pass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    acc_status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    astype_ID = table.Column<int>(type: "int", nullable: true),
                    parent_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.acc_ID);
                    table.ForeignKey(
                        name: "FK_Accounts_AccTypes_astype_ID",
                        column: x => x.astype_ID,
                        principalTable: "AccTypes",
                        principalColumn: "atype_ID");
                    table.ForeignKey(
                        name: "FK_Accounts_Parents_parent_ID",
                        column: x => x.parent_ID,
                        principalTable: "Parents",
                        principalColumn: "parent_ID");
                });

            migrationBuilder.CreateTable(
                name: "SessionPrices",
                columns: table => new
                {
                    session_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    session_bilangan = table.Column<int>(type: "int", nullable: false),
                    session_day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    session_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    sp_price = table.Column<double>(type: "float", nullable: false),
                    prog_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionPrices", x => x.session_ID);
                    table.ForeignKey(
                        name: "FK_SessionPrices_Programs_prog_ID",
                        column: x => x.prog_ID,
                        principalTable: "Programs",
                        principalColumn: "prog_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    a_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    a_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    acc_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.a_ID);
                    table.ForeignKey(
                        name: "FK_Admins_Accounts_acc_ID",
                        column: x => x.acc_ID,
                        principalTable: "Accounts",
                        principalColumn: "acc_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerServices",
                columns: table => new
                {
                    cs_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cs_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    acc_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerServices", x => x.cs_ID);
                    table.ForeignKey(
                        name: "FK_CustomerServices_Accounts_acc_ID",
                        column: x => x.acc_ID,
                        principalTable: "Accounts",
                        principalColumn: "acc_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Therapists",
                columns: table => new
                {
                    t_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    t_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    t_phoneNum = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    t_address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    acc_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapists", x => x.t_ID);
                    table.ForeignKey(
                        name: "FK_Therapists_Accounts_acc_ID",
                        column: x => x.acc_ID,
                        principalTable: "Accounts",
                        principalColumn: "acc_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    ann_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    a_ID = table.Column<int>(type: "int", nullable: false),
                    ann_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ann_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ann_media = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.ann_ID);
                    table.ForeignKey(
                        name: "FK_Announcements_Admins_a_ID",
                        column: x => x.a_ID,
                        principalTable: "Admins",
                        principalColumn: "a_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    c_myKid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prog_ID = table.Column<int>(type: "int", nullable: true),
                    t_ID = table.Column<int>(type: "int", nullable: true),
                    parent_ID = table.Column<int>(type: "int", nullable: false),
                    c_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    c_age = table.Column<int>(type: "int", nullable: false),
                    c_gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    c_dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    c_nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    c_religion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    c_race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    c_status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    c_photo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.c_myKid);
                    table.ForeignKey(
                        name: "FK_Children_Parents_parent_ID",
                        column: x => x.parent_ID,
                        principalTable: "Parents",
                        principalColumn: "parent_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Children_Programs_prog_ID",
                        column: x => x.prog_ID,
                        principalTable: "Programs",
                        principalColumn: "prog_ID");
                    table.ForeignKey(
                        name: "FK_Children_Therapists_t_ID",
                        column: x => x.t_ID,
                        principalTable: "Therapists",
                        principalColumn: "t_ID");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    rep_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rep_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    rep_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    c_myKid = table.Column<int>(type: "int", nullable: false),
                    t_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.rep_ID);
                    table.ForeignKey(
                        name: "FK_Reports_Children_c_myKid",
                        column: x => x.c_myKid,
                        principalTable: "Children",
                        principalColumn: "c_myKid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Therapists_t_ID",
                        column: x => x.t_ID,
                        principalTable: "Therapists",
                        principalColumn: "t_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    schedule_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    session_ID = table.Column<int>(type: "int", nullable: false),
                    t_ID = table.Column<int>(type: "int", nullable: false),
                    session_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    prog_ID = table.Column<int>(type: "int", nullable: false),
                    slot_ID = table.Column<int>(type: "int", nullable: false),
                    c_myKid = table.Column<int>(type: "int", nullable: false),
                    slot_price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.schedule_ID);
                    table.ForeignKey(
                        name: "FK_Schedules_Children_c_myKid",
                        column: x => x.c_myKid,
                        principalTable: "Children",
                        principalColumn: "c_myKid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Programs_prog_ID",
                        column: x => x.prog_ID,
                        principalTable: "Programs",
                        principalColumn: "prog_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_SessionPrices_session_ID",
                        column: x => x.session_ID,
                        principalTable: "SessionPrices",
                        principalColumn: "session_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Slots_slot_ID",
                        column: x => x.slot_ID,
                        principalTable: "Slots",
                        principalColumn: "slot_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Therapists_t_ID",
                        column: x => x.t_ID,
                        principalTable: "Therapists",
                        principalColumn: "t_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentHistories",
                columns: table => new
                {
                    c_myKid = table.Column<int>(type: "int", nullable: false),
                    th_pediatrician = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    th_recommendation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    th_deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    th_diagnosis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    th_prevTherapy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentHistories", x => x.c_myKid);
                    table.ForeignKey(
                        name: "FK_TreatmentHistories_Children_c_myKid",
                        column: x => x.c_myKid,
                        principalTable: "Children",
                        principalColumn: "c_myKid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    invoice_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_myKid = table.Column<int>(type: "int", nullable: false),
                    schedule_ID = table.Column<int>(type: "int", nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    invoice_amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.invoice_ID);
                    table.ForeignKey(
                        name: "FK_Invoices_Children_c_myKid",
                        column: x => x.c_myKid,
                        principalTable: "Children",
                        principalColumn: "c_myKid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Schedules_schedule_ID",
                        column: x => x.schedule_ID,
                        principalTable: "Schedules",
                        principalColumn: "schedule_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    pay_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parent_ID = table.Column<int>(type: "int", nullable: false),
                    pay_amount = table.Column<double>(type: "float", nullable: false),
                    pay_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pay_desc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pay_balance = table.Column<double>(type: "float", nullable: false),
                    receipt_id = table.Column<int>(type: "int", nullable: false),
                    c_myKid = table.Column<int>(type: "int", nullable: false),
                    a_ID = table.Column<int>(type: "int", nullable: false),
                    invoice_ID = table.Column<int>(type: "int", nullable: false),
                    Accountacc_ID = table.Column<int>(type: "int", nullable: true),
                    Therapistt_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.pay_ID);
                    table.ForeignKey(
                        name: "FK_Payments_Accounts_Accountacc_ID",
                        column: x => x.Accountacc_ID,
                        principalTable: "Accounts",
                        principalColumn: "acc_ID");
                    table.ForeignKey(
                        name: "FK_Payments_Admins_a_ID",
                        column: x => x.a_ID,
                        principalTable: "Admins",
                        principalColumn: "a_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Children_c_myKid",
                        column: x => x.c_myKid,
                        principalTable: "Children",
                        principalColumn: "c_myKid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Invoices_invoice_ID",
                        column: x => x.invoice_ID,
                        principalTable: "Invoices",
                        principalColumn: "invoice_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Parents_parent_ID",
                        column: x => x.parent_ID,
                        principalTable: "Parents",
                        principalColumn: "parent_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Therapists_Therapistt_ID",
                        column: x => x.Therapistt_ID,
                        principalTable: "Therapists",
                        principalColumn: "t_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_astype_ID",
                table: "Accounts",
                column: "astype_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_parent_ID",
                table: "Accounts",
                column: "parent_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_acc_ID",
                table: "Admins",
                column: "acc_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_a_ID",
                table: "Announcements",
                column: "a_ID");

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
                name: "IX_Children_parent_ID",
                table: "Children",
                column: "parent_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Children_prog_ID",
                table: "Children",
                column: "prog_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Children_t_ID",
                table: "Children",
                column: "t_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServices_acc_ID",
                table: "CustomerServices",
                column: "acc_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_c_myKid",
                table: "Invoices",
                column: "c_myKid");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_schedule_ID",
                table: "Invoices",
                column: "schedule_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_a_ID",
                table: "Payments",
                column: "a_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Accountacc_ID",
                table: "Payments",
                column: "Accountacc_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_c_myKid",
                table: "Payments",
                column: "c_myKid");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_invoice_ID",
                table: "Payments",
                column: "invoice_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_parent_ID",
                table: "Payments",
                column: "parent_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Therapistt_ID",
                table: "Payments",
                column: "Therapistt_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_c_myKid",
                table: "Reports",
                column: "c_myKid");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_t_ID",
                table: "Reports",
                column: "t_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_c_myKid",
                table: "Schedules",
                column: "c_myKid");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_prog_ID",
                table: "Schedules",
                column: "prog_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_session_ID",
                table: "Schedules",
                column: "session_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_slot_ID",
                table: "Schedules",
                column: "slot_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_t_ID",
                table: "Schedules",
                column: "t_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SessionPrices_prog_ID",
                table: "SessionPrices",
                column: "prog_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Therapists_acc_ID",
                table: "Therapists",
                column: "acc_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

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
                name: "CustomerServices");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "TreatmentHistories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "SessionPrices");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Therapists");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccTypes");

            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}
