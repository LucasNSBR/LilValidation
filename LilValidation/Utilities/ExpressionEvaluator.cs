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
        public static TProperty CompileLocalMember<T, TProperty>(MemberExpression memberExpression, T instance)
        {
            ParameterExpression parameter = null;

            if (memberExpression.Expression is ParameterExpression)
                parameter = (ParameterExpression)memberExpression.Expression;
            else
                throw new NotSupportedException("You need to pass a parameter in order to do this action, use (p => p.Property) like expression.");


            UnaryExpression conversion = Expression.Convert(memberExpression, typeof(TProperty));
            Expression<Func<T, TProperty>> expression = Expression.Lambda<Func<T, TProperty>>(conversion, parameter);

            return expression
                .Compile()
                .Invoke(instance);
        }
    }
}
