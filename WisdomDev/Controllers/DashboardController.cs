using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WisdomDev.Models;
using Microsoft.EntityFrameworkCore;
namespace WisdomDev.Controllers
{
    public class DashboardController : Controller
    {
        private readonly WisdomDevDbContext _dbContext;

        public DashboardController(WisdomDevDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
