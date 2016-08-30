using System;
using System.Text.RegularExpressions;

namespace SpaUserControl.Common.Validation
{
    public class AssertionConcern
    {
        public static void AssertArgumentEquals(object objectToCompare, object anotherObject, string message)
        {
            if (!objectToCompare.Equals(anotherObject))
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentFalse(bool value, string message)
        {
            if (value)
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentLength(string value, int maximum, string message)
        {
            var length = value.Trim().Length;
            if (length > maximum)
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentLength(string value, int minimum, int maximum, string message)
        {
            var length = value.Trim().Length;
            if (length < minimum || length > maximum)
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentMatches(string pattern, string value, string message)
        {
            if (!Regex.IsMatch(value, pattern))
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentNotEmpty(string value, string message)
        {
            if (value == null || value.Trim().Length == 0)
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentNotEquals(object objectToCompare, object anotherObject, string message)
        {
            if (objectToCompare.Equals(anotherObject))
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentNotNull(object objectToCompare, string message)
        {
            if (objectToCompare == null)
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentRange(double value, double minimum, double maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentRange(float value, float minimum, float maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentRange(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentRange(long value, long minimum, long maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentTrue(bool value, string message)
        {
            if (!value)
                throw new InvalidOperationException(message);
        }

        public static void AssertStateFalse(bool value, string message)
        {
            if (value)
                throw new InvalidOperationException(message);
        }

        public static void AssertStateTrue(bool value, string message)
        {
            if (!value)
                throw new InvalidOperationException(message);
        }

        protected AssertionConcern()
        {
        }

        protected static void SelfAssertArgumentEquals(object objectToCompare, object anotherObject, string message)
        {
            AssertionConcern.AssertArgumentEquals(objectToCompare, anotherObject, message);
        }

        protected static void SelfAssertArgumentFalse(bool value, string message)
        {
            AssertionConcern.AssertArgumentFalse(value, message);
        }

        protected static void SelfAssertArgumentLength(string value, int maximum, string message)
        {
            AssertionConcern.AssertArgumentLength(value, maximum, message);
        }

        protected static void SelfAssertArgumentLength(string value, int minimum, int maximum, string message)
        {
            AssertionConcern.AssertArgumentLength(value, minimum, maximum, message);
        }

        protected static void SelfAssertArgumentMatches(string pattern, string value, string message)
        {
            AssertionConcern.AssertArgumentMatches(pattern, value, message);
        }

        protected static void SelfAssertArgumentNotEmpty(string value, string message)
        {
            AssertionConcern.AssertArgumentNotEmpty(value, message);
        }

        protected static void SelfAssertArgumentNotEquals(object objectToCompare, object anotherObject, string message)
        {
            AssertionConcern.AssertArgumentNotEquals(objectToCompare, anotherObject, message);
        }

        protected static void SelfAssertArgumentNotNull(object objectToCompare, string message)
        {
            AssertionConcern.AssertArgumentNotNull(objectToCompare, message);
        }

        protected static void SelfAssertArgumentRange(double value, double minimum, double maximum, string message)
        {
            AssertionConcern.AssertArgumentRange(value, minimum, maximum, message);
        }

        protected static void SelfAssertArgumentRange(float value, float minimum, float maximum, string message)
        {
            AssertionConcern.AssertArgumentRange(value, minimum, maximum, message);
        }

        protected static void SelfAssertArgumentRange(int value, int minimum, int maximum, string message)
        {
            AssertionConcern.AssertArgumentRange(value, minimum, maximum, message);
        }

        protected static void SelfAssertArgumentRange(long value, long minimum, long maximum, string message)
        {
            AssertionConcern.AssertArgumentRange(value, minimum, maximum, message);
        }

        protected static void SelfAssertArgumentTrue(bool value, string message)
        {
            AssertionConcern.AssertArgumentTrue(value, message);
        }

        protected static void SelfAssertStateFalse(bool value, string message)
        {
            AssertionConcern.AssertStateFalse(value, message);
        }

        protected static void SelfAssertStateTrue(bool value, string message)
        {
            AssertionConcern.AssertStateTrue(value, message);
        }
    }
}