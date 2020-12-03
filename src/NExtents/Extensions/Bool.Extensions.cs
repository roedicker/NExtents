using System;
using System.Globalization;

namespace NExtents
{
  /// <summary>
  /// Extensions for type <see cref="bool"/>
  /// </summary>
  public static class BoolExtensions
  {
    /// <summary>
    /// Gets the lower-text representation of a boolean value
    /// </summary>
    /// <param name="value">Current value</param>
    /// <returns>Lower-text representation of a boolean value (<c>true</c> or <c>false</c>)</returns>
    public static string ToLowerString(this bool value)
    {
      return value.ToString(CultureInfo.InvariantCulture).ToLower(CultureInfo.InvariantCulture);
    }
  }
}
