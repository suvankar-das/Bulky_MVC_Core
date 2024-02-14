using System.Text.RegularExpressions;

namespace BulkyWeb.Utils
{
    public class Utils
    {
        public static bool CheckForSpecialCharacter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            string pattern = @"[^a-zA-Z0-9\s]";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}
