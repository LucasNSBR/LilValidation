using LilValidation.Configuration.Abstractions;
using System;

namespace LilValidation.Tests.Mocks
{
    public class TestValidatorOptions : IValidatorOptions
    {
        public IValidatorMessageCollection Messages => new TestMessageCollection();
    }
}
