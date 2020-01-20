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
    public class cn_starifa
    {
        private cd_starifa cdusu = new cd_starifa();
        private List<ob_starifa> listausu = new List<ob_starifa>();

        public List<ob_starifa> Todos_starifas()
        {
            listausu.Clear();
            DataTable dt = cdusu.mostrar_starifas();
            foreach (DataRow dr in dt.Rows)
            {
                ob_starifa starifa = new ob_starifa();
                starifa.suc_id = Convert.ToInt32(dr["ID Sucursal"].ToString());
                starifa.tar_id = Convert.ToInt32(dr["ID Tarifa"].ToString());
                listausu.Add(starifa);
            }
            return listausu;
        }
        public ob_starifa buscarxstarifa(string star)
        {

            ob_starifa us = new ob_starifa();
            cd_starifa cda = new cd_starifa();
            us = cda.buscarxstarifa(star);
            if (us.suc_id != 0)
            {
                return us;
            }
            else
            {
                ob_starifa sinna = new ob_starifa();
                sinna.suc_id = 0;
                sinna.tar_id = 0;
                return sinna;
            }
        }
        public void nuevo_starifa(int tar_id)
        {
            cdusu.nuevo_starifa(tar_id);
        }

        public void actualizar_starifa(int id, int tar_id)
        {
            cdusu.actualizar_starifa(id, tar_id);
        }

        public void eliminar_starifa(int id)
        {
            cdusu.eliminar_starifa(id);
        }
    }
}
