using LilValidation.Core;
using LilValidation.Sample.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LilValidation.Tests.Core
{
    [TestClass]
    public class BoolValidationContractExtensionsTests
    {
        Person person = new Person();
        ValidationContract<Person, bool> contract;

        public BoolValidationContractExtensionsTests()
        {
            contract = new ValidationContract<Person, bool>(person, p => p.Active);
        }

        #region IsTrue
        [TestMethod]
        [TestCategory("IsTrue Validation")]
        public void ContractShouldFailIsTrueValidation()
        {
            //Person.Active is false
            bool success = contract
                .IsTrue()
                .Success;

            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("IsTrue Validation")]
        public void ContractShouldGenerateIsTrueErrorValidationMessage()
        {
            //contract value is false, validation will fail and add a notification
            IReadOnlyList<ValidationError> errors = contract
                .IsTrue()
                .Build();

            Assert.AreEqual($"{contract.MemberName} falso", errors.First().ErrorCode);
        }

        [TestMethod]
        [TestCategory("IsTrue Validation")]
        public void ContractShouldSuccessIsTrueValidation()
        {
            //contract value now true, validation will success
            person.Active = true;
            contract = new ValidationContract<Person, bool>(person, p => p.Active);

            bool success = contract
                .IsTrue()
                .Success;

            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("IsTrue Validation")]
        public void ObjectShouldGenerateIsTrueErrorCustomizedValidationMessage()
        {
            //contract value is false, validation will fail and add a CUSTOMIZED notification
            IReadOnlyList<ValidationError> errors = contract
                .IsTrue("False", "False Value")
                .Build();

            Assert.AreEqual("False", errors.First().ErrorCode);
            Assert.AreEqual("False Value", errors.First().ErrorDescription);
        }
        #endregion

        #region IsFalse
        [TestMethod]
        [TestCategory("IsFalse Validation")]
        public void ContractShouldFailIsFalseValidation()
        {
            //Person.Active is true
            person.Active = true;
            contract = new ValidationContract<Person, bool>(person, p => p.Active);

            bool success = contract
                .IsFalse()
                .Success;

            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("IsFalse Validation")]
        public void ContractShouldGenerateIsFalseErrorValidationMessage()
        {
            //contract value is true, validation will fail and add a notification
            person.Active = true;
            contract = new ValidationContract<Person, bool>(person, p => p.Active);

            IReadOnlyList<ValidationError> errors = contract
                .IsFalse()
                .Build();

            Assert.AreEqual($"{contract.MemberName} verdadeiro", errors.First().ErrorCode);
        }

        [TestMethod]
        [TestCategory("IsFalse Validation")]
        public void ContractShouldSuccessIsFalseValidation()
        {
            //active is false
            bool success = contract
                .IsFalse()
                .Success;

            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("IsFalse Validation")]
        public void ObjectShouldGenerateIsFalseErrorCustomizedValidationMessage()
        {
            //contract value is true, validation will fail and add a CUSTOMIZED notification
            person.Active = true;
            contract = new ValidationContract<Person, bool>(person, p => p.Active);

            IReadOnlyList<ValidationError> errors = contract
                .IsFalse("True", "True Value")
                .Build();

            Assert.AreEqual("True", errors.First().ErrorCode);
            Assert.AreEqual("True Value", errors.First().ErrorDescription);
        }
        #endregion
    }
}
