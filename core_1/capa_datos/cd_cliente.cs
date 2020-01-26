using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using core_1.Models.capa_datos;
using capa_datos.objetos;

namespace capa_datos
{
   public class cd_cliente
    {
        cd_conexion conexion = new cd_conexion();
        public ob_cliente obcli = new ob_cliente();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_cliente()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_cliente";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_cliente buscar_cliente(string clie)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_cliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cliente", clie);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow clien = tabla.Rows[0];
                    obcli.cli_id = Convert.ToInt32(clien["ID Cliente"].ToString());
                    obcli.cli_ruc = clien["RUC"].ToString();
                    obcli.cli_nom = clien["Nombre"].ToString();
                    comando.Parameters.Clear();
                    conexion.cerrar_conexion();
                    return obcli;
                }
                else { 
                return obcli;
                }
            }
            catch (Exception)
            {
                obcli.cli_ruc = null;
                return obcli;
            }

        }

        public ob_cliente mostrar_todo_cli(string clie)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_usuarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow cli = tabla.Rows[0];
            obcli.cli_id = Convert.ToInt32(cli["ID Usuario"].ToString());
            obcli.cli_ruc = cli["RUC"].ToString();
            obcli.cli_nom = cli["Nombre"].ToString();
            obcli.cli_ape = cli["Apellido"].ToString();
            obcli.cli_dire = cli["Direccion"].ToString();
            obcli.cli_id = Convert.ToInt32(cli["Telefono"].ToString());
            obcli.cli_dire = cli["Correo"].ToString();
            obcli.cli_dire = cli["Fecha Nacimiento"].ToString();
            conexion.cerrar_conexion();
            return obcli;
        }

        public void eliminar_cliente(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "Eliminar_Cliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("cli_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_cliente(int cli_id, string cli_ruc, string cli_nom, string cli_ape, string cli_dire, int cli_tel, string cli_corr, string cli_fnaci,string cli_est)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_cliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cli_id", cli_id);
            comando.Parameters.AddWithValue("@cli_ruc", cli_ruc);
            comando.Parameters.AddWithValue("@cli_nom", cli_nom);
            comando.Parameters.AddWithValue("@cli_ape", cli_ape);
            comando.Parameters.AddWithValue("@cli_dire",cli_dire);
            comando.Parameters.AddWithValue("@cli_tel", cli_tel);
            comando.Parameters.AddWithValue("@cli_corr", cli_corr);
            comando.Parameters.AddWithValue("@cli_fnaci", cli_fnaci);
            comando.Parameters.AddWithValue("@cli_est", cli_est);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_cliente(string cli_ruc, string cli_nom, string cli_ape, string cli_dire, int cli_tel, string cli_corr, string cli_fnaci)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_cliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cli_id", 0);
            comando.Parameters.AddWithValue("@cli_ruc", cli_ruc);
            comando.Parameters.AddWithValue("@cli_nom", cli_nom);
            comando.Parameters.AddWithValue("@cli_ape", cli_ape);
            comando.Parameters.AddWithValue("@cli_dire", cli_dire);
            comando.Parameters.AddWithValue("@cli_tel", cli_tel);
            comando.Parameters.AddWithValue("@cli_corr", cli_corr);
            comando.Parameters.AddWithValue("@cli_fnaci", cli_fnaci);
            comando.Parameters.AddWithValue("@cli_est", "active"); 
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }
    }
}
