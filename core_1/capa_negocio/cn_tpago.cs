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
    public class cn_tpago
    {

        private cd_tpago cdtp = new cd_tpago();
        private List<ob_tpago> listatp = new List<ob_tpago>();

        public List<ob_tpago> Todos_tpagos()
        {
            listatp.Clear();
            DataTable dt = cdtp.mostrar_tpagos();
            foreach (DataRow dr in dt.Rows)
            {
                ob_tpago tpago = new ob_tpago();
                tpago.tpag_id = Convert.ToInt32(dr["ID Tipo_pago"].ToString());
                tpago.tpag_nom = dr["tpag_nom"].ToString();
                listatp.Add(tpago);
            }
            return listatp;
        }
        public ob_tpago buscarxtpago(string tpago)
        {

            ob_tpago us = new ob_tpago();
            cd_tpago cda = new cd_tpago();
            us = cda.buscarxtpago(tpago);
            if (us.tpag_nom != null)
            {
                return us;
            }
            else
            {
                ob_tpago sinna = new ob_tpago();
                sinna.tpag_id = 0;
                sinna.tpag_nom = null;
                return sinna;
            }
        }
        public void nuevo_tpago( string tpag_nom)
        {
            cdtp.nuevo_tpago(tpag_nom);
        }

        public void actualizar_tpago(int id, string tpag_nom)
        {
            cdtp.actualizar_tpago(id, tpag_nom);
        }

        public void eliminar_tpago(int id)
        {
            cdtp.eliminar_tpago(id);
        }
    }
}
