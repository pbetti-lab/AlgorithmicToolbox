using Microsoft.VisualStudio.TestTools.UnitTesting;
using PbettiLab.AlgorithmicToolbox.Logic.Searching.Algorithms;
using PbettiLab.AlgorithmicToolbox.Logic.Searching.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.UnitTests.Searching.Algorithms
{
	[TestClass]
    public class LinearSearch_IEnumerableSearch_Tests
	{
		#region byte tests

		[TestMethod]
        public void Find_ByteInputElementsIsNull_ThrowArgumentNullException()
        {
			IEnumerableSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Find(null, (byte)5));
		}

		[TestMethod]
		public void Find_ByteInputElementsIsEmpty_ReturnFalse()
		{
			var elements = new byte[] { };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_ByteInputElementsContainsSearchedValue_ReturnTrue()
		{
			var elements = new byte[] { 4, 5, 6, 7, 8 };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_ByteInputElementsNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new byte[] { 8, 9, 10, 11 };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5);

			Assert.IsFalse(result);
		}

		#endregion

		#region int tests

		[TestMethod]
		public void Find_IntInputElementsIsNull_ThrowArgumentNullException()
		{
			IEnumerableSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Find(null, 5));
		}

		[TestMethod]
		public void Find_IntInputElementsIsEmpty_ReturnFalse()
		{
			var elements = new int[] { };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_IntInputElementsContainsSearchedValue_ReturnTrue()
		{
			var elements = new int[] { 4, 5, 6, 7, 8 };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_IntInputElementsNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new int[] { 8, 9, 10, 11 };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5);

			Assert.IsFalse(result);
		}

		#endregion

		#region long tests

		[TestMethod]
		public void Find_LongInputElementsIsNull_ThrowArgumentNullException()
		{
			IEnumerableSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Find(null, 5L));
		}

		[TestMethod]
		public void Find_LongInputElementsIsEmpty_ReturnFalse()
		{
			var elements = new long[] { };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5L);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_LongInputElementsContainsSearchedValue_ReturnTrue()
		{
			var elements = new long[] { 4L, 5L, 6L, 7L, 8L };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5L);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_LongInputElementsNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new long[] { 8L, 9L, 10L, 11L };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5L);

			Assert.IsFalse(result);
		}

		#endregion

		#region float tests

		[TestMethod]
		public void Find_FloatInputElementsIsNull_ThrowArgumentNullException()
		{
			IEnumerableSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Find(null, 5.5F));
		}

		[TestMethod]
		public void Find_FloatInputElementsIsEmpty_ReturnFalse()
		{
			var elements = new float[] { };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5.5F);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_FloatInputElementsContainsSearchedValue_ReturnTrue()
		{
			var elements = new float[] { 4.4F, 5.5F, 6.6F, 7.7F, 8.8F };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5.5F);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_FloatInputElementsNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new float[] { 8.8F, 9.9F, 10.10F, 11.11F };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5.5F);

			Assert.IsFalse(result);
		}

		#endregion

		#region double tests

		[TestMethod]
		public void Find_DoubleInputElementsIsNull_ThrowArgumentNullException()
		{
			IEnumerableSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Find(null, 5.5D));
		}

		[TestMethod]
		public void Find_DoubleInputElementsIsEmpty_ReturnFalse()
		{
			var elements = new double[] { };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5.5D);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_DoubleInputElementsContainsSearchedValue_ReturnTrue()
		{
			var elements = new double[] { 4.4D, 5.5D, 6.6D, 7.7D, 8.8D };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5.5D);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_DoubleInputElementsNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new double[] { 8.8D, 9.9D, 10.10D, 11.11D };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5.5D);

			Assert.IsFalse(result);
		}

		#endregion

		#region decimal tests

		[TestMethod]
		public void Find_DecimalInputElementsIsNull_ThrowArgumentNullException()
		{
			IEnumerableSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Find(null, 5M));
		}

		[TestMethod]
		public void Find_DecimalInputElementsIsEmpty_ReturnFalse()
		{
			var elements = new decimal[] { };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5M);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_DecimalInputElementsContainsSearchedValue_ReturnTrue()
		{
			var elements = new decimal[] { 4.4M, 5.5M, 6.6M, 7.7M, 8.8M };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5.5M);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_DecimalInputElementsNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new decimal[] { 8.8M, 9.9M, 10.10M, 11.11M };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, 5.5M);

			Assert.IsFalse(result);
		}

		#endregion

		#region string tests

		[TestMethod]
		public void Find_StringInputElementsIsNull_ThrowArgumentNullException()
		{
			IEnumerableSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Find(null, "a"));
		}

		[TestMethod]
		public void Find_StringInputElementsIsEmpty_ReturnFalse()
		{
			var elements = new string[] { };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, "a");

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_StringInputElementsContainsSearchedValue_ReturnFalse()
		{
			var elements = new string[] { "a", "B", "c", "D" };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, "a");

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_StringInputElementsNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new string[] { "a", "B", "c", "D" };
			IEnumerableSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, "A");

			Assert.IsFalse(result);
		}
		
		#endregion
	}
}