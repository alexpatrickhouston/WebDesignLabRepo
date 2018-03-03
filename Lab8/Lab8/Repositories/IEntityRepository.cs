using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab8.Data.Entities;

namespace Lab8.Repositories
{
    public interface IEntityRepository
    {

        Pet GetPet(int id);

        IEnumerable<Pet> GetPetsForUser(int userId);

        void SavePet(Pet pet);

        void UpdatePet(Pet user);

        void DeletePet(int id);
        /*

        User GetUser(int id);

        IEnumerable<User> GetAllUsers();

        void SaveUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);
        */
    }
}