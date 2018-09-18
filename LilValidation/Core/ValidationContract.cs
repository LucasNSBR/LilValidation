using LilValidation.Configuration;
using LilValidation.Configuration.Abstractions;
using LilValidation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LilValidation.Core
{
    public class ValidationContract<T, TProperty>
    {
        /// <summary>
        /// Name of the property that are being validated.
        /// </summary>
        public string MemberName { get; }

        /// <summary>
        /// Value of the property that are being validated.
        /// </summary>
        public TProperty MemberValue { get; }

        private List<ValidationError> _errors;

        /// <summary>
        /// List of errors that the current validation contract was generated
        /// </summary>
        public IReadOnlyList<ValidationError> Errors
        {
            get
            {
                return _errors;
            }
        }

        /// <summary>
        /// Validation Options of this Contract
        /// </summary>
        public IValidatorOptions Options { get; private set; }

        /// <summary>
        /// Represents the status of the current validation
        /// </summary>
        public bool Success
        {
            get
            {
                return !_errors.Any();
            }
        }

        /// <summary>
        /// Entry point for a validation contract.
        /// </summary>
        /// <param name="expression">A MemberExpression to get the property to be validated</param>
        /// <param name="options">A IValidationOptions object to configure validation parameters</param>
        public ValidationContract(Expression<Func<T, TProperty>> expression)
        {
            _errors = new List<ValidationError>();

            try
            {
                MemberExpression member = null;

                switch (expression.Body.NodeType)
                {
                    case ExpressionType.Convert:
                        Expression conversion = ((UnaryExpression)expression.Body).Operand;
                        member = (MemberExpression)conversion;
                        break;

                    case ExpressionType.MemberAccess:
                        member = (MemberExpression)expression.Body;
                        break;

                    default:
                        throw new ArgumentException("The method argument should be a MemberExpression type.", nameof(expression));
                };

                MemberName = member.Member.Name;
                MemberValue = ExpressionEvaluator.CompileLocalMember<TProperty>(member);
            }
            catch (Exception e)
            {
                throw new NotSupportedException("The operation was failed at some point, see InnerExpection.", e);
            }
        }

        /// <summary>
        /// Alternative constructor for Validation Contract, should be used if contract already exists to pass informations. 
        /// It's not recommended to use this method outside Extension methods, utilize constructor with Expression instead.
        /// </summary>
        /// <param name="memberName">Name of the member coming from a existent contract</param>
        /// <param name="memberValue">Value of the member coming from a existent contract</param>
        /// <param name="errors">Notifications to be passed to this contract, coming from a existent contract</param>
        /// <param name="options">Options of this Contract. This value should come from previous existent contract.</param>
        public ValidationContract(string memberName, TProperty memberValue, IReadOnlyList<ValidationError> errors = null, IValidatorOptions options = null)
        {
            _errors = errors?.ToList() ?? new List<ValidationError>();

            MemberName = memberName;
            MemberValue = memberValue;

            AddValidatorOptions(options ?? GetDefaultOptions());
        }

        /// <summary>
        /// Configure Validator Options
        /// </summary>
        /// <param name="options">The options to configure object</param>
        /// <returns></returns>
        public ValidationContract<T, TProperty> AddValidatorOptions(IValidatorOptions options)
        {
            Options = options; 
            return this;
        }

        private IValidatorOptions GetDefaultOptions()
        {
            return new ValidatorOptions();
        }

        /// <summary>
        /// Add a Error to contract list
        /// </summary>
        /// <param name="errorCode">A title of Error to be added.</param>
        /// <param name="description">A description of Error to be added.</param>
        public void AddNotification(string errorCode, string description)
        {
            _errors.Add(new ValidationError(errorCode, description));
        }
        
        /// <summary>
        /// Build Validation structure
        /// </summary>
        /// <returns>A IEnumerable with all notifications.</returns>
        public IReadOnlyList<ValidationError> Build()
        {
            return _errors;
        }
    }
}
