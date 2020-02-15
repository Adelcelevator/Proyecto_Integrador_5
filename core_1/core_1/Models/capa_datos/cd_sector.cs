using core_1.Models.capa_datos.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace core_1.Models.capa_datos
{
    public class cd_sector
    {
        cd_conexion conexion = new cd_conexion();
        List<ob_sector> lista = new List<ob_sector>();
        ob_sector sec = new ob_sector();
        DataTable tabla1 = new DataTable();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable todas()
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_sectores";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            conexion.cerrar_conexion();
            return tabla1;
        }
    }
}