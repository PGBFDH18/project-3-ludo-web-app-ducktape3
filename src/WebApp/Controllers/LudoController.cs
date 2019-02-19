using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace WebApp.Controllers
{
    public class LudoController : Controller
    {
        // GET: Ludo
        public ActionResult Index()
        {
            // Retrive the name of a specific Ludo game using the REST API
            var client = new RestClient("http://localhost:56522");

            var request = new RestRequest("ludo", Method.GET);
            IRestResponse<List<string>> ludoGameResponse = client.Execute<List<string>>(request);
            var games = ludoGameResponse.Data;

            return View();
        }

        //[HttpPost]
        // GET: Ludo/CreateStartGame
        public ActionResult CreateStartGame()
        {
            // Anrop API med RestSharp
            // 1: skapa spel POST
            // 2: lägg till spelera POST
            // 3: starta spel PUT
            return View("Game");
        }

        public ActionResult Game()
        {
            // eg fetch all player locations from api using restsharp
            // skickar data till View om spelet
            // data kan vara placeringen av alla pjäser

            return View();
        }
        
    }
}