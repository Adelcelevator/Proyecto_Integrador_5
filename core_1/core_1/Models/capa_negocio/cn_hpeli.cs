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
    public class cn_hpeli
    {
        private cd_hpeli cdusu = new cd_hpeli();
        private List<ob_hpeli> listahp = new List<ob_hpeli>();

        public List<ob_hpeli> Todos_hpelis()
        {
            listahp.Clear();
            DataTable dt = cdusu.mostrar_hpelis();
            foreach (DataRow dr in dt.Rows)
            {
                ob_hpeli hpeli = new ob_hpeli();
                hpeli.pel_id = Convert.ToInt32(dr["ID Pelicula"].ToString());
                hpeli.hor_id = Convert.ToInt32(dr["ID Horario"].ToString());
                listahp.Add(hpeli);
            }
            return listahp;
        }
        public ob_hpeli buscarxhpeli(string hpel)
        {

            ob_hpeli hp = new ob_hpeli();
            cd_hpeli cda = new cd_hpeli();
            hp = cda.buscarxhpeli(hpel);
            if (hp.pel_id != 0)
            {
                return hp;
            }
            else
            {
                ob_hpeli sinna = new ob_hpeli();
                sinna.pel_id = 0;
                sinna.hor_id = 0;
                return sinna;
            }
        }
        public void nuevo_hpeli(int hor_id)
        {
            cdusu.nuevo_hpeli(hor_id);
        }

        public void actualizar_hpeli(int id, int hor_id)
        {
            cdusu.actualizar_hpeli(id, hor_id);
        }

        public void eliminar_hpeli(int id)
        {
            cdusu.eliminar_hpeli(id);
        }
    }
}
