using System;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMvc.Models.ViewModels
{
    public class Departament
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Responsavel { get; set; }

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departament() {
        }

        public Departament(int id, string nome, string responsavel)
        {
            this.id = id;
            Nome = nome;
            Responsavel = responsavel;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }

    }
}
