using System;
using System.Linq;
namespace MyFirstDll
{
    public class TextWork
    {
        public static Boolean IsPalindrome(String text)
        {
            String cleanedText = new String(text.Where(char.IsLetterOrDigit).ToArray());
            String reversedText = new String(cleanedText.Reverse().ToArray());
            return cleanedText.Equals(reversedText, StringComparison.OrdinalIgnoreCase);
        }

        public static Int32 CountSentences(String text)
        {
            return text.Split('.', '?', '!').Length - 1;
        }

        public static String ReverseString(String text)
        {
            Char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new String(charArray);
        }
    }
}
