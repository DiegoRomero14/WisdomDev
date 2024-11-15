using Microsoft.AspNetCore.Mvc;
using WisdomDev.Models;

namespace WisdomDev.Controllers
{
    public class ContenidoDiseñoController : Controller
    {
        private readonly WisdomDevDbContext _dbContext;

        public ContenidoDiseñoController(WisdomDevDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult ContenidoDiseño()
        {
            return View();
        }
    }
}
