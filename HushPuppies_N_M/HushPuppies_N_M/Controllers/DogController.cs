using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HushPuppies_N_M.Models;

namespace HushPuppies_N_M.Controllers
{
    public class DogController : Controller
    {
        // GET: Dog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dogs()
        {
            Dog d = new Dog("Nala", 2, new DateTime(2019, 11, 13), "Sehr freundlich", "min. 2h spazieren am Tag ");
            return View(d);
            
        }

        private List<Dog> CreateDog()
        {
            return new List<Dog>() {
                
                new Dog("Nimi", 2, new DateTime(2019, 11, 13), "aggresiv", "min. 2h spazieren am Tag ")
        };
        }
    }
}