﻿using capa_datos;
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
                sucursal.suc_id = Convert.ToInt32(dr["ID Sucursal"].ToString());
                sucursal.cin_id = Convert.ToInt32(dr["ID Cine"].ToString());
                sucursal.suc_nom = dr["suc_nom"].ToString();
                sucursal.suc_sec = dr["suc_sec"].ToString();
                sucursal.suc_ruc = dr["suc_ruc"].ToString();
                sucursal.suc_dir = dr["suc_dir"].ToString();
                sucursal.suc_id = Convert.ToInt32(dr["suc_tel"].ToString());
                sucursal.suc_cor = dr["suc_cor"].ToString();
                sucursal.suc_ciu = dr["suc_ciu"].ToString();

                listasuc.Add(sucursal);
                listasuc.Add(sucursal);
                listasuc.Add(sucursal);
            }
            return listasuc;
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
                sinna.suc_sec = null;
                sinna.suc_ruc= null;
                sinna.suc_dir = null;
                sinna.suc_tel = 0;
                sinna.suc_cor = null;
                sinna.suc_ciu = null;
                

                return sinna;
            }
        }
        public void nuevo_sucursal(int cin_id, string suc_nom, string suc_sec, string suc_ruc, string suc_dir, int suc_tel, string suc_cor, string suc_ciu)
        {
            cdsuc.nuevo_sucursal(cin_id, suc_nom, suc_sec, suc_ruc, suc_dir, suc_tel, suc_cor, suc_ciu);
        }

        public void actualizar_sucursal(int id, int cin_id, string suc_nom, string suc_sec, string suc_ruc, string suc_dir, int suc_tel, string suc_cor, string suc_ciu)
        {
            cdsuc.actualizar_sucursal( id, cin_id, suc_nom, suc_sec, suc_ruc, suc_dir, suc_tel, suc_cor, suc_ciu);
        }

        public void eliminar_sucursal(int id)
        {
            cdsuc.eliminar_sucursal(id);
        }
    }
}
