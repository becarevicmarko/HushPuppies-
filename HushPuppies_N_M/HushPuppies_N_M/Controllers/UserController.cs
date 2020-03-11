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
                
                if (char.IsLower(c))
                {
                   
                    count++;
                }
               
            }

            return count >= minCount;
        }

        private bool PaswordContainsUppercaseCharacter(string text, int minCount)
        {
            int count = 0;
            foreach (char c in text)
            {
               
                if (char.IsUpper(c))
                {
                    
                    count++;
                }
                
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
                   
                    count++;
                }

            }

            return count >= minCount;
        }
    }
}