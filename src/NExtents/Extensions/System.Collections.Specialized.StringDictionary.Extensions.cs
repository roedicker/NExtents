using System;
using System.Collections.Specialized;

namespace NExtents
{
  /// <summary>
  /// Extensions for type <see cref="StringDictionary" />
  /// </summary>
  public static class SystemCollectionsSpecializedStringDictionaryExtensions
  {
    /// <summary>
    /// Adds a key-/value-pair to a string dictionary to another one
    /// </summary>
    /// <param name="dict">String dictionary to process</param>
    /// <param name="key">Key of value to be adde.</param>
    /// <param name="value">Value to be adde.</param>
    /// <remarks>Assignment will be ignored if given key already exist</remarks>
    public static void AddDistinct(this StringDictionary dict, string key, string value)
    {
      if (!dict.ContainsKey(key))
      {
        dict.Add(key, value);
      }
    }

    /// <summary>
    /// Adds the content of a string dictionary to another one
    /// </summary>
    /// <param name="dict">String dictionary to process</param>
    /// <param name="dictionary">Dictionary elements to add to the string dictionary</param>
    public static void AddRange(this StringDictionary dict, StringDictionary dictionary)
    {
      if (dictionary == null)
      {
        throw new ArgumentNullException(nameof(dictionary));
      }

      foreach (string sKey in dictionary.Keys)
      {
        dict.Add(sKey, dictionary[sKey]);
      }
    }

    /// <summary>
    /// Adds the content of a string dictionary to another one. Result holds only distinct keys
    /// </summary>
    /// <param name="dict">String dictionary to process</param>
    /// <param name="dictionary">Dictionary elements to add to the string dictionary if its key does not exist in the string dictionary</param>
    /// <remarks>Values of existing keys will not be changed/upated even if they differ</remarks>
    public static void AddRangeDistinct(this StringDictionary dict, StringDictionary dictionary)
    {
      if (dictionary == null)
      {
        throw new ArgumentNullException(nameof(dictionary));
      }

      foreach (string sKey in dictionary.Keys)
      {
        if (!dict.ContainsKey(sKey))
        {
          dict.Add(sKey, dictionary[sKey]);
        }
      }
    }
  }
}
