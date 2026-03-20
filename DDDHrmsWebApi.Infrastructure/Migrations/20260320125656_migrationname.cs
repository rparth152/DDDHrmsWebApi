using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDHrmsWebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migrationname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddAdminDocName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddAdminDocName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddDepartments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddDepartments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "AddEmployeeDocName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddEmployeeDocName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddEventType",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddEventType", x => x.EventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AddRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddRole", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "AddTrainingType",
                columns: table => new
                {
                    TrainingTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddTrainingType", x => x.TrainingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AdminDocuments",
                columns: table => new
                {
                    AdminDocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocFile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminDocuments", x => x.AdminDocId);
                });

            migrationBuilder.CreateTable(
                name: "DeductionType",
                columns: table => new
                {
                    DeductionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeductionsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeductionType", x => x.DeductionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EarningType",
                columns: table => new
                {
                    EarntypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EarningName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarningType", x => x.EarntypeId);
                });

            migrationBuilder.CreateTable(
                name: "MasterLeaveType",
                columns: table => new
                {
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterLeaveType", x => x.LeaveTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjectValue = table.Column<double>(type: "float", nullable: false),
                    PriceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "AddDesignation",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddDesignation", x => x.DesignationId);
                    table.ForeignKey(
                        name: "FK_AddDesignation_AddDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AddDepartments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddNewEvent",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EventTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddNewEvent", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_AddNewEvent_AddEventType_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "AddEventType",
                        principalColumn: "EventTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddTrainer",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNUmber = table.Column<int>(type: "int", nullable: false),
                    UploadImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddTrainer", x => x.TrainerId);
                    table.ForeignKey(
                        name: "FK_AddTrainer_AddRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AddRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLeaves",
                columns: table => new
                {
                    DepartmentLeavesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    LeavesCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLeaves", x => x.DepartmentLeavesId);
                    table.ForeignKey(
                        name: "FK_DepartmentLeaves_AddDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AddDepartments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentLeaves_MasterLeaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "MasterLeaveType",
                        principalColumn: "LeaveTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deduction",
                columns: table => new
                {
                    DeductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeductionTypeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    DeductionPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deduction", x => x.DeductionId);
                    table.ForeignKey(
                        name: "FK_Deduction_AddDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AddDepartments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deduction_AddDesignation_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "AddDesignation",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deduction_DeductionType_DeductionTypeId",
                        column: x => x.DeductionTypeId,
                        principalTable: "DeductionType",
                        principalColumn: "DeductionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Earning",
                columns: table => new
                {
                    EarningsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EarntypeId = table.Column<int>(type: "int", nullable: false),
                    EarningsPercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EarningTypeEarntypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Earning", x => x.EarningsId);
                    table.ForeignKey(
                        name: "FK_Earning_AddDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AddDepartments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Earning_AddDesignation_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "AddDesignation",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Earning_EarningType_EarningTypeEarntypeId",
                        column: x => x.EarningTypeEarntypeId,
                        principalTable: "EarningType",
                        principalColumn: "EarntypeId");
                    table.ForeignKey(
                        name: "FK_Earning_EarningType_EarntypeId",
                        column: x => x.EarntypeId,
                        principalTable: "EarningType",
                        principalColumn: "EarntypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddRoleRoleId = table.Column<int>(type: "int", nullable: true),
                    ProjectsProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_AddDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AddDepartments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_AddDesignation_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "AddDesignation",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_AddRole_AddRoleRoleId",
                        column: x => x.AddRoleRoleId,
                        principalTable: "AddRole",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_Employee_AddRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AddRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateTable(
                name: "TaskBoards",
                columns: table => new
                {
                    TaskBoardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TasksTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskBoards", x => x.TaskBoardId);
                    table.ForeignKey(
                        name: "FK_TaskBoards_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskBoards_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskBoards_Tasks_TasksTaskId",
                        column: x => x.TasksTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId");
                });

            migrationBuilder.CreateTable(
                name: "AddTrainingLists",
                columns: table => new
                {
                    TraniningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    TrainingTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TrainingCost = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddTrainingLists", x => x.TraniningId);
                    table.ForeignKey(
                        name: "FK_AddTrainingLists_AddTrainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "AddTrainer",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddTrainingLists_AddTrainingType_TrainingTypeId",
                        column: x => x.TrainingTypeId,
                        principalTable: "AddTrainingType",
                        principalColumn: "TrainingTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddTrainingLists_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LunchIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LunchOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductionHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OvertimeHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BreakHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Late = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendances_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpBankDetailss",
                columns: table => new
                {
                    EmpBankDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IFSCCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpBankDetailss", x => x.EmpBankDetailsId);
                    table.ForeignKey(
                        name: "FK_EmpBankDetailss_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpEducationInfo",
                columns: table => new
                {
                    EducationInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpEducationInfo", x => x.EducationInfoId);
                    table.ForeignKey(
                        name: "FK_EmpEducationInfo_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpExperience",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpExperience", x => x.ExperienceId);
                    table.ForeignKey(
                        name: "FK_EmpExperience_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpFamilyInfo",
                columns: table => new
                {
                    FInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationShip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpFamilyInfo", x => x.FInfoId);
                    table.ForeignKey(
                        name: "FK_EmpFamilyInfo_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalaries",
                columns: table => new
                {
                    SalaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TotalSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalaries", x => x.SalaryId);
                    table.ForeignKey(
                        name: "FK_EmployeeSalaries_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveBalance",
                columns: table => new
                {
                    LeaveBalanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentLeavesId = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    TotalLeaves = table.Column<int>(type: "int", nullable: false),
                    UsedLeaves = table.Column<int>(type: "int", nullable: false),
                    MasterLeaveTypeLeaveTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveBalance", x => x.LeaveBalanceId);
                    table.ForeignKey(
                        name: "FK_LeaveBalance_DepartmentLeaves_DepartmentLeavesId",
                        column: x => x.DepartmentLeavesId,
                        principalTable: "DepartmentLeaves",
                        principalColumn: "DepartmentLeavesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveBalance_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveBalance_MasterLeaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "MasterLeaveType",
                        principalColumn: "LeaveTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveBalance_MasterLeaveType_MasterLeaveTypeLeaveTypeId",
                        column: x => x.MasterLeaveTypeLeaveTypeId,
                        principalTable: "MasterLeaveType",
                        principalColumn: "LeaveTypeId");
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequest",
                columns: table => new
                {
                    LeaveRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusHistory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequest", x => x.LeaveRequestId);
                    table.ForeignKey(
                        name: "FK_LeaveRequest_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRequest_MasterLeaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "MasterLeaveType",
                        principalColumn: "LeaveTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payslips",
                columns: table => new
                {
                    PayslipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PayslipPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneratedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payslips", x => x.PayslipId);
                    table.ForeignKey(
                        name: "FK_Payslips_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    PromotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    DesignationFrom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DesignationTo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PromotionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PromotionReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.PromotionId);
                    table.ForeignKey(
                        name: "FK_Promotion_AddDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AddDepartments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Promotion_AddDesignation_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "AddDesignation",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Promotion_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resignation",
                columns: table => new
                {
                    ResignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    NoticeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResignReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ResignStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resignation", x => x.ResignationId);
                    table.ForeignKey(
                        name: "FK_Resignation_AddDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AddDepartments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resignation_AddDesignation_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "AddDesignation",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resignation_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskMembers",
                columns: table => new
                {
                    AssignedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMembers", x => x.AssignedId);
                    table.ForeignKey(
                        name: "FK_TaskMembers_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskMembers_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    TicketPriority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketAssignTo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_AddDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "AddDepartments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Timesheet",
                columns: table => new
                {
                    TimesheetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkHours = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheet", x => x.TimesheetId);
                    table.ForeignKey(
                        name: "FK_Timesheet_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timesheet_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDeductions",
                columns: table => new
                {
                    EmployeeDeductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DeductionId = table.Column<int>(type: "int", nullable: false),
                    DeductionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDeductions", x => x.EmployeeDeductionId);
                    table.ForeignKey(
                        name: "FK_EmployeeDeductions_Deduction_DeductionId",
                        column: x => x.DeductionId,
                        principalTable: "Deduction",
                        principalColumn: "DeductionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDeductions_EmployeeSalaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "EmployeeSalaries",
                        principalColumn: "SalaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEarnings",
                columns: table => new
                {
                    EmployeeEarningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EarningId = table.Column<int>(type: "int", nullable: false),
                    EarningAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEarnings", x => x.EmployeeEarningId);
                    table.ForeignKey(
                        name: "FK_EmployeeEarnings_Earning_EarningId",
                        column: x => x.EarningId,
                        principalTable: "Earning",
                        principalColumn: "EarningsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEarnings_EmployeeSalaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "EmployeeSalaries",
                        principalColumn: "SalaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Termination",
                columns: table => new
                {
                    TerminationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ResignationId = table.Column<int>(type: "int", nullable: false),
                    TerminationType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TerminationReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TerminatNoticeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termination", x => x.TerminationId);
                    table.ForeignKey(
                        name: "FK_Termination_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Termination_Resignation_ResignationId",
                        column: x => x.ResignationId,
                        principalTable: "Resignation",
                        principalColumn: "ResignationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddDesignation_DepartmentId",
                table: "AddDesignation",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AddNewEvent_EventTypeId",
                table: "AddNewEvent",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AddTrainer_RoleId",
                table: "AddTrainer",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AddTrainingLists_EmployeeId",
                table: "AddTrainingLists",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AddTrainingLists_TrainerId",
                table: "AddTrainingLists",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_AddTrainingLists_TrainingTypeId",
                table: "AddTrainingLists",
                column: "TrainingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeId",
                table: "Attendances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Deduction_DeductionTypeId",
                table: "Deduction",
                column: "DeductionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Deduction_DepartmentId",
                table: "Deduction",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Deduction_DesignationId",
                table: "Deduction",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLeaves_DepartmentId",
                table: "DepartmentLeaves",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLeaves_LeaveTypeId",
                table: "DepartmentLeaves",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Earning_DepartmentId",
                table: "Earning",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Earning_DesignationId",
                table: "Earning",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Earning_EarningTypeEarntypeId",
                table: "Earning",
                column: "EarningTypeEarntypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Earning_EarntypeId",
                table: "Earning",
                column: "EarntypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpBankDetailss_EmployeeId",
                table: "EmpBankDetailss",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEducationInfo_EmployeeId",
                table: "EmpEducationInfo",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpExperience_EmployeeId",
                table: "EmpExperience",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyInfo_EmployeeId",
                table: "EmpFamilyInfo",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AddRoleRoleId",
                table: "Employee",
                column: "AddRoleRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DesignationId",
                table: "Employee",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ProjectsProjectId",
                table: "Employee",
                column: "ProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleId",
                table: "Employee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDeductions_DeductionId",
                table: "EmployeeDeductions",
                column: "DeductionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDeductions_SalaryId",
                table: "EmployeeDeductions",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEarnings_EarningId",
                table: "EmployeeEarnings",
                column: "EarningId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEarnings_SalaryId",
                table: "EmployeeEarnings",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalaries_EmployeeId",
                table: "EmployeeSalaries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalance_DepartmentLeavesId",
                table: "LeaveBalance",
                column: "DepartmentLeavesId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalance_EmployeeId",
                table: "LeaveBalance",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalance_LeaveTypeId",
                table: "LeaveBalance",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalance_MasterLeaveTypeLeaveTypeId",
                table: "LeaveBalance",
                column: "MasterLeaveTypeLeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_EmployeeId",
                table: "LeaveRequest",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_LeaveTypeId",
                table: "LeaveRequest",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_EmployeeId",
                table: "Payslips",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_DepartmentId",
                table: "Promotion",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_DesignationId",
                table: "Promotion",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_EmployeeId",
                table: "Promotion",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resignation_DepartmentId",
                table: "Resignation",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Resignation_DesignationId",
                table: "Resignation",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Resignation_EmployeeId",
                table: "Resignation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskBoards_ProjectId",
                table: "TaskBoards",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskBoards_TaskId",
                table: "TaskBoards",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskBoards_TasksTaskId",
                table: "TaskBoards",
                column: "TasksTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMembers_EmployeeId",
                table: "TaskMembers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMembers_TaskId",
                table: "TaskMembers",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Termination_EmployeeId",
                table: "Termination",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Termination_ResignationId",
                table: "Termination",
                column: "ResignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DepartmentId",
                table: "Tickets",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EmployeeId",
                table: "Tickets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheet_EmployeeId",
                table: "Timesheet",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheet_ProjectId",
                table: "Timesheet",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddAdminDocName");

            migrationBuilder.DropTable(
                name: "AddEmployeeDocName");

            migrationBuilder.DropTable(
                name: "AddNewEvent");

            migrationBuilder.DropTable(
                name: "AddTrainingLists");

            migrationBuilder.DropTable(
                name: "AdminDocuments");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "EmpBankDetailss");

            migrationBuilder.DropTable(
                name: "EmpEducationInfo");

            migrationBuilder.DropTable(
                name: "EmpExperience");

            migrationBuilder.DropTable(
                name: "EmpFamilyInfo");

            migrationBuilder.DropTable(
                name: "EmployeeDeductions");

            migrationBuilder.DropTable(
                name: "EmployeeEarnings");

            migrationBuilder.DropTable(
                name: "LeaveBalance");

            migrationBuilder.DropTable(
                name: "LeaveRequest");

            migrationBuilder.DropTable(
                name: "Payslips");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "TaskBoards");

            migrationBuilder.DropTable(
                name: "TaskMembers");

            migrationBuilder.DropTable(
                name: "Termination");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Timesheet");

            migrationBuilder.DropTable(
                name: "AddEventType");

            migrationBuilder.DropTable(
                name: "AddTrainer");

            migrationBuilder.DropTable(
                name: "AddTrainingType");

            migrationBuilder.DropTable(
                name: "Deduction");

            migrationBuilder.DropTable(
                name: "Earning");

            migrationBuilder.DropTable(
                name: "EmployeeSalaries");

            migrationBuilder.DropTable(
                name: "DepartmentLeaves");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Resignation");

            migrationBuilder.DropTable(
                name: "DeductionType");

            migrationBuilder.DropTable(
                name: "EarningType");

            migrationBuilder.DropTable(
                name: "MasterLeaveType");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "AddDesignation");

            migrationBuilder.DropTable(
                name: "AddRole");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AddDepartments");
        }
    }
}
