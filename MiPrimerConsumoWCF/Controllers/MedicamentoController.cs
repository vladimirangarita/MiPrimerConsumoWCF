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
        public JsonResult ListarFormaFarmaceutica()
        {
            MedicamentosClient oMedicamentosClient = new MedicamentosClient();
            var lista = oMedicamentosClient.ListaFormaFarmaceutica()
            .Select(p => new
            {
                p.IidFormaFarmaceutica,
                p.NombreFormaFarmaceutica
            }).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        // GET: Medicamento

            public JsonResult RecuperarMedicamento(int iidMedicamento)
        {
            MedicamentosClient oMedicamentosClient = new MedicamentosClient();

            var medicamento = oMedicamentosClient.RecuperarMedicamento(iidMedicamento);

            return Json(medicamento, JsonRequestBehavior.AllowGet);

        }
        public int AgregarYEditarMedicamento(MedicamentoCLS oMedicamentoCLS)
        {
            int rpta = 0;
            try
            {
                MedicamentosClient oMedicamentoClient = new MedicamentosClient();
                rpta = oMedicamentoClient.RegistraryActualizarMedicamento(oMedicamentoCLS);
            }
            catch (Exception)
            {

                rpta = 0;
            }
            return rpta;
        }

        public int EliminarMedicamento(int iidMedicamento)
        {

            int rpta = 0;
            try
            {
                MedicamentosClient oMedicamentoClient = new MedicamentosClient();
                rpta = oMedicamentoClient.EliminarMedicamento(iidMedicamento);

            }
            catch (Exception)
            {

                rpta = 0;
            }
            return rpta;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}