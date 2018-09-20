using System;

namespace LilValidation.Core
{
    public static class GuidValidationContractExtensions
    {
        /// <summary>
        /// Performs a Equals validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="errorCode">ErrorCode if Guid is NOT equal to value</param>
        /// <param name="errorDescription">Error description if Guid is NOT equal to value</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, Guid> IsEqual<T>(this ValidationContract<T, Guid> contract, Guid comparer, string errorCode = null, string errorDescription = null)
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.GuidEqualErrorMessage.Key, contract.MemberValue, comparer);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.GuidEqualErrorMessage.Value, contract.MemberName, comparer);

            if (contract.MemberValue != comparer)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, Guid>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a NotEquals validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="errorCode">ErrorCode if Guid is NOT equal to value</param>
        /// <param name="errorDescription">Error description if Guid is NOT equal to value</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, Guid> NotEqual<T>(this ValidationContract<T, Guid> contract, Guid comparer, string errorCode = null, string errorDescription = null)
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.GuidNotEqualErrorMessage.Key, contract.MemberValue, comparer);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.GuidNotEqualErrorMessage.Value, contract.MemberName, comparer);

            if (contract.MemberValue == comparer)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, Guid>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a NotEmpty validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="errorCode">ErrorCode if Guid is NOT equal to value</param>
        /// <param name="errorDescription">Error description if Guid is NOT equal to value</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, Guid> NotEmpty<T>(this ValidationContract<T, Guid> contract, string errorCode = null, string errorDescription = null)
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.GuidNotEmptyErrorMessage.Key, contract.MemberName);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.GuidNotEmptyErrorMessage.Value, contract.MemberName);

            if (contract.MemberValue == Guid.Empty)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, Guid>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a Empty validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="errorCode">ErrorCode if Guid is NOT equal to value</param>
        /// <param name="errorDescription">Error description if Guid is NOT equal to value</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, Guid> Empty<T>(this ValidationContract<T, Guid> contract, string errorCode = null, string errorDescription = null)
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.GuidEmptyErrorMessage.Key, contract.MemberName);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.GuidEmptyErrorMessage.Value, contract.MemberName);

            if (contract.MemberValue != Guid.Empty)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, Guid>(contract.MemberName, contract.MemberValue, contract.Errors);
        }
    }
}
