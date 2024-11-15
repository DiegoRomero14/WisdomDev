using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WisdomDev.Models;

namespace WisdomDev.Controllers
{
    public class ContenidoAnalisisController : Controller
    {
        private readonly WisdomDevDbContext _dbContext;

        public ContenidoAnalisisController(WisdomDevDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult ContenidoAnalisis()
        {
            return View();
        }
    }
}
