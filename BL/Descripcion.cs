using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Descripcion
    {
        public static ML.Result GetAllByModelo(int IdModelo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PruebaAARCOEntities context = new DL.PruebaAARCOEntities())
                {
                    var objDescripcion = context.DescripcionGetByIdModelo(IdModelo).ToList();
                    if (objDescripcion != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in objDescripcion)
                        {
                            ML.Descripcion descripcion = new ML.Descripcion();
                            descripcion.IdDescripcion = obj.IdDescripcion;
                            descripcion.DetalleDescription = obj.Descripcion;

                            descripcion.Modelo = new ML.Modelo();
                            descripcion.Modelo.IdModelo = obj.IdModelo.Value;
                            
                            result.Objects.Add(descripcion);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Erro al obtener los estados de la Tabla";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
