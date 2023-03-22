namespace PbettiLab.AlgorithmicToolbox.Logic.Search.Interfaces
{
	public interface ISearch
	{
		public bool Exist(int[] elements, int value);

		public long GetIndex(int[] elements, int value);
	}
}
