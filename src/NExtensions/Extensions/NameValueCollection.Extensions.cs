using System;
using System.Collections.Specialized;

namespace NExtensions
{
  /// <summary>
  /// Extensions for type <see cref="NameValueCollection"/>
  /// </summary>
  public static class NameValueCollectionExtensions
  {
    /// <summary>
    /// Checks if a key exists in the name value collection
    /// </summary>
    /// <param name="collection">Collection that holds key/value pairs</param>
    /// <param name="key">Key to search for</param>
    /// <returns><c>true</c> if key exists in the collection, otherwise <c>false</c>.</returns>
    public static bool KeyExists(this NameValueCollection collection, string key)
    {
      Array aValues;

      // check if there is a key named "Key"
      for (int i = 0; i < collection.Count; i++)
      {
        // if a key has no value, it is stored as a value of key NULL, thus it can be in a list of values if more than one key has no value
        if (collection.Keys[i] == null)
        {
          aValues = collection[i].Split(',');

          foreach (string sValue in aValues)
          {
            if (sValue.Trim() == key)
            {
              return true;
            }
          }
        }
        else if (collection.Keys[i] == key)
        {
          return true;
        }
      }

      return false;
    }
  }
}
