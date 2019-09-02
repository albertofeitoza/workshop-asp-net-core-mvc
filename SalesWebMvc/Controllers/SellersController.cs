using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exeptions;
    
namespace SalesWebMvc.Controllers
{


    public class SellersController : Controller
    {

        private readonly SellerService _SellerService;
        private readonly DepartamentService _DepartamentService;

        public SellersController(SellerService sellerService, DepartamentService departamentService)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _SellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Details(int? id)
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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //testar se o Id  existe no BD
            var obj = _SellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Departament> departaments = _DepartamentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departaments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.id)
            {
                return BadRequest();
            }

            try
            {
                _SellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch(DbConcurrencyExeption)
            {
                return BadRequest();

            }
           


         
        }
    }
}