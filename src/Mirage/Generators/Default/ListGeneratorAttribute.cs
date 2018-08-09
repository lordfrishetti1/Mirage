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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mirage.Generators.Default
{
    /// <summary>
    /// List generator attribute
    /// </summary>
    /// <seealso cref="GeneratorAttributeBase"/>
    public class ListGeneratorAttribute : GeneratorAttributeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayGeneratorAttribute"/> class.
        /// </summary>
        /// <param name="classType">Type of the class.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public ListGeneratorAttribute(Type classType, int min, int max)
            : base(min == 0 && max == 0 ? 1 : min, min == 0 && max == 0 ? 100 : max)
        {
            ClassType = classType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayGeneratorAttribute"/> class.
        /// </summary>
        public ListGeneratorAttribute()
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
            var Count = rand.Next((int)Min, (int)Max);
            var Results = rand.Next(ClassType, Count).ToList();
            var ReturnObject = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(ClassType));
            for (int x = 0; x < Count; ++x)
            {
                ReturnObject.Add(Results[x]);
            }
            return ReturnObject;
        }
    }
}