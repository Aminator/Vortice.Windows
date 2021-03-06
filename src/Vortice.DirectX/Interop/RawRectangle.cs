// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Vortice.Interop
{
    /// <summary>
    /// Interop type for a Rectangle (4 ints) in left, top, right, bottom.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [DebuggerDisplay("Left: {Left}, Top: {Top}, Right: {Right}, Bottom: {Bottom}")]
    public readonly struct RawRectangle
    {
        /// <summary>
        /// The left position.
        /// </summary>
        public readonly int Left;

        /// <summary>
        /// The top position.
        /// </summary>
        public readonly int Top;

        /// <summary>
        /// The right position
        /// </summary>
        public readonly int Right;

        /// <summary>
        /// The bottom position.
        /// </summary>
        public readonly int Bottom;

        /// <summary>
        /// Gets the width of the <see cref="RawRectangle" />.
        /// </summary>
        public int Width => Right - Left;

        /// <summary>
        /// Gets the height of the <see cref="RawRectangle" />.
        /// </summary>
        public int Height => Bottom - Top;

        public RawRectangle(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>
        /// Creates a new rectangle with the specified location and size.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="width">The rectangle width.</param>
        /// <param name="height">The rectangle height.</param>
        /// <returns>Returns the new rectangle.</returns>
        public static RawRectangle Create(int x, int y, int width, int height)
        {
            return new RawRectangle(x, y, x + width, y + height);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Rectangle"/> to <see cref="RawRectangle"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator RawRectangle(Rectangle value)
        {
            return new RawRectangle(value.Left, value.Top, value.Right, value.Bottom);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="RawRectangle"/> to <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Rectangle(RawRectangle value)
        {
            return Rectangle.FromLTRB(value.Left, value.Top, value.Right, value.Bottom);
        }
    }
}
