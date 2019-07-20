using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    public class DepartamentsController : Controller
    {
        public IActionResult Index()
        {

            List<Departament> list = new List<Departament>();
            list.Add(new Departament { id = 1, Nome = "Eletronics" });
            list.Add(new Departament { id = 2, Nome = "Fashion" });
            list.Add(new Departament { id = 3, Nome = "Casas" });
            list.Add(new Departament { id = 4, Nome = "Carros" });
            list.Add(new Departament { id = 5, Nome = "Status" });

            return View(list);
        }
    }
}