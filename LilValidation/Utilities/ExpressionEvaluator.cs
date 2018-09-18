using System;
using System.Linq.Expressions;

namespace LilValidation.Utilities
{
    public static class ExpressionEvaluator
    {
        /// <summary>
        /// Evaluate a MemberExperssion to return property
        /// </summary>
        /// <typeparam name="TProperty">The property type</typeparam>
        /// <param name="memberExpression">Expression to evaluate</param>
        /// <returns>Property</returns>
        public static TProperty CompileLocalMember<TProperty>(MemberExpression memberExpression)
        {
            UnaryExpression conversion = Expression.Convert(memberExpression, typeof(TProperty));
            Expression<Func<TProperty>> expression = Expression.Lambda<Func<TProperty>>(conversion);

            return expression
                .Compile()
                .Invoke();
        }
    }
}
