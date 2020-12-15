using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NExtents
{
  /// <summary>
  /// Extensions for array of type <see cref="string"/>
  /// </summary>
  public static class StringArrayExtensions
  {
    /// <summary>
    /// Converts all elements of an array of System.String to a single System.String object
    /// </summary>
    /// <param name="array">Array of System.String that has to be converted</param>
    /// <param name="delimeter">Optional. Delimeter for each element in the <see cref="string"/> array</param>
    /// <param name="startIndex">Optional. 1-based index of the first element to begin</param>
    /// <param name="count">Optional. Number of elements to convert</param>
    /// <param name="quotation">Optional. Quotation that encapsulates each converted element of the <see cref="string"/> array</param>
    /// <returns>Converted System.String array as a single System.String object with given delimeter and optional quotation</returns>
    /// <remarks>If no delimeter is given, the white-space charcter (&quot; &quot; / 0x032) is used</remarks>
    /// <exception cref="ArgumentOutOfRangeException"><i>StartIndex</i> is not between 1 and upper bound of array</exception>
    /// <exception cref="ArgumentOutOfRangeException"><i>Count</i> is -2 or lower</exception>
    public static string Join(this string[] array, string delimeter = " ", int startIndex = 0, int count = -1, string? quotation = null)
    {
      StringBuilder Result = new StringBuilder();

      // check array if non-empty only. Otherwise result is empty.
      if (array.Length > 0)
      {
        // check if start index is valid
        if ((startIndex < 0) || (startIndex > array.Length - 1))
        {
          throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, $"{nameof(startIndex)} must be between 0 and {array.Length - 1}");
        }

        // check if count is valid
        if (count < -1)
        {
          throw new ArgumentOutOfRangeException(nameof(count), count, $"{nameof(count)} must be -1 or greater");
        }

        int iLowerBound = startIndex;
        int iUpperBound;

        if (count == -1)
        {
          iUpperBound = array.Length - 1;
        }
        else
        {
          iUpperBound = startIndex - (count - 1);
        }

        for (int i = iLowerBound; i <= iUpperBound; i++)
        {
          if (i == iLowerBound)
          {
            // check for quotations
            if (String.IsNullOrEmpty(quotation))
            {
              Result.Append(array[i]);
            }
            else
            {
              Result.Append($"{quotation}{array[i]}{quotation}");
            }
          }
          else
          {
            // check for quotations
            if (String.IsNullOrEmpty(quotation))
            {
              Result.Append($"{delimeter}{array[i]}");
            }
            else
            {
              Result.Append($"{delimeter}{quotation}{array[i]}{quotation}");
            }
          }
        }
      }

      return Result.ToString();
    }

    /// <summary>
    /// Removes all leading occurrences of a set of characters specified in an array from all elements in the current array of System.String
    /// objects.
    /// </summary>
    /// <param name="array">System.String array to be trimmed.</param>
    /// <param name="trimChars">Optional. An array of Unicode characters to remove or <strong>null</strong>.</param>
    /// <returns>Trimmed System.String array.</returns>
    /// <remarks>Calls the method <see cref="String.TrimStart(char[])"/> for each element in the System.String array to perform the trim operation. If <i>TrimChars</i> is <strong>null</strong>, white-space characters are removed instead.</remarks>
    public static string[] TrimStart(this string[] array, char[]? trimChars = null)
    {
      // check if trim characters are available
      if (trimChars == null)
      {
        return Trim(array);
      }

      for (int i = 0; i < array.Length; i++)
      {
        array[i] = array[i].TrimStart(trimChars);
      }

      return array;
    }

    /// <summary>
    /// Removes all leading occurrences of a string from all elements in the current array of System.String objects
    /// </summary>
    /// <param name="array">System.String array to be trimmed</param>
    /// <param name="trimString">A System.String object to remove from the beginning or <c>null</c></param>
    /// <returns>Trimmed <see cref="string"/> array</returns>
    public static string[] TrimStart(this string[] array, string trimString)
    {
      for (int i = 0; i < array.Length; i++)
      {
        array[i] = array[i].TrimStart(trimString);
      }

      return array;
    }

    /// <summary>
    /// Removes all trailing occurrences of a set of characters specified in an array from all elements in the current array of <see cref="string"/>
    /// objects.
    /// </summary>
    /// <param name="array">System.String array to be trimmed</param>
    /// <param name="trimChars">Optional. An array of Unicode characters to remove or <c>null</c></param>
    /// <returns>Trimmed System.String array.</returns>
    public static string[] TrimEnd(this string[] array, char[]? trimChars = null)
    {
      // check if trim characters are available
      if (trimChars == null)
      {
        return Trim(array);
      }

      for (int i = 0; i < array.Length; i++)
      {
        array[i] = array[i].TrimEnd(trimChars);
      }

      return array;
    }

    /// <summary>
    /// Removes all trailing occurrences of a string from all elements in the current array of <see cref="string" /> objects
    /// </summary>
    /// <param name="array">System.String array to be trimmed</param>
    /// <param name="trimString">A <see cref="string" /> object to remove from the beginning or <c>null</c></param>
    /// <returns>Trimmed <see cref="string" /> array</returns>
    public static string[] TrimEnd(this string[] array, string trimString)
    {
      for (int i = 0; i < array.Length; i++)
      {
        array[i] = array[i].TrimEnd(trimString);
      }

      return array;
    }

    /// <summary>
    /// Removes all leading and trailing white-space characters from all elements in the current array of System.String objects
    /// </summary>
    /// <param name="array"><see cref="string"/> array to be trimmed</param>
    /// <returns>Trimmed <see cref="string" /> array</returns>
    public static string[] Trim(this string[] array)
    {
      for (int i = 0; i < array.Length; i++)
      {
        array[i] = array[i].Trim();
      }

      return array;
    }

    /// <summary>
    /// Removes all leading and trailing white-space characters from all elements in the current array of <see cref="string"/> objects and removes each empty or null elements
    /// </summary>
    /// <param name="array"><see cref="string" /> array to be purged</param>
    /// <returns>Purged <see cref="string" /> array</returns>
    public static string[] Purge(this string[] array)
    {
      List<string> Result = new List<string>();

      foreach (string sItem in array)
      {
        if (!String.IsNullOrWhiteSpace(sItem))
        {
          Result.Add(sItem.Trim());
        }
      }

      return Result.ToArray();
    }

    /// <summary>
    /// Determines whether the specified string (case insensitive) is in the string array
    /// </summary>
    /// <param name="array"><see cref="string" /> array to be analyzed</param>
    /// <param name="value">The string to locate in the string array. The value can be a <c>null</c>-reference</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules of the search</param>
    /// <returns><c>true</c> if value is found in the string array, otherwise <c>false</c></returns>
    public static bool Contains(this string[] array, string value, StringComparison comparisonType)
    {
      bool Result = false;

      foreach (string sItem in array)
      {
        if (String.Compare(sItem, value, comparisonType) == 0)
        {
          Result = true;
          break;
        }
      }

      return Result;
    }

    /// <summary>
    /// Converts all array items to a single string separated by a defined delimeter.
    /// </summary>
    /// <param name="array"><see cref="string" /> array to be processed</param>
    /// <param name="delimeter">Optional. Delimeter string used to separat each array item.</param>
    /// <returns>Formatted string that represents all array items separated by a defines delimeter.</returns>
    public static string ToString(this string[] array, string delimeter = " ")
    {
      StringBuilder Result = new StringBuilder();

      foreach (string sItem in array)
      {
        if (Result.Length == 0)
        {
          Result.Append(sItem);
        }
        else
        {
          Result.AppendFormat(CultureInfo.InvariantCulture, "{0}{1}", delimeter, sItem);
        }
      }

      return Result.ToString();
    }
  }
}
