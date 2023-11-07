using Microsoft.AspNetCore.Mvc;
using oop6_userList.Models;
using System.Diagnostics;
using System.Collections.Generic;

namespace oop6_userList.Controllers
{
    public class UserController : Controller
    {
        private List<User> userList;

        public UserController()
        {
            // Ініціалізація списку користувачів
            userList = new List<User>
            {
                new User { Id = 1, FirstName = "Ольга", LastName = "Богомолова", Email = "olha@example.com", RegistrationDate = new DateTime(2020, 5, 12) },
                new User { Id = 2, FirstName = "Олександр", LastName = "Синенко", Email = "oleksandr@example.com", RegistrationDate = new DateTime(2021, 8, 10) },
                new User { Id = 3, FirstName = "Петро", LastName = "Польовий", Email = "petro@example.com", RegistrationDate = new DateTime(2022, 12, 23) },
                new User { Id = 4, FirstName = "Олег", LastName = "Косенко", Email = "oleh@example.com", RegistrationDate = new DateTime(2021, 04, 08) },
                new User { Id = 5, FirstName = "Станіслав", LastName = "Триліс", Email = "stanislav@example.com", RegistrationDate = new DateTime(2022, 01, 29) },
            };
        }

        public IActionResult Index()
        {
            // Відображення списку користувачів
            return View("Index", userList);
        }

        public IActionResult UserDetails(int id)
        {
            User? user = userList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                // Повернення статусу 404 (Not Found) у випадку, якщо користувача не знайдено
                return NotFound();
            }
            // Відображення докладної інформації про користувача
            return View(user);
        }
    }
}
