using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;

        }
        public void Seed()
        {
            //testar se existe dados na tabela

            if (_context.Departament.Any()
                || _context.Seller.Any()
                || _context.SallesRecord.Any())

            {
                return; // A base de dados Já foi populada
            }
            Departament d1 = new Departament(1, "TI", "Alberto");
            Departament d2 = new Departament(2, "Impressão","João");
            Departament d3 = new Departament(3, "Pesos e Medidas", "Maria");
            Departament d4 = new Departament(4, "Suprimentos", "Carlos");

            Seller s1 = new Seller(1, "Vendedor Sistema", "teste@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Vendedor Sistema1", "teste@gmail.com", new DateTime(1998, 4, 21), 1000.0, d2);
            Seller s3 = new Seller(3, "Vendedor Sistema2", "teste@gmail.com", new DateTime(1998, 4, 21), 1000.0, d3);
            Seller s4 = new Seller(4, "Vendedor Sistema3", "teste@gmail.com", new DateTime(1998, 4, 21), 1000.0, d4);

            SallesRecord r1 = new SallesRecord(1, new DateTime(1998, 1, 21), 11000.0, SaleStatus.Billed, s1);
            SallesRecord r2 = new SallesRecord(2, new DateTime(1998, 1, 20), 11000.0, SaleStatus.Billed, s2);
            SallesRecord r3 = new SallesRecord(3, new DateTime(1998, 1, 21), 11000.0, SaleStatus.Billed, s3);
            SallesRecord r4 = new SallesRecord(4, new DateTime(1998, 1, 27), 11000.0, SaleStatus.Billed, s4);




            _context.Departament.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4);

            _context.SallesRecord.AddRange(r1, r2, r3, r4);

            _context.SaveChanges();

        }

    }
}
