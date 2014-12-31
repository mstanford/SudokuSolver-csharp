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
	public class GroupTallyGraphic : Graphic
	{

		public GroupTallyGraphic(int left, int top)
			: base(left, top, (CELL_SIZE3 * 3) + (CELL_PADDING * 4), (CELL_SIZE3 * 3) + (CELL_PADDING * 4))
		{
		}

		public override void Render(System.Drawing.Graphics graphics, Statistics statistics)
		{
			int x = Left + CELL_PADDING;
			int y = Top + CELL_PADDING;
			for (int j = 0; j < 3; j++)
			{
				for (int i = 0; i < 3; i++)
				{
					graphics.FillRectangle(System.Drawing.Brushes.PowderBlue, x, y, CELL_SIZE3, CELL_SIZE3);
					Render(graphics, statistics.GroupTally[(j * 3) + i], x, y);
					x += CELL_SIZE3 + CELL_PADDING;
				}
				x = Left + CELL_PADDING;
				y += CELL_SIZE3 + CELL_PADDING;
			}
		}

		private static void Render(System.Drawing.Graphics graphics, BitSet tally, int x, int y)
		{
			for (int i = 0; i < 9; i++)
				if (tally[i])
					graphics.FillRectangle(System.Drawing.Brushes.DodgerBlue, x + ((i % 3) * CELL_SIZE4), y + ((i / 3) * CELL_SIZE4), CELL_SIZE4, CELL_SIZE4);
		}

	}
}
