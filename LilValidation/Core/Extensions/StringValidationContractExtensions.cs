using System.Text.RegularExpressions;

namespace LilValidation.Core.Extensions
{
    public static class StringContractExtensions
    {
        /// <summary>
        /// Performs a empty validation, validation will fail if string IS empty
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="errorCode">ErrorCode if string is empty</param>
        /// <param name="errorDescription">Error description if string is empty</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, string> NotEmpty<T>(this ValidationContract<T, string> contract, string errorCode = null, string errorDescription = null)
        {
            string value = ConvertFromNull(contract.MemberValue);
            errorCode = errorCode ?? string.Format(contract.Options.Messages.NotEmptyErrorMessage.Key, contract.MemberName);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.NotEmptyErrorMessage.Value, contract.MemberName);

            if (string.IsNullOrWhiteSpace(value))
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, string>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a Minimum Length Validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="minLength">Minimum string required length</param>
        /// <param name="errorCode">ErrorCode if MinLength is not satisfied</param>
        /// <param name="errorDescription">ErrorDescription if MinLength is not satisfied</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, string> MinLength<T>(this ValidationContract<T, string> contract, int minLength, string errorCode = null, string errorDescription = null)
        {
            string value = ConvertFromNull(contract.MemberValue);
            errorCode = errorCode ?? string.Format(contract.Options.Messages.MinLengthErrorMessage.Key, contract.MemberName);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.MinLengthErrorMessage.Value, contract.MemberName, minLength);

            if (value.Length <= minLength)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, string>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a Maximum Length Validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="minLength">Maximum string length</param>
        /// <param name="errorCode">ErrorCode if MaxLength is not satisfied</param>
        /// <param name="errorDescription">ErrorDescription if MaxLength is not satisfied</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, string> MaxLength<T>(this ValidationContract<T, string> contract, int maxLength, string errorCode = null, string errorDescription = null)
        {
            string value = ConvertFromNull(contract.MemberValue);
            errorCode = errorCode ?? string.Format(contract.Options.Messages.MaxLengthErrorMessage.Key, contract.MemberName);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.MaxLengthErrorMessage.Value, contract.MemberName, maxLength);

            if (value.Length >= maxLength)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, string>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a Exactly Length Validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="minLength">Exactly required length</param>
        /// <param name="errorCode">ErrorCode if Length is not safistied</param>
        /// <param name="errorDescription">ErrorDescription if Length is not safistied</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, string> ExactlyLength<T>(this ValidationContract<T, string> contract, int length, string errorCode = null, string errorDescription = null)
        {
            string value = ConvertFromNull(contract.MemberValue);
            errorCode = errorCode ?? string.Format(contract.Options.Messages.ExactlyLengthErrorMessage.Key, contract.MemberName);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.ExactlyLengthErrorMessage.Value, contract.MemberName, length);

            if (value.Length != length)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, string>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a Regex Validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="pattern">Regex pattern</param>
        /// <param name="errorCode">ErrorCode if Regex is not safistied</param>
        /// <param name="errorDescription">Error description if Regex is not satisfied</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, string> Regex<T>(this ValidationContract<T, string> contract, string pattern, string errorCode = null, string errorDescription = null)
        {
            string value = ConvertFromNull(contract.MemberValue);
            errorCode = errorCode ?? string.Format(contract.Options.Messages.RegexErrorMessage.Key, contract.MemberName);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.RegexErrorMessage.Value, contract.MemberName);

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            if (!regex.IsMatch(contract.MemberValue))
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, string>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a Email Validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="errorCode">ErrorCode if Regex is not safistied</param>
        /// <param name="errorDescription">Error description if Regex is not satisfied</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, string> Email<T>(this ValidationContract<T, string> contract, string errorCode = null, string errorDescription = null)
        {
            string value = ConvertFromNull(contract.MemberValue);
            errorCode = errorCode ?? string.Format(contract.Options.Messages.EmailErrorMessage.Key, contract.MemberName);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.EmailErrorMessage.Value, contract.MemberName);

            Regex regex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnoreCase);

            if (!regex.IsMatch(contract.MemberValue))
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, string>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Convert a null string to empty string
        /// </summary>
        /// <param name="value">String to be converted</param>
        /// <returns></returns>
        private static string ConvertFromNull(string value)
        {
            return value ?? string.Empty;
        }
    }
}
