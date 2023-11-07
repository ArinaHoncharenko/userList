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
            userList = new List<User>
            {
               new User { Id = 0001, FirstName = "Ольга", LastName = "Богомолова", Email = "olha@example.com", RegistrationDate = new DateTime(2020, 5, 12) },
               new User { Id = 0002, FirstName = "Олександр", LastName = "Синенко", Email = "oleksandr@example.com", RegistrationDate = new DateTime(2021, 8, 10) },
               new User { Id = 0003, FirstName = "Петро", LastName = "Польовий", Email = "petro@example.com", RegistrationDate = new DateTime(2022, 12, 23) },
               new User { Id = 0004, FirstName = "Олег", LastName = "Косенко", Email = "oleh@example.com", RegistrationDate = new DateTime(2021, 04, 08) },
               new User { Id = 0005, FirstName = "Станіслав", LastName = "Триліс", Email = "stanislav@example.com", RegistrationDate = new DateTime(2022, 01, 29) },
            };
        }

        public IActionResult Index()
        {
            return View("Index", userList);
        }

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
