using System;
using System.Text.RegularExpressions;

namespace EasyFunFinder.DAL.Helpers
{
    public static class Verify
    {
        public static void HasContent(string paramName, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format("Parameter {0} is null or empty - a value was expected", paramName), paramName);
            }
        }

        public static void HasPositiveInteger(string paramName, int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format("Parameter {0} < 0 - postive value was expected", paramName), paramName);
            }
        }

        public static void Length(string paramName, int length, object[] value)
        {
            if (length != value.Length)
            {
                throw new ArgumentException(string.Format("Array parameter {0} does not have length of {1}", paramName, length), paramName);
            }
        }

        public static void IsTrue(string paramName, bool value)
        {
            if (!value)
            {
                throw new ArgumentException(string.Format("Parameter {0} did not assert to true", paramName), paramName);
            }
        }

        public static void NotZero(string paramName, int value)
        {
            if (value == 0)
            {
                throw new ArgumentException(string.Format("Parameter {0} was zero", paramName), paramName);
            }
        }
        public static void NotZero(string paramName, long value)
        {
            if (value == 0)
            {
                throw new ArgumentException(string.Format("Parameter {0} was zero", paramName), paramName);
            }
        }

        public static void NotZero(string paramName, float value)
        {
            if (value == 0)
            {
                throw new ArgumentException(string.Format("Parameter {0} was zero", paramName), paramName);
            }
        }

        public static void NotZero(string paramName, double value)
        {
            if (value == 0)
            {
                throw new ArgumentException(string.Format("Parameter {0} was zero", paramName), paramName);
            }
        }

        public static void NotNull(string paramName, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName, "Value expected");
            }
        }

        public static void IsType(string paramName, object value, Type aType)
        {
            if (value.GetType() != aType)
            {
                throw new ArgumentException(string.Format("Parameter {0} not of type: {1}", paramName, aType.Name), paramName);
            }
        }

        public static void EMail(string paramName, string email)
        {
            Verify.HasContent(paramName, email);
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                throw new ArgumentException(string.Format("EMail parameter {0} is not of the correct format", email));
            }
        }
    }
}