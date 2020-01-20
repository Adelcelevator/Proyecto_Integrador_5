using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using core_1.Models.objetos;

namespace core_1.Models.capa_datos
{
    public class cd_usuario
    {
        cd_conexion conexion = new cd_conexion();
        public ob_usuario obusu = new ob_usuario();
        SqlCommand comando = new SqlCommand();  
        SqlDataReader leer;

        public DataTable mostrar_usuarios()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_usuarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_usuario buscarxusu(string usua)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_usuario_x_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", usua);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow usu = tabla.Rows[0];
                    obusu.usu_id = Convert.ToInt32(usu["ID Usuario"].ToString());
                    obusu.cli_id = Convert.ToInt32(usu["ID Cliente"].ToString());
                    obusu.tus_id = Convert.ToInt32(usu["Tipo Usuario"].ToString());
                    obusu.usu_usu = usu["Usuario"].ToString();
                    obusu.usu_pass = usu["Password"].ToString();
                    comando.Parameters.Clear();
                    conexion.cerrar_conexion();
                    return obusu;
                }
                return obusu;
            }
            catch (Exception)
            {
                obusu.usu_usu = null;
                return obusu;
            }

        }

        public ob_usuario mostrar_todo_usu(string usua)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_usuarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow usu = tabla.Rows[0];
            obusu.usu_id = Convert.ToInt32(usu["ID Usuario"].ToString());
            obusu.cli_id = Convert.ToInt32(usu["ID Cliente"].ToString());
            obusu.tus_id = Convert.ToInt32(usu["Tipo Usuario"].ToString());
            obusu.usu_usu = usu["Usuario"].ToString();
            obusu.usu_pass = usu["Password"].ToString();
            conexion.cerrar_conexion();
            return obusu;
        }

        public void eliminar_usuario(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("usu_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_usuario(int id,int cli_id, int tus_id, string usu_usu, string usu_pass)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("usu_id", id);
            comando.Parameters.AddWithValue("@cli_id", cli_id);
            comando.Parameters.AddWithValue("@tus_id", tus_id);
            comando.Parameters.AddWithValue("@usuario", usu_usu);
            comando.Parameters.AddWithValue("@contra", usu_pass);
            comando.Parameters.AddWithValue("@estado", "a");
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_usuario(int clid, string usu, string contra)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("usu_id", 0);
            comando.Parameters.AddWithValue("@cli_id", clid);
            comando.Parameters.AddWithValue("@tus_id", 1);
            comando.Parameters.AddWithValue("@usuario", usu);
            comando.Parameters.AddWithValue("@contra", contra);
            comando.Parameters.AddWithValue("@estado", "a");
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

    }
}