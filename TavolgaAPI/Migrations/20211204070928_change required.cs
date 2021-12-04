using Microsoft.EntityFrameworkCore.Migrations;

namespace TavolgaAPI.Migrations
{
    public partial class changerequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nominations_Events_EventId",
                table: "Nominations");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuatorBase_Events_EventId",
                table: "ValuatorBase");

            migrationBuilder.DropIndex(
                name: "IX_ValuatorBase_EventId",
                table: "ValuatorBase");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "ValuatorBase");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Nominations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EventValuatorBase",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    ValuatorsEditedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventValuatorBase", x => new { x.EventsId, x.ValuatorsEditedId });
                    table.ForeignKey(
                        name: "FK_EventValuatorBase_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventValuatorBase_ValuatorBase_ValuatorsEditedId",
                        column: x => x.ValuatorsEditedId,
                        principalTable: "ValuatorBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EventValuatorBase_ValuatorsEditedId",
                table: "EventValuatorBase",
                column: "ValuatorsEditedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nominations_Events_EventId",
                table: "Nominations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nominations_Events_EventId",
                table: "Nominations");

            migrationBuilder.DropTable(
                name: "EventValuatorBase");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "ValuatorBase",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Nominations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ValuatorBase_EventId",
                table: "ValuatorBase",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nominations_Events_EventId",
                table: "Nominations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ValuatorBase_Events_EventId",
                table: "ValuatorBase",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
