using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SUM_Project.Controllers
{
    public class TilbudController : Controller
    {
        public IActionResult Index()
        {
            List<Models.TilbudModel> projekter = LavListe();
            Debug.WriteLine("Blaaah");
            return View(projekter);
        }

        public IActionResult Details()
        {
            return View();
        }

        public static List<Models.TilbudModel> LavListe() 
        {
            List<Models.TilbudModel> tilbud = new List<Models.TilbudModel>();
            ConnectionController.Open();
            string sSQL = "SELECT * FROM Tilbud where projekt_ansvarlig > 0;";
            SqlCommand command = new SqlCommand(sSQL, ConnectionController.conn);
            SqlDataReader reader = null;
            try
            {
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tilbud.Add(new Models.TilbudModel {
                            TilbudID = Convert.ToInt32(reader["tilbud_id"]),
                            KundeID = Convert.ToInt32(reader["kunde_id"]),
                            Titel = reader["title"].ToString(),
                            Beskrivelse = reader["beskrivelse"].ToString(),
                            Type = reader["type"].ToString(),
                            StartDato = reader["start_dato"].ToString(),
                            SlutDato = reader["slut_dato"].ToString(),
                            Rabat = Convert.ToDouble(reader["rabat"]),
                            Pris = Convert.ToDouble(reader["pris"]),
                            ProjektAnsvarlig = Convert.ToInt32(reader["projekt_ansvarlig"]),
                        });

                    }
                }

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to connect to the database" + "\n");
            }
            finally
            {
                reader.Close();
                ConnectionController.Close();
            }
            return tilbud;
        }
    }
}