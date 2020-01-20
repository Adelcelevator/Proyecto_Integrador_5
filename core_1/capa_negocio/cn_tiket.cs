using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using capa_datos;
using capa_datos.objetos;

namespace capa_negocio
{
    public class cn_tiket
    {
        private cd_tiket cdtik = new cd_tiket();
        private List<ob_tiket> listatik = new List<ob_tiket>();

        public List<ob_tiket> Todos_tikets()
        {
            listatik.Clear();
            DataTable dt = cdtik.mostrar_tikets();
            foreach (DataRow dr in dt.Rows)
            {
                ob_tiket tiket = new ob_tiket();
                tiket.tik_id = Convert.ToInt32(dr["ID Tiket"].ToString());
                tiket.usu_id = Convert.ToInt32(dr["ID USUARIO"].ToString());
                tiket.pel_id = Convert.ToInt32(dr["ID Pelicula"].ToString());
                tiket.sal_id = Convert.ToInt32(dr["ID Sala"].ToString());
                tiket.tpag_id = Convert.ToInt32(dr["ID Tipo_Pago"].ToString());
                tiket.tar_id = Convert.ToInt32(dr["ID Tarifa"].ToString());
                tiket.tik_asien = dr["Asiento"].ToString();
                tiket.tik_fec = dr["Fecha"].ToString();
                listatik.Add(tiket);
            }
            return listatik;
        }
        public ob_tiket buscarxtiket(string tike)
        {

            ob_tiket tk = new ob_tiket();
            cd_tiket cdti = new cd_tiket();
            tk = cdti.buscarxtiket(tike);
            if (tk.tik_asien != null)
            {
                return tk;
            }
            else
            {
                ob_tiket stk = new ob_tiket();
                stk.usu_id = 0;
                stk.pel_id = 0;
                stk.sal_id = 0;
                stk.tpag_id = 0;
                stk.tar_id = 0;
                stk.tik_asien = null;
                stk.tik_fec = null;

                return stk;
            }
        }
        public void nuevo_tiket(int usu_id, int pel_id, int sal_id, int tpag_id, int tar_id, string tik_asien, string tik_fec)
        {
            cdtik.nuevo_tiket(usu_id, pel_id, sal_id, tpag_id, tar_id,tik_asien, tik_fec);
        }

        public void actualizar_tiket(int id, int usu_id, int pel_id, int sal_id, int tpag_id, int tar_id, string tik_asien, string tik_fec)
        {
            cdtik.actualizar_tiket(id, usu_id, pel_id, sal_id, tpag_id, tar_id, tik_asien, tik_fec);
        }

        public void eliminar_tiket(int id)
        {
            cdtik.eliminar_tiket(id);
        }
    }
}