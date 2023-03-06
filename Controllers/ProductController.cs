using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _10.Controllers;
using _10.Models;
using _10.Data_Access;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace _10.Controllers
{
    public class ProductController : Controller
    {
            private ProductRippo _ProductRippo = new ProductRippo();
        
            public IActionResult List()
            {
              
            var result = _ProductRippo.GetList();
            return View(result);
               
            }
        public IActionResult Search( string search)
        {
            var result = _ProductRippo.GetList();
            if (search != null)
            {
                ViewBag.Search = search;
                result = result.Where(x => x.Name.Contains(search)).ToList();
            }
            else
            {
                ViewBag.Search = "همه موارد";
            }
            return View(result);
        }

        public IActionResult Create()
        {
            //throw new DivideByZeroException();
            return View();
        }
        public IActionResult Delete(int Id)

        {
            _ProductRippo.Delete(Id);
            return RedirectToAction("List");

        }
        public IActionResult Action()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete2(Product model)
        {
            var result = _ProductRippo.GetList();
            foreach (var p in result)
            {
                if (p.Name == model.Name)
                {
                    _ProductRippo.Delete(p.Id);
                    return RedirectToAction("List");
                }
            }
            return View("Home/Error"); 
        }
        
        [HttpPost]
        public IActionResult Create(Product model)
        {   
            var currentItem = _ProductRippo.GetList().Last();
            var result = _ProductRippo.GetList();

             foreach(var n in  result)
            {
                if(n.Name == model.Name)
                {
                    n.Number = n.Number + model.Number;
                    return RedirectToAction("List");
                }
               
            }
                _ProductRippo.Add(new Product
                {
                    Id = currentItem.Id + 1,
                    Name = model.Name,
                    Number = model.Number,
                    Price = model.Price,
                });
            
            return RedirectToAction("List");
        }
        public IActionResult Edit(int id)

        {
            var entity = _ProductRippo.Get(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(int id, string name, int number, decimal price)

        {
            _ProductRippo.Edite(id, name,number, price);
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Edite2( string name, int number, decimal price)
        {
            var result = _ProductRippo.GetList();
            foreach (var p in result)
            {
                if ((p.Name == name))
                {
                    _ProductRippo.Edite2( name, number, price);
                    return RedirectToAction("List");
                }
            }
            return View("Home/Error");
        }
    }
}
