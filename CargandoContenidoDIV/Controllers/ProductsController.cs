using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CargandoContenidoDIV.Models;
namespace CargandoContenidoDIV.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Buscar(string parametro)
        {
            var data = Product.ListarPorNombre( parametro );
            return PartialView( data );
        }
        public JsonResult Listar(string parametro)
        {
            var data = Product.ListarPorNombre( parametro );

            return Json( data , JsonRequestBehavior.AllowGet );
        }
    }
}