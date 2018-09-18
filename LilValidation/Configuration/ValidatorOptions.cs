using LilValidation.Configuration.Abstractions;

namespace LilValidation.Configuration
{
    public class ValidatorOptions : IValidatorOptions
    {
        /// <summary>
        /// Collection of error messages
        /// </summary>
        public IValidatorMessageCollection Messages { get; }

        /// <summary>
        /// Entry point for validation options
        /// </summary>
        /// <param name="messageCollection">Collection of messages to show on validation errors</param>
        public ValidatorOptions(IValidatorMessageCollection messageCollection = null)
        {
            Messages = messageCollection ?? new DefaultValidatorMessageCollection();
        }
    }
}