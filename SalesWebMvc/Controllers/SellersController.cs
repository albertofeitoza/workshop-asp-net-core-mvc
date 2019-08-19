using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _SellerService;
        private readonly DepartamentService _DepartamentService;

        public SellersController(SellerService sellerService , DepartamentService departamentService)
        {
            _SellerService = sellerService;
            _DepartamentService = departamentService;
        }
        public IActionResult Index()
        {
            var list = _SellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {

            var departaments = _DepartamentService.FindAll();
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            
            _SellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
            
        }



        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _SellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);   
                                 
        }
    }
}