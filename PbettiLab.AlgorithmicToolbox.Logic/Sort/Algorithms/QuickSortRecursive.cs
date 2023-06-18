using PbettiLab.AlgorithmicToolbox.Logic.Sort.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.Sort.Algorithms
{
	public class QuickSortRecursive : ISortable
	{
		private readonly Random _randomizer;

		public QuickSortRecursive() 
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
			if (leftIndex >= rightIndex)
				return;

			int startingPivotIndex = GetRandomPivotIndex(leftIndex, rightIndex);
			int sortedPivotIndex = ElementsPartition(elements, startingPivotIndex, leftIndex, rightIndex);

			Sort(elements, leftIndex, sortedPivotIndex - 1);
			Sort(elements, sortedPivotIndex + 1, rightIndex);
		}

		private int GetRandomPivotIndex(int leftIndex, int rightIndex)
		{
			return _randomizer.Next(leftIndex, rightIndex + 1);
		}

		private int ElementsPartition(int[] elements, int startingPivotIndex, int leftIndex, int rightIndex)
		{
			PutPivotElementInFirstPosition(elements, startingPivotIndex, leftIndex);

			startingPivotIndex = leftIndex;
			int sortedPivotIndex = leftIndex;

			for (int i = leftIndex + 1; i <= rightIndex; i++)
			{
				if (elements[i] <= elements[startingPivotIndex])
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

			PutPivotElementInFinalSortedPosition(elements, startingPivotIndex, sortedPivotIndex);

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

		private void ReverseOrder(int[] elements)
		{
			for (int i = 0; i < (elements.Length / 2); i++)
			{
				SwapValues(elements, elements.Length - 1 - i, i);
			}
		}
	}
}
