using _10.Data_Access;
using _10.Models;
using Microsoft.AspNetCore.Mvc;

namespace _10.Controllers
{
    public class AccountController : Controller
    {
        private AcountRippo _AcountRippo = new AcountRippo();
        private ProductRippo _ProductRippo = new ProductRippo();

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult AccountList()
        {
            var result = _AcountRippo.GetList();
            return View(result);
        }
        public IActionResult AdminList()
        {
            var result = _ProductRippo.GetList();
            return View(result);
        }
        public IActionResult memberList()
        {
            var result = _ProductRippo.GetList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Account model)
        {
            if (model.Id == 1)
            {
                model.AdminChecker = true;
            }
            return RedirectToAction("AccountList");
        }
        //[HttpPost]
        //public IActionResult Create(Account model)
        //{
        //    var currentItem = _AcountRippo.GetList().Last();
        //    _AcountRippo.Add(new Account
        //    {
        //        Id = currentItem.Id + 1,
        //        Name = model.Name,
        //        Email = model.Email,
        //        Password = model.Password,
        //        Phone = model.Phone
        //    });
        //    return RedirectToAction("List");
        //}
        


    }

    
}
