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

using BigBook;
using Mirage.Generators.BaseClasses;
using Mirage.Interfaces;
using System;
using System.Text;

namespace Mirage.Generators
{
    /// <summary>
    /// MaleName Generator
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public class MaleNameAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MaleNameAttribute(bool prefix = false, bool middleName = false, bool lastName = true, bool suffix = false)
            : base("", "")
        {
            Prefix = prefix;
            MiddleName = middleName;
            LastName = lastName;
            Suffix = suffix;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [last name].
        /// </summary>
        /// <value><c>true</c> if [last name]; otherwise, <c>false</c>.</value>
        public bool LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [middle name].
        /// </summary>
        /// <value><c>true</c> if [middle name]; otherwise, <c>false</c>.</value>
        public bool MiddleName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MaleNameAttribute"/> is prefix.
        /// </summary>
        /// <value><c>true</c> if prefix; otherwise, <c>false</c>.</value>
        public bool Prefix { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MaleNameAttribute"/> is suffix.
        /// </summary>
        /// <value><c>true</c> if suffix; otherwise, <c>false</c>.</value>
        public bool Suffix { get; set; }

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            return (Prefix ? new MaleNamePrefixAttribute().Next(rand) + " " : "")
                + new MaleFirstNameAttribute().Next(rand)
                + (MiddleName ? " " + new MaleFirstNameAttribute().Next(rand) : "")
                + (LastName ? " " + new LastNameAttribute().Next(rand) : "")
                + (Suffix ? " " + new NameSuffixAttribute().Next(rand) : "");
        }
    }
}