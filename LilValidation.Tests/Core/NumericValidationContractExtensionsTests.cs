using LilValidation.Core;
using LilValidation.Core.Extensions;
using LilValidation.Sample.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LilValidation.Tests.Core
{
    [TestClass]
    public class NumericValidationContractExtensionsTests
    {
        Person person = new Person();
        ValidationContract<Person, int> contract;

        public NumericValidationContractExtensionsTests()
        {
            person.Name = "Lucas";
            contract = new ValidationContract<Person, int>(p => person.Age);
        }

        #region LessThan
        [TestMethod]
        [TestCategory("LessThan Validation")]
        public void LessThanValidationShouldSuccess()
        {
            //person age is currently 0
            contract = new ValidationContract<Person, int>(p => person.Age);

            bool success = contract.LessThan(15).Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("LessThan Validation")]
        public void LessThanValidationShouldFail()
        {
            //Age is greather than or equal 20 (limit), validation will fail
            person.Age = 20;
            contract = new ValidationContract<Person, int>(p => person.Age);

            bool success = contract.LessThan(20).Success;
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("LessThan Validation")]
        public void ContractShouldGenerateLessThanErrorValidationMessage()
        {
            //Age is greather than or equal 20 (limit), validation will fail
            person.Age = 20;
            contract = new ValidationContract<Person, int>(p => person.Age);

            int limit = 20;

            string errorCode = contract.LessThan(limit).Build().First().ErrorCode;
            Assert.AreEqual($"{contract.MemberName} é maior ou igual a {limit}", errorCode);
        }

        [TestMethod]
        [TestCategory("LessThan Validation")]
        public void ContractShouldGenerateLessThanErrorCustomizedValidationMessage()
        {
            //Age is greather than or equal 20 (limit), validation will fail
            person.Age = 20;
            contract = new ValidationContract<Person, int>(p => person.Age);
            
            string errorDescription = contract.LessThan(20, "ErrorCode", "OutOfRange").Build().First().ErrorDescription;
            Assert.AreEqual($"OutOfRange", errorDescription);
        }
        #endregion

        #region GreatherThan
        [TestMethod]
        [TestCategory("GreatherThan Validation")]
        public void GreatherThanValidationShouldSuccess()
        {
            //person age is currently 25
            person.Age = 31;
            contract = new ValidationContract<Person, int>(p => person.Age);

            bool success = contract.GreaterThan(15).Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("GreatherThan Validation")]
        public void GreatherThanValidationShouldFail()
        {
            //Age is less than or equal 20 (limit), validation will fail
            person.Age = 20;
            contract = new ValidationContract<Person, int>(p => person.Age);

            bool success = contract.GreaterThan(20).Success;
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("GreatherThan Validation")]
        public void ContractShouldGenerateGreatherThanErrorValidationMessage()
        {
            //Age is less than or equal 20 (limit), validation will fail
            person.Age = 20;
            contract = new ValidationContract<Person, int>(p => person.Age);

            int limit = 20;

            string errorCode = contract.GreaterThan(limit).Build().First().ErrorCode;
            Assert.AreEqual($"{contract.MemberName} é menor ou igual a {limit}", errorCode);
        }

        [TestMethod]
        [TestCategory("GreatherThan Validation")]
        public void ContractShouldGenerateGreatherThanErrorCustomizedValidationMessage()
        {
            //Age is less than or equal 20 (limit), validation will fail
            person.Age = 20;
            contract = new ValidationContract<Person, int>(p => person.Age);

            string errorDescription = contract.GreaterThan(20, "ErrorCode", "OutOfRange").Build().First().ErrorDescription;
            Assert.AreEqual($"OutOfRange", errorDescription);
        }
        #endregion

        #region Equals
        [TestMethod]
        [TestCategory("Equals Validation")]
        public void EqualsValidationShouldBeSuccess()
        {
            //person age is currently 20
            person.Age = 20;
            contract = new ValidationContract<Person, int>(p => person.Age);

            //Generic types need to be specified because default of the default Equals() method
            bool success = contract.Equals<Person, int>(20).Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("Equals Validation")]
        public void EqualsValidationShouldFail()
        {
            //person age is currently 20
            person.Age = 20;
            contract = new ValidationContract<Person, int>(p => person.Age);

            //Generic types need to be specified because default of the default Equals() method
            bool success = contract.Equals<Person, int>(21).Success;
            Assert.IsFalse(success);
        }
        #endregion

        #region Between
        [TestMethod]
        [TestCategory("Between Validation")]
        [DataRow(16)]
        [DataRow(22)]
        [DataRow(23)]
        [DataRow(25)]
        [DataRow(89)]
        public void BetweenValidationShouldBeSuccess(int age)
        {
            int initial = 15;
            int final = 90;

            person.Age = age;
            contract = new ValidationContract<Person, int>(p => person.Age);

            bool success = contract.Between(initial, final).Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("Between Validation")]
        public void BetweenValidationShouldFail()
        {
            //person age is currently 20
            person.Age = 20;
            contract = new ValidationContract<Person, int>(p => person.Age);

            //Generic types need to be specified because default of the default Equals() method
            bool success = contract.Equals<Person, int>(21).Success;
            Assert.IsFalse(success);
        }
        #endregion

        #region LessThan
        [TestMethod]
        [TestCategory("LessOrEqualThan Validation")]
        public void LessOrEqualThanValidationShouldSuccess()
        {
            //person age is currently 0
            contract = new ValidationContract<Person, int>(p => person.Age);

            bool success = contract.LessOrEqualThan(15).Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("LessOrEqualThan Validation")]
        public void LessOrEqualThanValidationShouldFail()
        {
            //Age is greather than, validation will fail
            person.Age = 21;
            contract = new ValidationContract<Person, int>(p => person.Age);

            bool success = contract.LessOrEqualThan(20).Success;
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("LessOrEqualThan Validation")]
        public void ContractShouldGenerateLessOrEqualThanErrorValidationMessage()
        {
            //Age is greather than, validation will fail
            person.Age = 21;
            contract = new ValidationContract<Person, int>(p => person.Age);

            int limit = 20;

            string errorCode = contract.LessOrEqualThan(limit).Build().First().ErrorCode;
            Assert.AreEqual($"{contract.MemberName} é maior que {limit}", errorCode);
        }

        [TestMethod]
        [TestCategory("LessOrEqualThan Validation")]
        public void ContractShouldGenerateLessOrEqualThanErrorCustomizedValidationMessage()
        {
            //Age is greather than, validation will fail
            person.Age = 20;
            contract = new ValidationContract<Person, int>(p => person.Age);

            string errorDescription = contract.LessOrEqualThan(19, "ErrorCode", "OutOfRange").Build().First().ErrorDescription;
            Assert.AreEqual($"OutOfRange", errorDescription);
        }
        #endregion

        #region GreatherOrEqualThanThan
        [TestMethod]
        [TestCategory("GreatherOrEqualThan Validation")]
        public void GreatherOrEqualThanValidationShouldSuccess()
        {
            //person age is currently 25
            person.Age = 31;
            contract = new ValidationContract<Person, int>(p => person.Age);

            bool success = contract.GreaterOrEqualThan(15).Success;
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("GreatherOrEqualThan Validation")]
        public void GreatherOrEqualThanValidationShouldFail()
        {
            //Age is less than, validation will fail
            person.Age = 19;
            contract = new ValidationContract<Person, int>(p => person.Age);

            bool success = contract.GreaterOrEqualThan(20).Success;
            Assert.IsFalse(success);
        }

        [TestMethod]
        [TestCategory("GreatherOrEqualThan Validation")]
        public void ContractShouldGenerateGreatherOrEqualThanErrorValidationMessage()
        {
            //Age is less than, validation will fail
            person.Age = 20;
            contract = new ValidationContract<Person, int>(p => person.Age);

            int limit = 21;

            string errorCode = contract.GreaterOrEqualThan(limit).Build().First().ErrorCode;
            Assert.AreEqual($"{contract.MemberName} é menor que {limit}", errorCode);
        }

        [TestMethod]
        [TestCategory("GreatherOrEqualThan Validation")]
        public void ContractShouldGenerateGreatherOrEqualThanErrorCustomizedValidationMessage()
        {
            //Age is less than, validation will fail
            person.Age = 20;
            contract = new ValidationContract<Person, int>(p => person.Age);

            string errorDescription = contract.GreaterOrEqualThan(21, "ErrorCode", "OutOfRange").Build().First().ErrorDescription;
            Assert.AreEqual($"OutOfRange", errorDescription);
        }
        #endregion
    }
}
