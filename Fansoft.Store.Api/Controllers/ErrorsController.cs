using Microsoft.AspNetCore.Mvc;

namespace Fansoft.Store.Api.Controllers
{
    public class ErrorsController: Controller
    {
        
        [HttpGet("error404")]
        public IActionResult ENotFound()
        {
            return Json(new {error = "endereco invalido"});
        }

    }
}