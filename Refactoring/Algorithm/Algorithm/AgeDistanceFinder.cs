using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class AgeDistanceFinder
    {
        private readonly List<Person> _persons;

        public AgeDistanceFinder(List<Person> persons)
        {
            _persons = persons;
        }

        public AgeDistance Find(AgeDistanceMethod ageDistanceMethod)
        {
            var selector = ageDistanceMethod == AgeDistanceMethod.Closest
                               ? (Func<AgeDistance, AgeDistance, AgeDistance>) Closest
                               : (Func<AgeDistance, AgeDistance, AgeDistance>) Furthest;

            return GetAgeDistances().Aggregate(AgeDistance.Empty, selector);
        }

        private static AgeDistance Closest(AgeDistance x, AgeDistance y)
        {
            return x < y ? x : y;
        }

        private static AgeDistance Furthest(AgeDistance x, AgeDistance y)
        {
            return x > y ? x : y;
        }

        private IEnumerable<AgeDistance> GetAgeDistances()
        {
            return from person1 in _persons
                   from person2 in _persons
                   where person1 != person2
                   select new AgeDistance(person1, person2);
        }
    }
}