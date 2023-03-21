using PbettiLab.AlgorithmicToolbox.Logic.Searching.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PbettiLab.AlgorithmicToolbox.Logic.Searching.Algorithms
{
	public class LinearSearch : IArraySearch, IEnumerableSearch, IGenericSearch
	{
		#region public methods

		public bool Find(byte[] elements, byte value) => Find<byte>(elements, value);

		public bool Find(int[] elements, int value) => Find<int>(elements, value);

		public bool Find(long[] elements, long value) => Find<long>(elements, value);

		public bool Find(float[] elements, float value) => Find<float>(elements, value);

		public bool Find(double[] elements, double value) => Find<double>(elements, value);

		public bool Find(decimal[] elements, decimal value) => Find<decimal>(elements, value);

		public bool Find(string[] elements, string value) => Find<string>(elements, value);

		public bool Find(IEnumerable<byte> elements, byte value) => Find<byte>(elements, value);

		public bool Find(IEnumerable<int> elements, int value) => Find<int>(elements, value);

		public bool Find(IEnumerable<long> elements, long value) => Find<long>(elements, value);

		public bool Find(IEnumerable<float> elements, float value) => Find<float>(elements, value);

		public bool Find(IEnumerable<double> elements, double value) => Find<double>(elements, value);

		public bool Find(IEnumerable<decimal> elements, decimal value) => Find<decimal>(elements, value);

		public bool Find(IEnumerable<string> elements, string value) => Find<string>(elements, value);

		public bool Find<T>(T[] elements, T value)
		{
			if (elements is null)
				throw new ArgumentNullException(nameof(elements), "Input variable elements cannot be null");

			if (elements.Length == 0)
				return false;

			var result = false;
			var count = 0;

			while (count < elements.Length && !result)
			{
				if (EqualityComparer<T>.Default.Equals(elements[count], value))
					result = true;
				count++;
			}

			return result;
		}

		public bool Find<T>(T[] elements, T value, IEqualityComparer<T> equalityComparer) where T : class
		{
			if (elements is null)
				throw new ArgumentNullException(nameof(elements), "Input variable elements cannot be null");

			if (elements.Length == 0)
				return false;

			var result = false;
			var count = 0;

			while (count < elements.Length && !result)
			{
				if (equalityComparer.Equals(elements[count], value))
					result = true;
				count++;
			}

			return result;
		}

		public bool Find<T>(IEnumerable<T> elements, T value)
		{
			if (elements is null)
				throw new ArgumentNullException(nameof(elements), "Input variable elements cannot be null");

			if (!elements.Any())
				return false;

			foreach (var element in elements)
				if (EqualityComparer<T>.Default.Equals(element, value))
					return true;

			return false;
		}

		public bool Find<T>(IEnumerable<T> elements, T value, IEqualityComparer<T> equalityComparer) where T : class
		{
			if (elements is null)
				throw new ArgumentNullException(nameof(elements), "Input variable elements cannot be null");

			if (!elements.Any())
				return false;

			foreach (var element in elements)
				if (equalityComparer.Equals(element, value))
					return true;

			return false;
		}

		#endregion
	}
}
