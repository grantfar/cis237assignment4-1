using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort<T> where T:IComparable
    {
        //Used to start the sort
        public static T[] Merge_Sort(T[] toSort)
        {
            if (toSort.Length == 0)
                return toSort;
            return sort(toSort, 0, toSort.Length -1);
        }
        
        /// <summary>
        /// A Merge Sort
        /// </summary>
        /// <param name="toSort"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static T[] sort(T[] toSort, int start, int end)
        {
            T[] unsorted = toSort;
            if (end - start == 0)
                return toSort;
            T[] tmp = new T[end - start + 1];
            int split = (start + end) / 2;
            
            //recursive calls
            unsorted = sort(unsorted, start, split);
            unsorted = sort(unsorted, split + 1, end);
            
            int index1 = start , index2 = split + 1;
            
            while (index1 <= split  && index2 <= end)
            {
                // picks the correct Object
                if (unsorted[index1].CompareTo(unsorted[index2]) < 0)
                {
                    tmp[index1 + index2 - start - split - 1] = unsorted[index1];
                    index1++;
                }
                else
                {
                    tmp[index1 + index2 - start - split - 1] = unsorted[index2];
                    index2++;
                }
            }

            //tacks on the remaining objects
            while (index1 <= split)
            {
                tmp[index1 + index2 - start - split - 1] = unsorted[index1];
                index1++;
            }
            while (index2 <= end)
            {
                tmp[index1 + index2 - start - split - 1] = unsorted[index2];
                index2++;
            }
            return merge(tmp, unsorted, start);

        }
        
        /// <summary>
        /// Overides a certine section of the array
        /// </summary>
        /// <param name="toMerge"></param>
        /// <param name="mergeInto"></param>
        /// <param name="mergeIndex"></param>
        /// <returns></returns>
        private static T[] merge(T[] toMerge, T[] mergeInto, int mergeIndex)
        {
            T[] tmp = mergeInto;
            for(int i = 0; i < toMerge.Length; i++)
            {
                tmp[i + mergeIndex] = toMerge[i];
            }
            return tmp;
        }
    }
}
