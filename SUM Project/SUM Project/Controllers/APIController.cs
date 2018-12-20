using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using SUM_Project.Models;
using SUM_Project.Data;
using System.Diagnostics;

namespace SUM_Project.Controllers
{
    public class APIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public APIController(ApplicationDbContext context)
        {
            _context = context;
        }
       

        string baseUrl = "http://sumprojekt-api.gear.host/api/medarbejder";

        public async Task<ActionResult> Index()
        {

            List<MedarbejderModel> table = new List<MedarbejderModel>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(baseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    
                    table = JsonConvert.DeserializeObject<List<MedarbejderModel>>(data);

                }


            }
            return View(table);

        }

        public async Task<ActionResult> Details(int? id)
        {
            string url = baseUrl + "/" + id;


            MedarbejderModel medarbejder = new MedarbejderModel();

            using (HttpClient client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    medarbejder = JsonConvert.DeserializeObject<MedarbejderModel>(data);

                    Debug.WriteLine(medarbejder.navn + " " + medarbejder.med_id);
                }


            }
            return View(medarbejder);

        }
    }
}