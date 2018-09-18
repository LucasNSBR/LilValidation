using System.Collections.Generic;

namespace LilValidation.Configuration.Abstractions
{
    public interface IValidatorMessageCollection
    {
        /// <summary>
        /// Validation Message for Null() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> NullErrorMessage { get; }

        /// <summary>
        /// Validation Message for NotNull() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> NotNullErrorMessage { get; }
    }
}
