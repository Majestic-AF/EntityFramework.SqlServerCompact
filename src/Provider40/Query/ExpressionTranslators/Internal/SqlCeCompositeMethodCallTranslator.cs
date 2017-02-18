﻿using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal
{
    public class SqlCeCompositeMethodCallTranslator : RelationalCompositeMethodCallTranslator
    {
        private static readonly IMethodCallTranslator[] _methodCallTranslators =
        {
                new SqlCeContainsOptimizedTranslator(),
                new SqlCeConvertTranslator(),
                new SqlCeEndsWithOptimizedTranslator(),
                new SqlCeMathTranslator(),
                new SqlCeNewGuidTranslator(),
                new SqlCeObjectToStringTranslator(),
                new SqlCeStartsWithOptimizedTranslator(),
                new SqlCeStringIsNullOrWhiteSpaceTranslator(),
                new SqlCeStringReplaceTranslator(),
                new SqlCeStringSubstringTranslator(),
                new SqlCeStringToLowerTranslator(),
                new SqlCeStringToUpperTranslator(),
                new SqlCeStringTrimEndTranslator(),
                new SqlCeStringTrimStartTranslator(),
                new SqlCeStringTrimTranslator()
        };

        public SqlCeCompositeMethodCallTranslator([NotNull] ILogger<SqlCeCompositeMethodCallTranslator> logger)
            : base(logger)
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            AddTranslators(_methodCallTranslators);
        }
    }
}
