﻿using System;
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
            Departament d1 = new Departament(1, "Computers","12132321","Rua","00000","213131","Alberto");
            Departament d2 = new Departament(2, "Electronics", "12132321", "Rua", "00000", "213131", "Alberto");
            Departament d3 = new Departament(3, "Fasshion", "12132321", "Rua", "00000", "213131", "Alberto");
            Departament d4 = new Departament(4, "Books", "12132321", "Rua", "00000", "213131", "Alberto");

            Seller s1 = new Seller(1, "Vendedor Sistema", "teste@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Vendedor Sistema1", "teste@gmail.com", new DateTime(1998, 4, 21), 1000.0, d2);
            Seller s3 = new Seller(3, "Vendedor Sistema2", "teste@gmail.com", new DateTime(1998, 4, 21), 1000.0, d3);
            Seller s4 = new Seller(4, "Vendedor Sistema3", "teste@gmail.com", new DateTime(1998, 4, 21), 1000.0, d4);

            SallesRecord r1 = new SallesRecord(1, new DateTime(1998, 1, 21), 11000.0, SaleStatus.Billed, s1);
            //  SallesRecord r2 = new SallesRecord(2, new DateTime(1998, 1, 21), 11000.0, SaleStatus.Billed, s1);
            SallesRecord r3 = new SallesRecord(1, new DateTime(1998, 1, 20), 11000.0, SaleStatus.Billed, s2);
            // SallesRecord r4 = new SallesRecord(2, new DateTime(1998, 1, 20), 11000.0, SaleStatus.Billed, s2);
            SallesRecord r5 = new SallesRecord(1, new DateTime(1998, 1, 21), 11000.0, SaleStatus.Billed, s3);
            //SallesRecord r6 = new SallesRecord(2, new DateTime(1998, 1, 22), 11000.0, SaleStatus.Billed, s3);
            SallesRecord r7 = new SallesRecord(1, new DateTime(1998, 1, 27), 11000.0, SaleStatus.Billed, s4);
           // SallesRecord r8 = new SallesRecord(2, new DateTime(1998, 1, 27), 11000.0, SaleStatus.Billed, s4);



            _context.Departament.AddRange(d1,d2,d3,d4);

            _context.Seller.AddRange(s1, s2 ,s3 ,s4);

            _context.SallesRecord.AddRange(r1, r3, r5,  r7);

            _context.SaveChanges();

        }

    }
}
