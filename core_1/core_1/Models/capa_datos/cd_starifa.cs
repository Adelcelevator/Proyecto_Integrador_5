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
    public class cd_starifa
    {

        cd_conexion conexion = new cd_conexion();
        public ob_starifa obusu = new ob_starifa();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_starifas()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_starifa";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_starifa buscarxstarifa(string star)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_starifa_x_starifa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@suc_id", star);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow usu = tabla.Rows[0];
                    obusu.suc_id = Convert.ToInt32(usu["ID Sucursal"].ToString());
                    obusu.tar_id = Convert.ToInt32(usu["ID Tarifa"].ToString());
                    conexion.cerrar_conexion();
                    return obusu;
                }
                return obusu;
            }
            catch (Exception)
            {
                obusu.suc_id = 0;
                return obusu;
            }

        }

        public ob_starifa mostrar_todo_starifa(string star)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_starifa";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow usu = tabla.Rows[0];
            obusu.suc_id = Convert.ToInt32(usu["ID Sucursal"].ToString());
            obusu.tar_id = Convert.ToInt32(usu["ID Tarifa"].ToString());
            conexion.cerrar_conexion();
            return obusu;
        }

        public void eliminar_starifa(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_starifa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("suc_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_starifa(int id, int tar_id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_starifa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("suc_id", id);
            comando.Parameters.AddWithValue("@tar_id", tar_id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_starifa(int tar_id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_starifa";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("suc_id", 0);
            comando.Parameters.AddWithValue("@tar_id", tar_id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

    }
}
