using Microsoft.VisualStudio.TestTools.UnitTesting;
using PbettiLab.AlgorithmicToolbox.Logic.Searching.Algorithms;
using PbettiLab.AlgorithmicToolbox.Logic.Searching.Interfaces;
using PbettiLab.AlgorithmicToolbox.Logic.UnitTests.Searching.Algorithms.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PbettiLab.AlgorithmicToolbox.Logic.UnitTests.Searching.Algorithms
{
	[TestClass]
    public class LinearSearch_IGenericSearch_Tests
	{
		#region ValueType array tests

		[TestMethod]
        public void Find_ValueTypeArrayInputElementsIsNull_ThrowArgumentNullException()
        {
			int[] elements = null;
			IGenericSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Find<int>(elements, 5));
		}

		[TestMethod]
		public void Find_ValueTypeArrayInputElementsIsEmpty_ReturnFalse()
		{
			var elements = new int[] { };
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find<int>(elements, 5);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_ValueTypeArrayInputElementsContainsSearchedValue_ReturnTrue()
		{
			var elements = new int[] { 4, 5, 6, 7, 8 };
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find<int>(elements, 5);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_ValueTypeArrayInputElementsNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new int[] { 8, 9, 10, 11 };
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find<int>(elements, 5);

			Assert.IsFalse(result);
		}

		#endregion

		#region ReferenceType array tests

		[TestMethod]
		public void Find_ReferenceTypeArrayInputElementsIsNull_ThrowArgumentNullException()
		{
			string[] elements = null;
			IGenericSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Find<string>(elements, "a"));
		}
		
		[TestMethod]
		public void Find_ReferenceTypeArrayInputElementsIsEmpty_ReturnFalse()
		{
			var elements = new string[] { };
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find<string>(elements, "a");

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_ReferenceTypeArrayInputElementsContainsSearchedValue_ReturnTrue()
		{
			var elements = new string[] { "a", "B", "c", "D" };
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, "a");

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_ReferenceTypeArrayInputElementsNotContainsSearchedValue_ReturnFalse()
		{
			var elements = new string[] { "a", "B", "c", "D" };
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, "A");

			Assert.IsFalse(result);
		}

		#endregion

		#region EqualityComparer array tests

		[TestMethod]
		public void Find_ReferenceTypeArrayInputElementsIsNullWithIEqualtyComparer_ThrowArgumentNullException()
		{
			Person[] elements = null;
			var personX = new Person() { Name = "Jon", Surname = "Doe", Age = 32 };
			IGenericSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => 
				linearSearch.Find<Person>(elements, personX, new AgePersonEqualityComparer()));
		}

		[TestMethod]
		public void Find_ReferenceTypeArrayInputElementsIsEmptyWithIEqualtyComparer_ReturnFalse()
		{
			var elements = new Person[] { };
			var personX = new Person() { Name = "Jon", Surname = "Doe", Age = 32 };
			IGenericSearch linearSearch = new LinearSearch();
			
			var result = linearSearch.Find<Person>(elements, personX);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_ReferenceTypeArrayInputElementsContainsSearchedValueWithIEqualtyComparer_ReturnTrue()
		{
			var personX = new Person() { Name = "Jon", Surname = "Doe", Age = 32 };
			var personY = new Person() { Name = "Jane", Surname = "Doe", Age = 34 };
			var personZ = new Person() { Name = "Jon", Surname = "Smith", Age = 36 };
			var elements = new Person[] { personX, personY, personZ };
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, personY, new AgePersonEqualityComparer());

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_ReferenceTypeArrayInputElementsNotContainsSearchedValueWithIEqualtyComparer_ReturnFalse()
		{
			var personW = new Person() { Name = "Jennifer", Surname = "Dowson", Age = 30 };
			var personX = new Person() { Name = "Jon", Surname = "Doe", Age = 32 };
			var personY = new Person() { Name = "Jane", Surname = "Doe", Age = 34 };
			var personZ = new Person() { Name = "Jon", Surname = "Smith", Age = 36 };
			var elements = new Person[] { personX, personY, personZ };
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, personW, new AgePersonEqualityComparer());

			Assert.IsFalse(result);
		}

		#endregion

		#region ValueType enumerable tests

		[TestMethod]
		public void Find_ValueTypeEnumerableInputElementsIsNull_ThrowArgumentNullException()
		{
			IEnumerable<int> elements = null;
			IGenericSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Find<int>(elements, 5));
		}

		[TestMethod]
		public void Find_ValueTypeEnumerableInputElementsIsEmpty_ReturnFalse()
		{
			IEnumerable<int> elements = Enumerable.Empty<int>();
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find<int>(elements, 5);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_ValueTypeEnumerableInputElementsContainsSearchedValue_ReturnTrue()
		{
			IEnumerable<int> elements = Enumerable.Range(4, 5);
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find<int>(elements, 5);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_ValueTypeEnumerableInputElementsNotContainsSearchedValue_ReturnFalse()
		{
			IEnumerable<int> elements = Enumerable.Range(8, 4);
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find<int>(elements, 5);

			Assert.IsFalse(result);
		}

		#endregion

		#region ReferenceType array tests

		[TestMethod]
		public void Find_ReferenceTypeEnumerableInputElementsIsNull_ThrowArgumentNullException()
		{
			IGenericSearch linearSearch = new LinearSearch();
			IEnumerable<string> elements = null;

			Assert.ThrowsException<ArgumentNullException>(() => linearSearch.Find<string>(elements, "a"));
		}

		[TestMethod]
		public void Find_ReferenceTypeEnumerableInputElementsIsEmpty_ReturnFalse()
		{
			IEnumerable<string> elements = Enumerable.Empty<string>();
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find<string>(elements, "a");

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_ReferenceTypeEnumerableInputElementsContainsSearchedValue_ReturnTrue()
		{
			IEnumerable<string> elements = new string[] { "a", "B", "c", "D" }.AsEnumerable();
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, "a");

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_ReferenceTypeEnumerableInputElementsNotContainsSearchedValue_ReturnFalse()
		{
			IEnumerable<string> elements = new string[] { "a", "B", "c", "D" }.AsEnumerable();
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, "A");

			Assert.IsFalse(result);
		}

		#endregion

		#region EqualityComparer array tests

		[TestMethod]
		public void Find_ReferenceTypeEnumerableInputElementsIsNullWithIEqualtyComparer_ThrowArgumentNullException()
		{
			IEnumerable<Person> personArray = null;
			var personX = new Person() { Name = "Jon", Surname = "Doe", Age = 32 };
			IGenericSearch linearSearch = new LinearSearch();

			Assert.ThrowsException<ArgumentNullException>(() =>
				linearSearch.Find<Person>(personArray, personX, new AgePersonEqualityComparer()));
		}

		[TestMethod]
		public void Find_ReferenceTypeEnumerableInputElementsIsEmptyWithIEqualtyComparer_ReturnFalse()
		{
			IEnumerable<Person> elements = Enumerable.Empty<Person>();
			var personX = new Person() { Name = "Jon", Surname = "Doe", Age = 32 };
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find<Person>(elements, personX);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Find_ReferenceTypeEnumerableInputElementsContainsSearchedValueWithIEqualtyComparer_ReturnTrue()
		{
			var personX = new Person() { Name = "Jon", Surname = "Doe", Age = 32 };
			var personY = new Person() { Name = "Jane", Surname = "Doe", Age = 34 };
			var personZ = new Person() { Name = "Jon", Surname = "Smith", Age = 36 };
			var elements = new Person[] { personX, personY, personZ }.AsEnumerable();
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, personY, new AgePersonEqualityComparer());

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Find_ReferenceTypeEnumerableInputElementsNotContainsSearchedValueWithIEqualtyComparer_ReturnFalse()
		{
			var personW = new Person() { Name = "Jennifer", Surname = "Dowson", Age = 30 };
			var personX = new Person() { Name = "Jon", Surname = "Doe", Age = 32 };
			var personY = new Person() { Name = "Jane", Surname = "Doe", Age = 34 };
			var personZ = new Person() { Name = "Jon", Surname = "Smith", Age = 36 };
			var elements = new Person[] { personX, personY, personZ }.AsEnumerable();
			IGenericSearch linearSearch = new LinearSearch();

			var result = linearSearch.Find(elements, personW, new AgePersonEqualityComparer());

			Assert.IsFalse(result);
		}

		#endregion
	}
}