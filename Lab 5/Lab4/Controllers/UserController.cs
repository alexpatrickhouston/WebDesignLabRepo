using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4.Models.View;
using Lab4.Data.Entities;
using Lab4.Data;
using Lab4.Services;

namespace Lab4.Controllers
{
    public class UserController : Controller
    {
        private readonly IEntityService _userService;

        public UserController(IEntityService userService)
        {
            // __userService = new UserService();
            _userService = userService;
        }
        public ActionResult Index()
        {
            var users = _userService.GetAllUsers();

            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {

                _userService.SaveUser(userViewModel);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var user = _userService.GetUser(id);

            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _userService.GetUser(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(userViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            _userService.DeleteUser(id);

            return RedirectToAction("List");
        }

    }  
}
