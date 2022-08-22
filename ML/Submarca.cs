using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Submarca
    {
        public int IdSubmarca { get; set; }
        public string NombreSubmarca { get; set; }
        public List<object> Submarcas { get; set; }
        public ML.Marca Marca { get; set; }

    }
}
