using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class Game
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
    public class LudoController : Controller
    {
        private RestClient _client;
        public LudoController()
        {
            _client = new RestClient("http://localhost:56522");

        }
        // GET: Ludo
        public ActionResult Index()
        {
            // Retrive the name of a specific Ludo game using the REST API
            return View(GetGames());
        }

        private IEnumerable<Game> GetGames()
        {
            var request = new RestRequest("api/Ludo/", Method.GET);
            IRestResponse<List<string>> ludoGameResponse = _client.Execute<List<string>>(request);
            var games = new List<Game>();
            if (ludoGameResponse.Data != null)
            {
                foreach (var item in ludoGameResponse.Data)
                {
                    games.Add(new Game() { Name = item });
                }
            }

            return games;
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string Name = null)
        {
            var request = new RestRequest("api/Ludo/"+ Name, Method.POST);
            IRestResponse<Player> ludoGameResponse = _client.Execute<Player>(request);
            return RedirectToAction("Details", new {id = Name});
        }
        public ActionResult Details(string id)
        {
            var request = new RestRequest("api/ludo/" + id+ "/players", Method.GET);
            IRestResponse<List<string>> ludoGameResponse = _client.Execute<List<string>>(request);
            var players = new List<Player>();
            foreach (var item in ludoGameResponse.Data)
            {
                players.Add(JsonConvert.DeserializeObject<Player>(item));
                
            }
            var model = new Team();
            model.Players = players;
            model.gameId = id;
            return View(model);
        }

        public ActionResult PlayerDetails(string id,Player player)
        {
            var request = new RestRequest("api/ludo/" + id + "/players/" +player.PlayerId, Method.GET);
            IRestResponse<List<string>> ludoGameResponse = _client.Execute<List<string>>(request);
            var players = new List<Player>();
            foreach (var item in ludoGameResponse.Data)
            {
                players.Add(JsonConvert.DeserializeObject<Player>(item));

            }
            var model = new Team();
            model.Players = players;
            return View(model.Players.FirstOrDefault());
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