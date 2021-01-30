namespace CleanTestBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public abstract class Builder<T>
    {
        private readonly Dictionary<string, object> _properties =
            new();

        protected abstract T Build();

        public static implicit operator T(Builder<T> builder)
        {
            return builder.Build();
        }

        /// <summary>
        /// Temporarily hold property value
        /// </summary>
        /// <typeparam name="TProp">Property type</typeparam>
        /// <param name="action">Property expression</param>
        /// <param name="value">Value to hold</param>
        public void Set<TProp>(Expression<Func<T, TProp>> action, TProp value)
        {
            var expression = (MemberExpression)action.Body;
            var name = expression.Member.Name;

            _properties[name] = value;
        }

        /// <summary>
        /// Get previously set value
        /// </summary>
        /// <typeparam name="TProp">Property type</typeparam>
        /// <param name="action">Property expression</param>
        /// <returns></returns>
        public TProp Get<TProp>(Expression<Func<T, TProp>> action)
        {
            var expression = (MemberExpression)action.Body;
            var name = expression.Member.Name;

            var exists = _properties.TryGetValue(name, out var value);

            return exists ? value as dynamic : default(TProp);
        }
    }
}