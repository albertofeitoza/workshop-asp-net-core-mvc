
using System;
using SalesWebMvc.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMvc.Models
{
    public class Seller
    {

        public int id { get; set; }
        public string name  { get; set; }
        public string email { get; set; }
        public DateTime BirthDate { get; set; } // Data de nascimento
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public int DepartamentId { get; set; }
        public ICollection<SallesRecord> Sales { get; set; } = new List<SallesRecord>();


        public Seller() {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void AddSales(SallesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SallesRecord sr)
        {

            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {

            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
