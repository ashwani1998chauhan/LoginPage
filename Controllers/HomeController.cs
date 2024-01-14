﻿using Microsoft.AspNetCore.Mvc;
using DNTCaptcha.Core;
using LoginPage.Models;
using System.Collections.Generic;

namespace LoginPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<UserModel> _users = new List<UserModel>
        {
            new UserModel { Username = "123", Password = "Password123" },
          
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateDNTCaptcha(ErrorMessage = "Please enter correct captcha")]
        public IActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {  
                var user = _users.Find(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                   
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                }


            }

        
            return View("Index", model);
        }

        public IActionResult DownloadUserManual()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/UserManual.pdf");

            if (System.IO.File.Exists(filePath))
            {
                var fileContent = System.IO.File.ReadAllBytes(filePath);
                var contentType = "application/pdf"; // Set the content type for PDF files
                var fileName = "UserManual.pdf";

                return File(fileContent, contentType, fileName);
            }

            return NotFound();
        }
    }
}
