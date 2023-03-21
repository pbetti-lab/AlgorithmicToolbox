using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PbettiLab.AlgorithmicToolbox.Logic.UnitTests.Searching.Algorithms.Objects
{
	internal class AgePersonEqualityComparer : IEqualityComparer<Person>
	{
		public bool Equals(Person? personX, Person? personY)
		{
			if (personX == null || personY == null)
				return false;

			return personX.Age == personY.Age;
		}

		public int GetHashCode([DisallowNull] Person person)
		{
			return person.Age.GetHashCode();
		}
	}
}
