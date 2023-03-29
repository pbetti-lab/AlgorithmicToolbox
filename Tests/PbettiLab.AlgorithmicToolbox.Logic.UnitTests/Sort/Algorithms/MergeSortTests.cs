using Microsoft.VisualStudio.TestTools.UnitTesting;
using PbettiLab.AlgorithmicToolbox.Logic.Sort.Algorithms;
using PbettiLab.AlgorithmicToolbox.Logic.Sort.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.UnitTests.Order.Algorithms
{
	[TestClass]
	public class MergeSortTests
	{
		[TestMethod]
		public void Order_InputElementsIsNull_ThrowArgumentNullException()
		{
			int[] elements = null;
			ISortable mergeSort = new MergeSort();

			Assert.ThrowsException<ArgumentNullException>(() => mergeSort.Order(elements));
		}

		[TestMethod]
		public void Order_InputElementsIsEmpty_ElementsRemainsTheSame()
		{
			int[] elements = new int[] { };
			ISortable mergeSort = new MergeSort();

			mergeSort.Order(elements);

			Assert.AreEqual(0, elements.Length);
		}

		[TestMethod]
		public void Order_InputElementsContainsOnlyOneValue_ElementsRemainsTheSame()
		{
			const int ELEMENT_VALUE = 6;
			int[] elements = new int[] { ELEMENT_VALUE };
			ISortable mergeSort = new MergeSort();

			mergeSort.Order(elements);

			Assert.AreEqual(1, elements.Length);
			Assert.AreEqual(ELEMENT_VALUE, elements[0]);
		}

		[TestMethod]
		public void Order_SortElementsTest1_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 6, 5 };
			mergeSort.Order(elements);

			Assert.AreEqual(2, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest2_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 5, 5 };
			mergeSort.Order(elements);

			Assert.AreEqual(2, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest3_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 5, 6 };
			mergeSort.Order(elements);

			Assert.AreEqual(2, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest4_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 6, 5, 4 };
			mergeSort.Order(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest5_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 4, 5, 6 };
			mergeSort.Order(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest6_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 5, 4, 6 };
			mergeSort.Order(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest7_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 5, 6, 4 };
			mergeSort.Order(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest8_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 12, 5, 9, 4, 5, 8, 115, 2, 3, 7, 4 };
			mergeSort.Order(elements);

			Assert.AreEqual(11, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_InputElementsIsNull_ThrowArgumentNullException()
		{
			int[] elements = null;
			ISortable mergeSort = new MergeSort();

			Assert.ThrowsException<ArgumentNullException>(() => mergeSort.OrderByDescending(elements));
		}

		[TestMethod]
		public void OrderByDescending_InputElementsIsEmpty_ElementsRemainsTheSame()
		{
			int[] elements = new int[] { };
			ISortable mergeSort = new MergeSort();

			mergeSort.OrderByDescending(elements);

			Assert.AreEqual(0, elements.Length);
		}

		[TestMethod]
		public void OrderByDescending_InputElementsContainsOnlyOneValue_ElementsRemainsTheSame()
		{
			const int ELEMENT_VALUE = 6;
			int[] elements = new int[] { ELEMENT_VALUE };
			ISortable mergeSort = new MergeSort();

			mergeSort.OrderByDescending(elements);

			Assert.AreEqual(1, elements.Length);
			Assert.AreEqual(ELEMENT_VALUE, elements[0]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest1_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 6, 5 };
			mergeSort.OrderByDescending(elements);

			Assert.AreEqual(2, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest2_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 5, 5 };
			mergeSort.OrderByDescending(elements);

			Assert.AreEqual(2, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest3_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 5, 6 };
			mergeSort.OrderByDescending(elements);

			Assert.AreEqual(2, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest4_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 6, 5, 4 };
			mergeSort.OrderByDescending(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest5_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 4, 5, 6 };
			mergeSort.OrderByDescending(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest6_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 5, 4, 6 };
			mergeSort.OrderByDescending(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest7_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 5, 6, 4 };
			mergeSort.OrderByDescending(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest8_ElementsAreOrdered()
		{
			ISortable mergeSort = new MergeSort();

			int[] elements = new int[] { 12, 5, 9, 4, 5, 8, 115, 2, 3, 7, 4 };
			mergeSort.OrderByDescending(elements);

			Assert.AreEqual(11, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

	}
}
