using System.Collections.Generic;

namespace PbettiLab.AlgorithmicToolbox.Logic.Searching.Interfaces
{
	public interface IGenericSearch
	{
		public bool Find<T>(T[] elements, T value);

		public bool Find<T>(T[] elements, T value, IEqualityComparer<T> equalityComparer) where T : class;

		public bool Find<T>(IEnumerable<T> elements, T value);

		public bool Find<T>(IEnumerable<T> elements, T value, IEqualityComparer<T> equalityComparer) where T : class;
	}
}
