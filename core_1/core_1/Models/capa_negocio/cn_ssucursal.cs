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
   public class cn_ssucursal
    {
        private cd_ssucursal cdusu = new cd_ssucursal();
        private List<ob_ssucursal> listausu = new List<ob_ssucursal>();

        public List<ob_ssucursal> Todos_ssucursales()
        {
            listausu.Clear();
            DataTable dt = cdusu.mostrar_ssucursales();
            foreach (DataRow dr in dt.Rows)
            {
                ob_ssucursal ssucursal = new ob_ssucursal();
                ssucursal.sal_id = Convert.ToInt32(dr["ID Genero"].ToString());
                ssucursal.suc_id = Convert.ToInt32(dr["ID Pelicula"].ToString());
                listausu.Add(ssucursal);
            }
            return listausu;
        }
        public ob_ssucursal buscarxssucursal(string ssu)
        {

            ob_ssucursal ss = new ob_ssucursal();
            cd_ssucursal cda = new cd_ssucursal();
            ss = cda.buscarxssucursal(ssu);
            if (ss.sal_id != 0)
            {
                return ss;
            }
            else
            {
                ob_ssucursal sinna = new ob_ssucursal();
                sinna.sal_id = 0;
                sinna.suc_id = 0;
                return sinna;
            }
        }
        public void nuevo_ssucursal(int suc_id)
        {
            cdusu.nuevo_ssucursal(suc_id);
        }

        public void actualizar_ssucursal(int id, int suc_id)
        {
            cdusu.actualizar_ssucursal(id, suc_id);
        }

        public void eliminar_ssucursal(int id)
        {
            cdusu.eliminar_ssucursal(id);
        }

    }
}
