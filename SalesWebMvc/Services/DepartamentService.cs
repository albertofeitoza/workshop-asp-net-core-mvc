using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class DepartamentService
    {

        private readonly SalesWebMvcContext _context;

        public DepartamentService(SalesWebMvcContext context)
        {
            _context = context;
        }


        public List<Departament> FindAll()
        {
            return _context.Departament.OrderBy(x => x.Nome).ToList();
        }

    }
}
