using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact model)
        {
            if (ModelState.IsValid)
            {
                // Handle the form submission
                // For example, send an email or save to database
                // ...

                // Redirect to a thank you page or show a success message
                ViewBag.Message = "Your message has been sent!";
                ModelState.Clear();
            }
            return View(model);
        }
    }
}

