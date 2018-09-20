using LilValidation.Core;
using LilValidation.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LilValidation.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a simple object to validate
            Person person = new Person();
            person.Name = Console.ReadLine();
            person.Age = Convert.ToInt32(Console.ReadLine()); 
            person.NetWorth = Convert.ToDecimal(Console.ReadLine());
            
            //Generate lists of errors 
            IReadOnlyList<ValidationError> nameErrors = new ValidationContract<Person, string>(person, c => c.Name)
                .NotNull()
                .MinLength(5)
                .MaxLength(10)
                .Build();

            IReadOnlyList<ValidationError> ageErrors = new ValidationContract<Person, int>(person, c => c.Age)
                .GreaterThan(10)
                .LessThan(100)
                .Build();

            IReadOnlyList<ValidationError> netWorthErrors = new ValidationContract<Person, decimal>(person, p => p.NetWorth)
                .GreaterThan(2500)
                .Build();

            nameErrors.ToList().ForEach(e => ShowErrors(e));
            ageErrors.ToList().ForEach(e => ShowErrors(e));
            netWorthErrors.ToList().ForEach(e => ShowErrors(e));

            Console.ReadKey();
        }

        public static void ShowErrors(ValidationError error)
        {
            Console.WriteLine($"{error.ErrorCode} - {error.ErrorDescription}");
        }
    }
}
