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
using System.Collections.Generic;

namespace Mirage.Generators.Default
{
    /// <summary>
    /// IEnumerable generator
    /// </summary>
    /// <typeparam name="T">IEnumerable type</typeparam>
    /// <seealso cref="Interfaces.IGenerator{T}"/>
    public class IEnumerableGenerator<T> : IGenerator<T>
    {
        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public Type TypeGenerated => typeof(T);

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public T Next(Random rand)
        {
            return (T)rand.Next(typeof(List<>).MakeGenericType(TypeGenerated.GetGenericArguments()[0]));
        }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public T Next(Random rand, T min, T max)
        {
            return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Generates a random value and returns it as an object
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object</returns>
        public object NextObj(Random rand)
        {
            return rand.Next(typeof(List<>).MakeGenericType(TypeGenerated.GetGenericArguments()[0]));
        }
    }

    /// <summary>
    /// IEnumerable generator attribute
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    public class IEnumerableGeneratorAttribute : GeneratorAttributeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IEnumerableGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public IEnumerableGeneratorAttribute(Type classType, int min, int max)
            : base(min == 0 && max == 0 ? 1 : min, min == 0 && max == 0 ? 100 : max)
        {
            ClassType = classType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IEnumerableGeneratorAttribute"/> class.
        /// </summary>
        public IEnumerableGeneratorAttribute()
            : this(null, 1, 100)
        {
        }

        /// <summary>
        /// Gets or sets the type of the class.
        /// </summary>
        /// <value>The type of the class.</value>
        public Type ClassType { get; set; }

        /// <summary>
        /// Gets the type generated.
        /// </summary>
        /// <value>The type generated.</value>
        public override Type TypeGenerated => typeof(object);

        /// <summary>
        /// Generates next object
        /// </summary>
        /// <param name="rand">The rand.</param>
        /// <returns>The next object</returns>
        public override object NextObj(Random rand)
        {
            if (ClassType == null)
                return null;
            var Generator = (IGenerator)Canister.Builder.Bootstrapper.Resolve(typeof(IEnumerableGenerator<>).MakeGenericType(ClassType), null);
            return Generator.NextObj(rand);
        }
    }
}