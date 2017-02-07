﻿/*
Copyright 2017 James Craig

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using Mirage.Generators.BaseClasses;
using Mirage.Interfaces;
using System;

namespace Mirage.Generators
{
    /// <summary>
    /// SByte generator
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    /// <seealso cref="Interfaces.IGenerator{SByte}"/>
    public class SByteGeneratorAttribute : GeneratorAttributeBase, IGenerator<sbyte>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SByteGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public SByteGeneratorAttribute(sbyte min, sbyte max)
            : base(min == 0 && max == 0 ? sbyte.MinValue : min, min == 0 && max == 0 ? sbyte.MaxValue : max)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SByteGeneratorAttribute"/> class.
        /// </summary>
        public SByteGeneratorAttribute() : base(sbyte.MinValue, sbyte.MaxValue)
        {
        }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(sbyte);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public sbyte Next(Random rand)
        {
            return Next(rand, (sbyte)Min, (sbyte)Max);
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public sbyte Next(Random rand, sbyte min, sbyte max)
        {
            return (sbyte)(min + (sbyte)((max - min) * rand.NextDouble()));
        }

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <returns>The next object</returns>
        public override object NextObj(Random rand)
        {
            return Next(rand);
        }
    }
}