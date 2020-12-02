using System;
using System.Collections.Generic;
using System.Linq;

namespace NExtents
{
  /// <summary>
  /// Extensions for type <see cref="List{T}"/>
  /// </summary>
  public static class SystemCollectionsGenericListExtensions
  {
    /// <summary>
    /// Moves an element from one index to another.
    /// </summary>
    public static void MoveElement<T>(this List<T> list, int from, int to)
    {
      if (from < 0 || from > (list.Count - 1))
      {
        throw new ArgumentOutOfRangeException(nameof(from));
      }

      if (to < 0 || to > (list.Count - 1))
      {
        throw new ArgumentOutOfRangeException(nameof(to));
      }

      if (from != to)
      {
        T item = list.ElementAt(from);
        list.RemoveAt(from);

        if (to > from)
        {
          list.Insert(to - 1, item);
        }
        else
        {
          list.Insert(to, item);
        }
      }
    }
  }
}
