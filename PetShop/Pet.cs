using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{

    public class Pet
    {

        // Instance Variables 
        public string Name { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }

        // Constructor Declaration of Class 
        public Pet(string name, string type, string price, string amount)
        {
            Name = name;
            Type = type;
            Price = price;
            Amount = amount;
        }
        public Pet()
        {

        }

    }

    public class Feline : Pet
    {
        public Feline(string name, string type, string price, string amount) 
        {
            Name = name;
            Type = type;
            Price = price;
            Amount = amount;
        }

        public Feline()
        {

        }
    }

    public class Canine : Pet
    {
        public Canine(string name, string type, string price, string amount) 
        {
            Name = name;
            Type = type;
            Price = price;
            Amount = amount;
        }

        public Canine()
        {

        }
    }
}