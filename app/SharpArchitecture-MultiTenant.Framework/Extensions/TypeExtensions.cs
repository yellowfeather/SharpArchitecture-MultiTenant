using System;
using System.Linq;

namespace SharpArchitecture.MultiTenant.Framework.Extensions
{
  public static class TypeExtensions
  {
    public static bool IsImplementationOf<T>(this Type type)
    {
      return type.GetInterfaces().Any(x => x == typeof(T));
    }
  }
}