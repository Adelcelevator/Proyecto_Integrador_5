using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using capa_datos;
using capa_datos.objetos;

namespace capa_negocio
{
    public class cn_cliente
    {
        private cd_cliente cdcli = new cd_cliente();
        private List<ob_cliente> listaclie = new List<ob_cliente>();
        public List<ob_cliente> todos_clientes()
        {
            listaclie.Clear();
            DataTable dt = cdcli.mostrar_cliente();
            foreach (DataRow dr in dt.Rows)
            {
                ob_cliente cliente = new ob_cliente();
                cliente.cli_id = Convert.ToInt32(dr["cli_id"].ToString());
                cliente.cli_ruc = dr["cli_ruc"].ToString();
                cliente.cli_nom = dr["cli_nom"].ToString();
                cliente.cli_ape = dr["cli_ape"].ToString();
                cliente.cli_dire = dr["cli_dire"].ToString();
                cliente.cli_tel = Convert.ToInt32(dr["cli_tel"].ToString());
                cliente.cli_corr = dr["cli_corr"].ToString();
                cliente.cli_fnaci = dr["cli_fnaci"].ToString();
                cliente.cli_est = dr["cli_est"].ToString();
                listaclie.Add(cliente);
            }
            return listaclie;
        }
        public ob_cliente buscar_cliente(string ruc)
        {

            ob_cliente cl = new ob_cliente();
            cd_cliente clien = new cd_cliente();
            cl = clien.buscar_cliente(ruc);
            if (cl.cli_ruc != null)
            {
                return cl;
            }
            else
            {
                ob_cliente cliente1 = new ob_cliente();
                cliente1.cli_id = 0;
                cliente1.cli_ruc = null;
                return cliente1;
            }
        }
        public void nuevo_cliente(string cli_ruc, string cli_nom, string cli_ape, string cli_dire, int cli_tel, string cli_corr, string cli_fnaci)
        {
            cdcli.nuevo_cliente(cli_ruc, cli_nom, cli_ape, cli_dire, cli_tel, cli_corr, cli_fnaci);
        }

        public void actualizar_cliente(int cli_id, string cli_ruc, string cli_nom, string cli_ape, string cli_dire, int cli_tel, string cli_corr, string cli_fnaci,string cli_est)
        {
            cdcli.actualizar_cliente(cli_id, cli_ruc, cli_nom, cli_ape, cli_dire, cli_tel, cli_corr, cli_fnaci,cli_est);
        }

        public void eliminar_cliente(int id)
        {
            cdcli.eliminar_cliente(id);
        }
    }
}
