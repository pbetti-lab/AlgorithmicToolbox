using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PbettiLab.AlgorithmicToolbox.LogicTests.Search.Algorithms
{
	[TestClass]
	public class LinearSearchTests
	{
		[TestMethod]
		public void Find_ByteInputElementsIsNull_ThrowArgumentNullException()
		{
			ILinea linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Find(null, (byte)5));
		}
	}
}