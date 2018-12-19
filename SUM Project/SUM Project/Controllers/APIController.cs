using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using SUM_Project.Models;
using SUM_Project.Data;



namespace SUM_Project.Controllers
{
    public class APIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public APIController(ApplicationDbContext context)
        {
            _context = context;
        }
        //public IActionResult Indexold()
        //{
        //    return View();
        //}

        // Kilde: https://medium.com/@mwolfhoffman/making-api-requests-with-asp-net-core-1af8a9ffbc7
        //public static async void Index()
        //{
        //    //We will make a GET request to a really cool website...

        //    //string baseUrl = "http://mwolfhoffman.com";

        //    string baseUrl = "https://localhost:44303/api/medarbejder";
            

        //    //The 'using' will help to prevent memory leaks.

        //    //Create a new instance of HttpClient
        //    using (HttpClient client = new HttpClient())

        //    //Setting up the response...         

        //    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
        //    using (HttpContent content = res.Content)
        //    {
        //        string data = await content.ReadAsStringAsync();
        //        if (data != null)
        //        {
        //            Console.WriteLine(data);
        //            return View(data);
        //            //return View(await _context.Medarbejder.ToListAsync());

        //        }

        //    }
        //}

        // kilde https://stackoverflow.com/questions/29699884/calling-web-api-from-mvc-controller
        // GET: Products
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:44303/api/medarbejder";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    var table = JsonConvert.DeserializeObject<IEnumerable<APIModel>>(data);
                    //var table = JsonConvert.DeserializeObject<System.Data.DataTable>(data);

                }


            }
            return View();

        }

        //// GET: Medarbejder/Details
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var medarbejderModel = await _context.Medarbejder
        //        .SingleOrDefaultAsync(m => m.med_id == id);
        //    if (medarbejderModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(medarbejderModel);
        }
    }