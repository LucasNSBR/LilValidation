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
                return new KeyValuePair<string, string>("{0} muito pequeno", "A propriedade {0} não possui a quantidade mínima de caracteres ({1}).");
            }
        }

        public KeyValuePair<string, string> MaxLengthErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} muito grande", "A propriedade {0} extrapolou a quantidade máxima de caracteres ({1}).");
            }
        }

        public KeyValuePair<string, string> ExactlyLengthErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} muito grande", "A propriedade {0} não possui a quantidade especificada de caracteres ({1}).");
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

        public KeyValuePair<string, string> BetweenErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} fora do limite especificado", "O valor de {0} deve ser estar dentro do limite de {0} e {1}.");
            }
        }

        public KeyValuePair<string, string> EqualsErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} - Valor divergente", "O valor de {0} deve ser igual a {1}.");
            }
        }

        public KeyValuePair<string, string> LessOrEqualThanErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} é maior que {1}", "A propriedade {0} tem um valor maior que o especificado ({1}).");
            }
        }

        public KeyValuePair<string, string> GreaterOrEqualThanErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} é menor que {1}", "A propriedade {0} tem um valor menor que o especificado ({1}).");
            }
        }

        public KeyValuePair<string, string> LessThanErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} é maior ou igual a {1}", "A propriedade {0} tem um valor maior ou igual ao especificado ({1}).");
            }
        }

        public KeyValuePair<string, string> GreaterThanErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} é menor ou igual a {1}", "A propriedade {0} tem um valor menor ou igual ao especificado ({1}).");
            }
        }

        public KeyValuePair<string, string> IsTrueErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} falso", "O valor de {0} deve verdadeiro.");
            }
        }

        public KeyValuePair<string, string> IsFalseErrorMessage
        {
            get
            {
                return new KeyValuePair<string, string>("{0} verdadeiro", "O valor de {0} deve falso.");
            }
        }
    }
}
