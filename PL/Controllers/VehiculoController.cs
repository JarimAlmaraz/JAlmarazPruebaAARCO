using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult GetAll()
        {
            ML.Marca marca = new ML.Marca();
            marca.Marcas = new List<object>();

            using (var client = new HttpClient())
            {
                string urlApi = ConfigurationManager.AppSettings["WebApi"].ToString();
                client.BaseAddress = new Uri(urlApi);

                var responseTask = client.GetAsync("vehiculo/marca/");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();


                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        List<ML.Marca> resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ML.Marca>>(resultItem.ToString());
                        marca.Marcas.Add(resultItemList);
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al obtener la informacion";
                    return PartialView("Modal");
                }
            }
            return View(marca);
        }

        public JsonResult GetMarca(int IdPais)
        {
            var result = BL.Marca.GetAll();

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        
    }
}
//public ActionResult GetAll()
//{
//    //ML.Marca marca = new ML.Marca();
//    //marca.Marcas = new List<object>();

//    //using (var client = new HttpClient())
//    //{
//    //    string urlApi = ConfigurationManager.AppSettings["WebApi"].ToString();
//    //    client.BaseAddress = new Uri(urlApi);

//    //    var responseTask = client.GetAsync("vehiculo/marca/");
//    //    responseTask.Wait();

//    //    var result = responseTask.Result;
//    //    if (result.IsSuccessStatusCode)
//    //    {
//    //        var readTask = result.Content.ReadAsAsync<ML.Result>();


//    //        foreach (var resultItem in readTask.Result.Objects)
//    //        {
//    //            List<ML.Marca> resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ML.Marca>>(resultItem.ToString());
//    //            marca.Marcas.Add(resultItemList);
//    //        }
//    //    }
//    //    else
//    //    {
//    //        ViewBag.Mensaje = "Ocurrio un error al obtener la informacion";
//    //        return PartialView("Modal");
//    //    }
//    //}
//    //return View(marca);


//    return View();
//}


//public ActionResult GetAll()
//{
//    ML.Vehiculos vehiculos = new ML.Vehiculos();
//    vehiculos.Marca = new ML.Marca();
//    vehiculos.Submarca = new ML.Submarca();
//    vehiculos.Modelo = new ML.Modelo();
//    vehiculos.Decripcion = new ML.Descripcion();


//    ML.Result resultMarca = BL.Marca.GetAll();

//    if (resultMarca.Correct)
//    {
//        vehiculos.Marca.Marcas = resultMarca.Objects;
//    }

//    using (var client = new HttpClient())
//    {
//        string urlApi = ConfigurationManager.AppSettings["WebApi"].ToString();
//        client.BaseAddress = new Uri(urlApi);

//        var responseTask = client.GetAsync("vehiculo/marca/");
//        responseTask.Wait();

//        var result = responseTask.Result;
//        if (result.IsSuccessStatusCode)
//        {
//            var readTask = result.Content.ReadAsAsync<ML.Result>();
//            readTask.Wait();

//            vehiculos = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Vehiculos>(readTask.Result.Object.ToString());

//            ML.Result resultSubmarca = BL.Submarca.GetAllByMarca(vehiculos.Marca.IdMarca);
//            ML.Result resultModelo = BL.Modelo.GetAllBySubmarca(vehiculos.Submarca.IdSubmarca);
//            ML.Result resultDescripcion = BL.Descripcion.GetAllByModelo(vehiculos.Submarca.IdSubmarca);

//            vehiculos.Marca.Marcas = resultMarca.Objects;
//            vehiculos.Submarca.Submarcas = resultSubmarca.Objects;
//            vehiculos.Modelo.Modelos = resultModelo.Objects;
//            vehiculos.Decripcion.Descripciones = resultDescripcion.Objects;

//            return View(vehiculos);
//        }
//        else
//        {
//            ViewBag.Mensaje = "Ocurrio un error al obtener la informacion";
//            return PartialView("Modal");
//        }
//    }
//}