
namespace PetShop
{
    public  class Supplies
    {
        // Instance Variables 
        public string Name { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }

        // Constructor Declaration of Class 
        public Supplies(string name, string amount, string price)
        {
            Name = name;
            Price = amount;
            Amount = price;

        }
        public Supplies()
        {

        }
    }

    public class FelineSupplies : Supplies
    {
        public FelineSupplies(string name, string amount, string price)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }

        public FelineSupplies()
        {

        }
    }

    public class CanineSupplies : Supplies
    {
        public CanineSupplies(string name, string amount, string price)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }


        public CanineSupplies()
        {

        }
    }
}
