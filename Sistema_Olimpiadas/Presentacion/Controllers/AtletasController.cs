using DTO;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Mvc;
using Presentacion.Models;

namespace Presentacion.Controllers
{
    public class AtletaController : Controller
    {
        public IAltaAtleta CUAltaAtleta { get; set; }
        public IListadoAtletas CUListadoAtleta { get; set; }
        public ILoginUsuario CULoginUsuario { get; set; }
        public IListadoDisciplina CUlistadoDisciplina { get; set; }


        public AtletaController(IAltaAtleta cUAltaAtleta, IListadoAtletas cUListadoAtleta,
            ILoginUsuario cULoginUsuario, IListadoDisciplina cuListadoDisciplina)
        {
            CUAltaAtleta = cUAltaAtleta;
            CUListadoAtleta = cUListadoAtleta;
            CULoginUsuario = cULoginUsuario;
            CUlistadoDisciplina = cuListadoDisciplina;
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

        // GET: AtletaController
        public ActionResult Index()
        {
            if (EstaLogueado() && EsDigitador())
            {
                IEnumerable<ListadoAtletasDTO> atletasOrdenados = CUListadoAtleta.GetAtletas();
                return View(atletasOrdenados);
            }
            else
            {
                return RedirectToAction("Index", "Atleta");
            }
        }

        // GET: AtletaController/Edit/5
        public ActionResult Edit(int id)
        {
            if (EstaLogueado() && EsDigitador())
            {
                try
                {
                    ListadoAtletasDTO dto = CUListadoAtleta.GetAtletaPorId(id);
                    AtletaDisciplinasViewModel vm = new AtletaDisciplinasViewModel();
                    vm.DTOAtleta = CUListadoAtleta.GetAtletaPorId(dto.IdAtleta);
                    vm.DTODisciplinasDisponibles = CUlistadoDisciplina.GetDisciplinasDisponibles(dto.IdAtleta);
                    vm.DTODisciplinasRegistradas = CUlistadoDisciplina.GetDisciplinasRegistradas(dto.IdAtleta);
                    return View(vm);
                }
                catch (ExcepcionesAtleta ex)
                {
                    ViewBag.Mensaje = ex.Message;
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Atleta");
            }
        }

        // POST: AtletaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AtletaDisciplinasViewModel vm)
        {
            try
            {
                CUAltaAtleta.UpdateAtleta(vm.DTOAtleta);
                return RedirectToAction("Edit", "Atleta");

            }
            catch (ExcepcionesAtleta ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            vm.DTODisciplinasDisponibles = CUlistadoDisciplina.GetDisciplinasDisponibles(vm.DTOAtleta.IdAtleta);
            vm.DTODisciplinasRegistradas = CUlistadoDisciplina.GetDisciplinasRegistradas(vm.DTOAtleta.IdAtleta);
            return View(vm);
        }
    }
}
//// GET: AtletaController/Create
//public ActionResult Create()
//{
//    if (EstaLogueado() && EsDigitador())
//    {
//        AltaAtletaDTO dto = new AltaAtletaDTO();

//        dto.DisciplinasDisponibles = CUlistadoDisciplina.GetDisciplinas();
//        return View(dto);
//    }
//    else
//    {
//        return RedirectToAction("Index", "Home");
//    }
//}

//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Create(AltaAtletaDTO dto)
//{
//    try
//    {

//        CUAltaAtleta.AddAtleta(dto);
//        return RedirectToAction(nameof(Index));
//    }
//    catch (ExcepcionesAtleta ex)
//    {
//        ViewBag.Error = ex.Message;
//        return View(dto);
//    }
//}

/*   [HttpPost]
   [ValidateAntiForgeryToken]
   public ActionResult AsignarDisciplinas(int id, int[] NuevasDisciplinas)
   {
       if (EstaLogueado() && EsDigitador())
       {
           try
           {

               CUAltaAtleta.AsignarDisciplinas(id, NuevasDisciplinas);
               return RedirectToAction(nameof(Index));
           }
           catch (ExcepcionesAtleta ex)
           {
               ViewBag.Error = ex.Message;
               return RedirectToAction(nameof(Details), new { id });
           }
       }
       else
       {
           return RedirectToAction("Index", "Atleta");
       }
   }
*/
//// GET: AtletaController/Edit/5
//public ActionResult Edit(int id)
//{
//    return View();
//}

//// POST: AtletaController/Edit/5
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

//// GET: AtletaController/Delete/5
//public ActionResult Delete(int id)
//{
//    return View();
//}

//// POST: AtletaController/Delete/5
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