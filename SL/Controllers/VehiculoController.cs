using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class VehiculoController : ApiController
    {

        [Route("api/vehiculo/marca")]
        [HttpGet]
        public IHttpActionResult GetAll()  //OK
        {
            ML.Result result = BL.Marca.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

        [Route("api/vehiculo/marca/{IdMarca}")]
        [HttpGet]
        public IHttpActionResult GetByIdSubMarca(int IdMarca)  // OK
        {
            ML.Result result = BL.Submarca.GetAllByMarca(IdMarca);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

        [Route("api/vehiculo/submarca/{IdSubmarca}")]
        [HttpGet]
        public IHttpActionResult GetByIdModelo(int IdSubmarca)  // OK
        {
            ML.Result result = BL.Modelo.GetAllBySubmarca(IdSubmarca);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

        [Route("api/vehiculo/modelo/{IdModelo}")]
        [HttpGet]
        public IHttpActionResult GetByIdDescripcion(int IdModelo)  // OK
        {
            ML.Result result = BL.Descripcion.GetAllByModelo(IdModelo);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

    }
}
