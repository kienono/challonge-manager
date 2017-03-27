using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ChallongeManager
{
    public class Tools
    {
        public static string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        static string charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static int GetDigitValue(char digit)
        {
            return charset.IndexOf(digit)+1;
        }
        public static int ConvertFromBase26(string number)
        {
            int result = 0;
            foreach (char digit in number)
                result = result * charset.Length + GetDigitValue(digit);

            return result;
        }
    }
}
