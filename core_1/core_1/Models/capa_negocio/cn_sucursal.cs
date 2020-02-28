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
    public class cn_sucursal
    {
        private cd_sucursal cdsuc = new cd_sucursal();
        private List<ob_sucursal> listasuc = new List<ob_sucursal>();

        public List<ob_sucursal> Todos_sucursal()
        {
            listasuc.Clear();
            DataTable dt = cdsuc.mostrar_sucursal();
            foreach (DataRow dr in dt.Rows)
            {
                ob_sucursal sucursal = new ob_sucursal();
                sucursal.suc_id = Convert.ToInt32(dr["suc_id"].ToString());
                sucursal.cin_id = Convert.ToInt32(dr["cin_id"].ToString());
                sucursal.suc_nom = dr["suc_nom"].ToString();
                sucursal.sec_id = Convert.ToInt32(dr["sec_id"].ToString());
                sucursal.suc_ruc = dr["suc_ruc"].ToString();
                sucursal.suc_dir = dr["suc_dir"].ToString();
                sucursal.suc_tel = dr["suc_tel"].ToString();
                sucursal.suc_cor = dr["suc_cor"].ToString();
                sucursal.ciu_id = Convert.ToInt32(dr["ciu_id"].ToString());
                sucursal.suc_esta = dr["suc_esta"].ToString();
                listasuc.Add(sucursal);
            }
            return listasuc;
        }

        public List<ob_sucursal> sucs_x_ci(int id_ci)
        {
            listasuc.Clear();
            DataTable dt = cdsuc.buscarxcin(id_ci);
            foreach (DataRow dr in dt.Rows)
            {
                ob_sucursal sucursal = new ob_sucursal();
                sucursal.suc_id = Convert.ToInt32(dr["suc_id"].ToString());
                sucursal.cin_id = Convert.ToInt32(dr["cin_id"].ToString());
                sucursal.suc_nom = dr["suc_nom"].ToString();
                sucursal.sec_id = Convert.ToInt32(dr["sec_id"].ToString());
                sucursal.suc_ruc = dr["suc_ruc"].ToString();
                sucursal.suc_dir = dr["suc_dir"].ToString();
                sucursal.suc_tel = dr["suc_tel"].ToString();
                sucursal.suc_cor = dr["suc_cor"].ToString();
                sucursal.ciu_id = Convert.ToInt32(dr["ciu_id"].ToString());
                sucursal.suc_esta = dr["suc_esta"].ToString();
                listasuc.Add(sucursal);
            }
            return listasuc;
        }

        public ob_sucursal buscarxsuc(string nomb)
        {
            ob_sucursal suc =new ob_sucursal();
            DataTable dsa = cdsuc.buscarxsuc(nomb);
            if (dsa.Rows.Count != 0)
            {
                DataRow dr = dsa.Rows[0];
                suc.suc_id = Convert.ToInt32(dr["suc_id"].ToString());
                suc.cin_id = Convert.ToInt32(dr["cin_id"].ToString());
                suc.suc_nom = dr["suc_nom"].ToString();
                suc.sec_id = Convert.ToInt32(dr["sec_id"].ToString());
                suc.suc_ruc = dr["suc_ruc"].ToString();
                suc.suc_dir = dr["suc_dir"].ToString();
                suc.suc_tel = dr["suc_tel"].ToString();
                suc.suc_cor = dr["suc_cor"].ToString();
                suc.ciu_id = Convert.ToInt32(dr["ciu_id"].ToString());
                suc.suc_esta = dr["suc_esta"].ToString();
                return suc;
            }
            return suc;
        }

        public ob_sucursal buscarxsucursal(string sucu)
        {

            ob_sucursal sc = new ob_sucursal();
            cd_sucursal cds = new cd_sucursal();
            sc = cds.buscarxsucursal(sucu);
            if (sc.suc_nom != null)
            {
                return sc;
            }
            else
            {
                ob_sucursal sinna = new ob_sucursal();
                sinna.suc_id = 0;
                sinna.cin_id = 0;
                sinna.suc_nom = null;
                sinna.sec_id = 0;
                sinna.suc_ruc = null;
                sinna.suc_dir = null;
                sinna.suc_tel = null;
                sinna.suc_cor = null;
                sinna.ciu_id = 0;


                return sinna;
            }
        }
        public bool nuevo_sucursal(int cin_id, int ciu_id, int sec_id, string suc_nom, string suc_ruc, string suc_dir, string suc_tel, string suc_cor)
        {
            if (cdsuc.nuevo_sucursal(cin_id, ciu_id, sec_id, suc_nom, suc_ruc, suc_dir, suc_tel, suc_cor))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void actualizar_sucursal(int id, int ciu_id, int sec_id, int cin_id, string suc_nom, string suc_sec, string suc_ruc, string suc_dir, int suc_tel, string suc_cor, string suc_esta)
        {
            cdsuc.actualizar_sucursal(id, ciu_id, sec_id, cin_id, suc_nom, suc_sec, suc_ruc, suc_dir, suc_tel, suc_cor, suc_esta);
        }

        public void eliminar_sucursal(int id)
        {
            cdsuc.eliminar_sucursal(id);
        }
    }
}
