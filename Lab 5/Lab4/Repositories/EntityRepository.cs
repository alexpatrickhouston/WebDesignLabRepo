using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab4.Data.Entities;
using Lab4.Data;

namespace Lab4.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly AppDbContext _dbContext;

        public EntityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Pet GetPet(int id)
        {
            return _dbContext.Pets.Find(id);
        }

        public IEnumerable<Pet> GetPetsForUser(int userId)
        {
            return _dbContext.Pets.Where(pet => pet.UserId == userId).ToList();
        }

        public void SavePet(Pet pet)
        {
            _dbContext.Pets.Add(pet);

            _dbContext.SaveChanges();
        }

        public void UpdatePet(Pet pet)
        {
            _dbContext.SaveChanges();
        }

        public void DeletePet(int id)
        {
            var pet = _dbContext.Pets.Find(id);

            if (pet == null) return;

            _dbContext.Pets.Remove(pet);
            _dbContext.SaveChanges();
        }
        public User GetUser(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users;
        }

        public void SaveUser(User user)
        {
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);

            if (user == null) return;

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}