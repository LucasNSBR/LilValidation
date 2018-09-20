using LilValidation.Core;
using LilValidation.Sample.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LilValidation.Tests.Core
{
    [TestClass]
    public class GuidValidationContractExtensionsTests
    {
        Person person = new Person();
        ValidationContract<Person, Guid> contract;
        Guid IdOne = new Guid("add6655a-4269-452a-b3b7-c5081864313f");
        Guid IdTwo = new Guid("6e2b32fe-a4d1-4019-a080-5f5b325c71d6");

        public GuidValidationContractExtensionsTests()
        {
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);
        }

        #region Equals
        [TestMethod]
        [TestCategory("Equals Validation")]
        public void EqualsValidationShouldBeSuccess()
        {
            person.Id = IdOne;
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);

            //Id's are equal, operation will success
            bool success = contract.IsEqual(IdOne).Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("Equals Validation")]
        public void EqualsValidationShouldFail()
        {
            person.Id = IdOne;
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);
            
            //Id's are different, operation will fail
            bool success = contract.IsEqual(IdTwo).Success;
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("Equals Validation")]
        public void EqualsValidationShouldFailAndAddNotification()
        {
            person.Id = IdOne;
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);

            //Id's are different, operation will fail
            string errorCode = contract.IsEqual(IdTwo).Build().First().ErrorCode;
            Assert.AreEqual($"{IdOne} deve ser igual a {IdTwo}", errorCode);
        }
        #endregion

        #region NotEquals
        [TestMethod]
        [TestCategory("NotEquals Validation")]
        public void NotEqualsValidationShouldBeSuccess()
        {
            person.Id = IdOne;
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);

            //Id's are different, operation will success
            bool success = contract.NotEqual(IdTwo).Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("NotEquals Validation")]
        public void NotEqualsValidationShouldFail()
        {
            person.Id = IdOne;
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);

            //Id's are same, operation will fail
            bool success = contract.NotEqual(IdOne).Success;
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("NotEquals Validation")]
        public void NotEqualsValidationShouldFailAndAddNotification()
        {
            person.Id = IdOne;
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);

            //Id's are equal, operation will fail
            string errorCode = contract.NotEqual(IdOne).Build().First().ErrorCode;
            Assert.AreEqual($"{IdOne} deve ser diferente de {IdOne}", errorCode);
        }
        #endregion

        #region NotEmpty
        [TestMethod]
        [TestCategory("NotEmpty Validation")]
        public void NotEmptyValidationShouldBeSuccess()
        {
            person.Id = IdOne;
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);

            //Id is not empty, operation will success
            bool success = contract.NotEmpty().Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("NotEmpty Validation")]
        public void NotEmptyValidationShouldFail()
        {
            person.Id = Guid.Empty;
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);

            //Id is empty, operation will fail
            bool success = contract.NotEmpty().Success;
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("NotEmpty Validation")]
        public void NotEmptyValidationShouldFailAndAddNotification()
        {
            person.Id = Guid.Empty;
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);

            //Id is empty, operation will fail
            string errorCode = contract.NotEmpty().Build().First().ErrorCode;

            Assert.AreEqual($"Id vazio", errorCode);
        }
        #endregion

        #region NotEmpty
        [TestMethod]
        [TestCategory("Empty Validation")]
        public void EmptyValidationShouldBeSuccess()
        {
            person.Id = Guid.Empty;
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);

            //Id is empty, operation will success
            bool success = contract.Empty().Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("Empty Validation")]
        public void EmptyValidationShouldFail()
        {
            person.Id = IdOne;
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);

            //Id is not empty, operation will fail
            bool success = contract.Empty().Success;
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("Empty Validation")]
        public void EmptyValidationShouldFailAndAddNotification()
        {
            person.Id = IdOne;
            contract = new ValidationContract<Person, Guid>(person, p => p.Id);

            //Id is not empty, operation will fail
            string errorCode = contract.Empty().Build().First().ErrorCode;

            Assert.AreEqual($"Id não-vazio", errorCode);
        }
        #endregion
    }
}
