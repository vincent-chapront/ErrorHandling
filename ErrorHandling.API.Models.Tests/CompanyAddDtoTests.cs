using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ErrorHandling.API.Dto.Tests
{
    public class CompanyAddDtoTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Valid_Nominal()
        {
            var companyAddDto = GetNominalDto();

            var context = new ValidationContext(companyAddDto);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(companyAddDto, context, results, true);
            Assert.True(isValid);
            Assert.IsEmpty(results);
        }

        [TestCase("", Description = "Name is Empty")]
        [TestCase(null, Description = "Name is Null")]
        public void Valid_NameMissing_Invalid(string description)
        {
            var companyAddDto = GetNominalDto();
            companyAddDto.Name = description;

            var context = new ValidationContext(companyAddDto);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(companyAddDto, context, results, true);
            Assert.False(isValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(nameof(companyAddDto.Name), results[0].MemberNames.First());
        }

        [TestCase("", Description = "Description is Empty")]
        [TestCase(null, Description = "Description is Null")]
        public void Valid_DescriptionMissing_Invalid(string description)
        {
            var companyAddDto = GetNominalDto();
            companyAddDto.Description = description;

            var context = new ValidationContext(companyAddDto);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(companyAddDto, context, results, true);
            Assert.False(isValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(nameof(companyAddDto.Description), results[0].MemberNames.First());
        }

        [TestCase(0, Description = "UserCountMax is 0")]
        [TestCase(-1, Description = "UserCountMax is negative")]
        [TestCase(11, Description = "UserCountMax is greater than 10")]
        public void Valid_UserCountMaxIsOutsideRange_Invalid(int userCountMax)
        {
            var companyAddDto = GetNominalDto();
            companyAddDto.UserCountMax = userCountMax;

            var context = new ValidationContext(companyAddDto);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(companyAddDto, context, results, true);
            Assert.False(isValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(nameof(companyAddDto.UserCountMax), results[0].MemberNames.First());
        }

        private static CompanyAddDto GetNominalDto()
        {
            return new CompanyAddDto()
            {
                Name = "Name",
                Description = "Description",
                UserCountMax = 1
            };
        }
    }
}