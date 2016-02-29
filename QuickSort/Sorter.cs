using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickSort
{
	public static class Sorter
	{
		/// <summary>
		/// An imperative quick sort for IList
		/// </summary>
		public static void ArrayQuickSort<T> (ref IList<T> unsorted) where T: IComparable 
		{
			ImplArrayQuickSort (ref unsorted, 0, unsorted.Count - 1);
		}

		private static void ImplArrayQuickSort<T> (ref IList<T> unsorted, int lo, int hi) where T: IComparable
		{
			if (lo < hi) {
				T pivot = unsorted [lo];
				int l = lo;
				int h = hi;
				for (;;) {
					while (h > l && unsorted [h].CompareTo (pivot) >= 0) {
						h--;
					}
					while (l < h && unsorted [l].CompareTo (pivot) <= 0) {
						l++;
					}
					if (l == h) {
						break;
					} else {
						T t = unsorted [l];
						unsorted [l] = unsorted [h];
						unsorted [h] = t;
					}
				}

				unsorted[lo] = unsorted[l];
				unsorted[l] = pivot; // unsorted[lo]

				ImplArrayQuickSort (ref unsorted, lo, l - 1);
				ImplArrayQuickSort (ref unsorted, l + 1, hi);
			}
		}

		/*
naiveQsort :: (Ord a) => [a] -> [a] -- this one beats a black hole at EATING MEMORY!
naiveQsort [] = []
naiveQsort [v] = [v]
naiveQsort (p:vs) = naiveQsort lesser ++ [p] ++ naiveQsort greater
    where
        lesser = [ x | x <- vs, x < p ]
        greater = [ y | y <- vs, y >= p ]
*/
		
		/// <summary>
		/// The naiveQsort ported from Haskell.
		/// </summary>
		public static IEnumerable<T> NaiveQuickSort<T> (IEnumerable<T> unsorted) where T: IComparable
		{
			T pivot;
			using (var enu = unsorted.GetEnumerator ()) {
				if (!enu.MoveNext ()) { // empty
					return unsorted;
				}
				pivot = enu.Current;
				if (!enu.MoveNext ()) { // only one element
					return unsorted;
				}
			}
			var pivotenum = unsorted.Take (1);
			var sublist = unsorted.Skip (1);
			var lesser = from x in sublist
			             where x.CompareTo (pivot) <= 0
			             select x;
			var greater = from x in sublist
			              where x.CompareTo (pivot) > 0
			              select x;
			return NaiveQuickSort (lesser).Concat (pivotenum).Concat (NaiveQuickSort (greater));
		}
	}
}
