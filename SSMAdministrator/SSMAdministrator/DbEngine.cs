using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GMap.NET.WindowsPresentation;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using GMap;
using GMap.NET;

namespace SSMAdministrator
{
    static class DbEngine
    {
        /// <summary>
        /// Class with methods for DB
        /// </summary>

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings[1].ToString(); //0 is default localhost CS
        static public List<Marker> GetAllMarkers()
        {
            using (var dbConn = new MySqlConnection(connectionString))
            {
                var req = "SELECT  "
                dbConn.Open();

                dbConn.Close();    
            }
            
            return null;
        }

        static public void AddMarker()
        {
            var dbConn = new MySqlConnection(connectionString);
            dbConn.Open();
            dbConn.Close();
        }
    }
}
