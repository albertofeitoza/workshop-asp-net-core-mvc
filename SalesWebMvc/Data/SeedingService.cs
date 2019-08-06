using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvc context)
        {
            _context = context;

        }
        public void Seed()
        {
            //testar se existe dados na tabela

            if (_context.Departament.Any());

        }

    }
}
