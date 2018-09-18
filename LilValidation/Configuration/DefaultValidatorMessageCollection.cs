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

        public KeyValuePair<string, string> NotEmptyErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} vazio", "A operação não pode prosseguir se o valor de {0} estiver vazio.");
            }
        }

        public KeyValuePair<string, string> MinLengthErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} muito pequeno", "A propriedade {0} não tem a quantidade mínima de caracteres ({1}).");
            }
        }

        public KeyValuePair<string, string> MaxLengthErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} muito grande", "A propriedade {0} não extrapolou a quantidade máxima de caracteres ({1}).");
            }
        }

        public KeyValuePair<string, string> ExactlyLengthErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} muito grande", "A propriedade {0} não extrapolou a quantidade máxima de caracteres ({1}).");
            }
        }

        public KeyValuePair<string, string> RegexErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} não é compatível", "A propriedade {0} não é compatível com a expressão especificada.");
            }
        }

        public KeyValuePair<string, string> EmailErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} não é um endereço de e-mail", "A propriedade {0} não é reconhecida como nenhum tipo de endereço de e-mail.");
            }
        }
    }
}
