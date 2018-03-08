using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FakeItEasy;
using Lab8.Data.Entities;
using Lab8.Repositories;
using Lab8.Services;

namespace Lab8.tests
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
