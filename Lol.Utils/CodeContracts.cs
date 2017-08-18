using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Lol.Utils
{
    /// <summary>
    /// Code contracts to ensure preconditions and post conditions are met and errors are detected as early as possible.
    /// </summary>
    public static class CodeContracts
    {
        //public static void EnsureIsInSet<T>(this object value, string message, T setItem)
        //{
        //    if ()
        //}
        
        /// <summary>
        /// Ensures the value is false
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="message">error message</param>
        [ContractAnnotation("value:true => halt")]
        [AssertionMethod]
        public static void EnsureIsFalse(this bool value, string message)
        {
            if (value)
                throw new ArgumentException(message);
        }

        /// <summary>
        /// Ensures the value is true
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="message">error message</param>
        [ContractAnnotation("value:false => halt")]
        [AssertionMethod]
        public static void EnsureIsTrue(this bool value, string message)
        {
            if (!value)
                throw new ArgumentException(message);
        }

        /// <summary>
        /// Ensures a value to be greater than or equal a minimum value.
        /// </summary> 
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <exception cref="ArgumentOutOfRangeException">value must be greater or equal  + minValue</exception>
        [AssertionMethod]
        public static void EnsureIsGreaterOrEqual(this int value, int minValue)
        {
            if (value < minValue)
                throw new ArgumentOutOfRangeException("value must be greater or equal " + minValue);
        }

        /// <summary>
        /// Ensures a value to be greater than or equal a minimum value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <exception cref="ArgumentOutOfRangeException">value must be greater or equal  + minValue</exception>
        [AssertionMethod]
        public static void EnsureIsGreaterOrEqual(this double value, double minValue)
        {
            if (value < minValue)
                throw new ArgumentOutOfRangeException("value must be greater or equal " + minValue);
        }

        /// <summary>
        /// Ensures a value to be greater than a minimum value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <exception cref="ArgumentOutOfRangeException">value must be greater than  + minValue</exception>
        [AssertionMethod]
        public static void EnsureIsGreaterThan(this double value, double minValue)
        {
            if (value <= minValue)
                throw new ArgumentOutOfRangeException("value must be greater than " + minValue);
        }

        /// <summary>
        /// Ensures a value to be greater than a minimum value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="message">custom error message</param>
        /// <exception cref="ArgumentOutOfRangeException">value must be greater than  + minValue</exception>
        [AssertionMethod]
        public static void EnsureIsGreaterThan(this int value, int minValue, string message)
        {
            if (value <= minValue)
                throw new ArgumentOutOfRangeException(message);
        }

        /// <summary>
        /// Ensures a value to be greater than a minimum value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <exception cref="ArgumentOutOfRangeException">value must be greater than  + minValue</exception>
        [AssertionMethod]
        public static void EnsureIsGreaterThan(this int value, int minValue)
            => EnsureIsGreaterThan(value, minValue, "value must be greater than " + minValue);

        /// <summary>
        /// Ensures a value to be smaller than a maximum value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <exception cref="ArgumentOutOfRangeException">value must be less or equal  + maxValue</exception>
        [AssertionMethod]
        public static void EnsureIsLessOrEqual(this int value, int maxValue)
        {
            if (value > maxValue)
                throw new ArgumentOutOfRangeException("value must be less or equal " + maxValue);
        }

        /// <summary>
        /// Ensures two values to be equal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="equalValue">The value to compare.</param>
        /// <exception cref="ArgumentOutOfRangeException">value must equal  + equalValue</exception>
        [AssertionMethod]
        public static void EnsureEquals(this int value, int equalValue)
        {
            if (value != equalValue)
                throw new ArgumentOutOfRangeException("value must equal " + equalValue);
        }

        /// <summary>
        /// Ensures a value to be smaller than or equal a maximum value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <exception cref="ArgumentOutOfRangeException">value must be less than  + maxValue</exception>
        [AssertionMethod]
        public static void EnsureIsLessThan(this int value, int maxValue)
        {
            if (value >= maxValue)
                throw new ArgumentOutOfRangeException("value must be less than " + maxValue);
        }

        /// <summary>
        /// Ensures that a value is not null
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">value must not be null</exception>
        [ContractAnnotation("value: null => halt")]
        [AssertionMethod]
        public static void EnsureIsNotNull<T>([NoEnumeration] this T value) where T : class
        {
            EnsureIsNotNull(value, "Argument cannot be null");
        }

        /// <summary>
        /// Ensures that a value is not null
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="message">Custom error message</param>
        /// <exception cref="ArgumentNullException">value must not be null</exception>
        [ContractAnnotation("value: null => halt")]
        [AssertionMethod]
        public static void EnsureIsNotNull<T>([NoEnumeration] this T value, string message) where T : class
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), message);
        }

        /// <summary>
        /// Ensures two class references point to the same instance
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="other">The value to compare.</param>
        [AssertionMethod]
        public static void EnsureReferenceEquals(this object value, object other)
        {
            if (value != other)
                throw new ArgumentException("values must be equal");
        }

        /// <summary>
        /// Ensures two class references are not equal
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="other">The value to compare.</param>
        [AssertionMethod]
        public static void EnsuresReferenceNotEqual(this object value, object other)
        {
            if (value == other)
                throw new ArgumentException("values must not be equal");
        }

        /// <summary>
        /// Ensures that a value is not default (null for classes, default for structs, false for boolean etc.
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">value must not be default</exception>
        [ContractAnnotation("null => halt")]
        [AssertionMethod]
        public static void EnsureIsDefault<T>(this T value) =>
            value.EnsureIsDefault("value must be default");

        /// <summary>
        /// Ensures that a value is not default (null for classes, default for structs, false for boolean etc.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="message">Error message in case constraint is false.</param>
        /// <exception cref="ArgumentException">value must not be default.</exception>
        [ContractAnnotation("value: null => halt")]
        [AssertionMethod]
        public static void EnsureIsDefault<T>(this T value, string message)
        {
            if (!EqualityComparer<T>.Default.Equals(value, default(T)))
                throw new ArgumentException(message);
        }

        /// <summary>
        /// Ensures that a value is not default (null for classes, default for structs, false for boolean etc.
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">value must not be default</exception>
        [ContractAnnotation("null => halt")]
        [AssertionMethod]
        public static void EnsureIsNotDefault<T>(this T value) =>
            value.EnsureIsNotDefault("value must not be default");

        /// <summary>
        /// Ensures that a value is not default (null for classes, default for structs, false for boolean etc.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="message">Error message in case constraint is false.</param>
        /// <exception cref="ArgumentException">value must not be default.</exception>
        [ContractAnnotation("value: null => halt")]
        [AssertionMethod]
        public static void EnsureIsNotDefault<T>(this T value, string message)
        {
            if (EqualityComparer<T>.Default.Equals(value, default(T)))
                throw new ArgumentException(message);
        }

        /// <summary>
        /// Ensures that a value is null.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="message">Custom error message</param>
        /// <exception cref="ArgumentException">value must be null</exception>
        [ContractAnnotation("value:notnull => halt")]
        [AssertionMethod]
        public static void EnsureIsNull<T>(this T value, string message) where T : class
        {
            if (value != null)
                throw new ArgumentException(message);
        }

        /// <summary>
        /// Ensures that a value is null.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">value must be null</exception>
        [ContractAnnotation("notnull => halt")]
        [AssertionMethod]
        public static void EnsureIsNull<T>(this T value) where T : class =>
            EnsureIsNull(value, "value must be null");

        /// <summary>
        /// Ensures that a string is not null or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">string must not be null or empty</exception>
        [ContractAnnotation("value: null => halt")]
        [AssertionMethod]
        public static void EnsureIsNotNullOrEmpty(this string value) =>
            EnsureIsNotNullOrEmpty(value, "string must not be null or empty");

        /// <summary>
        /// Ensures that a string is not null or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">Custom error message</param>
        /// <exception cref="ArgumentException">string must not be null or empty</exception>
        [ContractAnnotation("value: null => halt")]
        [AssertionMethod]
        public static void EnsureIsNotNullOrEmpty(this string value, string message)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(message);
        }

        /// <summary>
        /// Ensures that a string is null or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">string must not be null or empty</exception>
        [AssertionMethod]
        public static void EnsureIsNullOrEmpty(this string value) =>
            EnsureIsNullOrEmpty(value, "string must be null or empty");

        /// <summary>
        /// Ensures that a string is null or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">Custom error message</param>
        /// <exception cref="ArgumentException">string must not be null or empty</exception>
        [AssertionMethod]
        public static void EnsureIsNullOrEmpty(this string value, string message)
        {
            if (!string.IsNullOrEmpty(value))
                throw new ArgumentException(message);
        }

        /// <summary>
        /// Ensures that a Guid is not empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">Custom error message.</param>
        /// <exception cref="ArgumentException">Guid must not be an empty guid</exception>
        [AssertionMethod]
        public static void EnsureIsNotEmpty(this Guid value, string message)
        {
            if (value == Guid.Empty)
                throw new ArgumentException(message);
        }

        /// <summary>
        /// Ensures that a Guid is empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">Custom error message</param>
        /// <exception cref="ArgumentException">Guid must not be an empty guid</exception>
        [AssertionMethod]
        public static void EnsureIsEmpty(this Guid value, string message)
        {
            if (value != Guid.Empty)
                throw new ArgumentException(message);
        }

        /// <summary>
        /// Ensures that an enumerable is not null or empty.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <exception cref="ArgumentException">Enumerable must not be null or empty</exception>
        [ContractAnnotation("null => halt")]
        [AssertionMethod]
        public static void EnsureIsNotNullOrEmpty<T>(this IEnumerable<T> enumerable) =>
            EnsureIsNotNullOrEmpty(enumerable, "Enumerable must not be null or empty");

        /// <summary>
        /// Ensures that an enumerable is not null or empty.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="errorMessage">custom error message</param>
        /// <exception cref="ArgumentException">Enumerable must not be null or empty</exception>
        [ContractAnnotation("enumerable: null => halt")]
        [AssertionMethod]
        public static void EnsureIsNotNullOrEmpty<T>(this IEnumerable<T> enumerable, string errorMessage)
        {
            if (enumerable == null || !enumerable.Any())
                throw new ArgumentException(errorMessage);
        }
    }
}
