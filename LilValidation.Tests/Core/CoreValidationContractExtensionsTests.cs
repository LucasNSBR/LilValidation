using LilValidation.Core;
using LilValidation.Core.Extensions;
using LilValidation.Sample.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LilValidation.Tests.Core
{
    [TestClass]
    public class CoreValidationContractExtensionsTests
    {
        Person person = new Person();
        ValidationContract<Person, string> contract;

        public CoreValidationContractExtensionsTests()
        {
            contract = new ValidationContract<Person, string>(p => person.Name);
        }

        #region NotNull()
        [TestMethod]
        [TestCategory("NotNull Validation")]
        public void ObjectShouldFailNotNullValidation()
        {
            //contract value is null, validation will fail
            bool success = contract
                .NotNull()
                .Success;

            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("NotNull Validation")]
        public void ObjectShouldGenerateNotNullErrorValidationMessage()
        {
            //contract value is null, validation will fail and add a notification
            IReadOnlyList<ValidationError> errors = contract
                .NotNull()
                .Build();

            Assert.AreEqual($"A operação não pode prosseguir se o valor de {contract.MemberName} for nulo.", errors.First().ErrorDescription);
        }

        [TestMethod]
        [TestCategory("NotNull Validation")]
        public void ObjectShouldSuccessNotNullValidation()
        {
            //contract value now it's not null, validation will success
            person.Name = "Fabrikam";
            contract = new ValidationContract<Person, string>(p => person.Name);

            bool success = contract
                .NotNull()
                .Success;

            Assert.IsTrue(success);
        }
        #endregion

        [TestMethod]
        [TestCategory("NotNull Validation")]
        public void ObjectShouldGenerateNotNullErrorCustomizedValidationMessage()
        {
            //contract value is null, validation will fail and add a CUSTOMIZED notification
            IReadOnlyList<ValidationError> errors = contract
                .NotNull("404", "Null Value")
                .Build();

            Assert.AreEqual("404", errors.First().ErrorCode);
            Assert.AreEqual("Null Value", errors.First().ErrorDescription);
        }

        #region Null()
        [TestMethod]
        [TestCategory("Null Validation")]
        public void ObjectShouldFailNullValidation()
        {
            //contract value is NOT null, validation will fail
            person.Name = "Fabrikam";
            contract = new ValidationContract<Person, string>(p => person.Name);

            bool success = contract
                .NotNull()
                .Success;

            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("Null Validation")]
        public void ObjectShouldGenerateNullErrorValidationMessage()
        {            
            //contract value is NOT null, validation will fail and add a notification
            person.Name = "Fabrikam";
            contract = new ValidationContract<Person, string>(p => person.Name);

            IReadOnlyList<ValidationError> errors = contract
                .Null()
                .Build();

            Assert.AreEqual($"A operação não pode prosseguir se o valor de {contract.MemberName} NÃO for nulo.", errors.First().ErrorDescription);
        }

        [TestMethod]
        [TestCategory("Null Validation")]
        public void ObjectShouldSuccessNullValidation()
        {
            //contract value is null, validation will success
            bool success = contract
                .Null()
                .Success;

            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("NotNull Validation")]
        public void ObjectShouldGenerateNullErrorCustomizedValidationMessage()
        {
            //contract value is NOT null, validation will fail and add a CUSTOMIZED notification
            person.Name = "Fabrikam";
            contract = new ValidationContract<Person, string>(p => person.Name);

            IReadOnlyList<ValidationError> errors = contract
                .Null("500", "Not Null Value")
                .Build();

            Assert.AreEqual("500", errors.First().ErrorCode);
            Assert.AreEqual("Not Null Value", errors.First().ErrorDescription);
        }
        #endregion
    }
}
