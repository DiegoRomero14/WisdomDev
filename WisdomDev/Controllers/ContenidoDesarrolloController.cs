using Microsoft.AspNetCore.Mvc;
using WisdomDev.Models;

namespace WisdomDev.Controllers
{
    public class ContenidoDesarrolloController : Controller
    {
        private readonly WisdomDevDbContext _dbContext;

        public ContenidoDesarrolloController(WisdomDevDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult ContenidoDesarrollo()
        {
            return View();
        }
    }
}
