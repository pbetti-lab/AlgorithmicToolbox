using PbettiLab.AlgorithmicToolbox.Logic.Sort.Interfaces;
using System;
using System.Runtime.InteropServices;

namespace PbettiLab.AlgorithmicToolbox.Logic.Sort.Algorithms
{
	public class MergeSortRecursive : ISortable
	{
		#region internl definitions

		private sealed class OrderParams
		{
			public long FirstPartCounter { get; set; }

			public long SecondPartCounter { get; set; }
			
			public long ElementsToMergeLength { get; set; }

			public long MergedElementsCounter { get; set; }
		}

		#endregion

		#region public methods

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

			CopySortedElements(elements, Sort(elements));
		}

		/// <summary>
		/// Sort the elements by descing order.
		/// </summary>
		/// <param name="elements">The elements to sort.</param>
		/// <exception cref="ArgumentNullException">If the elements array is null.</exception>
		public void OrderByDescending(int[] elements)
		{
			Order(elements);
			ReverseOrder(elements);
		}

		#endregion

		#region private methods

		private static int[] Sort(int[] elements)
		{
			if (elements.Length == 1)
				return elements;

			var (firstPart, secondPart) = SplitElementsIntoTwoParts(elements);

			firstPart = Sort(firstPart);
			secondPart = Sort(secondPart);

			return MergeElements(firstPart, secondPart); 
		}

		private static (int[] firstPart, int[] secondPart) SplitElementsIntoTwoParts(int[] elements)
		{
			long firstPartElementsCount = elements.Length > 2
				? elements.Length / 2
				: 1;

			var firstPart = CopyElementsToNewArray(elements, 0, firstPartElementsCount);
			var secondPart = CopyElementsToNewArray(elements, firstPartElementsCount, elements.Length - firstPartElementsCount);

			return new(firstPart, secondPart); 
		}

		private static int[] CopyElementsToNewArray(int[] source, long startIndex, long count)
		{
			var destination = new int[count];

			long elementCount = 0;
			while(elementCount < count)
			{
				destination[elementCount] = source[startIndex + elementCount];
				elementCount++;
			}

			return destination; 
		}

		private static int[] MergeElements(int[] firstPart, int[] secondPart)
		{
			OrderParams orderParams = InizializeOrderParams(firstPart.Length, secondPart.Length);
			
			var mergedElements = new int[orderParams.ElementsToMergeLength];

			while (ElementsNeedMerge(orderParams))
			{
				if (IsBetterToGetElementFromFirstPart(firstPart, secondPart, orderParams))
				{
					mergedElements[orderParams.MergedElementsCounter] = firstPart[orderParams.FirstPartCounter];
					orderParams.FirstPartCounter++;
				}
				else if (IsBetterToGetElementFromSecondPart(firstPart, secondPart, orderParams))
				{
					mergedElements[orderParams.MergedElementsCounter] = secondPart[orderParams.SecondPartCounter];
					orderParams.SecondPartCounter++;
				}

				orderParams.MergedElementsCounter++;
			}

			return mergedElements;
		}

		private static bool ElementsNeedMerge(OrderParams orderParams)
		{
			return orderParams.MergedElementsCounter < orderParams.ElementsToMergeLength;
		}

		private static OrderParams InizializeOrderParams(long firstPartLength, long secondPartLength)
		{
			return new OrderParams()
			{
				FirstPartCounter = 0,
				SecondPartCounter = 0,
				MergedElementsCounter = 0,
				ElementsToMergeLength = firstPartLength + secondPartLength,
			};
		}

		private static bool IsBetterToGetElementFromFirstPart(int[] firstPart, int[] secondPart, OrderParams orderParams)
		{
			bool canGetElementsFromBothPartButFirstIsSmaller = CanGetElementsFromFirstPart(firstPart, orderParams.FirstPartCounter)
				&& CanGetElementsFromSecondPart(secondPart, orderParams.SecondPartCounter)
				&& firstPart[orderParams.FirstPartCounter] < secondPart[orderParams.SecondPartCounter];
			
			bool onlyFirstPartContainsElements = CanGetElementsFromFirstPart(firstPart, orderParams.FirstPartCounter) 
				&& !CanGetElementsFromSecondPart(secondPart, orderParams.SecondPartCounter);

			return canGetElementsFromBothPartButFirstIsSmaller
				|| onlyFirstPartContainsElements;
		}

		private static bool IsBetterToGetElementFromSecondPart(int[] firstPart, int[] secondPart, OrderParams orderParams)
		{
			bool canGetElementsFromBothPartButSecondIsSmaller = CanGetElementsFromFirstPart(firstPart, orderParams.FirstPartCounter)
				&& CanGetElementsFromSecondPart(secondPart, orderParams.SecondPartCounter)
				&& secondPart[orderParams.SecondPartCounter] <= firstPart[orderParams.FirstPartCounter];
			
			bool onlySecondPartContainsElements = !CanGetElementsFromFirstPart(firstPart, orderParams.FirstPartCounter) 
				&& CanGetElementsFromSecondPart(secondPart, orderParams.SecondPartCounter);

			return canGetElementsFromBothPartButSecondIsSmaller 
				|| onlySecondPartContainsElements;
		}

		private static bool CanGetElementsFromSecondPart(int[] secondPart, long secondPartArrayCounter)
		{
			return secondPartArrayCounter < secondPart.Length;
		}

		private static bool CanGetElementsFromFirstPart(int[] firstPart, long firstPartArrayCounter)
		{
			return firstPartArrayCounter < firstPart.Length;
		}

		private static void CopySortedElements(int[] elements, int[] sortedElements)
		{
			for (int i = 0; i < elements.Length; i++)
			{
				elements[i] = sortedElements[i];
			}
		}

		private static void ReverseOrder(int[] elements)
		{
			for (long i = 0; i < (elements.Length / 2); i++)
			{
				(elements[elements.Length - 1 - i], elements[i]) = (elements[i], elements[elements.Length - 1 - i]);
			}
		}

		#endregion
	}
}
