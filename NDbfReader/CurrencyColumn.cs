﻿using System;
using System.Diagnostics;
using System.Text;

namespace NDbfReader
{
    /// <summary>
    /// Represents a currency column.
    /// </summary>
    [DebuggerDisplay("Decimal {Name}")]
    public class CurrencyColumn : Column<decimal?>
    {
        /// <summary>
        /// Initializes a new instance with the specified name and offset.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <param name="offset">The column offset in a row.</param>
        /// <param name="size">The column size in bytes.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is <c>null</c> or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/> is &lt; 0 or <paramref name="size"/> is &lt; 0.</exception>
        public CurrencyColumn(string name, int offset, int size)
            : base(name, offset, size)
        {
        }

        /// <summary>
        /// Loads a value from the specified buffer.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="offset">The offset in <paramref name="buffer"/> at which to begin loading the value.</param>
        /// <param name="encoding">The encoding to use to parse the value.</param>
        /// <returns>A column value.</returns>
        protected override decimal? DoLoad(byte[] buffer, int offset, Encoding encoding)
        {
            return BitConverter.ToInt64(buffer, offset) / 10000.0m;
        }
    }
}