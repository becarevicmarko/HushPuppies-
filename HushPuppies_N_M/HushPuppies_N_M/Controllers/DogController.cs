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
            Dog d1 = new Dog("Nala", 2, new DateTime(2019, 11, 13), "Sehr freundlich", "min. 2h spazieren am Tag ");
            //Dog d2 = new Dog("Nimi", 2, new DateTime(2019, 11, 13), "aggro", "min. 2h spazieren am Tag ");
            //Dog d3 = new Dog("Lana", 2, new DateTime(2019, 11, 13), "ruhig", "min. 2h spazieren am Tag ");
            //Dog d4 = new Dog("Bobi", 2, new DateTime(2019, 11, 13), "spielerisch", "min. 2h spazieren am Tag ");

            //List<Dog> d = new List<Dog>();

            //d.Add(d1);
            //d.Add(d2);
            //d.Add(d3);
            //d.Add(d4);
           
            return View(d1);
            
        }

        }
    }
