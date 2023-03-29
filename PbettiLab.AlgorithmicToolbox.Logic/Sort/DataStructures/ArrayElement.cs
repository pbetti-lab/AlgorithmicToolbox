namespace PbettiLab.AlgorithmicToolbox.Logic.Sort.DataStructures
{
	public struct ArrayElement
	{
		public ArrayElement(long index, int value)
		{
			Index = index;
			Value = value;
		}

		public long Index { get; set; }

		public int Value { get; set; }
	}
}
