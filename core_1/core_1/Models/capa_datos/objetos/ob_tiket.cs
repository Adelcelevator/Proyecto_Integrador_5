using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_datos.objetos
{
    public class ob_tiket
    {
        public Int32 tik_id { get; set; }
        public Int32 usu_id { get; set; }
        public Int32 pel_id { get; set; }
        public Int32 sal_id { get; set; }
        public Int32 tpag_id { get; set; }
        public Int32 tar_id { get; set; }
        public string tik_asien { get; set; }
        public string tik_fec { get; set; }
        public string tik_estd { get; set; }
        public ob_tiket()
        {
        }
    }
}
