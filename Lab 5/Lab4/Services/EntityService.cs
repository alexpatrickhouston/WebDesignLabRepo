using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab4.Data.Entities;
using Lab4.Models.View;
using Lab4.Repositories;

namespace Lab4.Services
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _repository;

        public EntityService(IEntityRepository respository)
        {
            _repository = respository;
        }

        public PetViewModel GetPet(int id)
        {
            var pet = _repository.GetPet(id);
            return MapToPetViewModel(pet);
        }

        public IEnumerable<PetViewModel> GetPetsForUser(int userId)
        {
            var petViewModels = new List<PetViewModel>();

            var pets = _repository.GetPetsForUser(userId);

            foreach (var pet in pets)
            {
                petViewModels.Add(MapToPetViewModel(pet));
            }

            return petViewModels;
        }

        public void SavePet(PetViewModel petViewModel)
        {
            //throw new Exception("Test Exception");

            var pet = MapToPet(petViewModel);

            _repository.SavePet(pet);
        }

        public void UpdatePet(PetViewModel petViewModel)
        {
            var pet = _repository.GetPet(petViewModel.Id);

            CopyToPet(petViewModel, pet);

            _repository.UpdatePet(pet);
        }

        public void DeletePet(int id)
        {
            _repository.DeletePet(id);
        }

        private Pet MapToPet(PetViewModel petViewModel)
        {
            return new Pet
            {
                Id = petViewModel.Id,
                Name = petViewModel.Name,
                Age = petViewModel.Age,
                NextCheckup = petViewModel.NextCheckup,
                VetName = petViewModel.VetName,
                UserId = petViewModel.UserId
            };
        }

        private PetViewModel MapToPetViewModel(Pet pet)
        {
            var petViewModel = new PetViewModel
            {
                Id = pet.Id,
                Name = pet.Name,
                Age = pet.Age,
                NextCheckup = pet.NextCheckup,
                VetName = pet.VetName,
                UserId = pet.UserId
            };

            petViewModel.CheckupAlert = (petViewModel.NextCheckup - DateTime.Now).Days < 14;

            return petViewModel;
        }

        private void CopyToPet(PetViewModel petViewModel, Pet pet)
        {
            pet.Id = petViewModel.Id;
            pet.Name = petViewModel.Name;
            pet.Age = petViewModel.Age;
            pet.NextCheckup = petViewModel.NextCheckup;
            pet.VetName = petViewModel.VetName;
            pet.UserId = petViewModel.UserId;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _repository.GetUser(id);

            return (MapToUserViewModel(user));
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var userViewModels = new List<UserViewModel>();

            var users = _repository.GetAllUsers();
            foreach (var user in users)
            {
                userViewModels.Add(MapToUserViewModel(user));
            }

            return userViewModels;
        }

        public void SaveUser(UserViewModel userViewModel)
        {
            _repository.SaveUser(MapToUser(userViewModel));
        }

        public void UpdateUser(UserViewModel userViewModel)
        {
            var user = _repository.GetUser(userViewModel.Id);
            CopyToUser(userViewModel, user);

            _repository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _repository.DeleteUser(id);
        }

        private User MapToUser(UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                EmailAddress = userViewModel.EmailAddress,
                DateOfBirth = userViewModel.DOB,
                YearsInSchool = userViewModel.YearsInSchool
            };
        }

        private UserViewModel MapToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                DOB = user.DateOfBirth,
                YearsInSchool = user.YearsInSchool
            };
        }

        private void CopyToUser(UserViewModel userViewModel, User user)
        {
            user.FirstName = userViewModel.FirstName;
            user.MiddleName = userViewModel.MiddleName;
            user.LastName = userViewModel.LastName;
            user.EmailAddress = userViewModel.EmailAddress;
            user.DateOfBirth = userViewModel.DOB;
            user.YearsInSchool = userViewModel.YearsInSchool;
        }
    }
}
