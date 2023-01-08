﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Xunit
{
    partial class Assert
    {
        public static void ReferenceEqual<T>(T? expected, T? actual)
            where T : class
            => Equal<T>(expected, actual, ReferenceEqualityComparer.Instance);

        public static void NotReferenceEqual<T>(T? expected, T? actual)
            where T : class
            => NotEqual<T>(expected, actual, ReferenceEqualityComparer.Instance);

        public static T NotNull<T>([NotNull] T? obj)
            where T : class
        {
            NotNull((object?)obj);
            return obj!;
        }
    }
}
