namespace LilValidation.Core
{
    public class ValidationError
    {
        /// <summary>
        /// Code or Title of the error
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// Description of the error
        /// </summary>
        public string ErrorDescription { get; }

        /// <summary>
        /// ValidationError constructor
        /// </summary>
        /// <param name="errorCode">Code or title of the error</param>
        /// <param name="errorDescription">Brief description of the error</param>
        public ValidationError(string errorCode, string errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }
    }
}
