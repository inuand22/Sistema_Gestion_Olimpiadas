using DTO;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    public class DisciplinaController : Controller
    {
        public IAltaDisciplina CUAltaDisciplina { get; set; }
        public IListadoDisciplina CUListadoDisciplina { get; set; }
        public ILoginUsuario CULoginUsuario { get; set; }

        public DisciplinaController(IAltaDisciplina cUAltaDisciplina, IListadoDisciplina cUListadoDisciplina,
            ILoginUsuario cULoginUsuario)
        {
            CUAltaDisciplina = cUAltaDisciplina;
            CUListadoDisciplina = cUListadoDisciplina;
            CULoginUsuario = cULoginUsuario;
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

        public bool EsDigitador()
        {
            string admin = HttpContext.Session.GetString("rolUsuarioLogueado");
            if (admin == "Digitador")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // GET: DisciplinaController
        public ActionResult Index()
        {
            if (EstaLogueado() && EsDigitador())
            {
                return View(CUListadoDisciplina.GetDisciplinas());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: DisciplinaController/Create
        public ActionResult Create()
        {
            if (EstaLogueado() && EsDigitador())
            {
                AltaDisciplinaDTO dto = new AltaDisciplinaDTO();
                return View(dto);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: DisciplinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaDisciplinaDTO dto)
        {
            try
            {
                CUAltaDisciplina.AltaDisci(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (ExcepcionesDisciplina ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        //// GET: DisciplinaController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: DisciplinaController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DisciplinaController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DisciplinaController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: DisciplinaController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
