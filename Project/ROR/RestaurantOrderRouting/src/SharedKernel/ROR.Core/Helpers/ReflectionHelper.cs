using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ROR.Core.Helpers
{
    public static class ReflectionHelper
    {
        public static IEnumerable<Type> GetInheritedClasses(Type MyType)
        {
            return Assembly.GetAssembly(MyType).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(MyType));
        }
    }
}
