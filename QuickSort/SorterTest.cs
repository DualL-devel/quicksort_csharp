using System;
using Xunit;
using System.Collections.Generic;

namespace QuickSort
{
	public class SorterTest
	{
		[Theory]
		//[InlineData (new int[] { 2, 1, 3 }, new int[] { 1, 2, 3 })]
		//[InlineData (new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
		//[InlineData (new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
		[InlineData (new int[] { 2, 3, 4, 5, 1 }, new int[] { 1, 2, 3, 4, 5 })]
		public void NaiveQsort (int[] unsorted, int[] sorted)
		{
			var ret1 = Sorter.NaiveQuickSort (unsorted);
			Assert.Equal (sorted, ret1);

			IList<int> tosort = new List<int>(unsorted);
			Sorter.ArrayQuickSort (ref tosort);
			Assert.Equal (sorted, tosort);
		}
	}
}
