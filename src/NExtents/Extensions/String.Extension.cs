using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NExtents
{
  /// <summary>
  /// Extensions for type <see cref="string"/>.
  /// </summary>
  public static class StringExtensions
  {
    /// <summary>
    /// Checks if current string is contained in one of the items of the given values.
    /// </summary>
    /// <param name="s"><see cref="string"/> object to be used.</param>
    /// <param name="values">Enumeration character values to be hecked</param>
    /// <param name="comparisonType">Comparison to be used for checks.</param>
    /// <returns>Index of the first matching location or -1 if no matches have been found.</returns>
    public static int IndexOf(this string s, IEnumerable<char> values, StringComparison comparisonType)
    {
      if (String.IsNullOrEmpty(s) || values == null)
      {
        return -1;
      }

      int result = -1;

      foreach (char value in values)
      {
#if NET45 || NETSTANDARD2_0
        result = s.IndexOf(value);
#else
        result = s.IndexOf(value, comparisonType);
#endif

        if (result >= 0)
        {
          break;
        }
      }

      return result;
    }

    /// <summary>
    /// Checks if current string is contained in one of the items of the given values.
    /// </summary>
    /// <param name="s"><see cref="string"/> object to be used.</param>
    /// <param name="values">Enumeration string values to be hecked</param>
    /// <param name="comparisonType">Comparison to be used for checks.</param>
    /// <returns>Index of the first matching location or -1 if no matches have been found.</returns>
    public static int IndexOf(this string s, IEnumerable<string> values, StringComparison comparisonType)
    {
      if (String.IsNullOrEmpty(s) || values == null)
      {
        return -1;
      }

      int result = -1;

      foreach (string value in values)
      {
        result = s.IndexOf(value, comparisonType);

        if (result >= 0)
        {
          break;
        }
      }

      return result;
    }

    /// <summary>
    /// Gets a string array that contains the substrings in this string that are delimited by elements of a specified string
    /// </summary>
    /// <param name="s">System.String object to be splitted</param>
    /// <param name="separator">A string that delimits the substrings in this instance, an empty string that contains no delimiters, or <c>null</c>.</param>
    /// <param name="options">Options for splitting strings</param>
    /// <returns>An array whose elements contain the substrings in this instance that are delimited by one or more characters in separator.
    /// For more information, see the Remarks section.</returns>
    /// <remarks>
    /// <para>
    ///   Delimiter string is not included in the elements of the returned array.
    /// </para>
    /// <para>
    /// If this instance does not contain the separator string, the returned array consists of a single element that contains
    /// this instance. If the separator parameter is <code>Nothing</code> or contains no characters, space character (&quot; &quot;) is
    /// assumed to be the delimiter.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentException"><i>Options</i> is not one of the <see cref="StringSplitOptions" /> values.</exception>
    public static string[] Split(this string s, string separator, StringSplitOptions options = StringSplitOptions.None)
    {
      if (options != StringSplitOptions.None && options != StringSplitOptions.RemoveEmptyEntries)
      {
        throw new ArgumentException(Resources.FailedToSplitStringOptionsMustEitherBeRemoveEmptyEntriesOrNoneErrorMessage, nameof(options));
      }

      if (String.IsNullOrEmpty(separator))
      {
        return s.Split((char[]?)null, options);
      }
      else
      {
        List<string> Result = new List<string>();
        int iSeparatorPos = 0;
        char[] acStringBuffer = s.ToCharArray();
        char[] acSeparatorBuffer = separator.ToCharArray();
        StringBuilder sbSplitBuffer = new StringBuilder();

        for (int i = 0; i < acStringBuffer.Length; i++)
        {
          // add current character to the split buffer
          sbSplitBuffer.Append(acStringBuffer[i]);

          // check if separator matches
          if (acStringBuffer[i] == acSeparatorBuffer[iSeparatorPos])
          {
            iSeparatorPos++;

            // check if complete separator did match
            if (iSeparatorPos == acSeparatorBuffer.Length)
            {
              // copy split buffer to result, but separator and reset split buffer
              Result.Add(sbSplitBuffer.ToString(0, sbSplitBuffer.Length - acSeparatorBuffer.Length));
              sbSplitBuffer.Remove(0, sbSplitBuffer.Length);

              // reset separator search index
              iSeparatorPos = 0;

              // add an empty element if the seperator was the last part of the System.String object.
              if (i == (acStringBuffer.Length - 1))
              {
                Result.Add("");
              }
            }
          }
          else
          {
            // no match found, reset separator search index
            iSeparatorPos = 0;
          }
        }

        // add current split buffer result if available
        if (sbSplitBuffer.Length > 0)
        {
          Result.Add(sbSplitBuffer.ToString());
        }

        // check whether empty entries have to be removed or not
        if (options == StringSplitOptions.RemoveEmptyEntries)
        {
          Result.RemoveAll(x => String.IsNullOrEmpty(x));
        }

        return Result.ToArray();
      }
    }

    /// <summary>
    /// Gets an indicator whether a string starts with one of the given values
    /// </summary>
    /// <param name="s">String to analyze</param>
    /// <param name="values">Enumeration of values</param>
    /// <param name="comparisonType">Optional. Specifies the comparison-type for the analysis. Default value is <see cref="StringComparison.Ordinal" />.</param>
    /// <returns><c>true</c> if string starts with one of the values, otherwise <c>false</c></returns>
    public static bool StartsWith(this string s, IEnumerable<string> values, StringComparison comparisonType = StringComparison.Ordinal)
    {
      if (values != null)
      {
        foreach (string sValue in values)
        {
          if (s.StartsWith(sValue, comparisonType))
          {
            return true;
          }
        }
      }

      return false;
    }

    /// <summary>
    /// Gets an indicator whether a string starts with on of the given values based on a culture
    /// </summary>
    /// <param name="s">String to analyze</param>
    /// <param name="values">Enumeration of values</param>
    /// <param name="ignoreCase">Indicator whether the analysis shall be case-sensetive or not</param>
    /// <param name="culture">Specifies the culture to use for the analysis</param>
    /// <returns><c>true</c> if string starts with one of the values, otherwise <c>false</c></returns>
    public static bool StartsWith(this string s, IEnumerable<string> values, bool ignoreCase, CultureInfo culture)
    {
      if (values != null)
      {
        foreach (string sValue in values)
        {
          if (s.StartsWith(sValue, ignoreCase, culture))
          {
            return true;
          }
        }
      }

      return false;
    }

    /// <summary>
    /// Tokenizes a string reagarding quoted parts
    /// </summary>
    /// <param name="s">String to be tokenized</param>
    /// <param name="quoteChar">Quote control character</param>
    /// <param name="separator">Additional seperator (beside space and tabulator)</param>
    /// <returns>String list containing all string tokens</returns>
    public static IList<string> Tokenize(this string s, char quoteChar = '"', char separator = ' ')
    {
      List<string> Result = new List<string>();
      StringBuilder sbToken = new StringBuilder();

      char[] aChars = s.ToCharArray();
      bool bInQuote = false;

      foreach (char cChar in aChars)
      {
        if (cChar == ' ' || cChar == (char)9 || cChar == separator)
        {
          // spaces, tabs and (optional) an additional delimeter
          // separates the tokens: only if not quoted
          if (!bInQuote)
          {
            // only create a new token if current entry is not empty. This
            // can occur if several seperators appear in a sequence
            if (sbToken.Length > 0)
            {
              Result.Add(sbToken.ToString());
              sbToken = new StringBuilder();
            }
          }
          else
          {
            // if quoted, it is part of the token, so append it
            sbToken.Append(cChar);
          }
        }
        else if (cChar == quoteChar)
        {
          bInQuote = !bInQuote;
        }
        else
        {
          sbToken.Append(cChar);
        }
      }

      // add the last token to the collection - only if not empty
      if (sbToken.Length > 0)
      {
        Result.Add(sbToken.ToString());
      }

      return Result.ToArray();
    }

    /// <summary>
    /// Trims a string based on a given value
    /// </summary>
    /// <param name="s">String to be trimmed</param>
    /// <param name="trimValue">Value to be trimmed on both sides</param>
    /// <param name="comparisonType">Optional. Specifies the comparison-type for the analysis. Default value is <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>Trimmed string based on given value</returns>
    public static string Trim(this string s, string trimValue, StringComparison comparisonType = StringComparison.Ordinal)
    {
      string Result;

      Result = TrimStart(s, trimValue, comparisonType);
      Result = TrimEnd(Result, trimValue, comparisonType);

      return Result;
    }

    /// <summary>
    /// Trims a string based on a given values
    /// </summary>
    /// <param name="s">String to be trimmed</param>
    /// <param name="trimValues">Values to be trimmed on both sides</param>
    /// <param name="comparisonType">Optional. Specifies the comparison-type for the analysis. Default value is <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>Trimmed string based on given values</returns>
    public static string Trim(this string s, IEnumerable<string> trimValues, StringComparison comparisonType = StringComparison.Ordinal)
    {
      if (!String.IsNullOrWhiteSpace(s) && trimValues != null)
      {
        foreach (string sTrimValue in trimValues)
        {
          s = StringExtensions.TrimStart(s, sTrimValue, comparisonType);
          s = StringExtensions.TrimEnd(s, sTrimValue, comparisonType);
        }
      }

      return s;
    }

    /// <summary>
    /// Trims a string's beginning based on a given value
    /// </summary>
    /// <param name="s">String to be trimmed at its beginning</param>
    /// <param name="trimValue">Value to be trimmed at the beginning</param>
    /// <param name="comparisonType">Optional. Specifies the comparison-type for the analysis. Default value is <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>Trimmed string based on the given value</returns>
    public static string TrimStart(this string s, string trimValue, StringComparison comparisonType = StringComparison.Ordinal)
    {
      if (!String.IsNullOrWhiteSpace(s) && !String.IsNullOrWhiteSpace(trimValue))
      {
        int iIndex = s.IndexOf(trimValue, comparisonType);

        if (iIndex != -1)
        {
          s = s.Substring(iIndex + trimValue.Length);
        }
      }

      return s;
    }

    /// <summary>
    /// Trims a string's beginning based on a given values
    /// </summary>
    /// <param name="s">String to be trimmed at its beginning</param>
    /// <param name="trimValues">Values to be trimmed at the beginning</param>
    /// <param name="comparisonType">Optional. Specifies the comparison-type for the analysis. Default value is <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>Trimmed string based on the given values</returns>
    public static string TrimStart(this string s, IEnumerable<string> trimValues, StringComparison comparisonType = StringComparison.Ordinal)
    {
      if (!String.IsNullOrWhiteSpace(s) && trimValues != null)
      {
        foreach (string sTrimValue in trimValues)
        {
          s = StringExtensions.TrimStart(s, sTrimValue, comparisonType);
        }
      }

      return s;
    }

    /// <summary>
    /// Trims a string's beginning based on a given value
    /// </summary>
    /// <param name="s">String to be trimmed at its beginning</param>
    /// <param name="trimValue">Value to be trimmed at the beginning</param>
    /// <param name="comparisonType">Optional. Specifies the comparison-type for the analysis. Default value is <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>Trimmed string based on the given value</returns>
    public static string TrimEnd(this string s, string trimValue, StringComparison comparisonType = StringComparison.Ordinal)
    {
      if (!String.IsNullOrWhiteSpace(s) && !String.IsNullOrWhiteSpace(trimValue))
      {
        int iIndex = s.IndexOf(trimValue, comparisonType);

        if (iIndex != -1)
        {
          s = s.Substring(0, iIndex);
        }
      }

      return s;
    }

    /// <summary>
    /// Trims a string's end based on a given values
    /// </summary>
    /// <param name="s">String to be trimmed at its end</param>
    /// <param name="trimValues">Values to be trimmed at the end</param>
    /// <param name="comparisonType">Optional. Specifies the comparison-type for the analysis. Default value is <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>Trimmed string based on the given values</returns>
    public static string TrimEnd(this string s, IEnumerable<string> trimValues, StringComparison comparisonType = StringComparison.Ordinal)
    {
      if (!String.IsNullOrWhiteSpace(s) && trimValues != null)
      {
        foreach (string sTrimValue in trimValues)
        {
          s = StringExtensions.TrimEnd(s, sTrimValue, comparisonType);
        }
      }

      return s;
    }

    /// <summary>
    /// Capitalizes a string
    /// </summary>
    /// <param name="s">String to be capitalized</param>
    /// <returns>Capitalized string</returns>
    public static string Capitalize(this string s)
    {
      if (String.IsNullOrWhiteSpace(s))
      {
        return s;
      }
      else
      {
        return s.Substring(0, 1).ToUpper(CultureInfo.InvariantCulture) + s.Substring(1, s.Length - 1);
      }
    }

    /// <summary>
    /// Decapitalizes a string
    /// </summary>
    /// <param name="s">String to be decapitalized</param>
    /// <returns>Decapitalized string</returns>
    public static string Decapitalize(this string s)
    {
      if (String.IsNullOrWhiteSpace(s))
      {
        return s;
      }
      else
      {
        return s.Substring(0, 1).ToLower(CultureInfo.InvariantCulture) + s.Substring(1, s.Length - 1);
      }
    }

    /// <summary>
    /// Returns a value indicating whether a specified substring occurs within this string
    /// </summary>
    /// <param name="s">The string to examine</param>
    /// <param name="value">The string to seek</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules of the search</param>
    /// <returns><c>true</c> if the value parameter occurs within this string, otherwise <c>false</c>.</returns>
    public static bool Contains(this string s, string value, StringComparison comparisonType)
    {
#if NETSTANDARD2_1
      return s.Contains(value, comparisonType);
#else
      return (s.IndexOf(value, comparisonType) >= 0);
#endif
    }

    /// <summary>
    /// Returns a value indicating if the content of a specific string is equal to the current one
    /// </summary>
    /// <param name="s">String to be analyzed</param>
    /// <param name="value">Value to compare</param>
    /// <remarks>The difference to the default <see cref="string.Equals(string)"/> is, that linebreaks are treated equally (either \r\n or \n)</remarks>
    /// <returns></returns>
    public static bool ContentEquals(this string s, string value)
    {
      if (value == null)
      {
        return false;
      }
      else
      {
        return s.Replace("\r\n", "\n", StringComparison.Ordinal).Equals(value.Replace("\r\n", "\n", StringComparison.Ordinal), StringComparison.Ordinal);
      }
    }

    /// <summary>
    /// Returns a value indicating whether a specific string value contains a numeric value or not
    /// </summary>
    /// <param name="s">String to be analyzed</param>
    /// <returns><c>true</c> if value contains a numeric value, otherwise <c>false</c></returns>
    public static bool IsNumeric(this string s)
    {
      return double.TryParse(s, out double _);
    }

    /// <summary>
    /// Repeats the string several times.
    /// </summary>
    /// <param name="s">System.String object that has to be repeated.</param>
    /// <param name="number">Number of repeatitions.</param>
    /// <returns>String that contains several repeatitions of the string.</returns>
    public static string Repeat(this string s, int number)
    {
      StringBuilder Result = new StringBuilder();

      for (int i = 0; i < number; i++)
      {
        Result.Append(s);
      }

      return Result.ToString();
    }

    /// <summary>
    /// Returns a string in which a specified substring has been replaced with another substring
    /// </summary>
    /// <param name="s">System.String object to be replaced</param>
    /// <param name="oldValue">Substring being searched for</param>
    /// <param name="newValue">Replacement substring.</param>
    /// <param name="comparison">One of the enumeration values that specifies the rules of the search</param>
    /// <returns>Replaced string</returns>string>
    public static string Replace(this string s, string oldValue, string newValue, StringComparison comparison)
    {
      // check if parameters are invalid - return unchanged string
      if (String.IsNullOrEmpty(oldValue))
      {
        return s;
      }

      if (newValue == null)
      {
        newValue = String.Empty;
      }

      string Result = s;
      int iReplaceIndex;

      while ((iReplaceIndex = Result.IndexOf(oldValue, comparison)) >= 0)
      {
        string sTemp = String.Empty;

        if (iReplaceIndex > 0)
        {
          sTemp = Result.Substring(0, iReplaceIndex);
        }

        Result = sTemp + newValue + Result.Substring(iReplaceIndex + oldValue.Length);
      }

      return Result;
    }

    /// <summary>
    /// Returns a string in which specified substrings has been replaced with another substring
    /// </summary>
    /// <param name="s">System.String object to be replaced.</param>
    /// <param name="oldValues">List of substring being searched for</param>
    /// <param name="newValue">Replacement substring</param>
    /// <param name="comparison">One of the enumeration values that specifies the rules of the search</param>
    /// <returns>Replaced string</returns>string>
    public static string Replace(this string s, IEnumerable<string> oldValues, string newValue, StringComparison comparison)
    {
      if (oldValues == null)
      {
        return s;
      }

      string Result = s;

      foreach (string oldValue in oldValues)
      {
        Result = Result.Replace(oldValue, newValue, comparison);
      }

      return Result;
    }
  }
}
