using PbettiLab.AlgorithmicToolbox.Logic.Order.DataStructures;
using PbettiLab.AlgorithmicToolbox.Logic.Order.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.Order.Algorithms
{
	public class SelectionSort : ISortable
	{

		#region public methods

		public void Order(int[] elements)
		{
			if (elements is null)
				throw new ArgumentNullException(nameof(elements), "Input variable elements cannot be null");

			if (elements.Length <= 1)
				return;

			SortElements(elements, SortOrderType.Ascending);
		}

		public void OrderByDescending(int[] elements)
		{
			if (elements is null)
				throw new ArgumentNullException(nameof(elements), "Input variable elements cannot be null");

			if (elements.Length <= 1)
				return;

			SortElements(elements, SortOrderType.Descending);
		}

		#endregion

		#region private methods

		private void SortElements(int[] elements, SortOrderType sortOrderType)
		{
			var startingPositionValue = new ArrayElement(0, elements[0]);

			while (startingPositionValue.Index < elements.Length - 1)
			{
				var value = GetElementBySortOrderType(elements, startingPositionValue, sortOrderType);

				SwapValues(elements, startingPositionValue, value);

				IncrementStartingPosition(elements, ref startingPositionValue);
			}
		}

		private ArrayElement GetElementBySortOrderType(int[] elements, ArrayElement startingPositionValue, 
			SortOrderType sortOrderType) => sortOrderType switch
		{
			SortOrderType.Ascending => GetMinValueElementFromSpecifiedStartingPosition(elements, startingPositionValue),
			SortOrderType.Descending => GetMaxValueElementFromSpecifiedStartingPosition(elements, startingPositionValue),
			_ => throw new ArgumentOutOfRangeException(nameof(sortOrderType), $"Order type value {sortOrderType} not recognized.")
		};

		private ArrayElement GetMinValueElementFromSpecifiedStartingPosition(int[] elements, ArrayElement startingPositionValue)
		{
			var minValue = new ArrayElement(startingPositionValue.Index, elements[startingPositionValue.Index]);

			for (long i = startingPositionValue.Index; i <= elements.Length - 1; i++)
			{
				if (elements[i] < minValue.Value)
				{
					minValue.Index = i;
					minValue.Value = elements[i];
				}
			}

			return minValue;
		}

		private ArrayElement GetMaxValueElementFromSpecifiedStartingPosition(int[] elements, ArrayElement startingPositionValue)
		{
			var maxValue = new ArrayElement(startingPositionValue.Index, elements[startingPositionValue.Index]);

			for (long i = startingPositionValue.Index; i <= elements.Length - 1; i++)
			{
				if (elements[i] > maxValue.Value)
				{
					maxValue.Index = i;
					maxValue.Value = elements[i];
				}
			}

			return maxValue;
		}

		private void SwapValues(int[] elements, ArrayElement startingPosition, ArrayElement minValue)
		{
			if (startingPosition.Index != minValue.Index)
			{
				elements[startingPosition.Index] = minValue.Value;
				elements[minValue.Index] = startingPosition.Value;
			}
		}

		private void IncrementStartingPosition(int[] elements, ref ArrayElement startingPositionValue)
		{
			startingPositionValue.Index++;
			startingPositionValue.Value = elements[startingPositionValue.Index];
		}
		
		#endregion
	}
}
