﻿using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Tests
{    
    public class FinderTests
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finder = new AgeDistanceFinder(list);

            var result = finder.Find(AgeDistanceMethod.Closest);

            Assert.Null(result.Person1);
            Assert.Null(result.Person2);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person> { sue };
            var finder = new AgeDistanceFinder(list);

            var result = finder.Find(AgeDistanceMethod.Closest);

            Assert.Null(result.Person1);
            Assert.Null(result.Person2);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Person> { sue, greg };
            var finder = new AgeDistanceFinder(list);

            var result = finder.Find(AgeDistanceMethod.Closest);

            Assert.Same(sue, result.Person1);
            Assert.Same(greg, result.Person2);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Person> { greg, mike };
            var finder = new AgeDistanceFinder(list);

            var result = finder.Find(AgeDistanceMethod.Furthest);

            Assert.Same(greg, result.Person1);
            Assert.Same(mike, result.Person2);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Person> { greg, mike, sarah, sue };
            var finder = new AgeDistanceFinder(list);

            var result = finder.Find(AgeDistanceMethod.Furthest);

            Assert.Same(sue, result.Person1);
            Assert.Same(sarah, result.Person2);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Person> { greg, mike, sarah, sue };
            var finder = new AgeDistanceFinder(list);

            var result = finder.Find(AgeDistanceMethod.Closest);

            Assert.Same(sue, result.Person1);
            Assert.Same(greg, result.Person2);
        }

        readonly Person sue = new Person {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        readonly Person greg = new Person {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        readonly Person sarah = new Person { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        readonly Person mike = new Person { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}