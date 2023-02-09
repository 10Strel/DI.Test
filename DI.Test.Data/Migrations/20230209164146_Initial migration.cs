using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DI.Test.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameTitle = table.Column<string>(name: "Name_Title", type: "nvarchar(max)", nullable: true),
                    NameFirst = table.Column<string>(name: "Name_First", type: "nvarchar(max)", nullable: false),
                    NameLast = table.Column<string>(name: "Name_Last", type: "nvarchar(max)", nullable: false),
                    LocationStreetNumber = table.Column<string>(name: "Location_Street_Number", type: "nvarchar(max)", nullable: true),
                    LocationStreetName = table.Column<string>(name: "Location_Street_Name", type: "nvarchar(max)", nullable: false),
                    LocationCity = table.Column<string>(name: "Location_City", type: "nvarchar(max)", nullable: false),
                    LocationState = table.Column<string>(name: "Location_State", type: "nvarchar(max)", nullable: false),
                    LocationCountry = table.Column<string>(name: "Location_Country", type: "nvarchar(max)", nullable: false),
                    LocationPostcode = table.Column<string>(name: "Location_Postcode", type: "nvarchar(max)", nullable: false),
                    LocationCoordinatesLatitude = table.Column<string>(name: "Location_Coordinates_Latitude", type: "nvarchar(max)", nullable: false),
                    LocationCoordinatesLongitude = table.Column<string>(name: "Location_Coordinates_Longitude", type: "nvarchar(max)", nullable: false),
                    LocationTimezoneOffset = table.Column<string>(name: "Location_Timezone_Offset", type: "nvarchar(max)", nullable: false),
                    LocationTimezoneDescription = table.Column<string>(name: "Location_Timezone_Description", type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginUuid = table.Column<string>(name: "Login_Uuid", type: "nvarchar(max)", nullable: false),
                    LoginUsername = table.Column<string>(name: "Login_Username", type: "nvarchar(max)", nullable: false),
                    LoginPassword = table.Column<string>(name: "Login_Password", type: "nvarchar(max)", nullable: false),
                    LoginSalt = table.Column<string>(name: "Login_Salt", type: "nvarchar(max)", nullable: false),
                    LoginMd5 = table.Column<string>(name: "Login_Md5", type: "nvarchar(max)", nullable: true),
                    LoginSha1 = table.Column<string>(name: "Login_Sha1", type: "nvarchar(max)", nullable: true),
                    LoginSha256 = table.Column<string>(name: "Login_Sha256", type: "nvarchar(max)", nullable: true),
                    DobDate = table.Column<DateTime>(name: "Dob_Date", type: "datetime2", nullable: false),
                    DobAge = table.Column<int>(name: "Dob_Age", type: "int", nullable: false),
                    RegisteredDate = table.Column<DateTime>(name: "Registered_Date", type: "datetime2", nullable: false),
                    RegisteredAge = table.Column<int>(name: "Registered_Age", type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserIdName = table.Column<string>(name: "UserId_Name", type: "nvarchar(max)", nullable: false),
                    UserIdValue = table.Column<string>(name: "UserId_Value", type: "nvarchar(max)", nullable: false),
                    PictureLargeUrl = table.Column<string>(name: "Picture_Large_Url", type: "nvarchar(max)", nullable: false),
                    PictureLargeImage = table.Column<byte[]>(name: "Picture_Large_Image", type: "varbinary(max)", nullable: true),
                    PictureMediumUrl = table.Column<string>(name: "Picture_Medium_Url", type: "nvarchar(max)", nullable: false),
                    PictureMediumImage = table.Column<byte[]>(name: "Picture_Medium_Image", type: "varbinary(max)", nullable: true),
                    PictureThumbnailUrl = table.Column<string>(name: "Picture_Thumbnail_Url", type: "nvarchar(max)", nullable: false),
                    PictureThumbnailImage = table.Column<byte[]>(name: "Picture_Thumbnail_Image", type: "varbinary(max)", nullable: true),
                    Nat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
