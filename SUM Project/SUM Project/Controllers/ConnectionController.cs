using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SUM_Project.Controllers
{
    public class ConnectionController : Controller
    // Skrevet Af Jonas
    {

        private static string strconn = "Server=den1.mssql8.gear.host;Database=sumproject;Uid=sumproject;Pwd=Wu6GN?66ar?f;";

        public static SqlConnection conn = new SqlConnection(strconn);

        public static void Open()
        {
            try
            {
                conn.Open();
                Debug.WriteLine("Succesfully connected to the database" + "\n");
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to connect to the database" + "\n");
            }

        }

        public static void Close()
        {
            try
            {
                conn.Close();
                Debug.WriteLine("Succesfully closed the database" + "\n");
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to close the database" + "\n");
            }
        }

    }
}