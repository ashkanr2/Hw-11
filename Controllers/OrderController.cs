using _10.Data_Access;
using Microsoft.AspNetCore.Mvc;

namespace _10.Controllers
{
    public class OrderController : Controller
    {
        private ProductRippo _ProductRippo = new ProductRippo();
        public IActionResult List()
        {
            decimal? TotalPrice = 0;
            var result = _ProductRippo.GetList();
            foreach (var item in result)
            {
                if ((item.PersonId != null) && (item.Number2 > 0))
                {
                     TotalPrice = (item.Price * item.Number2)+TotalPrice;
                }
                ViewBag.TotalPrice = TotalPrice;
            }
                return View(result); 
           
        }
        public IActionResult Delete(int Id)

        {
            foreach (var item in _ProductRippo.GetList())
            {
                if (item.Id == Id)
                {

                    item.Number = item.Number + item.Number2;
                    item.Number2 = 0;
                    item.PersonId = null;
                    break;
                }
            }

            return RedirectToAction("List");

        }
        public IActionResult Search(string search)
        {
            var result = _ProductRippo.GetList();
            if (search != null)
            {
                result = result.Where(x => x.Name.Contains(search)).ToList();
            }
            return View(result);
        }
        public IActionResult Delete2(int Id)

        {
            foreach (var item in _ProductRippo.GetList())
            {
                if (item.Id == Id)
                {

                    item.Number++;
                    item.Number2 --;
                    break;
                }
            }

            return RedirectToAction("List");

        }
        public IActionResult Add(int Id)

        {
            foreach (var item in _ProductRippo.GetList())
            {
                if (item.Id == Id)
                {
                    item.Number2 ++;
                    item.Number--;
                    item.PersonId = 2;
                    break;
                }
            }
            return RedirectToAction("List");
        }
    }
}
