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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SudokuSolver.Graphics;

namespace SudokuSolver
{
	public partial class FormMain : Form
	{
		private Statistics _statistics;
		private readonly GroupTallyGraphic _groupTallyGraphic;
		private readonly ColumnTallyGraphic _columnTallyGraphic;
		private readonly RowTallyGraphic _rowTallyGraphic;
		private readonly BoardGraphic _boardGraphic;

		public FormMain()
		{
			InitializeComponent();

			SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		public FormMain(string[] args)
			: this()
		{
			int margin = 8;
			_groupTallyGraphic = new GroupTallyGraphic(margin + 4, margin + 4);
			_columnTallyGraphic = new ColumnTallyGraphic(_groupTallyGraphic.Left + _groupTallyGraphic.Width - 2, margin);
			_rowTallyGraphic = new RowTallyGraphic(margin, _groupTallyGraphic.Top + _groupTallyGraphic.Height - 2);
			_boardGraphic = new BoardGraphic(_rowTallyGraphic.Left + _rowTallyGraphic.Width, _columnTallyGraphic.Top + _columnTallyGraphic.Height);
			ClientSize = new Size(_boardGraphic.Left + _boardGraphic.Width + margin, _boardGraphic.Top + _boardGraphic.Height + margin);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Run));
			thread.IsBackground = true;
			thread.Start();
		}

		private void Run()
		{
			string[] ABC = new string[] { "A.csv", "B.csv", "C.csv" };
			int index = 0;

			while (true)
			{
				Solve(ABC[index]);

				System.Threading.Thread.Sleep(1000);

				index++;
				if (index == ABC.Length)
					index = 0;
			}
		}

		private void Solve(string name)
		{
			int[][] board = ParseResource(name);
			int[][] originalBoard = ParseResource(name);

			int updated = 1;

			_statistics = new Statistics(board, originalBoard);
			Invalidate();
			System.Threading.Thread.Sleep(2000);

			while (updated > 0)
			{
				updated = 0;

				_statistics = new Statistics(board, originalBoard);
				for (int j = 0; j < 9; j++)
				{
					for (int i = 0; i < 9; i++)
					{
						if (board[j][i] == 0 && _statistics.Candidates[j][i].Sum == 1)
						{
							int k = 0;
							for (int l = 0; l < 9; l++)
							{
								if (_statistics.Candidates[j][i][l])
									k = l + 1;
							}

							board[j][i] = k;
							updated++;
							goto NEXT;
						}
					}
				}

			NEXT:
				Invalidate();
				System.Threading.Thread.Sleep(500);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (_statistics != null)
			{
				_groupTallyGraphic.Render(e.Graphics, _statistics);
				_columnTallyGraphic.Render(e.Graphics, _statistics);
				_rowTallyGraphic.Render(e.Graphics, _statistics);
				_boardGraphic.Render(e.Graphics, _statistics);
			}
		}

		private static int[][] ParseResource(string name)
		{
			List<int[]> board = new List<int[]>();
			System.IO.Stream stream = System.Reflection.Assembly.GetAssembly(typeof(FormMain)).GetManifestResourceStream(typeof(FormMain).Namespace + ".samples." + name);
			using (System.IO.TextReader reader = new System.IO.StreamReader(stream))
			{
				while (reader.Peek() != -1)
				{
					string[] asz = reader.ReadLine().Split('\t');
					int[] an = new int[asz.Length];
					for (int i = 0; i < asz.Length; i++)
						if (asz[i].Length > 0)
							an[i] = int.Parse(asz[i]);
					board.Add(an);
				}
				reader.Close();
			}
			stream.Close();
			return board.ToArray();
		}

	}
}