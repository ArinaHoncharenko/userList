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
                new User { Id = 1, FirstName = "Іван", LastName = "Петров", Email = "ivan@example.com", RegistrationDate = DateTime.Now },
                new User { Id = 2, FirstName = "Марія", LastName = "Сидорова", Email = "maria@example.com", RegistrationDate = DateTime.Now },
                new User { Id = 3, FirstName = "Петро", LastName = "Коваль", Email = "petro@example.com", RegistrationDate = DateTime.Now },
            };
        }

        public IActionResult Index()
        {
            return View(userList);
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