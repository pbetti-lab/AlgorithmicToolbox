namespace PbettiLab.AlgorithmicToolbox.Logic.Searching.Interfaces
{
	public interface IArraySearch
	{
		public bool Find(byte[] elements, byte value);

		public bool Find(int[] elements, int value);

		public bool Find(long[] elements, long value);

		public bool Find(float[] elements, float value);

		public bool Find(double[] elements, double value);

		public bool Find(decimal[] elements, decimal value);

		public bool Find(string[] elements, string value);
	}
}
