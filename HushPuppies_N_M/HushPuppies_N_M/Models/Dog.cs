﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HushPuppies_N_M.Models
{
    public class Dog
    {

        //properties
        public string Image { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }

        public int Expirience { get; set; }

        public DateTime Birthdate { get; set; }

        public string Informations { get; set; }

        public string Description { get; set; }

        //ctors
        public Dog() : this("", 0, "", 0, DateTime.MinValue, "", "") { }

        public Dog(string image, int id, string name, int expirience, DateTime birthdate, string informations, string description)
        {
            this.Image = image;
            this.ID = id;
            this.Name = name;
            this.Expirience = expirience;
            this.Birthdate = birthdate;
            this.Informations = informations;
            this.Description = description;
        }

    }
}