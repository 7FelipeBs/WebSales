using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSales.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void addSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public void removeSeller(Seller seller)
        {
            Sellers.Remove(seller);
        }

        public double totalSales(DateTime Initial, DateTime Final)
        {
            return Sellers.Sum(x => x.totalSales(Initial, Final));
        }
    }
}
