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
	public class BitSet
	{
		private int _n;

		public BitSet() { }

		public int Sum
		{
			get
			{
				int sum = 0;
				for (int i = 0; i < 9; i++)
					if (this[i])
						sum++;
				return sum;
			}
		}

		public bool this[int index]
		{
			get { return (_n & (1 << index)) != 0; }
			set
			{
				if (value)
				{
					_n |= 1 << index;
				}
				else
				{
					_n &= ~(1 << index);
				}
			}
		}

		public static BitSet Or(BitSet A, BitSet B)
		{
			BitSet C = new BitSet();
			for (int i = 0; i < 9; i++)
				C[i] = A[i] || B[i];
			if (C.Sum < System.Math.Max(A.Sum, B.Sum))
				throw new System.Exception();
			return C;
		}

		public static BitSet Not(BitSet A)
		{
			BitSet B = new BitSet();
			for (int i = 0; i < 9; i++)
				B[i] = !A[i];
			if (B.Sum != (9 - A.Sum))
				throw new System.Exception();
			return B;
		}
	}
}
