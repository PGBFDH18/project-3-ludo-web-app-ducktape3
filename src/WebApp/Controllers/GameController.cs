using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WebApp.Code;
using WebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class GameController : Controller
    {
        private readonly RestClient _client;
        public GameController()
        {
            _client = new RestClient("http://localhost:56522");

            //var request = new RestRequest("ludo", Method.GET);
            //IRestResponse<List<string>> ludoGameResponse = client.Execute<List<string>>(request);
            //var games = ludoGameResponse.Data;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllPlayers(Team team)
        {
            //var apiSimulator = new ApiSimulator();
            //apiSimulator.RollDiece();


            return View(team.Players);
        }
        public IActionResult Start(Team team)
        {
            //var apiSimulator = new ApiSimulator();
            //apiSimulator.RollDiece();
            
            
            return View(team);
        }

    }
}
