using LilValidation.Core;
using System.Collections.Generic;

namespace LilValidation.Configuration.Abstractions
{
    public interface IValidatorMessageCollection
    {
        KeyValuePair<string, string> Default()
    }
}
