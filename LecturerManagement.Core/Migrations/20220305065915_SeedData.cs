using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LecturerManagement.Core.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Permission",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CreatedDate", "Description", "DiscountPercent", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { "CV01", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5591), "Giảm 25 phần trăm số giờ chuẩn.", 25, null, "Trưởng Khoa", 1 },
                    { "CV02", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5616), "Giảm 20 phần trăm số giờ chuẩn.", 20, null, "Phó Khoa", 1 },
                    { "CV03", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5618), "Giảm 20 phần trăm số giờ chuẩn.", 20, null, "Trưởng Bộ Môn", 1 },
                    { "CV04", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5620), "Dành cho những giảng viên chỉ phụ trách công việc giảng dạy...", 0, null, "Không Có Chức Vụ", 1 }
                });

            migrationBuilder.InsertData(
                table: "StandardTimes",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate", "Name", "StandardHours", "Status" },
                values: new object[,]
                {
                    { "CD01", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5865), "Số giờ chuẩn cho 1 kỳ học", null, "Giáo sư và giảng viên cao cấp", 360, 1 },
                    { "CD02", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5867), "Số giờ chuẩn cho 1 kỳ học", null, "Phó giáo sư và giảng viên chính", 320, 1 },
                    { "CD03", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5869), "Số giờ chuẩn cho 1 kỳ học", null, "Giảng viên", 280, 1 },
                    { "CD04", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5871), "Số giờ chuẩn cho 1 kỳ học", null, "Giảng viên tập sự", 140, 1 }
                });

            migrationBuilder.InsertData(
                table: "SubjectDepartments",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { "BM01", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5831), "Bộ Môn Hệ Thống Thông Tin", null, "Hệ Thống Thông Tin", 1 },
                    { "BM02", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5835), "Bộ Môn Công Nghệ Thông Tin", null, "Công Nghệ Thông Tin", 1 },
                    { "BM03", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5837), "Truyền Thông Mạng Máy Tính", null, "Truyền Thông Mạng Máy Tính", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubjectTypes",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { "LM01", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5906), "Môn học lý thuyết", null, "Lý Thuyết", 1 },
                    { "LM02", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5910), "Môn học thực hành", null, "Thực Hành", 1 },
                    { "LM03", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5913), "Thực tập cơ sở và thực tập tốt nghiệp", null, "Các Đồ án, TTCS,TTCN, TTTN, Project", 1 },
                    { "LM04", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5916), "Thực tập doanh nghiệp", null, "Thực tập doanh nghiệp", 1 },
                    { "LM05", new DateTime(2022, 3, 5, 13, 59, 14, 877, DateTimeKind.Local).AddTicks(5919), "Thực tập sư phạm", null, "Thực tập sư phạm", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: "CV01");

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: "CV02");

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: "CV03");

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: "CV04");

            migrationBuilder.DeleteData(
                table: "StandardTimes",
                keyColumn: "Id",
                keyValue: "CD01");

            migrationBuilder.DeleteData(
                table: "StandardTimes",
                keyColumn: "Id",
                keyValue: "CD02");

            migrationBuilder.DeleteData(
                table: "StandardTimes",
                keyColumn: "Id",
                keyValue: "CD03");

            migrationBuilder.DeleteData(
                table: "StandardTimes",
                keyColumn: "Id",
                keyValue: "CD04");

            migrationBuilder.DeleteData(
                table: "SubjectDepartments",
                keyColumn: "Id",
                keyValue: "BM01");

            migrationBuilder.DeleteData(
                table: "SubjectDepartments",
                keyColumn: "Id",
                keyValue: "BM02");

            migrationBuilder.DeleteData(
                table: "SubjectDepartments",
                keyColumn: "Id",
                keyValue: "BM03");

            migrationBuilder.DeleteData(
                table: "SubjectTypes",
                keyColumn: "Id",
                keyValue: "LM01");

            migrationBuilder.DeleteData(
                table: "SubjectTypes",
                keyColumn: "Id",
                keyValue: "LM02");

            migrationBuilder.DeleteData(
                table: "SubjectTypes",
                keyColumn: "Id",
                keyValue: "LM03");

            migrationBuilder.DeleteData(
                table: "SubjectTypes",
                keyColumn: "Id",
                keyValue: "LM04");

            migrationBuilder.DeleteData(
                table: "SubjectTypes",
                keyColumn: "Id",
                keyValue: "LM05");

            migrationBuilder.AlterColumn<int>(
                name: "Permission",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);
        }
    }
}
