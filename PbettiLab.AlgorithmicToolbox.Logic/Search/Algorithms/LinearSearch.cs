using PbettiLab.AlgorithmicToolbox.Logic.Search.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.Search
{
	public class LinearSearch : ILinearSearch
	{
		/// <summary>
		/// Check if the elements array contains a specific value.
		/// </summary>
		/// <param name="elements">The elements array.</param>
		/// <param name="value">The value to search.</param>
		/// <exception cref="ArgumentNullException">If the elements array is null.</exception>
		public bool Exist(int[] elements, int value)
		{
			if (elements is null)
				throw new ArgumentNullException(nameof(elements), "Input variable elements cannot be null");

			if (elements.Length == 0)
				return false;

			var result = false;
			var count = 0L;

			while (count < elements.Length && !result)
			{
				result = elements[count] == value;
				count++;
			}

			return result;
		}

		/// <summary>
		/// If exist, return the index of the value present in the elements array, if not return -1.
		/// </summary>
		/// <param name="elements">The elements array.</param>
		/// <param name="value">The value to search.</param>
		/// <exception cref="ArgumentNullException">If the elements array is null.</exception>
		public long GetIndex(int[] elements, int value)
		{
			if (elements is null)
				throw new ArgumentNullException(nameof(elements), "Input variable elements cannot be null");

			var result = -1L;
			var count = 0L;

			while (count < elements.Length && result < 0)
			{
				result = elements[count] == value 
					? count 
					: result;

				count++;
			}

			return result;
		}
	}
}
