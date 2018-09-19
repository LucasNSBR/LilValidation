using System;

namespace LilValidation.Core
{
    public static class NumericValidationContractExtensions
    {
        /// <summary>
        /// Performs a Equals validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <typeparam name="TProperty">Property to be compared, must be a Struct and Implements IComparable<T>, also needs to implement IFormattable (this will discard bool types)</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="value">Value to compare</param>
        /// <param name="errorCode">ErrorCode if number is NOT equal to value</param>
        /// <param name="errorDescription">Error description if number is NOT equal to value</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, TProperty> Equals<T, TProperty>(this ValidationContract<T, TProperty> contract, TProperty value, string errorCode = null, string errorDescription = null) where TProperty : struct, IComparable<TProperty>, IFormattable
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.EqualsErrorMessage.Key, contract.MemberName, value);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.EqualsErrorMessage.Value, contract.MemberName, value);

            if (contract.MemberValue.CompareTo(value) != 0)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, TProperty>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a Between validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <typeparam name="TProperty">Property to be compared, must be a Struct and Implements IComparable<T>, also needs to implement IFormattable (this will discard bool types)</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="initial">Initial range value to compare</param>
        /// <param name="final">Final range value to compare</param>
        /// <param name="errorCode">ErrorCode if number is not between the range</param>
        /// <param name="errorDescription">Error description if between the range</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, TProperty> Between<T, TProperty>(this ValidationContract<T, TProperty> contract, TProperty initial, TProperty final, string errorCode = null, string errorDescription = null) where TProperty : struct, IComparable<TProperty>, IFormattable
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.BetweenErrorMessage.Key, contract.MemberName, initial);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.BetweenErrorMessage.Value, contract.MemberName, initial, final);

            if (contract.MemberValue.CompareTo(initial) <= 0 || contract.MemberValue.CompareTo(final) >= 0)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, TProperty>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a LessOrEqualThan validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <typeparam name="TProperty">Property to be compared, must be a Struct and Implements IComparable<T>, also needs to implement IFormattable (this will discard bool types)</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="value">Value to compare</param>
        /// <param name="errorCode">ErrorCode if number is LessOrEqual to value</param>
        /// <param name="errorDescription">Error description if number is LessOrEqual to value</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, TProperty> LessOrEqualThan<T, TProperty>(this ValidationContract<T, TProperty> contract, TProperty value, string errorCode = null, string errorDescription = null) where TProperty : struct, IComparable<TProperty>, IFormattable
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.LessOrEqualThanErrorMessage.Key, contract.MemberName, value);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.LessOrEqualThanErrorMessage.Value, contract.MemberName, value);

            if (contract.MemberValue.CompareTo(value) > 0)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, TProperty>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a GreaterThanOrEqual validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <typeparam name="TProperty">Property to be compared, must be a Struct and Implements IComparable<T>, also needs to implement IFormattable (this will discard bool types)</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="value">Value to compare</param>
        /// <param name="errorCode">ErrorCode if number is GreaterOrEqual to value</param>
        /// <param name="errorDescription">Error description if number is GreaterOrEqual to value</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, TProperty> GreaterOrEqualThan<T, TProperty>(this ValidationContract<T, TProperty> contract, TProperty value, string errorCode = null, string errorDescription = null) where TProperty : struct, IComparable<TProperty>, IFormattable
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.GreaterOrEqualThanErrorMessage.Key, contract.MemberName, value);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.GreaterOrEqualThanErrorMessage.Value, contract.MemberName, value);

            if (contract.MemberValue.CompareTo(value) < 0)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, TProperty>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a LessThan validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <typeparam name="TProperty">Property to be compared, must be a Struct and Implements IComparable<T>, also needs to implement IFormattable (this will discard bool types)</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="value">Value to compare</param>
        /// <param name="errorCode">ErrorCode if number is less to value</param>
        /// <param name="errorDescription">Error description if number is less to value</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, TProperty> LessThan<T, TProperty>(this ValidationContract<T, TProperty> contract, TProperty value, string errorCode = null, string errorDescription = null) where TProperty : struct, IComparable<TProperty>, IFormattable
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.LessThanErrorMessage.Key, contract.MemberName, value);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.LessThanErrorMessage.Value, contract.MemberName, value);

            if (contract.MemberValue.CompareTo(value) >= 0)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, TProperty>(contract.MemberName, contract.MemberValue, contract.Errors);
        }

        /// <summary>
        /// Performs a GreaterThan validation
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <typeparam name="TProperty">Property to be compared, must be a Struct and Implements IComparable<T>, also needs to implement IFormattable (this will discard bool types)</typeparam>
        /// <param name="contract">Current contract</param>
        /// <param name="value">Value to compare</param>
        /// <param name="errorCode">ErrorCode if number is Greater to value</param>
        /// <param name="errorDescription">Error description if number is Greater to value</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, TProperty> GreaterThan<T, TProperty>(this ValidationContract<T, TProperty> contract, TProperty value, string errorCode = null, string errorDescription = null) where TProperty : struct, IComparable<TProperty>, IFormattable
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.GreaterThanErrorMessage.Key, contract.MemberName, value);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.GreaterThanErrorMessage.Value, contract.MemberName, value);

            if (contract.MemberValue.CompareTo(value) <= 0)
                contract.AddError(errorCode, errorDescription);

            return new ValidationContract<T, TProperty>(contract.MemberName, contract.MemberValue, contract.Errors);
        }
    }
}
