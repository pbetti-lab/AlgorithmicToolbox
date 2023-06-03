using PbettiLab.AlgorithmicToolbox.Logic.Search.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.Search
{
	public class LinearSearch : ISearch
	{
		#region public methods

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

			return InternalGetIndex(elements, value) >= 0;
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

			if (elements.Length == 0)
				return -1L;

			return InternalGetIndex(elements, value);
		}
		
		#endregion

		#region private methods

		/// <summary>
		/// If exist, return the index of the value present in the elements array, if not return -1.
		/// </summary>
		/// <param name="elements">The elements array.</param>
		/// <param name="value">The value to search.</param>
		private static long InternalGetIndex(int[] elements, int value)
		{
			var elementIndexFound = -1L;
			var count = 0L;

			while (count < elements.Length && elementIndexFound < 0)
			{
				elementIndexFound = elements[count] == value
					? count
					: -1;

				count++;
			}

			return elementIndexFound;
		}

		#endregion
	}
}
