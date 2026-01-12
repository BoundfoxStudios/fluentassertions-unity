using System;

namespace BoundfoxStudios.FluentAssertions
{
  public static class Guard
  {
    public static void AgainstNull<T>(T obj, string paramName)
    {
      if (obj is null)
      {
        throw new ArgumentNullException(paramName);
      }
    }
  }
}
