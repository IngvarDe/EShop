using EShop.Common.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Admin.Controllers
{
    public class BaseController : Controller
    {
        public JsonResult ValidationError()
        {
            Response.StatusCode = ApplicationHttpStatusCodes.ValidationError;
            return Json(ModelState.Errors());
        }

        public static class ApplicationHttpStatusCodes
        {
            public const int ValidationError = 299;
        }
    }
}