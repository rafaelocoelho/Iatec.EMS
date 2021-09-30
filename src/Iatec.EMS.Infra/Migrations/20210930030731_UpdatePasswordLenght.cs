using Microsoft.EntityFrameworkCore.Migrations;

namespace Iatec.EMS.Infra.Migrations
{
    public partial class UpdatePasswordLenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ems_eveprt_ems_event_EventId1",
                table: "ems_eveprt");

            migrationBuilder.DropForeignKey(
                name: "FK_ems_eveprt_ems_user_UserId1",
                table: "ems_eveprt");

            migrationBuilder.DropIndex(
                name: "IX_ems_eveprt_EventId1",
                table: "ems_eveprt");

            migrationBuilder.DropIndex(
                name: "IX_ems_eveprt_UserId1",
                table: "ems_eveprt");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "ems_eveprt");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ems_eveprt");

            migrationBuilder.AlterColumn<string>(
                name: "usr_passwd",
                table: "ems_user",
                type: "VARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "usr_passwd",
                table: "ems_user",
                type: "VARCHAR(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)");

            migrationBuilder.AddColumn<long>(
                name: "EventId1",
                table: "ems_eveprt",
                type: "BIGINT",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "ems_eveprt",
                type: "BIGINT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ems_eveprt_EventId1",
                table: "ems_eveprt",
                column: "EventId1");

            migrationBuilder.CreateIndex(
                name: "IX_ems_eveprt_UserId1",
                table: "ems_eveprt",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ems_eveprt_ems_event_EventId1",
                table: "ems_eveprt",
                column: "EventId1",
                principalTable: "ems_event",
                principalColumn: "evt_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ems_eveprt_ems_user_UserId1",
                table: "ems_eveprt",
                column: "UserId1",
                principalTable: "ems_user",
                principalColumn: "usr_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
