using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Marca
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PruebaAARCOEntities context = new DL.PruebaAARCOEntities())
                {
                    var marca = context.MarcaGetAll().ToList();
                    if (marca != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in marca)
                        {
                            ML.Marca marcas = new ML.Marca();
                            marcas.IdMarca = obj.IdMarca;
                            marcas.NombreMarca = obj.Marca;

                            result.Objects.Add(marca);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al obtener los datos de la Tabla";
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
