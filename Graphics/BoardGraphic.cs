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
	public class BoardGraphic : Graphic
	{

		public BoardGraphic(int left, int top)
			: base(left, top, (CELL_SIZE * 9) + (CELL_PADDING * 10) + (CELL_GROUP_PADDING * 2), (CELL_SIZE * 9) + (CELL_PADDING * 10) + (CELL_GROUP_PADDING * 2))
		{
		}

		public override void Render(System.Drawing.Graphics graphics, Statistics statistics)
		{
			int x = Left + CELL_PADDING;
			int y = Top + CELL_PADDING;
			int i = 0;
			int j = 0;
			for (int n = 0; n < 3; n++)
			{
				for (int m = 0; m < 3; m++)
				{
					for (int l = 0; l < 3; l++)
					{
						for (int k = 0; k < 3; k++)
						{
							graphics.FillRectangle(System.Drawing.Brushes.White, x, y, CELL_SIZE, CELL_SIZE);
							if (statistics.OriginalBoard[j][i] != 0)
							{
								graphics.DrawString(statistics.OriginalBoard[j][i].ToString(), FONT, System.Drawing.Brushes.Black, x - 1, y - 2);
							}
							else
							{
								if (statistics.Board[j][i] != 0)
								{
									graphics.DrawString(statistics.Board[j][i].ToString(), FONT, System.Drawing.Brushes.Red, x - 1, y - 2);
								}
								else
								{
									graphics.FillRectangle(System.Drawing.Brushes.Gray, x + 1, y + 1, CELL_SIZE - 2, CELL_SIZE - 2);
								}
							}
							x += CELL_SIZE + CELL_PADDING;
							i++;
						}
						x += CELL_GROUP_PADDING;
					}
					x = Left + CELL_PADDING;
					i = 0;
					y += CELL_SIZE + CELL_PADDING;
					j++;
				}
				y += CELL_GROUP_PADDING;
			}
		}

	}
}
