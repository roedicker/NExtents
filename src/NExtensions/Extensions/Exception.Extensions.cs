using System;
using System.Collections.Generic;
using System.Text;

namespace NExtensions
{
  /// <summary>
  /// Extensions for type <see cref="Exception"/>
  /// </summary>
  public static class ExceptionExtensions
  {
    /// <summary>
    /// Gets a string representation of all exception-messages of the entire exception stack. This includes all inner exceptions.
    /// </summary>
    /// <param name="exception">Exception to process</param>
    /// <param name="includeStackTrace">Optional. Indicator whether the stack-trace shall be included or not. Default value is <c>false</c>.</param>
    /// <param name="delimeter">Delimeter for each message of the stack</param>
    /// <returns>String representation of all exception-messages</returns>
    public static string GetMessageStackString(this Exception exception, bool includeStackTrace = false, string delimeter = NewLine)
    {
      StringBuilder sbResult = new StringBuilder();
      Exception oException = exception;

      while (oException != null)
      {
        if (sbResult.Length > 0 && !sbResult.ToString().EndsWith(delimeter, StringComparison.Ordinal))
        {
          sbResult.Append(delimeter);
        }

        // add exception message if not an aggregated exception
        if (oException as AggregateException == null)
        {
          sbResult.Append(oException.Message);
        }

        oException = oException.InnerException;
      }

      if (includeStackTrace)
      {
        sbResult.Append($"{Environment.NewLine}{Environment.NewLine}{exception.StackTrace}");
      }

      return sbResult.ToString();
    }

    /// <summary>
    /// Gets a list of all exception-messages of the entire exception stack. This includes all inner exceptions.
    /// </summary>
    /// <param name="exception">Exception to process</param>
    /// <param name="includeStackTrace">Optional. Indicator whether the stack-trace shall be included or not. Default value is <c>false</c>.</param>
    /// <returns>List of all exception-messages</returns>
    public static IEnumerable<string> GetMessageStackStrings(this Exception exception, bool includeStackTrace = false)
    {
      List<string> Result = new List<string>();
      Exception oException = exception;

      while (oException != null)
      {
        // add exception message if not an aggregated exception
        if (oException as AggregateException == null)
        {
          Result.Add(oException.Message);
        }

        oException = oException.InnerException;
      }

      if (includeStackTrace)
      {
        Result.Add(exception.StackTrace);
      }

      return Result;
    }

    private const string NewLine = "\n";
  }
}
