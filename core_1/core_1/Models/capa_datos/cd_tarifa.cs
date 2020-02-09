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
    public class cd_tarifa
    {
        cd_conexion conexion = new cd_conexion();
        public ob_tarifa obtar = new ob_tarifa();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_tarifas()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_tarifas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_tarifa buscarxtarifa(string tari)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_tarifa_x_tarifa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@tarifa", tari);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow tr = tabla.Rows[0];
                    obtar.tar_id = Convert.ToInt32(tr["ID Tarifa"].ToString());
                    obtar.tar_val = Convert.ToDouble(tr["tar_val"].ToString());
                    obtar.tar_det = tr["tar_det"].ToString();
                    comando.Parameters.Clear();
                    conexion.cerrar_conexion();
                    return obtar;
                }
                return obtar;
            }
            catch (Exception)
            {
                obtar.tar_val = 0;
                return obtar;
            }

        }

        public ob_tarifa mostrar_todo_tarifa(string tari)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_tarifas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow tr = tabla.Rows[0];
            obtar.tar_id = Convert.ToInt32(tr["ID Tarifa"].ToString());
            obtar.tar_val = Convert.ToDouble(tr["tar_val"].ToString());
            obtar.tar_det = tr["tar_det"].ToString();
            conexion.cerrar_conexion();
            return obtar;
        }

        public void eliminar_tarifa(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_trifa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("tar_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_tarifa(int id, float tar_val,  string tar_det)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_tarifa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("tar_id", id);
            comando.Parameters.AddWithValue("@tar_val", tar_val);
            comando.Parameters.AddWithValue("@tar_det", tar_det);
            comando.Parameters.AddWithValue("@estado", "a");
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_tarifa(float tar_val, string tar_det)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_tarifa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("tar_id", 0);
            comando.Parameters.AddWithValue("@tar_val", tar_val);
            comando.Parameters.AddWithValue("@tar_det", tar_det);
            comando.Parameters.AddWithValue("@estado", "a");
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }
    }
}
