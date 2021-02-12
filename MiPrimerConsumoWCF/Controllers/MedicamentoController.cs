using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using MiPrimerConsumoWCF.ServiceMedicamentos;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace MiPrimerConsumoWCF.Controllers
{
    public class MedicamentoController : Controller
    {

        public JsonResult ListarMedicamentos()
        {
            MedicamentosClient oMedicamentosClient = new MedicamentosClient();
            oMedicamentosClient.ClientCredentials.UserName.UserName = "lhurol";
            oMedicamentosClient.ClientCredentials.UserName.Password = "1234";

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
                    p.Precio,
                    p.Presentacion
                }
                ).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarMedicamentosPorNombre(string NombreMedicamento)
        {
            MedicamentosClient oMedicamentosClient = new MedicamentosClient();
            oMedicamentosClient.ClientCredentials.UserName.UserName = "lhurol";
            oMedicamentosClient.ClientCredentials.UserName.Password = "1234";
            var lista = oMedicamentosClient.ListarMedicamentos()
                .Where(p => p.BHabilitado == 1 && p.Nombre.ToLower().Contains(NombreMedicamento.ToLower()))
                .Select(
                p => new
                {
                    p.IidMedicamento,
                    p.Nombre,
                    p.Concentracion,
                    p.NombreFormaFarmaceutica,
                    p.Stock,
                    p.Precio,
                    p.Presentacion
                }
                ).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarFormaFarmaceutica()
        {
            MedicamentosClient oMedicamentosClient = new MedicamentosClient();
            oMedicamentosClient.ClientCredentials.UserName.UserName = "lhurol";
            oMedicamentosClient.ClientCredentials.UserName.Password = "1234";
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
            oMedicamentosClient.ClientCredentials.UserName.UserName = "lhurol";
            oMedicamentosClient.ClientCredentials.UserName.Password = "1234";
            var medicamento = oMedicamentosClient.RecuperarMedicamento(iidMedicamento);

            return Json(medicamento, JsonRequestBehavior.AllowGet);

        }
        public int AgregarYEditarMedicamento(MedicamentoCLS oMedicamentoCLS)
        {
            int rpta = 0;
            try
            {
                MedicamentosClient oMedicamentoClient = new MedicamentosClient();
                oMedicamentoClient.ClientCredentials.UserName.UserName = "lhurol";
                oMedicamentoClient.ClientCredentials.UserName.Password = "1234";
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
                oMedicamentoClient.ClientCredentials.UserName.UserName = "lhurol";
                oMedicamentoClient.ClientCredentials.UserName.Password = "1234";
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
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(remove);
            return View();
        }

        private bool remove(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}