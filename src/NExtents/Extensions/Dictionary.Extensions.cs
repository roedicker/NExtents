using System;
using System.Collections.Generic;

namespace NExtents
{
  /// <summary>
  /// Provides extensions for type <see cref="Dictionary{TKey, TValue}"/>
  /// </summary>
  public static class SystemCollectionsGenericDictionaryExtensions
  {
    /// <summary>
    /// Adds a key-/value-pair to a dictionary to another one
    /// </summary>
    /// <param name="dict">Dictionary to process</param>
    /// <param name="key">Key of value to be added</param>
    /// <param name="value">Value to be added</param>
    /// <remarks>Assignment will be ignored if given key already exist</remarks>
    public static void AddDistinct<T, V>(this Dictionary<T, V> dict, T key, V value)
    {
      if (!dict.ContainsKey(key))
      {
        dict.Add(key, value);
      }
    }

    /// <summary>
    /// Adds the content of a dictionary to another one
    /// </summary>
    /// <param name="dict">Dictionary to process</param>
    /// <param name="dictionary">Dictionary elements to add to the dictionary</param>
    public static void AddRange<T, V>(this Dictionary<T, V> dict, Dictionary<T, V> dictionary)
    {
      if (dictionary == null)
      {
        throw new ArgumentNullException(nameof(dictionary));
      }

      foreach (T oKey in dictionary.Keys)
      {
        dict.Add(oKey, dictionary[oKey]);
      }
    }

    /// <summary>
    /// Adds the content of a dictionary to another one. Result holds only distinct keys
    /// </summary>
    /// <param name="dict">Dictionary to process</param>
    /// <param name="dictionary">Dictionary elements to add to the dictionary if its key does not exist in the dictionary</param>
    /// <remarks>Values of existing keys will not be changed/upated even if they differs</remarks>
    public static void AddRangeDistinct<T, V>(this Dictionary<T, V> dict, Dictionary<T, V> dictionary)
    {
      if (dictionary == null)
      {
        throw new ArgumentNullException(nameof(dictionary));
      }

      foreach (T oKey in dictionary.Keys)
      {
        if (!dict.ContainsKey(oKey))
        {
          dict.Add(oKey, dictionary[oKey]);
        }
      }
    }
  }
}
