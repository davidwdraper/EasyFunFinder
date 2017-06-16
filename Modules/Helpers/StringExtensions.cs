using System.Text;

namespace EasyFunFinder.Modules.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Return all lower case with no spaces to be used for normalized string comparisons
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CompareVal(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value.RemoveSpaces().ToLower();
        }

        /// <summary>
        /// Remove everything except alpha and numeric characters after first setting to lowercase.
        /// Used for string comparisons for items such as a postal code (i.e., Canadian postal code)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CompareAlphaNumeric(this string value)
        {
            var result = new StringBuilder(value.Length);
            value = value.Trim().ToLower();
            foreach (char c in value)
            {
                if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z'))
                    result.Append(c);
            }

            return result.ToString();
        }

        public static string RemoveSpaces(this string value)
        {
            var result = new StringBuilder(value.Length);
            foreach (char c in value)
            {
                if (c != ' ')
                    result.Append(c);
            }

            return result.ToString();
        }

        public static string RemoveNonNumeric(this string value)
        {
            var result = new StringBuilder(value.Length);
            foreach (char c in value)
            {
                if (c >= '0' && c <= '9')
                    result.Append(c);
            }

            return result.ToString();
        }
    }
}
