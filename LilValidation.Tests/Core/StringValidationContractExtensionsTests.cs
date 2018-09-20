using LilValidation.Core;
using LilValidation.Sample.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LilValidation.Tests.Core
{
    [TestClass]
    public class StringValidationContractExtensionsTests
    {
        Person person = new Person();
        ValidationContract<Person, string> contract;

        public StringValidationContractExtensionsTests()
        {
            person.Name = "Lucas";
            contract = new ValidationContract<Person, string>(person, p => p.Email);
        }

        #region Helpers
        [TestMethod]
        public void TestConvertFromNull()
        {
            //This is a private logic from string validation extensions
            string nullstring = null;
            string value = nullstring ?? string.Empty;

            Assert.AreEqual("", value);
        }
        #endregion

        #region Email Validation
        [TestMethod]
        [TestCategory("Email Validation")]
        [DataRow("fabrikam@gmail.com")]
        [DataRow("fabrikam.admin@hotmail.com")]
        [DataRow("fabrikam-source@fabrikam.com")]
        [DataRow("fabrikamcourses@fabrikam.com.br")]
        public void EmailValidationShouldSuccess(string email)
        {
            person.Email = email;
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            bool success = contract.Email().Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("Email Validation")]
        [DataRow("fabrikam@gmail..com")]
        [DataRow("fabrikam..admin@hotmail.com")]
        [DataRow("fabrikam@source@fabrikam.com")]
        [DataRow("fabrikam---courses")]
        public void EmailValidationShouldFail(string email)
        {
            //The validation should fail because all these emails are not valid
            person.Email = email;
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            bool success = contract.Email().Success;

            //Success is false
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("Email Validation")]
        public void ContractShouldGenerateEmailErrorValidationMessage()
        {
            //Email is invalid
            person.Email = "fabrikam......admin@gmail.com";

            ValidationError error = new ValidationContract<Person, string>(person, p => p.Email)
                .Email()
                .Build()
                .First();

            Assert.AreEqual($"{contract.MemberName} não é um endereço de e-mail", error.ErrorCode);
        }

        [TestMethod]
        [TestCategory("Email Validation")]
        public void ContractShouldGenerateEmailErrorCustomizedValidationMessage()
        {
            //Email is invalid
            person.Email = "fabrikam......admin@gmail.com";

            ValidationError error = new ValidationContract<Person, string>(person, p => p.Email)
                .Email("Inválido", "E-mail inválido")
                .Build()
                .First();

            Assert.AreEqual("Inválido", error.ErrorCode);
        }
        #endregion

        #region Regex Validation
        [TestMethod]
        [TestCategory("Regex Validation")]
        [DataRow("dabrikam")]
        [DataRow("fabrikam")]
        [DataRow("nabrikam")]
        [DataRow("yabrikam")]
        public void RegexValidationShouldSuccess(string test)
        {
            person.Email = test;
            string pattern = "[dfny]abrikam";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            bool success = contract.Regex(pattern).Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("Regex Validation")]
        [DataRow("fabrikam")]
        [DataRow("nabrikam")]
        [DataRow("dabrikam")]
        [DataRow("pabrikam")]
        public void RegexValidationShouldFail(string test)
        {
            //The validation should fail because all these regex are not valid
            person.Email = test;
            string pattern = "yabrikam";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            bool success = contract.Regex(pattern).Success;
            //Success is false
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("Regex Validation")]
        public void ContractShouldGenerateRegexErrorValidationMessage()
        {
            //Regex (test field) is invalid
            person.Email = "fabrikam";

            ValidationError error = new ValidationContract<Person, string>(person, p => p.Email)
                .Regex("nabrikam")
                .Build()
                .First();

            Assert.AreEqual($"{contract.MemberName} não é compatível", error.ErrorCode);
        }

        [TestMethod]
        [TestCategory("Regex Validation")]
        public void ContractShouldGenerateRegexErrorCustomizedValidationMessage()
        {
            //Regex (test field) is invalid
            person.Email = "fabrikam";

            ValidationError error = new ValidationContract<Person, string>(person, p => p.Email)
                .Regex("nabrikam", "Inválido", "Regex inválido")
                .Build()
                .First();

            Assert.AreEqual("Inválido", error.ErrorCode);
        }
        #endregion

        #region NotEmpty Validation
        [TestMethod]
        [TestCategory("NotEmpty Validation")]
        public void NotEmptyValidationShouldSuccess()
        {
            //Field is not empty, validation will pass
            person.Email = "emaildeexemplo";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            bool success = contract.NotEmpty().Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("NotEmpty Validation")]
        public void NotEmptyValidationShouldFail()
        {
            //Field is empty, validation will fail
            person.Email = "";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            bool success = contract.NotEmpty().Success;
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("NotEmpty Validation")]
        public void ContractShouldGenerateNotEmptyErrorValidationMessage()
        {
            //Field is empty, validation will fail
            person.Email = "";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            string errorDescription = contract.NotEmpty().Build().First().ErrorDescription;
            Assert.AreEqual($"A operação não pode prosseguir se o valor de {contract.MemberName} estiver vazio.", errorDescription);
        }

        [TestMethod]
        [TestCategory("NotEmpty Validation")]
        public void ContractShouldGenerateNotEmptyErrorCustomizedValidationMessage()
        {
            //Field is empty, validation will fail
            person.Email = "";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            string errorDescription = contract.NotEmpty("ErrorCode", "Empty").Build().First().ErrorDescription;
            Assert.AreEqual($"Empty", errorDescription);
        }
        #endregion

        #region ExactlyLength Validation
        [TestMethod]
        [TestCategory("ExactlyLength Validation")]
        public void ExactlyLengthValidationShouldSuccess()
        {
            //Field length is 10
            person.Email = "0123456789";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            bool success = contract.ExactlyLength(10).Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("ExactlyLength Validation")]
        public void ExactlyLengthValidationShouldFail()
        {
            //Field don't have specified length, validation will fail
            person.Email = "1234";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            bool success = contract.ExactlyLength(10).Success;
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("ExactlyLength Validation")]
        public void ContractShouldGenerateExactlyLengthErrorValidationMessage()
        {
            //Field don't have specified length, validation will fail
            person.Email = "12345";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            string errorCode = contract.ExactlyLength(10).Build().First().ErrorCode;
            Assert.AreEqual($"{contract.MemberName} fora do especificado", errorCode);
        }

        [TestMethod]
        [TestCategory("ExactlyLength Validation")]
        public void ContractShouldGenerateExactlyLengthErrorCustomizedValidationMessage()
        {
            //Field don't have specified length, validation will fail
            person.Email = "";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            string errorDescription = contract.ExactlyLength(10, "ErrorCode", "OutOfRange").Build().First().ErrorDescription;
            Assert.AreEqual($"OutOfRange", errorDescription);
        }
        #endregion

        #region MaxLength Validation 
        [TestMethod]
        [TestCategory("MaxLength Validation")]
        public void MaxLengthValidationShouldSuccess()
        {
            //Field length is 10
            person.Email = "0123456789";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            bool success = contract.MaxLength(15).Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("MaxLength Validation")]
        public void MaxLengthValidationShouldFail()
        {
            //Field don't have specified length, validation will fail
            person.Email = "1234";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            bool success = contract.MaxLength(2).Success;
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("MaxLength Validation")]
        public void ContractShouldGenerateMaxLengthErrorValidationMessage()
        {
            //Field don't have specified length, validation will fail
            person.Email = "12345";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            string errorCode = contract.MaxLength(3).Build().First().ErrorCode;
            Assert.AreEqual($"{contract.MemberName} muito grande", errorCode);
        }

        [TestMethod]
        [TestCategory("MaxLength Validation")]
        public void ContractShouldGenerateMaxLengthErrorCustomizedValidationMessage()
        {
            //Field don't have specified length, validation will fail
            person.Email = "12345";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            string errorDescription = contract.MaxLength(2, "ErrorCode", "OutOfRange").Build().First().ErrorDescription;
            Assert.AreEqual($"OutOfRange", errorDescription);
        }
        #endregion

        #region MinLength Validation 
        [TestMethod]
        [TestCategory("MinLength Validation")]
        public void MinLengthValidationShouldSuccess()
        {
            //Field length is 10
            person.Email = "0123456789";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            bool success = contract.MinLength(1).Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("MinLength Validation")]
        public void MinLengthValidationShouldFail()
        {
            //Field don't have specified length, validation will fail
            person.Email = "1234";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            bool success = contract.MinLength(23).Success;
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("MinLength Validation")]
        public void ContractShouldGenerateMinLengthErrorValidationMessage()
        {
            //Field don't have specified length, validation will fail
            person.Email = "12345";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            string errorCode = contract.MinLength(8).Build().First().ErrorCode;
            Assert.AreEqual($"{contract.MemberName} muito pequeno", errorCode);
        }

        [TestMethod]
        [TestCategory("MinLength Validation")]
        public void ContractShouldGenerateMinLengthErrorCustomizedValidationMessage()
        {
            //Field don't have specified length, validation will fail
            person.Email = "12345";
            contract = new ValidationContract<Person, string>(person, p => p.Email);

            string errorDescription = contract.MinLength(20, "ErrorCode", "OutOfRange").Build().First().ErrorDescription;
            Assert.AreEqual($"OutOfRange", errorDescription);
        }
        #endregion
    }
}

