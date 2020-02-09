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
    public class cd_ssucursal
    {
        cd_conexion conexion = new cd_conexion();
        public ob_ssucursal obusu = new ob_ssucursal();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_ssucursales()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_ssucursal";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_ssucursal buscarxssucursal(string ssu)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_ssucursal_x_ssucursal";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@sal_id", ssu);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow ss = tabla.Rows[0];
                    obusu.sal_id = Convert.ToInt32(ss["ID Sala"].ToString());
                    obusu.suc_id = Convert.ToInt32(ss["ID Sucursal"].ToString());
                    conexion.cerrar_conexion();
                    return obusu;
                }
                return obusu;
            }
            catch (Exception)
            {
                obusu.sal_id = 0;
                return obusu;
            }

        }

        public ob_ssucursal mostrar_todo_ssucursal(string ssu)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_ssucursal";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow ss = tabla.Rows[0];
            obusu.sal_id = Convert.ToInt32(ss["ID Genero"].ToString());
            obusu.suc_id = Convert.ToInt32(ss["ID Pelicula"].ToString());
            conexion.cerrar_conexion();
            return obusu;
        }

        public void eliminar_ssucursal(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_ssucursal";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("sal_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_ssucursal(int id, int suc_id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_ssucursal";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("sal_id", id);
            comando.Parameters.AddWithValue("@suc_id", suc_id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_ssucursal(int suc_id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_ssucursal";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("sal_id", 0);
            comando.Parameters.AddWithValue("@suc_id", suc_id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }
    }
}
