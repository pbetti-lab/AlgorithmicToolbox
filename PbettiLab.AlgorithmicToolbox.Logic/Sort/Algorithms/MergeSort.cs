using PbettiLab.AlgorithmicToolbox.Logic.Sort.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.Sort.Algorithms
{
	public class MergeSort : ISortable
	{
		#region public methods

		/// <summary>
		/// Sort the elements by ascending order.
		/// </summary>
		/// <param name="elements">The elements to sort.</param>
		/// <exception cref="ArgumentNullException">If the elements array is null.</exception>
		public void Order(int[] elements)
		{
			if (elements is null)
				throw new ArgumentNullException(nameof(elements), "Input variable elements cannot be null");

			if (elements.Length <= 1)
				return;

			var sortedElements = SortElements(elements);
			for (int i = 0; i < elements.Length; i++)
				elements[i] = sortedElements[i];
		}

		/// <summary>
		/// Sort the elements by descing order.
		/// </summary>
		/// <param name="elements">The elements to sort.</param>
		/// <exception cref="ArgumentNullException">If the elements array is null.</exception>
		public void OrderByDescending(int[] elements)
		{
			if (elements is null)
				throw new ArgumentNullException(nameof(elements), "Input variable elements cannot be null");

			if (elements.Length <= 1)
				return;

			var sortedElements = SortElements(elements);
			for (int i = 0; i < elements.Length; i++)
				elements[i] = sortedElements[elements.Length - i - 1];
		}

		#endregion

		#region private methods

		private int[] SortElements(int[] elements)
		{
			if (elements.Length == 1)
				return elements;

			var (FirstPart, SecondPart) = SplitArray(elements);
			
			var elementsFirstPartSorted = SortElements(FirstPart);
			var elementsSecondPartSorted = SortElements(SecondPart);

			return MergeElements(elementsFirstPartSorted, elementsSecondPartSorted); 
		}

		private (int[] FirstPart, int[] SecondPart) SplitArray(int[] elements)
		{
			long middlePositionIndex = elements.Length > 2
				? elements.Length / 2
				: 0;

			var elementsFirstPart = CopyArrayElements(elements, 0, middlePositionIndex);
			var elementsSecondPart = CopyArrayElements(elements, middlePositionIndex + 1, elements.Length - 1);

			return new(elementsFirstPart, elementsSecondPart); 
		}

		private int[] MergeElements(int[] firstPart, int[] secondPart)
		{
			long mergedArrayLength = firstPart.Length + secondPart.Length;
			var mergedArray = new int[mergedArrayLength];

			long mergedArrayCounter = 0;
			long firstPartArrayCounter = 0;
			long secondPartArrayCounter = 0;

			while (mergedArrayCounter < mergedArrayLength)
			{
				if (TakeElementFromFirstPartArray(firstPart, firstPartArrayCounter, secondPart, secondPartArrayCounter))
				{
					mergedArray[mergedArrayCounter] = firstPart[firstPartArrayCounter];
					firstPartArrayCounter++;
				}
				else if (TakeElementFromSecondPartArray(firstPart, firstPartArrayCounter, secondPart, secondPartArrayCounter))
				{
					mergedArray[mergedArrayCounter] = secondPart[secondPartArrayCounter];
					secondPartArrayCounter++;
				}

				mergedArrayCounter++;
			}

			return mergedArray;
		}

		private int[] CopyArrayElements(int[] source, long startIndex, long endIndex)
		{
			long copiedArrayLength = endIndex - startIndex + 1;
			var copiedArray = new int[copiedArrayLength];

			for (long i = startIndex; i <= endIndex; i++)
				copiedArray[i-startIndex] = source[i];

			return copiedArray; 
		}

		private bool TakeElementFromFirstPartArray(int[] firstPart, long firstPartArrayCounter, 
			int[] secondPart, long secondPartArrayCounter)
		{
			bool firtPartContainsElementsToMerge = firstPartArrayCounter < firstPart.Length;
			bool secondPartContainsElementsToMerge = secondPartArrayCounter < secondPart.Length;

			bool onlyFirstPartContainsElements = firtPartContainsElementsToMerge && !secondPartContainsElementsToMerge;
			
			bool firstPartElementIsSmallerThanSecondPartElement = firtPartContainsElementsToMerge
				&& secondPartContainsElementsToMerge
				&& firstPart[firstPartArrayCounter] < secondPart[secondPartArrayCounter];

			return onlyFirstPartContainsElements || firstPartElementIsSmallerThanSecondPartElement;
		}

		private bool TakeElementFromSecondPartArray(int[] firstPart, long firstPartArrayCounter,
			int[] secondPart, long secondPartArrayCounter)
		{
			bool firtPartContainsElementsToMerge = firstPartArrayCounter < firstPart.Length;
			bool secondPartContainsElementsToMerge = secondPartArrayCounter < secondPart.Length;

			bool onlySecondPartContainsElements = !firtPartContainsElementsToMerge && secondPartContainsElementsToMerge;

			bool secondPartElementIsSmallerThanFirstPartElement = firtPartContainsElementsToMerge
				&& secondPartContainsElementsToMerge
				&& secondPart[secondPartArrayCounter] <= firstPart[firstPartArrayCounter];

			return onlySecondPartContainsElements || secondPartElementIsSmallerThanFirstPartElement;
		}

		#endregion
	}
}
