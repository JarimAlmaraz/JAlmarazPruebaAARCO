using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Modelo
    {
        public int IdModelo { get; set; }
        public string NombreModelo { get; set; }
        public List<object> Modelos { get; set; }
        public ML.Submarca Submarca { get; set; }
    }
}
