namespace MvcTemplate.Common.Extensions
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string Chop(this string s, int length)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(s);
            }

            var words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words[0].Length > length)
            {
                return words[0];
            }

            var sb = new StringBuilder();

            foreach (var word in words)
            {
                if ((sb + word).Length > length)
                {
                    return string.Format("{0}...", sb.ToString().TrimEnd(' '));
                }

                sb.Append(word + " ");
            }

            return string.Format("{0}...", sb.ToString().TrimEnd(' '));
        }

        public static string HideEmail(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(s);
            }

            string regex = @"(.{2}).+@.+(.{2}(?:\..{2,3}){1,2})";
            string replace = "$1*@*$2";

            return Regex.Replace(s, regex, replace);
        }
    }
}
