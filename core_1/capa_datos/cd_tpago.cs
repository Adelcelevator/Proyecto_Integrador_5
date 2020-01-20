using capa_datos.objetos;
using core_1.Models.capa_datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_datos
{
    public class cd_tpago
    {
        cd_conexion conexion = new cd_conexion();
        public ob_tpago obtp = new ob_tpago();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_tpagos()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_tpagos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_tpago buscarxtpago(string tpago)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_tpagos_x_tpagos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@tpago", tpago);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow tp = tabla.Rows[0];
                    obtp.tpag_id = Convert.ToInt32(tp["ID Tipo_Pago"].ToString());
                    obtp.tpag_nom = tp["tpag_nom"].ToString();
                    comando.Parameters.Clear();
                    conexion.cerrar_conexion();
                    return obtp;
                }
                return obtp;
            }
            catch (Exception)
            {
                obtp.tpag_nom = null;
                return obtp;
            }

        }

        public ob_tpago mostrar_todo_tpago(string tpago)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_usuarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow tp = tabla.Rows[0];
            obtp.tpag_id = Convert.ToInt32(tp["ID Tipo_pago"].ToString());
            obtp.tpag_nom = tp["tpag_nom"].ToString();
            conexion.cerrar_conexion();
            return obtp;
        }

        public void eliminar_tpago(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_tpago";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("tpag_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_tpago(int id, string tpag_nom)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_tpago";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("tpag_id", id);
            comando.Parameters.AddWithValue("@tpag_nom", tpag_nom);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_tpago(string tpag_nom)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_tpago";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("tpag_id", 0);
            comando.Parameters.AddWithValue("@tpag_nom", tpag_nom);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }
    }
}
