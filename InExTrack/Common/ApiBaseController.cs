using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InExTrack.Common
{
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        private Guid? UserId
        {
            get
            {
                if (User.Identity?.IsAuthenticated == true)
                {
                    var claim = User.FindFirst(ClaimTypes.NameIdentifier);
                    if (claim != null && Guid.TryParse(claim.Value, out Guid id))
                    {
                        return id;
                    }
                }
                return null;
            }
        }

        protected Guid getUserId()
        {
            if (UserId == null)
            {
                throw new Exception("User ID claim not found or invalid.");
            }
            return UserId.Value;
        }

        //public int? UserId
        //{
        //    get
        //    {
        //        if (HttpContext.User.Identity?.IsAuthenticated == true)
        //        {
        //            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        //            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
        //            {
        //                return userId;
        //            }
        //        }
        //        return null;
        //    }
        //}

    }
}
