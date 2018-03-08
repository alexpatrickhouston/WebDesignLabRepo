using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab8.Models.View;

namespace Lab8.Services
{
    public interface IEntityService
    {
        PetViewModel GetPet(int id);

        IEnumerable<PetViewModel> GetPetsForUser(string userId);

        void SavePet(string userId,PetViewModel pet);

        void UpdatePet(PetViewModel user);


        void DeletePet(int id);
        /*
        UserViewModel GetUser(int id);

        IEnumerable<UserViewModel> GetAllUsers();

        void SaveUser(UserViewModel user);

        void UpdateUser(UserViewModel user);

        void DeleteUser(int id);
        */
    }
}