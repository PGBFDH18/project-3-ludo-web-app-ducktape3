using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Code;
using WebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    public class GameController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Start(string name1, string name2, string name3, string name4)
        {
            var apiSimulator = new ApiSimulator();
            apiSimulator.RollDiece();
            Team t = new Team();
            t.Name1 = name1;
            t.Name2 = name2;
            t.Name3 = name3;
            t.Name4 = name4;
            
            
            return View(t);
        }

    }
}
