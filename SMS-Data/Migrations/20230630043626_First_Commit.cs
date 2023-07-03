using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS_Data.Migrations
{
    /// <inheritdoc />
    public partial class First_Commit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "salaries",
                columns: table => new
                {
                    salary_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    total_amount = table.Column<double>(type: "float", nullable: true),
                    tax_amount = table.Column<double>(type: "float", nullable: true),
                    pf_amount = table.Column<double>(type: "float", nullable: true),
                    amount_paid = table.Column<double>(type: "float", nullable: true),
                    payment_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salaries", x => x.salary_id);
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                columns: table => new
                {
                    staff_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salary_id = table.Column<long>(type: "bigint", nullable: true),
                    staff_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    age = table.Column<int>(type: "int", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    religion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    subject_speciality = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    qualification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    employee_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    state = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    pincode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    profile_photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    joined_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_login_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_password_change = table.Column<DateTime>(type: "datetime", nullable: true),
                    release_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    has_medical_condition = table.Column<bool>(type: "bit", nullable: true),
                    previous_experience = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffs", x => x.staff_id);
                    table.ForeignKey(
                        name: "FK_staffs_salaries",
                        column: x => x.salary_id,
                        principalTable: "salaries",
                        principalColumn: "salary_id");
                });

            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    class_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    total_section = table.Column<int>(type: "int", nullable: true),
                    class_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    staff_id = table.Column<long>(type: "bigint", nullable: true),
                    total_space_left = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.class_id);
                    table.ForeignKey(
                        name: "FK_classes_staffs",
                        column: x => x.staff_id,
                        principalTable: "staffs",
                        principalColumn: "staff_id");
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    student_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    guardian_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    relation_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    class_id = table.Column<long>(type: "bigint", nullable: true),
                    age = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    religion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    state = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    pincode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    profile_photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    admission_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_attendence_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    number_of_attendences = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    has_medical_condition = table.Column<bool>(type: "bit", nullable: true),
                    attend_school_before = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_students_classes",
                        column: x => x.class_id,
                        principalTable: "classes",
                        principalColumn: "class_id");
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    subject_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    class_id = table.Column<long>(type: "bigint", nullable: true),
                    total_marks = table.Column<int>(type: "int", nullable: true),
                    subject_code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    subject_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.subject_id);
                    table.ForeignKey(
                        name: "FK_subjects_classes",
                        column: x => x.class_id,
                        principalTable: "classes",
                        principalColumn: "class_id");
                });

            migrationBuilder.CreateTable(
                name: "marks",
                columns: table => new
                {
                    mark_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<long>(type: "bigint", nullable: true),
                    class_id = table.Column<long>(type: "bigint", nullable: true),
                    subject_id = table.Column<long>(type: "bigint", nullable: true),
                    check_id = table.Column<long>(type: "bigint", nullable: true),
                    obtain_marks = table.Column<double>(type: "float", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marks", x => x.mark_id);
                    table.ForeignKey(
                        name: "FK_marks_classes",
                        column: x => x.class_id,
                        principalTable: "classes",
                        principalColumn: "class_id");
                    table.ForeignKey(
                        name: "FK_marks_staffs",
                        column: x => x.check_id,
                        principalTable: "staffs",
                        principalColumn: "staff_id");
                    table.ForeignKey(
                        name: "FK_marks_students",
                        column: x => x.student_id,
                        principalTable: "students",
                        principalColumn: "student_id");
                    table.ForeignKey(
                        name: "FK_marks_subjects",
                        column: x => x.subject_id,
                        principalTable: "subjects",
                        principalColumn: "subject_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_classes_staff_id",
                table: "classes",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_marks_check_id",
                table: "marks",
                column: "check_id");

            migrationBuilder.CreateIndex(
                name: "IX_marks_class_id",
                table: "marks",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_marks_student_id",
                table: "marks",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_marks_subject_id",
                table: "marks",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_staffs_salary_id",
                table: "staffs",
                column: "salary_id");

            migrationBuilder.CreateIndex(
                name: "IX_students_class_id",
                table: "students",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_class_id",
                table: "subjects",
                column: "class_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "marks");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "staffs");

            migrationBuilder.DropTable(
                name: "salaries");
        }
    }
}
