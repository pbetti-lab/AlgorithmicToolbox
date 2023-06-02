using PbettiLab.AlgorithmicToolbox.Logic.Sort.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.Sort.Algorithms
{
	public class MergeSortIterative : ISortable
	{
		#region internl definitions

		private sealed class OrderParams
		{
			public long ArrayToMergeLength { get; set; }
			
			public long FirstPartPosition { get; set; }

			public long SecondPartPosition { get; set; }

			public long SortedElementsCount { get; set; }

			public long MergeStep { get; set; }

			public long StartingStepPosition { get; set; }
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

			Sort(elements);
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

		private static void Sort(int[] elements)
		{
			int[] mergedElements = new int[elements.Length];
			
			var orderParams = InitOrderParams();

			while (ElementsNeedSort(elements, orderParams))
			{
				MergeSortElementsByStep(elements, mergedElements, orderParams);

				CopyMergedElementsToElementsArray(elements, orderParams, mergedElements);

				ReInitializeParamsForNextStep(orderParams);
			}
		}

		private static OrderParams InitOrderParams()
		{
			var orderParams = new OrderParams()
			{
				FirstPartPosition = 0,
				ArrayToMergeLength = 1,
				SortedElementsCount = 0,
				MergeStep = 0,
			};
			
			orderParams.SecondPartPosition = orderParams.FirstPartPosition + orderParams.ArrayToMergeLength;
			
			return orderParams;
		}

		private static bool ElementsNeedSort(int[] elements, OrderParams orderParams)
		{
			return orderParams.ArrayToMergeLength < elements.Length;
		}

		private static void MergeSortElementsByStep(int[] elements, int[] mergedElements, OrderParams orderParams)
		{
			while (ElementsInThisStepNeedSort(elements, orderParams))
			{
				orderParams.StartingStepPosition = orderParams.FirstPartPosition;

				MergeSortElement(elements, mergedElements, orderParams);

				orderParams.MergeStep++;
				orderParams.FirstPartPosition = orderParams.MergeStep * orderParams.ArrayToMergeLength * 2;
				orderParams.SecondPartPosition = orderParams.FirstPartPosition + orderParams.ArrayToMergeLength;
			}
		}

		private static bool ElementsInThisStepNeedSort(int[] elements, OrderParams orderParams)
		{
			return orderParams.SecondPartPosition < elements.Length;
		}

		private static void MergeSortElement(int[] elements, int[] mergedElements, OrderParams orderParams)
		{
			while (IsThereElementsToMergeFromAnyParts(orderParams))
			{
				if (IsBetterToGetElementFromFirstPart(elements, orderParams))
				{
					mergedElements[orderParams.SortedElementsCount] = elements[orderParams.FirstPartPosition];
					orderParams.FirstPartPosition++;
				}
				else if (IsBetterToGetElementFromSecondPart(elements, orderParams))
				{
					mergedElements[orderParams.SortedElementsCount] = elements[orderParams.SecondPartPosition];
					orderParams.SecondPartPosition++;
				}

				orderParams.SortedElementsCount++;
			}
		}

		private static bool IsThereElementsToMergeFromAnyParts(OrderParams orderParams)
		{
			return orderParams.SortedElementsCount < orderParams.StartingStepPosition + (orderParams.ArrayToMergeLength * 2);
		}

		private static bool IsBetterToGetElementFromFirstPart(int[] elements, OrderParams orderParams)
		{
			bool canGetElementsFromBothPartButFirstIsSmaller = CanGetElementsFromFirstPart(orderParams)
				&& CanGetElementsFromSecondPart(orderParams, elements.Length)
				&& elements[orderParams.FirstPartPosition] <= elements[orderParams.SecondPartPosition];

			bool onlyFirstPartContainsElements = CanGetElementsFromFirstPart(orderParams)
				&& !CanGetElementsFromSecondPart(orderParams, elements.Length);

			return canGetElementsFromBothPartButFirstIsSmaller 
				|| onlyFirstPartContainsElements;
		}

		private static bool IsBetterToGetElementFromSecondPart(int[] elements, OrderParams orderParams)
		{
			bool canGetElementsFromBothPartButSecondIsShorter = CanGetElementsFromFirstPart(orderParams)
				&& CanGetElementsFromSecondPart(orderParams, elements.Length)
				&& elements[orderParams.FirstPartPosition] > elements[orderParams.SecondPartPosition];

			bool mustGetElementsFromSecondPart = !CanGetElementsFromFirstPart(orderParams)
				&& CanGetElementsFromSecondPart(orderParams, elements.Length);

			return canGetElementsFromBothPartButSecondIsShorter 
				|| mustGetElementsFromSecondPart;
		}

		private static bool CanGetElementsFromFirstPart(OrderParams orderParams)
		{
			long firstPartMaxPosition = orderParams.StartingStepPosition + orderParams.ArrayToMergeLength;

			return orderParams.FirstPartPosition < firstPartMaxPosition;
		}

		private static bool CanGetElementsFromSecondPart(OrderParams orderParams, long elementsLength)
		{
			long secondPartMaxPosition = orderParams.StartingStepPosition + (orderParams.ArrayToMergeLength * 2);

			return orderParams.SecondPartPosition < secondPartMaxPosition
				&& orderParams.SecondPartPosition < elementsLength;
		}

		private static void CopyMergedElementsToElementsArray(int[] elements, OrderParams orderParams, int[] mergedElements)
		{
			long elementsToCopy = Math.Min(orderParams.SortedElementsCount, elements.Length);

			for (long i = 0; i < elementsToCopy; i++)
			{
				elements[i] = mergedElements[i];
			}
		}

		private static void ReInitializeParamsForNextStep(OrderParams orderParams)
		{
			orderParams.MergeStep = 0;
			orderParams.ArrayToMergeLength *= 2;
			orderParams.FirstPartPosition = orderParams.MergeStep * orderParams.ArrayToMergeLength * 2;
			orderParams.SecondPartPosition = orderParams.FirstPartPosition + orderParams.ArrayToMergeLength;
			orderParams.SortedElementsCount = 0;
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
