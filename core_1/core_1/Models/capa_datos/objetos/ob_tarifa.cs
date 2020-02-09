using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_datos.objetos
{
    public class ob_tarifa
    {
        public Int32 tar_id { get; set; }
        public double tar_val { get; set; }
        public string tar_det { get; set; }
        public string tar_esta { get; set; }

        public ob_tarifa()
        {
        }
    }
}
