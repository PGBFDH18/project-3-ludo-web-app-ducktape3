using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
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
        private static readonly ILog log = LogManager.GetLogger(typeof(LudoController));
        public LudoController()
        {
            _client = new RestClient("http://localhost:56522");

        }
        // GET: Ludo
        public ActionResult Index()
        {
            // Retrive the name of a specific Ludo game using the REST API
            log.Info("List games");
            return View(GetGames());
        }
        public ActionResult MoviePlayerPiece(string id, int playerId,int pieceId)
        {
            var randome = new Random();
            var steps = randome.Next(0, 70);
            var request = new RestRequest("api/ludo/" + id , Method.PUT);
            request.Parameters.Add(new Parameter("playerId", playerId, ParameterType.QueryString));
            request.Parameters.Add(new Parameter("pieceId", pieceId, ParameterType.QueryString));
            request.Parameters.Add(new Parameter("numberOfFields", steps, ParameterType.QueryString));
            var respons = _client.Execute(request);

            if(respons.IsSuccessful && respons.StatusCode == HttpStatusCode.OK)
            {

                IRestResponse<List<string>> ludoGameResponse = _client.Execute<List<string>>(request);
                var players = new List<Player>();
                foreach (var item in ludoGameResponse.Data)
                {
                    players.Add(JsonConvert.DeserializeObject<Player>(item));

                }

                return View("Winner", players.FirstOrDefault());
            }

            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet]
        public ActionResult PlayerEdit(string id,int playerId)
        {
            var request = new RestRequest("api/ludo/" + id + "/players/" + playerId, Method.GET);
            IRestResponse<List<string>> ludoGameResponse = _client.Execute<List<string>>(request);
            var players = new List<Player>();
            foreach (var item in ludoGameResponse.Data)
            {
                players.Add(JsonConvert.DeserializeObject<Player>(item));

            }

            return View(players.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult PlayerEdit(string id,Player player)
        {
            var request = new RestRequest("api/ludo/" + id + "/players/" + player.PlayerId, Method.PUT);
            request.Parameters.Add(new Parameter("name", player.Name,ParameterType.QueryString));
            request.Parameters.Add(new Parameter("color", player.PlayerColor,ParameterType.QueryString));
            var respons = _client.Execute(request);
            if (respons.IsSuccessful)
            {
                return RedirectToAction("Details",new { id = id});
            }

            return Json(respons.ErrorMessage);
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