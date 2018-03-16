using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Lab4.Data;
using Lab4.Data.Entities;

namespace myappapi.Controllers
{
    [RoutePrefix("api/pets")]
    public class PetController : ApiController
    {
        private AppDbContext _dbContext;
        public PetController()
        {
            _dbContext = new AppDbContext();
        }
        // GET: Pet
        [HttpGet]
        public IEnumerable<Pet> GetAllPets()
        {
            return _dbContext.Pets.ToList();
        }
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetPet(int id)
        {
            var pet = _dbContext.Pets.FirstOrDefault((p) => p.Id == id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }
    }
}