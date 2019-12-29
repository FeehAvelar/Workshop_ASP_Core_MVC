using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Associations
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        //Constructors
        public Departament()
        {
            
        }

        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void addSeller (Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));

            /*
            double value = 0.0;
            foreach (Seller seller in Sellers)
            {
                value += seller.TotalSales(initial, final);
            }
            return value;
            */
        }
    }
}
