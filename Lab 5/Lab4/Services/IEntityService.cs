using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab4.Models.View;

namespace Lab4.Services
{
    public interface IEntityService
    {
        PetViewModel GetPet(int id);

        IEnumerable<PetViewModel> GetPetsForUser(int userId);

        void SavePet(PetViewModel pet);

        void UpdatePet(PetViewModel user);


        void DeletePet(int id);

        UserViewModel GetUser(int id);

        IEnumerable<UserViewModel> GetAllUsers();

        void SaveUser(UserViewModel user);

        void UpdateUser(UserViewModel user);

        void DeleteUser(int id);
    }
}