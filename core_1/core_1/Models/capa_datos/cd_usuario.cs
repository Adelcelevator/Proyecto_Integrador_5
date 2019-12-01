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

        public ob_usuario buscarxusu(string usua)
        {
                DataTable tabla = new DataTable();
                comando.Connection = conexion.abrir_conexion();
                comando.CommandText = "mostrar_usuarios_x_usuario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@usuario", usua);
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                comando.Parameters.Clear();
                conexion.cerrar_conexion();
            return obusu;
        }

    }
}