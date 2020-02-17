using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_datos.objetos
{
    public class ob_sucursal
    {
        public Int32 suc_id { get; set; }
        public Int32 cin_id { get; set; }
        public string suc_nom { get; set; }
        public Int32 sec_id { get; set; }
        public string suc_ruc { get; set; }
        public string suc_dir { get; set; }
        public string suc_tel { get; set; }
        public string suc_cor { get; set; }
        public Int32 ciu_id { get; set; }
        public string suc_esta { get; set; }
        public ob_sucursal()
        {
        }
    }
}
