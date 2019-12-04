using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;



namespace core_1.Models.capa_datos
{
    public class cd_conexion
    {
        private SqlConnection conexion = new SqlConnection(@"Data Source=PANCHITO\PANCHITO;Initial Catalog=statemovie;Integrated Security=True");

        public SqlConnection abrir_conexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;

        }

        public SqlConnection cerrar_conexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }

    }
}