// ------------------------------------------------------------------------
// 
// This is free and unencumbered software released into the public domain.
// 
// Anyone is free to copy, modify, publish, use, compile, sell, or
// distribute this software, either in source code form or as a compiled
// binary, for any purpose, commercial or non-commercial, and by any
// means.
// 
// In jurisdictions that recognize copyright laws, the author or authors
// of this software dedicate any and all copyright interest in the
// software to the public domain. We make this dedication for the benefit
// of the public at large and to the detriment of our heirs and
// successors. We intend this dedication to be an overt act of
// relinquishment in perpetuity of all present and future rights to this
// software under copyright law.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// 
// For more information, please refer to <http://unlicense.org/>
// 
// ------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Graphics
{
	public abstract class Graphic
	{
		protected static readonly int CELL_SIZE = 11;
		protected static readonly int CELL_PADDING = 2;
		protected static readonly int CELL_PADDING2 = 1;
		protected static readonly int CELL_SIZE2 = 2;
		protected static readonly int CELL_SIZE3 = 6;
		protected static readonly int CELL_SIZE4 = CELL_SIZE3 / 3;
		protected static readonly int CELL_GROUP_PADDING = 2;
		protected static readonly System.Drawing.Font FONT = new System.Drawing.Font("Courier New", 11, System.Drawing.FontStyle.Bold);

		public readonly int Left;
		public readonly int Top;
		public readonly int Width;
		public readonly int Height;

		public Graphic(int left, int top, int width, int height)
		{
			Left = left;
			Top = top;
			Width = width;
			Height = height;
		}

		public abstract void Render(System.Drawing.Graphics graphics, Statistics statistics);

	}
}
