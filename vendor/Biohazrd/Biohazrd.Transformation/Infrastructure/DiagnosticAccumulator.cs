﻿using System.Collections.Immutable;

namespace Biohazrd.Transformation.Infrastructure
{
    /// <summary>Provides infrastructure for accumulating diagnostics from type transformations.</summary>
    public ref struct DiagnosticAccumulator
    {
        // Do not change the layout of this struct without also modifying DiagnosticAccumulatorRef
        internal ImmutableArray<TranslationDiagnostic>.Builder? _Diagnostics;

        /// <summary>Indicates whether diagnostics have accumulated in this accumulator.</summary>
        public bool HasDiagnostics => _Diagnostics is not null && _Diagnostics.Count > 0;

        /// <summary>Moves the accumulated diagnostics to an <see cref="ImmutableArray{TranslationDiagnostic}"/> collection.</summary>
        public ImmutableArray<TranslationDiagnostic> MoveToImmutable()
        {
            if (_Diagnostics is null)
            { return ImmutableArray<TranslationDiagnostic>.Empty; }

            return _Diagnostics.MoveToImmutableSafe();
        }
    }
}
