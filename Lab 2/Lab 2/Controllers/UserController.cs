using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_2.Data.Entities;
using Lab_2.Data;
namespace Lab_2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            user.Id = InMemoryDatabase.NextId();
            InMemoryDatabase.Users.Add(user);
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            var users = InMemoryDatabase.Users;
            return View(users);
        }
        public ActionResult Details(int id)
        {
            User user = InMemoryDatabase.FindUser(id);
            return View(user);
        }
        public ActionResult Delete(int id)
        {
            InMemoryDatabase.DeleteUser(id);
            return RedirectToAction("List");
        }
    }
}