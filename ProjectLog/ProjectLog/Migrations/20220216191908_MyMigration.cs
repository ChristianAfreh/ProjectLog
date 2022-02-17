using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectLog.Migrations
{
    public partial class MyMigration : Migration
    {
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

            ////migrationBuilder.CreateTable(
            ////    name: "Department",
            ////    columns: table => new
            ////    {
            ////        DepartmentID = table.Column<int>(type: "int", nullable: false)
            ////            .Annotation("SqlServer:Identity", "1, 1"),
            ////        DepartmentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
            ////    },
            ////    constraints: table =>
            ////    {
            ////        table.PrimaryKey("PK4", x => x.DepartmentID)
            ////            .Annotation("SqlServer:Clustered", false);
            ////    });

            ////migrationBuilder.CreateTable(
            ////    name: "SDG",
            ////    columns: table => new
            ////    {
            ////        GoalID = table.Column<int>(type: "int", nullable: false)
            ////            .Annotation("SqlServer:Identity", "1, 1"),
            ////        Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            ////        Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
            ////    },
            ////    constraints: table =>
            ////    {
            ////        table.PrimaryKey("PK1", x => x.GoalID)
            ////            .Annotation("SqlServer:Clustered", false);
            ////    });

            ////migrationBuilder.CreateTable(
            ////    name: "Status",
            ////    columns: table => new
            ////    {
            ////        StatusID = table.Column<int>(type: "int", nullable: false)
            ////            .Annotation("SqlServer:Identity", "1, 1"),
            ////        Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
            ////    },
            ////    constraints: table =>
            ////    {
            ////        table.PrimaryKey("PK9", x => x.StatusID)
            ////            .Annotation("SqlServer:Clustered", false);
            ////    });

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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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

            //migrationBuilder.CreateTable(
            //    name: "Staff",
            //    columns: table => new
            //    {
            //        StaffID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        OtherNames = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        DepartmentID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK7", x => x.StaffID)
            //            .Annotation("SqlServer:Clustered", false);
            //        table.ForeignKey(
            //            name: "RefDepartment3",
            //            column: x => x.DepartmentID,
            //            principalTable: "Department",
            //            principalColumn: "DepartmentID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Project",
            //    columns: table => new
            //    {
            //        ProjectID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        ProjectManager = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
            //        UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: true),
            //        ProjectStartDate = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        PhotoName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        StatusID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK2", x => x.ProjectID)
            //            .Annotation("SqlServer:Clustered", false);
            //        table.ForeignKey(
            //            name: "RefStatus7",
            //            column: x => x.StatusID,
            //            principalTable: "Status",
            //            principalColumn: "StatusID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SDGProject",
            //    columns: table => new
            //    {
            //        SDGProjectID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        GoalID = table.Column<int>(type: "int", nullable: false),
            //        ProjectID = table.Column<int>(type: "int", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK3", x => x.SDGProjectID)
            //            .Annotation("SqlServer:Clustered", false);
            //        table.ForeignKey(
            //            name: "RefProject2",
            //            column: x => x.ProjectID,
            //            principalTable: "Project",
            //            principalColumn: "ProjectID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "RefSDG1",
            //            column: x => x.GoalID,
            //            principalTable: "SDG",
            //            principalColumn: "GoalID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StaffProject",
            //    columns: table => new
            //    {
            //        StaffProjectID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProjectID = table.Column<int>(type: "int", nullable: false),
            //        StaffID = table.Column<int>(type: "int", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK8", x => x.StaffProjectID)
            //            .Annotation("SqlServer:Clustered", false);
            //        table.ForeignKey(
            //            name: "RefProject4",
            //            column: x => x.ProjectID,
            //            principalTable: "Project",
            //            principalColumn: "ProjectID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "RefStaff5",
            //            column: x => x.StaffID,
            //            principalTable: "Staff",
            //            principalColumn: "StaffID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

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
                name: "IX_Project_StatusID",
                table: "Project",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_SDGProject_GoalID",
                table: "SDGProject",
                column: "GoalID");

            migrationBuilder.CreateIndex(
                name: "IX_SDGProject_ProjectID",
                table: "SDGProject",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_DepartmentID",
                table: "Staff",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffProject_ProjectID",
                table: "StaffProject",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffProject_StaffID",
                table: "StaffProject",
                column: "StaffID");
        }

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
                name: "SDGProject");

            migrationBuilder.DropTable(
                name: "StaffProject");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SDG");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
