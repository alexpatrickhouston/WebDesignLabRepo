using System;
using NUnit.Framework;
using FakeItEasy;
using Lab4.Data.Entities;
using Lab4.Repositories;
using Lab4.Services;

namespace Lab5.tests
{
    [TestFixture]
    public class EntityServiceTests
    {
        private IEntityRepository _entityRepository;
        [SetUp]
        public void SetUp()
        {
            _entityRepository = A.Fake<IEntityRepository>();
        }
        [Test]
        public void NoCheckupCase()
        {
            A.CallTo(() => _entityRepository.GetPet(A<int>.Ignored)).Returns(new Pet
            {
                NextCheckup = DateTime.Now.AddDays(29)
            });
            var petService = new EntityService(_entityRepository);
            var petViewModel = petService.GetPet(1);
            Assert.IsFalse(petViewModel.CheckupAlert);
        }
        [Test]
        public void CheckupCase()
        {
            A.CallTo(() => _entityRepository.GetPet(A<int>.Ignored)).Returns(new Pet
            {
                NextCheckup = DateTime.Now.AddDays(12)
            });
            var petService = new EntityService(_entityRepository);
            var petViewModel = petService.GetPet(1);
            Assert.IsTrue(petViewModel.CheckupAlert);
        }
    }
}
