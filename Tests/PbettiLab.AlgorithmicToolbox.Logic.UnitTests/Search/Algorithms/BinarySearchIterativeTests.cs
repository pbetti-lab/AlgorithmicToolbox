using Microsoft.VisualStudio.TestTools.UnitTesting;
using PbettiLab.AlgorithmicToolbox.Logic.Search.Algorithms;
using PbettiLab.AlgorithmicToolbox.Logic.Search.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.UnitTests.Search.Algorithms
{
	[TestClass]
    public class BinarySearchIterativeTests
	{
		[TestMethod]
		public void Exist_InputElementsIsNull_ThrowArgumentNullException()
		{
			int[] elements = null;
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			Assert.ThrowsException<ArgumentNullException>(() => binaryIterativeSearch.Exist(elements, 5));
		}

		[TestMethod]
		public void Exist_InputElementsIsEmpty_ReturnFalse()
		{
			var elements = new int[] { };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.Exist(elements, 5);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Exist_InputElementsWithOneValueContainsSearchedValue_ReturnTrue()
		{
			var elements = new int[] { 5 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.Exist(elements, 5);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Exist_InputElementsWithTwoValuesContainsSearchedValueOnUpperBound_ReturnTrue()
		{
			var elements = new int[] { 4, 5 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.Exist(elements, 5);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Exist_InputElementsWithTwoValuesContainsSearchedValueOnLowerBound_ReturnTrue()
		{
			var elements = new int[] { 5, 6 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.Exist(elements, 5);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Exist_InputElementsContainsSearchedValueDoubled_ReturnTrue()
		{
			var elements = new int[] { 3, 4, 5, 5, 6, 7 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.Exist(elements, 5);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Exist_InputElementsWithOneValueNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new int[] { 8 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.Exist(elements, 5);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Exist_InputElementsWithTwoValuesNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new int[] { 8, 9 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.Exist(elements, 5);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Exist_InputElementsWithTreeValuesNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new int[] { 8, 9, 10 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.Exist(elements, 5);

			Assert.IsFalse(result);
		}
		 
		[TestMethod]
		public void GetIndex_InputElementsIsNull_ThrowArgumentNullException()
		{
			int[] elements = null;
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			Assert.ThrowsException<ArgumentNullException>(() => binaryIterativeSearch.GetIndex(elements, 5));
		}

		[TestMethod]
		public void GetIndex_InputElementsIsEmpty_ReturnNegativeIndex()
		{
			var elements = new int[] { };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.GetIndex(elements, 5);

			Assert.AreEqual(-1, result);
		}

		[TestMethod]
		public void GetIndex_InputElementsWithOneValueContainsSearchedValue_ReturnIndexFound()
		{
			var elements = new int[] { 5 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.GetIndex(elements, 5);

			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void GetIndex_InputElementsWithTwoValuesContainsSearchedValueOnUpperBound_ReturnIndexFound()
		{
			var elements = new int[] { 4, 5 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.GetIndex(elements, 5);

			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void GetIndex_InputElementsWithTwoValuesContainsSearchedValueOnLowerBound_ReturnIndexFound()
		{
			var elements = new int[] { 5, 6 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.GetIndex(elements, 5);

			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void GetIndex_InputElementsContainsSearchedValueDoubled_ReturnIndexFound()
		{
			var elements = new int[] { 3, 4, 5, 5, 6, 7 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.GetIndex(elements, 5);

			Assert.IsTrue(result == 2 || result == 3);
		}

		[TestMethod]
		public void GetIndex_InputElementsWithOneValueNotContainsSearchedValue_ReturnNegativeIndex()
		{
			var elements = new int[] { 8 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.GetIndex(elements, 5);

			Assert.AreEqual(-1, result);
		}

		[TestMethod]
		public void GetIndex_InputElementsWithTwoValuesNotContainsSearchedValue_ReturnNegativeIndex()
		{
			var elements = new int[] { 8, 9 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.GetIndex(elements, 5);

			Assert.AreEqual(-1, result);
		}

		[TestMethod]
		public void GetIndex_InputElementsWithTreeValuesNotContainsSearchedValue_ReturnNegativeIndex()
		{
			var elements = new int[] { 8, 9, 10 };
			ISearch binaryIterativeSearch = new BinarySearchIterative();

			var result = binaryIterativeSearch.GetIndex(elements, 5);

			Assert.AreEqual(-1, result);
		}
	}
}