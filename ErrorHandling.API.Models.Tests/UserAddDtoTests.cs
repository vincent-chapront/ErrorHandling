using ErrorHandling.Service.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ErrorHandling.API.Dto.Tests
{
    public class UserAddDtoTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Valid_Nominal()
        {
            var userAddDto = GetNominalDto();

            var mockCompanyService = new Mock<ICompanyService>();
            mockCompanyService.Setup(x => x.Exists(It.IsAny<int>())).Returns(true);
            var mockServiceProvider = new Mock<IServiceProvider>();
            mockServiceProvider.Setup(x => x.GetService(typeof(ICompanyService))).Returns(mockCompanyService.Object);
            var context = new ValidationContext(userAddDto, serviceProvider: mockServiceProvider.Object, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(userAddDto, context, results, true);
            Assert.True(isValid);
            Assert.IsEmpty(results);
        }

        [Test]
        public void Valid_CompanyNotExisting_Invalid()
        {
            var userAddDto = GetNominalDto();

            var mockCompanyService = new Mock<ICompanyService>();
            mockCompanyService.Setup(x => x.Exists(It.IsAny<int>())).Returns(false);
            var mockServiceProvider = new Mock<IServiceProvider>();
            mockServiceProvider.Setup(x => x.GetService(typeof(ICompanyService))).Returns(mockCompanyService.Object);
            var context = new ValidationContext(userAddDto, serviceProvider: mockServiceProvider.Object, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(userAddDto, context, results, true);
            Assert.False(isValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(nameof(userAddDto.CompanyId), results[0].MemberNames.First());
        }

        [TestCase("", Description = "Name is Empty")]
        [TestCase(null, Description = "Name is Null")]
        public void Valid_CompanyNotExisting_Invalid(string name)
        {
            var userAddDto = GetNominalDto();
            userAddDto.Name = name;

            var mockCompanyService = new Mock<ICompanyService>();
            mockCompanyService.Setup(x => x.Exists(It.IsAny<int>())).Returns(true);
            var mockServiceProvider = new Mock<IServiceProvider>();
            mockServiceProvider.Setup(x => x.GetService(typeof(ICompanyService))).Returns(mockCompanyService.Object);
            var context = new ValidationContext(userAddDto, serviceProvider: mockServiceProvider.Object, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(userAddDto, context, results, true);
            Assert.False(isValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(nameof(userAddDto.Name), results[0].MemberNames.First());
        }

        private static UserAddDto GetNominalDto()
        {
            return new UserAddDto()
            {
                Name = "Name",
                CompanyId = 1,
                Email = "email@example.com",
                ExpirationDate = DateTime.Now.AddDays(100),
                QuotaInSecond = 100,
                SubscriptionPlans = SubscriptionPlans.Standard
            };
        }
    }
}