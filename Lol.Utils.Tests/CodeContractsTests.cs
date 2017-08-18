using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

#pragma warning disable 414

namespace Lol.Utils.Tests
{
    [Trait("Type", "Unit")]
    [SuppressMessage("ReSharper", "CollectionNeverUpdated.Local", Justification = "Test Code")]
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "Test Code")]
    public sealed class CodeContractsTests
    {
        [Fact]
        public void Ensure_is_greater_or_equal_int_works()
        {
            5.EnsureIsGreaterOrEqual(4);
            5.EnsureIsGreaterOrEqual(5);
            Action a = () => 5.EnsureIsGreaterOrEqual(6);
            a.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Ensure_is_greater_or_equal_double_works()
        {
            5.0.EnsureIsGreaterOrEqual(4.0);
            5.0.EnsureIsGreaterOrEqual(5.0);
            Action a = () => 5.0.EnsureIsGreaterOrEqual(6.0);
            a.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Ensure_is_greater_than_int_works()
        {
            5.EnsureIsGreaterThan(4);
            Action a = () => 5.EnsureIsGreaterThan(6);
            a.ShouldThrow<ArgumentOutOfRangeException>();
            a = () => 5.EnsureIsGreaterThan(5);
            a.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Ensure_is_greater_than_double_works()
        {
            5.0.EnsureIsGreaterThan(4.0);
            Action a = () => 5.0.EnsureIsGreaterThan(6.0);
            a.ShouldThrow<ArgumentOutOfRangeException>();
            a = () => 5.0.EnsureIsGreaterThan(5.0);
            a.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Ensure_is_less_or_equal_int_works()
        {
            3.EnsureIsLessOrEqual(4);
            5.EnsureIsLessOrEqual(5);
            Action a = () => 7.EnsureIsLessOrEqual(6);
            a.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Ensure_is_less_than_int_works()
        {
            3.EnsureIsLessThan(4);
            Action a = () => 5.EnsureIsLessThan(5);
            a.ShouldThrow<ArgumentOutOfRangeException>();
            a = () => 6.EnsureIsLessThan(5);
            a.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Ensure_equals_int_works()
        {
            3.EnsureEquals(3);
            Action a = () => 4.EnsureEquals(5);
            a.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Ensure_is_not_null_works()
        {
            "my".EnsureIsNotNull();
            object b = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            Action a = () => b.EnsureIsNotNull();
            a.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Ensure_reference_equals_works()
        {
            var a = new object();
            var b = new object();
            var c = b;
            ref var d = ref c;
            Action action = () => a.EnsureReferenceEquals(b);
            action.ShouldThrow<ArgumentException>();
            c.EnsureReferenceEquals(b);
            d.EnsureReferenceEquals(c);
            d.EnsureReferenceEquals(b);
        }

        [Fact]
        public void Ensure_is_reference_equals_works()
        {
            var a = new object();
            var b = new object();
            var c = b;
            ref var d = ref c;
            Action action = () => c.EnsuresReferenceNotEqual(b);
            action.ShouldThrow<ArgumentException>();
            c.EnsuresReferenceNotEqual(a);
            d.EnsuresReferenceNotEqual(a);
        }

        [Fact]
        public void Ensure_is_null_works()
        {
            object a = null;
            var b = new object();
            a.EnsureIsNull("must be null");
            Action action = () => b.EnsureIsNull();
            action.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Ensure_is_null_or_empty_works()
        {
            string a = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            a.EnsureIsNullOrEmpty();
            string.Empty.EnsureIsNullOrEmpty();
            Action action = () => "asdsd".EnsureIsNullOrEmpty();
            action.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Ensure_is_not_default_works()
        {
            Action a = () => false.EnsureIsNotDefault();
            a.ShouldThrow<ArgumentException>();
            true.EnsureIsNotDefault();
            new object().EnsureIsNotDefault();
            object b = null;
            // ReSharper disable once ExpressionIsAlwaysNull
            a = () => b.EnsureIsNotDefault();
            a.ShouldThrow<ArgumentException>();

            var vt = new ValueType { B = true };
            vt.EnsureIsNotDefault();

            vt = new ValueType { B = default(bool) };
            // ReSharper disable once AccessToModifiedClosure
            a = () => vt.EnsureIsNotDefault();
            a.ShouldThrow<ArgumentException>();

            vt = default(ValueType);
            a = () => vt.EnsureIsNotDefault();
            a.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Ensure_is_not_null_or_empty_string_works()
        {
            string a = null;
            "notempty".EnsureIsNotNullOrEmpty();

            // ReSharper disable once ExpressionIsAlwaysNull
            Action action = () => a.EnsureIsNotNullOrEmpty();
            action.ShouldThrow<ArgumentException>();

            action = () => string.Empty.EnsureIsNotNullOrEmpty();
            action.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Ensure_is_true_works()
        {
            true.EnsureIsTrue("No Error");
            Action action = () => false.EnsureIsTrue("Error");
            action.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Ensure_is_false_works()
        {
            false.EnsureIsFalse("No Error");
            Action action = () => true.EnsureIsFalse("Error");
            action.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Ensure_is_empty_works()
        {
            Guid.Empty.EnsureIsEmpty("no error");
            Action a = () => Guid.NewGuid().EnsureIsEmpty("this is an error");
            a.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Ensure_is_not_null_or_empty_enumerable_works()
        {
            IList<string> list = new List<string> { "string1 " };
            IList<string> emptyList = new List<string>();
            IList<string> nullList = null;
            list.EnsureIsNotNullOrEmpty("Error message");
            Action action = () => emptyList.EnsureIsNotNullOrEmpty();
            action.ShouldThrow<ArgumentException>();
            action = () => nullList.EnsureIsNotNullOrEmpty();
            action.ShouldThrow<ArgumentException>();
        }

        private struct ValueType
        {
            public bool B;
        }
    }
}
