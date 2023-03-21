using System.Collections.Generic;

namespace PbettiLab.AlgorithmicToolbox.Logic.Searching.Interfaces
{
	public interface IEnumerableSearch
	{
		public bool Find(IEnumerable<byte> elements, byte value);

		public bool Find(IEnumerable<int> elements, int value);

		public bool Find(IEnumerable<long> elements, long value);

		public bool Find(IEnumerable<float> elements, float value);

		public bool Find(IEnumerable<double> elements, double value);

		public bool Find(IEnumerable<decimal> elements, decimal value);

		public bool Find(IEnumerable<string> elements, string value);
	}
}
