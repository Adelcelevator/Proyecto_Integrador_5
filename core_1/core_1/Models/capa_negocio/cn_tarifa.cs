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
    public class cn_tarifa
    {

        private cd_tarifa cdtar = new cd_tarifa();
        private List<ob_tarifa> listatar = new List<ob_tarifa>();

        public List<ob_tarifa> Todos_tarifas()
        {
            listatar.Clear();
            DataTable dt = cdtar.mostrar_tarifas();
            foreach (DataRow dr in dt.Rows)
            {
                ob_tarifa tarifa = new ob_tarifa();
                tarifa.tar_id = Convert.ToInt32(dr["ID Tarifa"].ToString());
                tarifa.tar_val =Convert.ToDouble(dr["Usuario"].ToString());
                tarifa.tar_det = dr["tar_det"].ToString();
                listatar.Add(tarifa);
            }
            return listatar;
        }
        public ob_tarifa buscarxtarifa(string tari)
        {

            ob_tarifa tr = new ob_tarifa();
            cd_tarifa cdt = new cd_tarifa();
            tr = cdt.buscarxtarifa(tari);
            if (tr.tar_val != 0)
            {
                return tr;
            }
            else
            {
                ob_tarifa sinna = new ob_tarifa();
                sinna.tar_id = 0;
                sinna.tar_val = 0;
                sinna.tar_det = null;
                return sinna;
            }
        }
        public void nuevo_tarifa( float tar_val, string tar_det)
        {
            cdtar.nuevo_tarifa(tar_val , tar_det);
        }

        public void actualizar_tarifa(int id, float tar_val, string tar_det)
        {
            cdtar.actualizar_tarifa(id, tar_val, tar_det);
        }

        public void eliminar_tarifa(int id)
        {
            cdtar.eliminar_tarifa(id);
        }
    }
}
