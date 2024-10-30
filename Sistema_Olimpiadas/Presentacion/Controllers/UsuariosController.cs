using DTO;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Mvc;
using Presentacion.Models;

namespace Presentacion.Controllers
{
    public class UsuariosController : Controller
    {
        public IAltaUsuario CUAltaUsuario { get; set; }
        public IListadoUsuarios CUListadoUsuarios { get; set; }
        public IListadoRoles CUListadoRoles { get; set; }
        public IBajaUsuario CUBajaUsuario { get; set; }
        public IUpdateUsuario CUUpdateUsuario { get; set; }
        public ILoginUsuario CULoginUsuario { get; set; }
        public IBuscarUsuarioPorID CUBuscarUsuarioPorID { get; set; }

        public UsuariosController(IAltaUsuario cuAltaUsuarios, IListadoUsuarios cuListadoUsuarios, IListadoRoles cuListadoRoles,
            IBajaUsuario cuBajaUsuario, IUpdateUsuario cUUpdateUsuario, ILoginUsuario cULoginUsuario, IBuscarUsuarioPorID cuBuscarUsuarioPorID)
        {
            CUAltaUsuario = cuAltaUsuarios;
            CUListadoUsuarios = cuListadoUsuarios;
            CUListadoRoles = cuListadoRoles;
            CUBajaUsuario = cuBajaUsuario;
            CUUpdateUsuario = cUUpdateUsuario;
            CULoginUsuario = cULoginUsuario;
            CUBuscarUsuarioPorID = cuBuscarUsuarioPorID;
        }

        public bool EstaLogueado()
        {
            string email = HttpContext.Session.GetString("emailUsuarioLogueado");
            try
            {
                Usuario userLogueado = CULoginUsuario.FindByMail(email);
                if (userLogueado == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (ExcepcionesUsuario ex)
            {
                ViewBag.Error = ex.Message;
                return false;
            }
        }

        public bool EsAdmin()
        {
            string admin = HttpContext.Session.GetString("rolUsuarioLogueado");
            if (admin == "Administrador")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // GET: UsuariosController
        public ActionResult ListaUsuarios()
        {
            if (EstaLogueado() && EsAdmin())
            {
                string emailUsuarioLogueado = HttpContext.Session.GetString("emailUsuarioLogueado");
                Usuario userLogueado = CULoginUsuario.FindByMail(emailUsuarioLogueado);
                ViewBag.Usuario = userLogueado;
                IEnumerable<ListadoUsuariosDTO> dtos = CUListadoUsuarios.ObtenerListado();
                return View(dtos);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            if (EstaLogueado() && EsAdmin())
            {
                AltaUsuarioDTO user = CUBuscarUsuarioPorID.BuscarUsuarioId(id);
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            if (EstaLogueado() && EsAdmin())
            {
                try
                {
                    AltaUsuarioViewModel vm = new AltaUsuarioViewModel();
                    vm.DTOAltaUsuario = new AltaUsuarioDTO();
                    vm.RolesDTO = CUListadoRoles.ObtenerListado();
                    return View(vm);
                }
                catch (ExcepcionesUsuario ex)
                {
                    ViewBag.Error = ex.Message;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaUsuarioViewModel vm)
        {
            try
            {
                string? emailUsuarioLogueado = HttpContext.Session.GetString("emailUsuarioLogueado");
                DateTime fecha = DateTime.Now.Date;
                string fechaFormateada = fecha.ToString("dd/MM/yyyy");
                string horaFormateada = DateTime.Now.ToString("HH:mm");
                vm.DTOAltaUsuario.EmailAdmin = emailUsuarioLogueado;
                vm.DTOAltaUsuario.Date = fechaFormateada;
                vm.DTOAltaUsuario.Hora = horaFormateada;
                CUAltaUsuario.Alta(vm.DTOAltaUsuario);
                return RedirectToAction(nameof(ListaUsuarios));
            }
            catch (ExcepcionesUsuario ex)
            {
                ViewBag.Error = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Error = "No es posible realizar el alta al Usuario";
            }
            vm.RolesDTO = CUListadoRoles.ObtenerListado();
            return View(vm);
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            if (EstaLogueado() && EsAdmin())
            {
                AltaUsuarioDTO user = CUBuscarUsuarioPorID.BuscarUsuarioId(id);
                AltaUsuarioViewModel vm = new AltaUsuarioViewModel
                {
                    DTOAltaUsuario = user,
                    RolesDTO = CUListadoRoles.ObtenerListado()
                };
                return View(vm);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AltaUsuarioViewModel vm)
        {
            //AltaUsuarioViewModel vmPost = new AltaUsuarioViewModel
            //{
            //    DTOAltaUsuario = vm.DTOAltaUsuario,
            //    RolesDTO = CUListadoRoles.ObtenerListado()
            //};
            try
            {
                string? emailUsuarioLogueado = HttpContext.Session.GetString("emailUsuarioLogueado");
                DateTime fecha = DateTime.Now.Date;
                string fechaFormateada = fecha.ToString("dd/MM/yyyy");
                string horaFormateada = DateTime.Now.ToString("HH:mm");
                vm.DTOAltaUsuario.EmailAdmin = "Admin-Actualizador " + emailUsuarioLogueado;
                vm.DTOAltaUsuario.Date = "Fecha-Actualización " + fechaFormateada;
                vm.DTOAltaUsuario.Hora = "Hora-Actualización " + horaFormateada;
                CUUpdateUsuario.UpdateUser(vm.DTOAltaUsuario);
                return RedirectToAction(nameof(ListaUsuarios));
            }
            catch (ExcepcionesUsuario ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(vm);
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(string email)
        {
            return View((object)email);
        }

        // POST: UsuariosController/DeleteConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string email)
        {
            try
            {
                CUBajaUsuario.BajaUser(email);
                return RedirectToAction("ListaUsuarios", "Usuarios");
            }
            catch (ExcepcionesUsuario ex)
            {
                ViewBag.Error = ex.Message;
                return View("Delete", "Usuarios");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error al intentar eliminar al usuario: " + ex.Message;
                return View("Delete", "Usuarios");
            }
        }
    }
}




