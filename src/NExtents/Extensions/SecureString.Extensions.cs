using System;
using System.Runtime.InteropServices;
using System.Security;

namespace NExtents
{
  /// <summary>
  /// Extensions for type <see cref="SecureString" />
  /// </summary>
  public static class SecureStringExtensions
  {
    /// <summary>
    /// Appends a string to a secure string
    /// </summary>
    /// <param name="s">Secure string</param>
    /// <param name="value">String to append</param>
    /// <returns>Updated secure string</returns>
    public static SecureString AppendString(this SecureString s, string value)
    {
      if (s == null)
      {
        throw new ArgumentNullException(nameof(s));
      }

      if (value != null)
      {
        foreach (char c in value)
        {
          s.AppendChar(c);
        }
      }

      return s;
    }

    /// <summary>
    /// Sets a string to a secure string
    /// </summary>
    /// <param name="s">Secure string</param>
    /// <param name="value">String to be set</param>
    /// <returns>Updated secure string</returns>
    public static SecureString SetString(this SecureString s, string value)
    {
      if (s == null)
      {
        throw new ArgumentNullException(nameof(s));
      }

      s.Clear();

      return AppendString(s, value);
    }

    /// <summary>
    /// Indicator whether a secure string is empty or not
    /// </summary>
    /// <param name="s">Secure string</param>
    /// <returns>Indicator whether a secure string is empty or not</returns>
    public static bool IsEmpty(this SecureString s)
    {
      if (s == null)
      {
        throw new ArgumentNullException(nameof(s));
      }

      return (s.Length == 0);
    }

    /// <summary>
    /// Gets the string from a secure string
    /// </summary>
    /// <param name="s">Secure string</param>
    /// <returns>String from a secure string</returns>
    public static string GetString(this SecureString s)
    {
      if (s == null)
      {
        throw new ArgumentNullException(nameof(s));
      }

      string Result;
      IntPtr ptrValue = IntPtr.Zero;

      if ((s == null) || (s.Length == 0))
      {
        Result = String.Empty;
      }
      else
      {
        try
        {
          ptrValue = Marshal.SecureStringToBSTR(s);
          Result = Marshal.PtrToStringBSTR(ptrValue);
        }
        finally
        {
          if (ptrValue != IntPtr.Zero)
          {
            Marshal.ZeroFreeBSTR(ptrValue);
          }
        }
      }

      return Result;
    }
  }
}
