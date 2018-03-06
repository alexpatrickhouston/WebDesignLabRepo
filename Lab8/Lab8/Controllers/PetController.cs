using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab8.Data;
using Lab8.Data.Entities;
using Lab8.Models.View;
using Lab8.Services;
using log4net;
using Microsoft.AspNet.Identity;

namespace Lab4.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private readonly IEntityService _petService;
        private readonly ILog _log = log4net.LogManager.GetLogger(typeof(PetController));

        public PetController(IEntityService petService)
        {
            _petService = petService;
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            _log.Debug("Getting list of pets for user: " + userId);



            var petViewModels = _petService.GetPetsForUser(userId);

            return View(petViewModels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PetViewModel petViewModel)
        {
            _log.Info("Creating pet");

            if (ModelState.IsValid)
            {
                try
                {
                    _petService.SavePet(petViewModel);
                }
                catch (Exception ex)
                {
                    _log.Error("Failed to save pet.", ex);
                    throw;
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pet = _petService.GetPet(id);

            return View(pet);
        }

        [HttpPost]
        public ActionResult Edit(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                _petService.UpdatePet(petViewModel);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var pet = _petService.GetPet(id);

            _petService.DeletePet(id);

            return RedirectToAction("Index");
        }

    }
}