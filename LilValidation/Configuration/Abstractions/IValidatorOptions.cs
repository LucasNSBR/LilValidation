namespace LilValidation.Configuration.Abstractions
{
    public interface IValidatorOptions
    {
        /// <summary>
        /// Collection of error messages
        /// </summary>
        IValidatorMessageCollection Messages { get; }
    }
}
