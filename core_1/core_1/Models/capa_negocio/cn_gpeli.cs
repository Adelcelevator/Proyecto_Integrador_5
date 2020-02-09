using capa_datos;
using capa_datos.objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_negocio
{
    public class cn_gpeli
    {

        private cd_gpeli cdusu = new cd_gpeli();
        private List<ob_gpeli> listausu = new List<ob_gpeli>();

        public List<ob_gpeli> Todos_gpelis()
        {
            listausu.Clear();
            DataTable dt = cdusu.mostrar_gpelis();
            foreach (DataRow dr in dt.Rows)
            {
                ob_gpeli gpeli = new ob_gpeli();
                gpeli.gen_id = Convert.ToInt32(dr["gen_id"].ToString());
                gpeli.pel_id = Convert.ToInt32(dr["pel_id"].ToString());
                listausu.Add(gpeli);
            }
            return listausu;
        }
        public ob_gpeli buscarxgpeli(string gpel)
        {

            ob_gpeli us = new ob_gpeli();
            cd_gpeli cda = new cd_gpeli();
            us = cda.buscarxgpeli(gpel);
            if (us.gen_id != 0)
            {
                return us;
            }
            else
            {
                ob_gpeli sinna = new ob_gpeli();
                sinna.gen_id = 0;
                sinna.pel_id = 0;
                return sinna;
            }
        }
        public void nuevo_gpeli( int pel_id)
        {
            cdusu.nuevo_gpeli(pel_id);
        }

        public void actualizar_gpeli(int id, int pel_id)
        {
            cdusu.actualizar_gpeli(id,pel_id);
        }

        public void eliminar_gpeli(int id)
        {
            cdusu.eliminar_gpeli(id);
        }
    }
}
