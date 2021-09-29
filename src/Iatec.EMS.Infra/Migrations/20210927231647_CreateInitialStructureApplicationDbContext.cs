using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace Iatec.EMS.Infra.Migrations
{
    public partial class CreateInitialStructureApplicationDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ems_event",
                columns: table => new
                {
                    evt_id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    evt_name = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    evt_descri = table.Column<string>(type: "VARCHAR(240)", nullable: false),
                    evt_date = table.Column<DateTime>(type: "DATE", nullable: false),
                    evt_local = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    evt_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_evt_id", x => x.evt_id);
                });

            migrationBuilder.CreateTable(
                name: "ems_user",
                columns: table => new
                {
                    usr_id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usr_name = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    usr_email = table.Column<string>(type: "VARCHAR(180)", nullable: false),
                    usr_passwd = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    usr_birthd = table.Column<DateTime>(type: "DATE", nullable: false),
                    usr_gender = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usr_id", x => x.usr_id);
                });

            migrationBuilder.CreateTable(
                name: "ems_eveprt",
                columns: table => new
                {
                    ept_id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ept_evt_id = table.Column<long>(type: "BIGINT", nullable: false),
                    evt_usr_id = table.Column<long>(type: "BIGINT", nullable: false),
                    EventId1 = table.Column<long>(type: "BIGINT", nullable: true),
                    UserId1 = table.Column<long>(type: "BIGINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ept_id", x => x.ept_id);
                    table.ForeignKey(
                        name: "FK_ems_eveprt_ems_event_EventId1",
                        column: x => x.EventId1,
                        principalTable: "ems_event",
                        principalColumn: "evt_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ems_eveprt_ems_user_UserId1",
                        column: x => x.UserId1,
                        principalTable: "ems_user",
                        principalColumn: "usr_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ept_evt",
                        column: x => x.ept_evt_id,
                        principalTable: "ems_event",
                        principalColumn: "evt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ept_usr",
                        column: x => x.evt_usr_id,
                        principalTable: "ems_user",
                        principalColumn: "usr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ems_eveprt_ept_evt_id",
                table: "ems_eveprt",
                column: "ept_evt_id");

            migrationBuilder.CreateIndex(
                name: "IX_ems_eveprt_EventId1",
                table: "ems_eveprt",
                column: "EventId1");

            migrationBuilder.CreateIndex(
                name: "IX_ems_eveprt_evt_usr_id",
                table: "ems_eveprt",
                column: "evt_usr_id");

            migrationBuilder.CreateIndex(
                name: "IX_ems_eveprt_UserId1",
                table: "ems_eveprt",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ems_eveprt");

            migrationBuilder.DropTable(
                name: "ems_event");

            migrationBuilder.DropTable(
                name: "ems_user");
        }
    }
}
