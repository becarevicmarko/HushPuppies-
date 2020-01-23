using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HushPuppies_N_M.Models;

namespace HushPuppies_N_M.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {

            return View(new User());
        }
        [HttpPost]
        public ActionResult Registration(User user)
        {
            //Parameter user: hier sind die eingeg. Daten des Formulars enthalten 

            //1. Parameter überprüfen 
            if (user == null)
            {
                return RedirectToAction("Registration");
            }
            CheckUserData(user);

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            else
            {
                //nun würden wir die Daten in einer DB-Tabelle abspeichern

                return View("Message", new Message("Registrierung", "Ihre Daten wurden erfolgreich abgespeichert"));
            }


        }

        public ActionResult Login()
        {
            return View();
        }


        private void CheckUserData(User user)
        {
            if (user == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(user.Lastname.Trim()))
            {
                ModelState.AddModelError("Lastname", "Nachname ist ein Pflichtfeld");
            }
            if (user.Gender == Gender.notSpecified)
            {
                ModelState.AddModelError("Gender", "Bitte wählen Sie das Geschlecht aus");
            }

            if (string.IsNullOrEmpty(user.Username.Trim()))
            {
                ModelState.AddModelError("Username", "Benutzername ist ein Pflichtfeld");
            }
            //Passwordfeld
            //Richtlinien: min 8 Zeichen lang, mind. 1 Großbuchstabe, min. Sonderzeichen
            if (!CheckPassword(user.Password))
            {
                ModelState.AddModelError("Password", "Passwort muss min. 8 Zeichen, einen Großbuchstaben, und min. ein Sonderzeichen enthalten");
            }
            if (user.Password != user.Password2)
            {
                ModelState.AddModelError("Password2", "Passwort2 muss mit Password1 übereinstimmen");
            }


        }
        private bool CheckPassword(string password)
        {
            string pwd = password.Trim();
            if (pwd.Length < 8)
            {
                return false;
            }
            if (!PaswordContainsLowercaseCharacter(pwd, 1))
            {
                return false;
            }
            if (!PaswordContainsUppercaseCharacter(pwd, 1))
            {
                return false;
            }
            if (!PaswordContainsSpecialCharacter(pwd, 1))
            {
                return false;
            }
            return true;
        }
        private bool PaswordContainsLowercaseCharacter(string text, int minCount)
        {
            int count = 0;
            foreach (char c in text)
            {
                //falls das aktuelle Zeichen ein Großbuchstabe ist 
                if (char.IsLower(c))
                {
                    //Anzahl erhöhen
                    count++;
                }
                //if(c >= 'a'&& c<= 'z' || c== 'ö' ||...)
                //{

                //}
            }

            return count >= minCount;
        }

        private bool PaswordContainsUppercaseCharacter(string text, int minCount)
        {
            int count = 0;
            foreach (char c in text)
            {
                //falls das aktuelle Zeichen ein Kleinbuchstabe ist 
                if (char.IsUpper(c))
                {
                    //Anzahl erhöhen
                    count++;
                }
                //if(c >= 'a'&& c<= 'z' || c== 'ö' ||...)
                //{

                //}
            }

            return count >= minCount;
        }

        private bool PaswordContainsSpecialCharacter(string text, int minCount)
        {
            string allowedChars = "!§$%&/(){}[]=?`´*+~#'@^°,;.:-_|";
            int count = 0;
            foreach (char c in text)
            {

                if (allowedChars.Contains(c))
                {
                    //Anzahl erhöhen
                    count++;
                }

            }

            return count >= minCount;
        }
    }
}