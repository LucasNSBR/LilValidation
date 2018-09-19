using System;

namespace LilValidation.Core.Extensions
{
    public static class BoolValidationContractExtensions
    {
        /// <summary>
        /// Performs a IsTrue validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="errorCode">ErrorCode if number is NOT equal to value</param>
        /// <param name="errorDescription">Error description if number is NOT equal to value</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, bool> IsTrue<T>(this ValidationContract<T, bool> contract, string errorCode = null, string errorDescription = null)
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.IsTrueErrorMessage.Key, contract.MemberName);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.IsTrueErrorMessage.Value, contract.MemberName);

            if (!contract.MemberValue)
                contract.AddNotification(errorCode, errorDescription);

            return new ValidationContract<T, bool>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a IsFalse validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="errorCode">ErrorCode if number is NOT equal to value</param>
        /// <param name="errorDescription">Error description if number is NOT equal to value</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, bool> IsFalse<T>(this ValidationContract<T, bool> contract, string errorCode = null, string errorDescription = null)
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.IsFalseErrorMessage.Key, contract.MemberName);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.IsFalseErrorMessage.Value, contract.MemberName);

            if (contract.MemberValue)
                contract.AddNotification(errorCode, errorDescription);

            return new ValidationContract<T, bool>(contract.MemberName, contract.MemberValue, contract.Errors);
        }
    }
}
