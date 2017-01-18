﻿using Mirage.Generators;
using Mirage.Tests.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mirage.Tests.Generators
{
    public class EnumGenerator : TestingDirectoryFixture
    {
        [Fact]
        public void Next()
        {
            EnumGeneratorAttribute Generator = new EnumGeneratorAttribute(typeof(MyTest));
            Assert.InRange((MyTest)Generator.NextObj(new Random()), MyTest.Item1, MyTest.Item3);
        }

        public enum MyTest
        {
            Item1,
            Item2,
            Item3
        }
    }
}