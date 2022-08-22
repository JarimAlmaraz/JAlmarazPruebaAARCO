using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Submarca
    {
        public static ML.Result GetAllByMarca(int IdMarca)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PruebaAARCOEntities context = new DL.PruebaAARCOEntities())
                {
                    var objSubmarca = context.SubmarcaGetByIdMarca(IdMarca).ToList();
                    if (objSubmarca != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in objSubmarca)
                        {
                            ML.Submarca submarca = new ML.Submarca();
                            submarca.IdSubmarca = obj.IdSubmarca;
                            submarca.NombreSubmarca = obj.Submarca;

                            submarca.Marca = new ML.Marca();
                            submarca.Marca.IdMarca = obj.IdMarca.Value;

                            result.Objects.Add(submarca);
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
