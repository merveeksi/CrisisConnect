using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_Centers_Name",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "CurrentStatus",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "AlertStatus",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "AlertType",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Datelssued",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "EstimatedArrival",
                table: "Logistics",
                newName: "ExpectedDeliveryDate");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Logistics",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Donors",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Centers",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Centers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CurrentStaff",
                table: "Centers",
                newName: "Volunteers");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Centers",
                newName: "TotalStaff");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Alerts",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Alerts",
                newName: "Status");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "Volunteers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "Volunteers",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "text[]");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Volunteers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Volunteers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Volunteers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Volunteers",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Volunteers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Volunteers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Volunteers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "IdentityNumber",
                table: "Volunteers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Volunteers",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualifications",
                table: "Volunteers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShelterId",
                table: "Volunteers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Volunteers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "VolunteerId",
                table: "Teams",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "VolunteerId",
                table: "Shelters",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "RequestId",
                table: "Shelters",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Resources",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Resources",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Resources",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Resources",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                table: "Resources",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Resources",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Resources",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Resources",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Resources",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasTransferRestriction",
                table: "Resources",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Resources",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Resources",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPerishable",
                table: "Resources",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "Resources",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MinimumQuantity",
                table: "Resources",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumStockLevel",
                table: "Resources",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresColdChain",
                table: "Resources",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Resources",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Resources",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Resources",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                table: "Requests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Logistics",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualDeliveryDate",
                table: "Logistics",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AssignedVehicleId",
                table: "Logistics",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Logistics",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Logistics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Logistics",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DestinationLocation",
                table: "Logistics",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Logistics",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Logistics",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsiblePersonId",
                table: "Logistics",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceLocation",
                table: "Logistics",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Logistics",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Logistics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "CenterId",
                table: "Disasters",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Centers",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalImageUrls",
                table: "Centers",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Centers",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AvailableBeds",
                table: "Centers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AvailableServices",
                table: "Centers",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Centers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CloseTime",
                table: "Centers",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Centers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Centers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<int>(
                name: "CurrentOccupancy",
                table: "Centers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Centers",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DisasterId",
                table: "Centers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Centers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyPhone",
                table: "Centers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Is24Hours",
                table: "Centers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Centers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTemporaryClosed",
                table: "Centers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Centers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Centers",
                type: "double precision",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Centers",
                type: "double precision",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MainImageUrl",
                table: "Centers",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MedicalStaff",
                table: "Centers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OpenTime",
                table: "Centers",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Centers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Centers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SupportStaff",
                table: "Centers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCapacity",
                table: "Centers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                table: "Centers",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Severity",
                table: "Alerts",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Alerts",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Alerts",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "Alerts",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssuedAt",
                table: "Alerts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<Guid>(
                name: "IssuedBy",
                table: "Alerts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Alerts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "Location_Address",
                table: "Alerts",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location_City",
                table: "Alerts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location_Country",
                table: "Alerts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Location_Latitude",
                table: "Alerts",
                type: "double precision",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Location_Longitude",
                table: "Alerts",
                type: "double precision",
                precision: 9,
                scale: 6,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Location_Region",
                table: "Alerts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResolvedAt",
                table: "Alerts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_FirstName_LastName",
                table: "Volunteers",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_IsAvailable",
                table: "Volunteers",
                column: "IsAvailable");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_Location",
                table: "Volunteers",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_ShelterId",
                table: "Volunteers",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_TeamId",
                table: "Volunteers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ExpiryDate",
                table: "Resources",
                column: "ExpiryDate");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_IsAvailable",
                table: "Resources",
                column: "IsAvailable");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Location",
                table: "Resources",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Name",
                table: "Resources",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Type",
                table: "Resources",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Logistics_DestinationLocation",
                table: "Logistics",
                column: "DestinationLocation");

            migrationBuilder.CreateIndex(
                name: "IX_Logistics_ExpectedDeliveryDate",
                table: "Logistics",
                column: "ExpectedDeliveryDate");

            migrationBuilder.CreateIndex(
                name: "IX_Logistics_Priority",
                table: "Logistics",
                column: "Priority");

            migrationBuilder.CreateIndex(
                name: "IX_Logistics_SourceLocation",
                table: "Logistics",
                column: "SourceLocation");

            migrationBuilder.CreateIndex(
                name: "IX_Logistics_Status",
                table: "Logistics",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Logistics_Type",
                table: "Logistics",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Centers_City",
                table: "Centers",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Centers_Latitude_Longitude",
                table: "Centers",
                columns: new[] { "Latitude", "Longitude" });

            migrationBuilder.CreateIndex(
                name: "IX_Centers_Name",
                table: "Centers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Centers_Status",
                table: "Centers",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_IssuedAt",
                table: "Alerts",
                column: "IssuedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_Name",
                table: "Alerts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_Severity",
                table: "Alerts",
                column: "Severity");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_Status",
                table: "Alerts",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_Type",
                table: "Alerts",
                column: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Volunteers_FirstName_LastName",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_IsAvailable",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_Location",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_ShelterId",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_TeamId",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Resources_ExpiryDate",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_IsAvailable",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_Location",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_Name",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_Type",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Logistics_DestinationLocation",
                table: "Logistics");

            migrationBuilder.DropIndex(
                name: "IX_Logistics_ExpectedDeliveryDate",
                table: "Logistics");

            migrationBuilder.DropIndex(
                name: "IX_Logistics_Priority",
                table: "Logistics");

            migrationBuilder.DropIndex(
                name: "IX_Logistics_SourceLocation",
                table: "Logistics");

            migrationBuilder.DropIndex(
                name: "IX_Logistics_Status",
                table: "Logistics");

            migrationBuilder.DropIndex(
                name: "IX_Logistics_Type",
                table: "Logistics");

            migrationBuilder.DropIndex(
                name: "IX_Centers_City",
                table: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Centers_Latitude_Longitude",
                table: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Centers_Name",
                table: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Centers_Status",
                table: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_IssuedAt",
                table: "Alerts");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_Name",
                table: "Alerts");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_Severity",
                table: "Alerts");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_Status",
                table: "Alerts");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_Type",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "Qualifications",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "ShelterId",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Shelters");

            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "HasTransferRestriction",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "IsPerishable",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "MinimumQuantity",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "MinimumStockLevel",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "RequiresColdChain",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ActualDeliveryDate",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "AssignedVehicleId",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "DestinationLocation",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "ResponsiblePersonId",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "SourceLocation",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Logistics");

            migrationBuilder.DropColumn(
                name: "AdditionalImageUrls",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "AvailableBeds",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "AvailableServices",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "CloseTime",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "CurrentOccupancy",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "DisasterId",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "EmergencyPhone",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Is24Hours",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "IsTemporaryClosed",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "MainImageUrl",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "MedicalStaff",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "OpenTime",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "SupportStaff",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "TotalCapacity",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "WebsiteUrl",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "IssuedAt",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "IssuedBy",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Location_Address",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Location_City",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Location_Country",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Location_Latitude",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Location_Longitude",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Location_Region",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "ResolvedAt",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Logistics",
                newName: "Destination");

            migrationBuilder.RenameColumn(
                name: "ExpectedDeliveryDate",
                table: "Logistics",
                newName: "EstimatedArrival");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Donors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Volunteers",
                table: "Centers",
                newName: "CurrentStaff");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Centers",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "TotalStaff",
                table: "Centers",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Centers",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Alerts",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Alerts",
                newName: "Location");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "Volunteers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<List<string>>(
                name: "Skills",
                table: "Volunteers",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Volunteers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Volunteers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Volunteers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Volunteers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Volunteers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Volunteers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "Volunteers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "VolunteerId",
                table: "Teams",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "VolunteerId",
                table: "Shelters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Resources",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Resources",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Resources",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Resources",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShelterId",
                table: "Requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Logistics",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStatus",
                table: "Logistics",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ResourceId",
                table: "Logistics",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Donors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Donors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "CenterId",
                table: "Disasters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Centers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "Severity",
                table: "Alerts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Alerts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "AlertStatus",
                table: "Alerts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AlertType",
                table: "Alerts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Datelssued",
                table: "Alerts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "UK_Centers_Name",
                table: "Centers",
                column: "Name",
                unique: true);
        }
    }
}
