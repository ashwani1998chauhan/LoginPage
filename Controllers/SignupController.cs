using Microsoft.AspNetCore.Mvc;
using LoginPage.Models;
using System.Collections.Generic;
using System.Linq;

namespace LoginPage.Controllers
{
    public class SignupController : Controller
    {
        private readonly List<UserModel> _users = new List<UserModel>();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupModel model)
        {
            if (ModelState.IsValid)
            {
                if (IsUsernameTaken(model.Username))
                {
                    ModelState.AddModelError("Username", "Username is already taken. Please choose a different one.");
                    return View("Index", model);
                }

                AddUserToDatabase(model);

                TempData["SignupSuccess"] = true;

                return RedirectToAction("Index", "Home");
            }

            return View("Index", model);
        }

        private bool IsUsernameTaken(string username)
        {
            return _users.Any(u => u.Username == username);
        }

        private void AddUserToDatabase(SignupModel model)
        {
            // In a real application, this is where you would save the user to a database
            _users.Add(new UserModel { Username = model.Username, Password = model.Password });
        }
    }
}
