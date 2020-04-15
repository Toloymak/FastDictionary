using Microsoft.AspNetCore.Mvc;

namespace UnitTestCore.Extensions
{
    public static class ActionResultExtension
    {
        public static OkObjectResult GetOkObjectResult(this IActionResult actionResult) 
            => actionResult as OkObjectResult;
    }
}