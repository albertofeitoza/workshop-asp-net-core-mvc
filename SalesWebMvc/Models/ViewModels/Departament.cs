using System;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMvc.Models.ViewModels
{
    public class Departament
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Cnpj { get; set; }
        public string nscricaoEstadual { get; set; }
        public string Responsavel { get; set; }

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departament() {
        }

        public Departament(int id, string nome, string telefone, string endereco, string cnpj, string nscricaoEstadual, string responsavel)
        {
            this.id = id;
            Nome = nome;
            //Telefone = telefone;
            //Endereco = endereco;
            //Cnpj = cnpj;
            //this.nscricaoEstadual = nscricaoEstadual;
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
