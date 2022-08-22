using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Descripcion
    {
        public int IdDescripcion { get; set; }
        public string DetalleDescription { get; set; }
        public List<object> Descripciones { get; set; }
        public ML.Modelo Modelo { get; set; }
    }
}
