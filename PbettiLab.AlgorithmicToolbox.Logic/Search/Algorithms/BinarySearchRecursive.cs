using PbettiLab.AlgorithmicToolbox.Logic.Search.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.Search.Algorithms
{
	public class BinarySearchRecursive : ISearch
	{
		#region public methods

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
				return -1;

			return InternalGetIndex(elements, value, 0, elements.Length - 1);
		}

		/// <summary>
		/// Check if the elements array contains a specific value.
		/// </summary>
		/// <param name="elements">The elements array.</param>
		/// <param name="value">The value to search.</param>
		/// <exception cref="ArgumentNullException">If the elements array is null.</exception>
		public bool Exist(int[] elements, int value)
		{
			return GetIndex(elements, value) >= 0;
		}

		#endregion

		#region private methods

		/// <summary>
		/// If exist, return the index of the value present in the elements array, if not return -1.
		/// </summary>
		/// <param name="elements">The elements array.</param>
		/// <param name="value">The value to search.</param>
		private long InternalGetIndex(int[] elements, int value, long leftBoundIndex, long rightBoundIndex)
		{
			if (leftBoundIndex > rightBoundIndex)
				return -1;

			long elementIndex = (leftBoundIndex + rightBoundIndex) / 2;

			if (elements[elementIndex] < value)
			{
				leftBoundIndex = elementIndex + 1;
			}
			else if (elements[elementIndex] > value)
			{
				rightBoundIndex = elementIndex - 1;
			}
			else
			{
				return elementIndex;
			}

			return InternalGetIndex(elements, value, leftBoundIndex, rightBoundIndex);
		}
		
		#endregion
	}
}
