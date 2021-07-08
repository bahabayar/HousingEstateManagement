using System.ComponentModel;

namespace HousingEstateManagement.Web.Enums
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Resident = "Resident";

    }

    public enum RoleTypes : byte
    {
        [Description(Roles.Admin)]
        Admin = 1,
        [Description(Roles.Resident)]
        Resident = 2
    }
}