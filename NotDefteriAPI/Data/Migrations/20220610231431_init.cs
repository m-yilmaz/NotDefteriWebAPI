using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotDefteriAPI.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notlar", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notlar",
                columns: new[] { "Id", "Baslik", "GuncellemeTarihi", "Icerik", "OlusturulmaTarihi" },
                values: new object[] { 1, "Alışveriş Listesi", null, "Şampuan, 1.5 Litre Su, Ekmek, 1 Kilo kiraz", new DateTime(2022, 6, 11, 2, 14, 31, 182, DateTimeKind.Local).AddTicks(5392) });

            migrationBuilder.InsertData(
                table: "Notlar",
                columns: new[] { "Id", "Baslik", "GuncellemeTarihi", "Icerik", "OlusturulmaTarihi" },
                values: new object[] { 2, "İş Notlarım", null, "ASP.NET CORE WEB API ile Not Defteri uygulaması yapılacak", new DateTime(2022, 6, 11, 2, 14, 31, 183, DateTimeKind.Local).AddTicks(3992) });

            migrationBuilder.InsertData(
                table: "Notlar",
                columns: new[] { "Id", "Baslik", "GuncellemeTarihi", "Icerik", "OlusturulmaTarihi" },
                values: new object[] { 3, "Güzel Sözler", null, "\"Dünden ders çıkar, bugünü yaşa, yarın için umut et\" Albert Einstein", new DateTime(2022, 6, 11, 2, 14, 31, 183, DateTimeKind.Local).AddTicks(4009) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notlar");
        }
    }
}
