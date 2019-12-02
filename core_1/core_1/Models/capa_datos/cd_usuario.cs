using core_1.Models.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

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

        public void eliminar_usuario()
        {

        }

    }
}