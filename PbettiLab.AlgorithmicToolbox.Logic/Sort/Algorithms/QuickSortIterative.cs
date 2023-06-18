using PbettiLab.AlgorithmicToolbox.Logic.Sort.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PbettiLab.AlgorithmicToolbox.Logic.Sort.Algorithms
{
	public class QuickSortIterative : ISortable
	{
		#region internal definitions

		private sealed class SortIndexes
		{
			public int LeftIndex { get; set; }

			public int RightIndex { get; set; }

            public int StartingPivotIndex { get; set; }
		}

		#endregion

		private readonly Random _randomizer;

		public QuickSortIterative() 
		{
			_randomizer = new Random();
		}

		/// <summary>
		/// Sort the elements by ascending order.
		/// </summary>
		/// <param name="elements">The elements to sort.</param>
		/// <exception cref="ArgumentNullException">If the elements array is null.</exception>
		public void Order(int[] elements)
		{
			if (elements is null)
			{
				throw new ArgumentNullException(nameof(elements), "Input variable elements cannot be null");
			}

			if (elements.Length <= 1)
			{
				return;
			}

			Sort(elements, 0, elements.Length - 1);
		}

		public void OrderByDescending(int[] elements)
		{
			Order(elements);
			ReverseOrder(elements);
		}

		private void Sort(int[] elements, int leftIndex, int rightIndex)
		{
			var indexesStack = new Stack<SortIndexes>();
			PushIndexesIntoStack(indexesStack, leftIndex, rightIndex);

			while (indexesStack.Any()) 
			{
				var indexes = indexesStack.Pop();
				int sortedPivotIndex = ElementsPartition(elements, indexes);

				if (indexes.LeftIndex < sortedPivotIndex - 1)
				{
					PushIndexesIntoStack(indexesStack, indexes.LeftIndex, sortedPivotIndex - 1);
				}

				if (sortedPivotIndex + 1 < indexes.RightIndex)
				{
					PushIndexesIntoStack(indexesStack, sortedPivotIndex + 1, indexes.RightIndex);
				}
			}
		}

		private int GetRandomPivotIndex(int leftIndex, int rightIndex)
		{
			return _randomizer.Next(leftIndex, rightIndex + 1);
		}

		private int ElementsPartition(int[] elements, SortIndexes indexes)
		{
			PutPivotElementInFirstPosition(elements, indexes.StartingPivotIndex, indexes.LeftIndex);

			indexes.StartingPivotIndex = indexes.LeftIndex;
			int sortedPivotIndex = indexes.LeftIndex;

			for (int i = indexes.LeftIndex + 1; i <= indexes.RightIndex; i++)
			{
				if (elements[i] <= elements[indexes.StartingPivotIndex])
				{
					if (sortedPivotIndex + 1 == i)
					{ 
						sortedPivotIndex++;
					}
					else 
					{
						sortedPivotIndex++;
						SwapValues(elements, i, sortedPivotIndex);
					}
				}
			}

			PutPivotElementInFinalSortedPosition(elements, indexes.StartingPivotIndex, sortedPivotIndex);

			return sortedPivotIndex;
		}

		private void PutPivotElementInFinalSortedPosition(int[] elements, int startingPivotIndex, int sortedPivotIndex)
		{
			if (startingPivotIndex != sortedPivotIndex)
			{ 
				SwapValues(elements, startingPivotIndex, sortedPivotIndex);
			}
		}

		private void PutPivotElementInFirstPosition(int[] elements, int startingPivotIndex, int leftIndex)
		{
			if (startingPivotIndex != leftIndex)
			{ 
				SwapValues(elements, startingPivotIndex, leftIndex);
			}
		}

		private void SwapValues(int[] elements, int leftPosition, int rightPosition)
		{
			(elements[leftPosition], elements[rightPosition]) = (elements[rightPosition], elements[leftPosition]);
		}

		private void PushIndexesIntoStack(Stack<SortIndexes> indexesStack, int leftIndex, int rightIndex)
		{
			indexesStack.Push(
				new SortIndexes()
				{
					LeftIndex = leftIndex,
					RightIndex = rightIndex,
					StartingPivotIndex = GetRandomPivotIndex(leftIndex, rightIndex),
				}
			);
		}

		private void ReverseOrder(int[] elements)
		{
			for (int i = 0; i < (elements.Length / 2); i++)
			{
				SwapValues(elements, elements.Length - 1 - i, i);
			}
		}
	}
}
