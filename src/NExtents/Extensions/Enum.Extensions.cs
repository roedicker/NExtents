using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace NExtents
{
  /// <summary>
  /// Extensions for type <see cref="Enum"/>
  /// </summary>
  public static class EnumExtensions
  {
    /// <summary>
    /// Gets the <see cref="DisplayAttribute"/> value of an enum
    /// </summary>
    /// <param name="value">Enumeration</param>
    /// <returns>Either the value of the <see cref="DisplayAttribute" /> or the string representation of the enumeration itself</returns>
    public static string GetDisplayName(this Enum value)
    {
      MemberInfo oInfo = value.GetType().GetMember(value.ToString()).FirstOrDefault();

      if (oInfo == null)
      {
        return value.ToString();
      }
      else
      {
        Attribute oAttribute = oInfo.GetCustomAttribute(typeof(DisplayAttribute), false);

        if (oAttribute == null)
        {
          return value.ToString();
        }
        else
        {
          return ((DisplayAttribute)oAttribute).GetName();
        }
      }
    }

    /// <summary>
    /// Gets the <see cref="EnumMemberAttribute"/> value of an enum
    /// </summary>
    /// <param name="e">Enumeration</param>
    /// <returns>Either the value of the <see cref="EnumMemberAttribute" /> or the string representation of the enumeration itself</returns>
    public static string GetEnumMember(this Enum e)
    {
      if (e == null)
      {
        throw new ArgumentNullException(nameof(e));
      }

      MemberInfo oInfo = e.GetType().GetMember(e.ToString()).FirstOrDefault();

      if (oInfo == null)
      {
        return e.ToString();
      }
      else
      {
        Attribute oAttribute = oInfo.GetCustomAttribute(typeof(EnumMemberAttribute), false);

        if (oAttribute == null)
        {
          return e.ToString();
        }
        else
        {
          return ((EnumMemberAttribute)oAttribute).Value;
        }
      }
    }
  }
}
