using PbettiLab.AlgorithmicToolbox.Logic.Sort.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.Sort.Algorithms
{
	public class SelectionSort : ISortable
	{
		#region public methods

		/// <summary>
		/// Sort input elements by ascending order.
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
		/// Sort input elements by descending order.
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
			long startingPosition = 0;

			while (startingPosition < elements.Length - 1)
			{
				long minValuePosition = GetMinValuePosition(elements, startingPosition);

				SwapValues(elements, startingPosition, minValuePosition);

				startingPosition++;
			}
		}

		private static long GetMinValuePosition(int[] elements, long startingPosition)
		{
			long minValuePosition = startingPosition;

			for (long i = startingPosition+1; i < elements.Length; i++)
			{
				if (elements[i] < elements[minValuePosition])
				{ 
					minValuePosition = i;
				}
			}

			return minValuePosition;
		}

		private static void SwapValues(int[] elements, long startingPosition, long minValuePosition)
		{
			(elements[startingPosition], elements[minValuePosition]) = (elements[minValuePosition], elements[startingPosition]);
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
