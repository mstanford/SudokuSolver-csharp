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

namespace SudokuSolver
{
	public class Statistics
	{
		public readonly int[][] OriginalBoard;
		public readonly int[][] Board;
		public readonly BitSet[] ColumnTally;
		public readonly BitSet[] RowTally;
		public readonly BitSet[] GroupTally;
		public readonly BitSet[][] Candidates;

		public Statistics(int[][] board, int[][] originalBoard)
		{
			Board = board;
			OriginalBoard = originalBoard;

			int i, j;

			ColumnTally = new BitSet[9];
			for (i = 0; i < ColumnTally.Length; i++)
				ColumnTally[i] = new BitSet();
			RowTally = new BitSet[9];
			for (i = 0; i < RowTally.Length; i++)
				RowTally[i] = new BitSet();
			GroupTally = new BitSet[9];
			for (i = 0; i < GroupTally.Length; i++)
				GroupTally[i] = new BitSet();

			i = 0;
			j = 0;
			for (int n = 0; n < 3; n++)
			{
				for (int m = 0; m < 3; m++)
				{
					for (int l = 0; l < 3; l++)
					{
						for (int k = 0; k < 3; k++)
						{
							int z = Board[j][i];
							if (z != 0)
							{
								ColumnTally[i][z - 1] = true;
								RowTally[j][z - 1] = true;
								GroupTally[(n * 3) + l][z - 1] = true;
							}
							i++;
						}
					}
					i = 0;
					j++;
				}
			}

			Candidates = new BitSet[9][];
			for (j = 0; j < Candidates.Length; j++)
			{
				Candidates[j] = new BitSet[9];
				for (i = 0; i < Candidates[j].Length; i++)
				{
					int k = (((j / 3) * 3) + (i / 3));
					Candidates[j][i] = BitSet.Not(BitSet.Or(BitSet.Or(ColumnTally[i], RowTally[j]), GroupTally[k]));

					//System.Console.WriteLine("(" + (i + 1) + "," + (j + 1) + "," + (k + 1) + ")");
					//if (Board[j][i] == 0)
					//{
					//    for (int z = 0; z < 9; z++)
					//        if (Candidates[j][i][z])
					//            System.Console.Write((z + 1) + " ");
					//        else
					//            System.Console.Write("  ");
					//}
					//System.Console.WriteLine("");
					//System.Console.WriteLine("");
				}
			}
		}

	}
}
