using LilValidation.Configuration.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LilValidation.Tests.Mocks
{
    public class TestMessageCollection : IValidatorMessageCollection
    {
        public KeyValuePair<string, string> NullErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> NotNullErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> NotEmptyErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> MinLengthErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> MaxLengthErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> ExactlyLengthErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> RegexErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> EmailErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> EqualsErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> BetweenErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> LessOrEqualThanErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> GreaterOrEqualThanErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> LessThanErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> GreaterThanErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> IsFalseErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> IsTrueErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> GuidEqualErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> GuidNotEqualErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> GuidNotEmptyErrorMessage => throw new NotImplementedException();

        public KeyValuePair<string, string> GuidEmptyErrorMessage => throw new NotImplementedException();
    }
}
