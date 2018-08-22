using System.Text.RegularExpressions;

namespace Common
{
    public class InputCheck
    {
        /// <summary>
        /// 半角英字チェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ContainsHalfWidthAlpthabet(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (Regex.IsMatch(input, @"[\u0041-\u005A]") || Regex.IsMatch(input, @"[\u0061-\u007A]"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 半角カナチェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ContainsHalfWidthKana(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(input,@"[\uFF61-\uFF9F]");
        }

        /// <summary>
        /// 半角記号チェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ContainsHalfWidthSybol(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (Regex.IsMatch(input, @"[\u0021-\002F]") || Regex.IsMatch(input, @"[\u003A-\u0040]") ||
                Regex.IsMatch(input, @"[\u005B-\u0060]") || Regex.IsMatch(input, @"[\u007B-\u007F]"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 全角数値チェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ContainsFullWidthNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(input, @"[\uFF10-\uFF19]");
        }

        /// <summary>
        /// 全角英字チェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ContainsFullWidthAlpthabet(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if(Regex.IsMatch(input, @"[\uFF21-\uFF3A]") || Regex.IsMatch(input, @"[\uFF41-\uFF5A]"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// ひらがなチェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ContainsFullWidthHiragana(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(input, @"[\u3041-\u3096]");
        }

        /// <summary>
        /// 全角カナチェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ContainsFullWidthKana(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return Regex.IsMatch(input, @"[\u30A1-\u30FA]");
        }

        /// <summary>
        /// 全角記号チェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ContainsFullWidthSybol(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (Regex.IsMatch(input, @"[\uFF01-\uFF0F]") || Regex.IsMatch(input, @"[\uFF1A-\uFF20]") ||
                Regex.IsMatch(input, @"[\uFF3B-\uFF40]") || Regex.IsMatch(input, @"[\uFF5B-\uFF65]"))
            {
                return true;
            }
            return false;
        }

    }
}
