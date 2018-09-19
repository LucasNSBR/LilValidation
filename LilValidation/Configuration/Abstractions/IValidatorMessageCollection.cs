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

        /// <summary>
        /// Validation Message for NotEmpty() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> NotEmptyErrorMessage { get; }

        /// <summary>
        /// Validation Message for MinLength() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> MinLengthErrorMessage { get; }

        /// <summary>
        /// Validation Message for MaxLength() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> MaxLengthErrorMessage { get; }

        /// <summary>
        /// Validation Message for ExactlyLength() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> ExactlyLengthErrorMessage { get; }

        /// <summary>
        /// Validation Message for Regex() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> RegexErrorMessage { get; }

        /// <summary>
        /// Validation Message for Email() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> EmailErrorMessage { get; }

        /// <summary>
        /// Validation Message for Equals() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> EqualsErrorMessage { get; }

        /// <summary>
        /// Validation Message for Between() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> BetweenErrorMessage { get; }

        /// <summary>
        /// Validation Message for LessOrEqualThan() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> LessOrEqualThanErrorMessage { get; }

        /// <summary>
        /// Validation Message for GreaterOrEqualThan() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> GreaterOrEqualThanErrorMessage { get; }

        /// <summary>
        /// Validation Message for LessThan() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> LessThanErrorMessage { get; }

        /// <summary>
        /// Validation Message for GreaterThan() extension method.
        /// </summary>
        /// <returns>KeyValuePair with ErrorCode and ErrorMessage</returns>
        KeyValuePair<string, string> GreaterThanErrorMessage { get; }
    }
}
