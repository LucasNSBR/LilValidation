using LilValidation.Configuration.Abstractions;
using System.Collections.Generic;

namespace LilValidation.Configuration
{
    public class DefaultValidatorMessageCollection : IValidatorMessageCollection
    {
        public KeyValuePair<string, string> NullErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} não-nulo", "A operação não pode prosseguir se o valor de {0} NÃO for nulo.");
            }
        }

        public KeyValuePair<string, string> NotNullErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} nulo", "A operação não pode prosseguir se o valor de {0} for nulo.");
            }
        }
    }
}
