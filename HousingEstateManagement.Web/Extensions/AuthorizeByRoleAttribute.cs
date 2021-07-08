using Microsoft.AspNetCore.Authorization;

namespace HousingEstateManagement.Web.Extensions
{
    public class AuthorizeByRoleAttribute:AuthorizeAttribute
    {
        public AuthorizeByRoleAttribute(params string[] roles)
        {
            Roles = string.Join(",",roles);
        }
    }
}