using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSales.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();
        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addSales(SalesRecord sr)
        {
            SalesRecords.Add(sr);
        }

        public void removeSales(SalesRecord sr)
        {
            SalesRecords.Remove(sr);
        }

        public double totalSales(DateTime Initial, DateTime Final)
        {
            return SalesRecords.Where(x => x.Date >= Initial && x.Date <= Final).Sum(x => x.Amount);
        }
    }
}
