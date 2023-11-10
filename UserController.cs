using Microsoft.AspNetCore.Mvc;
using oop6_userList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace oop6_userList.Controllers
{
    public class UserController : Controller
    {
        private static List<User> userList = new List<User>
        {
            new User { Id = 1, FirstName = "Ольга", LastName = "Богомолова", Email = "olha@example.com", RegistrationDate = new DateTime(2020, 5, 12) },
            new User { Id = 2, FirstName = "Олександр", LastName = "Синенко", Email = "oleksandr@example.com", RegistrationDate = new DateTime(2021, 8, 10) },
            new User { Id = 3, FirstName = "Петро", LastName = "Польовий", Email = "petro@example.com", RegistrationDate = new DateTime(2022, 12, 23) },
            new User { Id = 4, FirstName = "Олег", LastName = "Косенко", Email = "oleh@example.com", RegistrationDate = new DateTime(2021, 4, 8) },
            new User { Id = 5, FirstName = "Станіслав", LastName = "Триліс", Email = "stanislav@example.com", RegistrationDate = new DateTime(2022, 1, 29) },
        };

        // Додавання користувача
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User newUser)
        {
            // Перевірка наявності символу "@" в полі Email
            if (!Regex.IsMatch(newUser.Email, @"@"))
            {
                ModelState.AddModelError("Email", "Некоректний формат електронної пошти.");
            }

            if (ModelState.IsValid)
            {
                newUser.Id = userList.Max(u => u.Id) + 1;
                newUser.RegistrationDate = DateTime.Now;
                userList.Add(newUser);

                // Перенаправлення на сторінку деталей нового користувача
                return RedirectToAction("Index");
            }

            return View(newUser);
        }

        // Відображення списку користувачів
        public IActionResult Index()
        {
            return View(userList);
        }

        // Відображення деталей користувача
        public IActionResult UserDetails(int id)
        {
            User? user = userList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
    }
}
