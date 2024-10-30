using DTO;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {
        public ILoginUsuario CULoginUsuario { get; }

        public HomeController(ILoginUsuario cuLoginUsuario)
        {
            CULoginUsuario = cuLoginUsuario;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUsuarioDTO loginUserDTO)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(loginUserDTO.EmailUsuario) || string.IsNullOrWhiteSpace(loginUserDTO.ContraseniaUsuario))
                {
                    ViewBag.Error = "Email y contraseña son requeridos.";
                    return View();
                }
                Usuario usuarioLogueado = CULoginUsuario.FindByMail(loginUserDTO.EmailUsuario);
                if (usuarioLogueado == null || usuarioLogueado.Contrasenia.Valor != loginUserDTO.ContraseniaUsuario)
                {
                    ViewBag.Error = "Email o contraseña incorrectos.";
                    return View();
                }
                HttpContext.Session.SetString("rolUsuarioLogueado", usuarioLogueado.Rol.Nombre);
                HttpContext.Session.SetString("emailUsuarioLogueado", usuarioLogueado.Email.Valor);
                HttpContext.Session.SetInt32("idUsuarioLogueado", usuarioLogueado.Id);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error inesperado. Intente de nuevo.";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
