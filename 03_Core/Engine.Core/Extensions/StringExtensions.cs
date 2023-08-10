/*
 * MIT License
 * Copyright (c) 2022 Tony Haase
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Engine.Core.Extensions;

/// <summary>
///     Class to provide string extension methods
/// </summary>
public static class StringExtensions
{
    /// <summary>
    ///     Capitalizes the first character of the specified string.
    /// </summary>
    /// <param name="value">The string to capitalize.</param>
    /// <returns>A new string with the first character capitalized, or the original string if it is null or empty.</returns>
    public static string Capitalize(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        var chars = value.ToCharArray();

        if (char.IsLetter(chars[0]))
        {
            chars[0] = char.ToUpper(chars[0]);
        }

        return new string(chars);
    }

    /// <summary>
    ///     Counts the number of occurrences of a specified character in a string.
    /// </summary>
    /// <param name="value">The string to search in.</param>
    /// <param name="search">The character to count.</param>
    /// <returns>The number of occurrences of the specified character in the string.</returns>
    public static int Count(this string value, char search) =>
        string.IsNullOrEmpty(value)
            ? 0
            : value.Count(c => c == search);

    /// <summary>
    ///     Counts the number of occurrences of a specified string in another string.
    /// </summary>
    /// <param name="value">The string to search in.</param>
    /// <param name="search">The string to count.</param>
    /// <returns>The number of occurrences of the specified string in the string.</returns>
    public static int Count(this string value, string search)
    {
        // Check if the search string is null or empty
        if (string.IsNullOrEmpty(search) || string.IsNullOrEmpty(value))
        {
            return 0;
        }

        var count = 0;
        var index = 0;

        while (index >= 0 && index < value.Length)
        {
            index = value.IndexOf(search, index, StringComparison.Ordinal);

            // Check if an occurrence was found
            if (index >= 0)
            {
                // Increment the count and move the index past the search string
                count++;
                index += search.Length;
            }
        }

        // Return the count
        return count;
    }

    /// <summary>
    ///     Determines whether a string consists only of numeric characters.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True if the string consists only of numeric characters, false otherwise.</returns>
    public static bool IsAllNum(this string value) =>

        // Check if the string is null or empty
        !string.IsNullOrEmpty(value) && value.All(ch => char.IsDigit(ch));

    /// <summary>
    ///     Determines whether a string consists only of ASCII characters.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True if the string consists only of ASCII characters, false otherwise.</returns>
    public static bool IsAscii(this string value) => !string.IsNullOrEmpty(value) && value.All(ch => ch <= 127);

    /// <summary>
    ///     Determines whether a string is encoded in UTF-8.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True if the string is encoded in UTF-8, false otherwise.</returns>
    public static bool IsUtf8(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return false;
        }

        return value == Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(value));
    }

    /// <summary>
    ///     Determines whether a string is encoded in UTF-16.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True if the string is encoded in UTF-16, false otherwise.</returns>
    public static bool IsUtf16(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return false;
        }

        return value == Encoding.Unicode.GetString(Encoding.Unicode.GetBytes(value));
    }

    /// <summary>
    ///     Determines whether a string represents a decimal number.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True if the string represents a decimal number, false otherwise.</returns>
    public static bool IsDecimal(this string value) => !string.IsNullOrEmpty(value) && decimal.TryParse(value, out _);

    /// <summary>
    ///     Determines whether a string is a valid C# identifier.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True if the string is a valid C# identifier, false otherwise.</returns>
    public static bool IsIdentifier(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return false;
        }

        if (!char.IsLetter(value[0]) && value[0] != '_')
        {
            return false;
        }

        for (var i = 1; i < value.Length; i++)
        {
            if (!char.IsLetterOrDigit(value[i]) && value[i] != '_')
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether a string consists only of lowercase characters.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True if the string consists only of lowercase characters, false otherwise.</returns>
    public static bool IsLower(this string value) => !string.IsNullOrEmpty(value) && value.All(ch => char.IsLower(ch));

    /// <summary>
    ///     Determines whether a string consists only of uppercase characters.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True if the string consists only of uppercase characters, false otherwise.</returns>
    public static bool IsUpper(this string value) => !string.IsNullOrEmpty(value) && value.All(ch => char.IsUpper(ch));

    /// <summary>
    ///     Generates a JSON string from a source string with the format "key:value|Key:value ...".
    /// </summary>
    /// <param name="value">The source string.</param>
    /// <returns>A JSON string representing the key-value pairs in the source string.</returns>
    public static string ToJson(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return "{}";
        }

        var pairs = value.Split('|');
        var jsonBuilder = new StringBuilder();
        jsonBuilder.Append('{');

        for (var i = 0; i < pairs.Length; i++)
        {
            var keyValue = pairs[i].Split(':');
            jsonBuilder.Append($"\"{keyValue[0]}\":\"{keyValue[1]}\"");

            if (i < pairs.Length - 1)
            {
                jsonBuilder.Append(',');
            }
        }

        jsonBuilder.Append('}');
        return jsonBuilder.ToString();
    }

    /// <summary>
    ///     Reverses the order of the characters in a string.
    /// </summary>
    /// <param name="value">The string to reverse.</param>
    /// <returns>The reversed string.</returns>
    public static string Reverse(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        var reversedBuilder = new StringBuilder();

        for (var i = value.Length - 1; i >= 0; i--)
        {
            reversedBuilder.Append(value[i]);
        }

        return reversedBuilder.ToString();
    }

    /// <summary>
    ///     Determines whether a string consists only of alphabetic characters.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True if the string consists only of alphabetic characters, false otherwise.</returns>
    public static bool IsAlpha(this string value) => !string.IsNullOrEmpty(value) && value.All(ch => char.IsLetter(ch));

    /// <summary>
    ///     Converts a string to an Int16 value.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The Int16 value represented by the string.</returns>
    public static short ToInt16(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("The input string must not be null or empty.");
        }

        if (short.TryParse(value, out var result))
        {
            return result;
        }

        throw new FormatException("The input string is not in a valid format for an Int16 value.");
    }

    /// <summary>
    ///     Converts a string to an Int32 value.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The Int32 value represented by the string.</returns>
    public static int ToInt32(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("The input string must not be null or empty.");
        }

        if (int.TryParse(value, out var result))
        {
            return result;
        }

        throw new FormatException("The input string is not in a valid format for an Int32 value.");
    }

    /// <summary>
    ///     Converts a string to an Int64 value.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The Int64 value represented by the string.</returns>
    public static long ToInt64(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("The input string must not be null or empty.");
        }

        if (long.TryParse(value, out var result))
        {
            return result;
        }

        throw new FormatException("The input string is not in a valid format for an Int64 value.");
    }

    /// <summary>
    ///     Converts a string to a decimal value.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The decimal value represented by the string.</returns>
    public static decimal ToDecimal(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("The input string must not be null or empty.");
        }

        var numberFormatInfo = new NumberFormatInfo
        {
            NumberDecimalSeparator = ","
        };
        if (decimal.TryParse(value, NumberStyles.Any, numberFormatInfo, out var result))
        {
            return result;
        }

        numberFormatInfo = new NumberFormatInfo
        {
            NumberDecimalSeparator = "."
        };
        if (decimal.TryParse(value, NumberStyles.Any, numberFormatInfo, out result))
        {
            return result;
        }

        throw new FormatException("The input string is not in a valid format for a decimal value.");
    }

    /// <summary>
    ///     Converts a string to a float value.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The float value represented by the string.</returns>
    public static float ToFloat(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("The input string must not be null or empty.");
        }

        var numberFormatInfo = new NumberFormatInfo
        {
            NumberDecimalSeparator = ","
        };
        if (float.TryParse(value, NumberStyles.Any, numberFormatInfo, out var result))
        {
            return result;
        }

        numberFormatInfo = new NumberFormatInfo
        {
            NumberDecimalSeparator = "."
        };
        if (float.TryParse(value, NumberStyles.Any, numberFormatInfo, out result))
        {
            return result;
        }

        throw new FormatException("The input string is not in a valid format for a float value.");
    }

    /// <summary>
    ///     Converts a string to a boolean value.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The boolean value represented by the string.</returns>
    public static bool ToBoolean(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("The input string must not be null or empty.");
        }

        if (value.IsAllNum() && value.Length == 1)
        {
            switch (value[..1])
            {
                case "1":
                    return true;
                case "0":
                    return false;
            }
        }

        if (bool.TryParse(value, out var result))
        {
            return result;
        }

        throw new FormatException("The input string is not in a valid format for a boolean value.");
    }

    /// <summary>
    ///     Extracts the text inside a quote inside a string.
    /// </summary>
    /// <param name="value">The string to extract from.</param>
    /// <param name="quote">The quote character to use (single quote by default).</param>
    /// <returns>The extracted text inside the quote.</returns>
    public static string ExtractQuotedText(this string value, char quote = '\'')
    {
        // Check if the string is null or empty
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("The input string must not be null or empty.");
        }

        var regex = new Regex($"{quote}(.*?){quote}");
        var match = regex.Match(value);

        if (match.Success)
        {
            return match.Groups[1].Value;
        }

        throw new ArgumentException("The input string does not contain a quote character.");
    }

    /// <summary>
    ///     Evaluates a mathematical formula represented as a string and returns the result.
    /// </summary>
    /// <param name="value">The input string that represents the formula.</param>
    /// <returns>The calculated result as a string.</returns>
    public static string Calculate(this string value)
    {
        value = value.Replace(" ", "");
        var dt = new DataTable();
        var result = dt.Compute(value, "");
        return result.ToString() ?? string.Empty;
    }
}
