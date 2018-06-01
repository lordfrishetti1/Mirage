﻿using BigBook;
using Mirage.Generators.Default.Nullable;
using Mirage.Tests.BaseClasses;
using Xunit;

namespace Mirage.Tests.Generators.Default.Nullable
{
    public class NullableLongGeneratorTests : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            var Generator = new NullableLongGeneratorAttribute();
            var Rand = new Random();
            Assert.Contains(true, 100.Times(x => Generator.Next(Rand).HasValue));
            Assert.Contains(false, 100.Times(x => Generator.Next(Rand).HasValue));
            for (long x = 0; x < 100; ++x)
            {
                var Value = Generator.Next(Rand);
                if (Value.HasValue)
                    Assert.InRange(Value.Value, long.MinValue, long.MaxValue);
            }
        }
    }
}