using LilValidation.Configuration;
using LilValidation.Core;
using LilValidation.Sample.Models;
using LilValidation.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LilValidation.Tests.Core
{
    [TestClass]
    public class ValidationContractTests
    {
        Person person = new Person();
        ValidationContract<Person, int> contract;

        public ValidationContractTests()
        {
            contract = new ValidationContract<Person, int>(person, p => p.Age);
        }

        [TestMethod]
        public void ValidationContractConstructorShouldInitializeMembers()
        {
            person.Age = 21;
            
            Assert.IsNotNull(contract.MemberName);
            Assert.IsNotNull(contract.MemberValue);
        }

        [TestMethod]
        public void ValidationContractConstructorShouldInitializeDefaultValidatorOptions()
        {
            contract = new ValidationContract<Person, int>(person, p => p.Age);

            Assert.IsNotNull(contract.Options);
            Assert.IsNotNull(contract.Options.Messages);

            Assert.AreEqual(typeof(ValidatorOptions), contract.Options.GetType());
            Assert.AreEqual(typeof(DefaultValidatorMessageCollection), contract.Options.Messages.GetType());
        }

        [TestMethod]
        public void ValidationContractAlternativeConstructorShouldInitializeMembers()
        {
            person.Age = 21;

            contract = new ValidationContract<Person, int>("Age", 21);

            Assert.IsNotNull(contract.MemberName);
            Assert.IsNotNull(contract.MemberValue);
        }

        [TestMethod]
        public void ValidationContractAlternativeConstructorShouldInitializeNotifications()
        {
            IReadOnlyList<ValidationError> errors = new List<ValidationError>
            {
                new ValidationError("ErrorCode", "ErrorDescription")
            };

            contract = new ValidationContract<Person, int>("Age", 21, errors);

            Assert.AreEqual(1, contract.Errors.Count);
        }

        [TestMethod]
        public void ValidationContractAlternativeConstructorShouldInitializeOptions()
        {
            TestValidatorOptions test = new TestValidatorOptions();
            contract = new ValidationContract<Person, int>("Age", 21, null, test);

            Assert.IsNotNull(contract.Options);
            Assert.IsNotNull(contract.Options.Messages);

            Assert.AreEqual(typeof(TestValidatorOptions), contract.Options.GetType());
            Assert.AreEqual(typeof(TestMessageCollection), contract.Options.Messages.GetType());
        }

        [TestMethod]
        public void ValidationContractShouldChangeValidatorOptions()
        {
            contract = new ValidationContract<Person, int>(person, p => p.Age);
            contract.AddValidatorOptions(new TestValidatorOptions());

            Assert.IsNotNull(contract.Options);
            Assert.IsNotNull(contract.Options.Messages);

            Assert.AreEqual(typeof(TestValidatorOptions), contract.Options.GetType());
            Assert.AreEqual(typeof(TestMessageCollection), contract.Options.Messages.GetType());
        }

        [TestMethod]
        public void ValidationContractShouldAddNotification()
        {
            contract.AddError("ErrorCode", "ErrorDescription");
            Assert.AreEqual(1, contract.Errors.Count);
        }

        [TestMethod]
        public void ValidationContractShouldBuild()
        {
            contract.AddError("ErrorCode", "ErrorDescription");
            IReadOnlyList<ValidationError> errors = contract.Build();

            Assert.IsNotNull(errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void ValidationShouldNotSuccess()
        {
            contract.AddError("ErrorCode", "ErrorDescription");
            Assert.IsFalse(contract.Success);
        }
    }
}
