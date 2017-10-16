    using System.Collections.Generic;
    using System.Text;

    public class RomanConverter
    {
        private static readonly Dictionary<char, int> RomanDic = new Dictionary<char, int>
                                                            {
                                                                {'I', 1},
                                                                {'V', 5},
                                                                {'X', 10},
                                                                {'L', 50},
                                                                {'C', 100},
                                                                {'D', 500},
                                                                {'M', 1000}
                                                            };

        private static readonly Dictionary<int, string> NumberRomanDictionary = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

        public static int ConvertToNumber(string roman)
        {
            int number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && RomanDic[roman[i]] < RomanDic[roman[i + 1]])
                {
                    number -= RomanDic[roman[i]];
                }
                else
                {
                    number += RomanDic[roman[i]];
                }
            }

            return number;
        }

        public static string ConvertToRoman(int number)
        {
            var roman = new StringBuilder();
            foreach (var item in NumberRomanDictionary)
            {
                while (number >= item.Key)
                {
                    roman.Append(item.Value);
                    number -= item.Key;
                }
            }
            return roman.ToString();
        }
    }
