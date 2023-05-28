using Microsoft.VisualStudio.TestTools.UnitTesting;
using PbettiLab.AlgorithmicToolbox.Logic.Sort.Algorithms;
using PbettiLab.AlgorithmicToolbox.Logic.Sort.Interfaces;
using System;

namespace PbettiLab.AlgorithmicToolbox.Logic.UnitTests.Sort.Algorithms
{
	[TestClass]
	public class SelectionSortTests
	{
		[TestMethod]
		public void Order_InputElementsIsNull_ThrowArgumentNullException()
		{
			int[] elements = default;
			ISortable selectionSort = new SelectionSort();

			Assert.ThrowsException<ArgumentNullException>(() => selectionSort.Order(elements));
		}

		[TestMethod]
		public void Order_InputElementsIsEmpty_ElementsRemainsTheSame()
		{
			int[] elements = new int[] { };
			ISortable selectionSort = new SelectionSort();

			selectionSort.Order(elements);

			Assert.AreEqual(0, elements.Length);
		}

		[TestMethod]
		public void Order_InputElementsContainsOnlyOneValue_ElementsRemainsTheSame()
		{
			const int ELEMENT_VALUE = 6;
			int[] elements = new int[] { ELEMENT_VALUE };
			ISortable selectionSort = new SelectionSort();

			selectionSort.Order(elements);

			Assert.AreEqual(1, elements.Length);
			Assert.AreEqual(ELEMENT_VALUE, elements[0]);
		}

		[TestMethod]
		public void Order_SortElementsTest1_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 6, 5 };
			selectionSort.Order(elements);

			Assert.AreEqual(2, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i-1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest2_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 5, 5 };
			selectionSort.Order(elements);

			Assert.AreEqual(2, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest3_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 5, 6 };
			selectionSort.Order(elements);

			Assert.AreEqual(2, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest4_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 6, 5, 4 };
			selectionSort.Order(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest5_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 4, 5, 6 };
			selectionSort.Order(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest6_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 5, 4, 6 };
			selectionSort.Order(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest7_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 5, 6, 4 };
			selectionSort.Order(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest8_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 12, 5, 9, 4, 5, 8, 115, 2, 3, 7, 4 };
			selectionSort.Order(elements);

			Assert.AreEqual(11, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void Order_SortElementsTest9_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 8, 7, 6, 5, 4, 3, 2, 1 };
			selectionSort.Order(elements);

			Assert.AreEqual(8, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] <= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_InputElementsIsNull_ThrowArgumentException()
		{
			int[] elements = null;
			ISortable selectionSort = new SelectionSort();

			Assert.ThrowsException<ArgumentNullException>(() => selectionSort.OrderByDescending(elements));
		}

		[TestMethod]
		public void OrderByDescending_InputElementsIsEmpty_ElementsRemainsTheSame()
		{
			int[] elements = new int[] { };
			ISortable selectionSort = new SelectionSort();

			selectionSort.OrderByDescending(elements);

			Assert.AreEqual(0, elements.Length);
		}

		[TestMethod]
		public void OrderByDescending_InputElementsContainsOnlyOneValue_ElementsRemainsTheSame()
		{
			const int ELEMENT_VALUE = 2;
			int[] elements = new int[] { ELEMENT_VALUE };
			ISortable selectionSort = new SelectionSort();

			selectionSort.OrderByDescending(elements);

			Assert.AreEqual(1, elements.Length);
			Assert.AreEqual(ELEMENT_VALUE, elements[0]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest1_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 6, 5 };
			selectionSort.OrderByDescending(elements);

			Assert.AreEqual(2, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest2_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 5, 5 };
			selectionSort.OrderByDescending(elements);

			Assert.AreEqual(2, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest3_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 5, 6 };
			selectionSort.OrderByDescending(elements);

			Assert.AreEqual(2, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest4_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 6, 5, 4 };
			selectionSort.OrderByDescending(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest5_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 4, 5, 6 };
			selectionSort.OrderByDescending(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest6_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 5, 4, 6 };
			selectionSort.OrderByDescending(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest7_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 5, 6, 4 };
			selectionSort.OrderByDescending(elements);

			Assert.AreEqual(3, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest8_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 12, 5, 9, 4, 5, 8, 115, 2, 3, 7, 4 };
			selectionSort.OrderByDescending(elements);

			Assert.AreEqual(11, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

		[TestMethod]
		public void OrderByDescending_SortElementsTest9_ElementsAreOrdered()
		{
			ISortable selectionSort = new SelectionSort();

			int[] elements = new int[] { 8, 7, 6, 5, 4, 3, 2, 1 };
			selectionSort.OrderByDescending(elements);

			Assert.AreEqual(8, elements.Length);
			for (int i = 1; i < elements.Length - 1; i++)
				Assert.IsTrue(elements[i - 1] >= elements[i]);
		}

	}
}
