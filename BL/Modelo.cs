using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Modelo
    {
        public static ML.Result GetAllBySubmarca(int IdSubmarca)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PruebaAARCOEntities context = new DL.PruebaAARCOEntities())
                {
                    var objModelo = context.ModeloGetByIdSubmarca(IdSubmarca).ToList();
                    if (objModelo != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in objModelo)
                        {
                            ML.Modelo modelo = new ML.Modelo();
                            modelo.IdModelo = obj.IdModelo;
                            modelo.NombreModelo = obj.Modelo;

                            modelo.Submarca = new ML.Submarca();
                            modelo.Submarca.IdSubmarca = obj.IdSubmarca.Value;

                            result.Objects.Add(modelo);
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
