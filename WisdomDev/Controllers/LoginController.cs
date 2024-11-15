using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WisdomDev.Models;
using Microsoft.EntityFrameworkCore;
namespace WisdomDev.Controllers
{
    public class LoginController : Controller
    {

        private readonly WisdomDevDbContext _dbContext;

        public LoginController(WisdomDevDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> InicioSesion(string email, string password)
        {
            // Busca el usuario en la base de datos
            var user = await _dbContext.CuentaEstudiantes.FirstOrDefaultAsync(u => u.Correo == email);

            if (user == null || user.Contraseña != password)
            {
                // Si el usuario no existe o la contraseña es incorrecta
                ViewBag.ErrorMessage = "Credenciales incorrectas.";
                return View("Login");
            }

            // Si las credenciales son correctas, redirige a una página principal
            return RedirectToAction("Dashboard", "Dashboard");
        }

    }
}

