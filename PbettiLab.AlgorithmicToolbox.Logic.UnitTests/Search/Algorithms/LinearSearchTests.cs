using Microsoft.VisualStudio.TestTools.UnitTesting;
using PbettiLab.AlgorithmicToolbox.Logic.Search;
using PbettiLab.AlgorithmicToolbox.Logic.Search.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.UnitTests.Search.Algorithms
{
    [TestClass]
    public class LinearSearchTests
	{
		[TestMethod]
		public void Exist_InputElementsIsNull_ThrowArgumentNullException()
		{
			int[] elements = null;
			ILinearSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Exist(elements, 5));
		}

		[TestMethod]
		public void Exist_InputElementsIsEmpty_ReturnFalse()
		{
			var elements = new int[] { };
			ILinearSearch linearSearch = new LinearSearch();

			var result = linearSearch.Exist(elements, 5);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Exist_InputElementsContainsSearchedValue_ReturnTrue()
		{
			var elements = new int[] { 4, 5, 6, 7, 8 };
			ILinearSearch linearSearch = new LinearSearch();

			var result = linearSearch.Exist(elements, 5);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Exist_InputElementsNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new int[] { 8, 9, 10, 11 };
			ILinearSearch linearSearch = new LinearSearch();

			var result = linearSearch.Exist(elements, 5);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void GetIndex_InputElementsIsNull_ThrowArgumentNullException()
		{
			int[] elements = null;
			ILinearSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.GetIndex(elements, 5));
		}

		[TestMethod]
		public void GetIndex_InputElementsIsEmpty_ReturnNegativeIndex()
		{
			var elements = new int[] { };
			ILinearSearch linearSearch = new LinearSearch();

			var result = linearSearch.GetIndex(elements, 5);

			Assert.AreEqual(-1, result);
		}

		[TestMethod]
		public void GetIndex_InputElementsContainsSearchedValue_ReturnIndexFound()
		{
			var elements = new int[] { 3, 4, 5, 6, 7, 8 };
			ILinearSearch linearSearch = new LinearSearch();

			var result = linearSearch.GetIndex(elements, 5);

			Assert.AreEqual(2, result);
		}

		[TestMethod]
		public void GetIndex_InputElementsNotContainsSearchedValue_ReturnNegativeIndex()
		{
			var elements = new int[] { 8, 9, 10, 11 };
			ILinearSearch linearSearch = new LinearSearch();

			var result = linearSearch.GetIndex(elements, 5);

			Assert.AreEqual(-1, result);
		}
	}
}