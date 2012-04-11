using System;
using Xunit;

namespace Algorithm.Tests
{
    public class AgeDistanceTests
    {
        [Fact]
        public void Person1_Is_Always_Oldest_Person()
        {
            var ageDistance = new AgeDistance(greg, sue);

            Assert.Same(sue, ageDistance.Person1);
            Assert.Same(greg, ageDistance.Person2);
        }

        [Fact]
        public void Person2_Is_Always_Youngest_Person()
        {
            var ageDistance = new AgeDistance(sue, greg);

            Assert.Same(sue, ageDistance.Person1);
            Assert.Same(greg, ageDistance.Person2);
        }

        [Fact]
        public void Distance_Is_Youngest_Minus_Oldest()
        {
            var ageDistance = new AgeDistance(greg, sue);

            Assert.Equal(greg.BirthDate - sue.BirthDate, ageDistance.Distance);
        }

        [Fact]
        public void AnyAgeDistance_Is_Smaller_Than_Empty_Distance()
        {
            var ageDistance = new AgeDistance(sue, greg);

            Assert.True(ageDistance < AgeDistance.Empty);
        }

        [Fact]
        public void AnyAgeDistance_Is_Greater_Than_Empty_Distance()
        {
            var ageDistance = new AgeDistance(sue, greg);

            Assert.True(ageDistance > AgeDistance.Empty);
        }

        [Fact]
        public void Empty_Distance_Is_Not_Smaller_Than_AnyAgeDistance()
        {
            var ageDistance = new AgeDistance(sue, greg);

            Assert.False(AgeDistance.Empty < ageDistance);
        }

        [Fact]
        public void Empty_Distance_Is_Not_Greater_Than_AnyAgeDistance()
        {
            var ageDistance = new AgeDistance(sue, greg);

            Assert.False(AgeDistance.Empty > ageDistance);
        }

        [Fact]
        public void GreaterThan_Returns_True_When_Distance_Is_Greater()
        {
            var smallest = new AgeDistance(sue, greg);
            var greatest = new AgeDistance(sarah, sue);

            Assert.True(greatest > smallest);
        }

        [Fact]
        public void GreaterThan_Returns_False_When_Distance_Is_Smaller()
        {
            var smallest = new AgeDistance(sue, greg);
            var greatest = new AgeDistance(sarah, sue);

            Assert.False(smallest > greatest);
        }

        [Fact]
        public void LessThan_Returns_True_When_Distance_Is_Smaller()
        {
            var smallest = new AgeDistance(sue, greg);
            var greatest = new AgeDistance(sarah, sue);

            Assert.True(smallest < greatest);
        }

        [Fact]
        public void LessThan_Returns_False_When_Distance_Is_Greater()
        {
            var smallest = new AgeDistance(sue, greg);
            var greatest = new AgeDistance(sarah, sue);

            Assert.False(greatest < smallest);
        }

        readonly Person sue = new Person {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        readonly Person greg = new Person {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        readonly Person sarah = new Person { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
    }
}