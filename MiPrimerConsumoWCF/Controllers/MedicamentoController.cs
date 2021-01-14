using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimerConsumoWCF.ServiceMedicamento;

namespace MiPrimerConsumoWCF.Controllers
{
    public class MedicamentoController : Controller
    {

        public JsonResult ListarMedicamentos()
        {
            MedicamentosClient oMedicamentosClient = new MedicamentosClient();
            var lista = oMedicamentosClient.ListarMedicamentos()
                .Where(p => p.BHabilitado == 1)
                .Select(
                p => new
                {
                    p.IidMedicamento,
                    p.Nombre,
                    p.Concentracion,
                    p.NombreFormaFarmaceutica,
                    p.Stock,
                    p.Presentacion
                }
                ).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        // GET: Medicamento
        public ActionResult Index()
        {
            return View();
        }
    }
}