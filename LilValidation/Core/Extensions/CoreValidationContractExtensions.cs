namespace LilValidation.Core.Extensions
{
    public static class CoreValidationContractExtensions
    {
     /// <summary>
     /// Check if current object is null
     /// </summary>
     /// <param name="errorDescription">Description to be added if object is null.</param>
     /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, TProperty> NotNull<T, TProperty>(this ValidationContract<T, TProperty> contract, string errorCode = null, string errorDescription = null)
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.NotNullErrorMessage.Key, contract.MemberName);
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.NotNullErrorMessage.Value, contract.MemberName);

            if (contract.MemberValue == null)
                contract.AddNotification(errorCode, errorDescription);

            return new ValidationContract<T, TProperty>(contract.MemberName, contract.MemberValue, contract.Errors, contract.Options);
        }

        /// <summary>
        /// Check if current object is null
        /// </summary>
        /// <param name="errorDescription">Description to be added if object is NOT null.</param>
        /// <returns>A new validation contract with this validation embedded</returns>
        public static ValidationContract<T, TProperty> Null<T, TProperty>(this ValidationContract<T, TProperty> contract, string errorCode = null, string errorDescription = null)
        {
            errorCode = errorCode ?? string.Format(contract.Options.Messages.NullErrorMessage.Key, contract.MemberName); 
            errorDescription = errorDescription ?? string.Format(contract.Options.Messages.NullErrorMessage.Value, contract.MemberName); 

            if (contract.MemberValue != null)
                contract.AddNotification(errorCode, errorDescription);

            return new ValidationContract<T, TProperty>(contract.MemberName, contract.MemberValue, contract.Errors, contract.Options);
        }
    }
}
