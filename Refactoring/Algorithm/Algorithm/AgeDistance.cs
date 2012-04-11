using System;

namespace Algorithm
{
    public class AgeDistance
    {
        public Person Person1 { get; private set; }
        public Person Person2 { get; private set; }
        public TimeSpan Distance { get; private set; }

        public static readonly AgeDistance Empty = new AgeDistance();

        AgeDistance() { }

        public AgeDistance(Person person1, Person person2)
        {
            if (person1 == null) throw new ArgumentNullException("person1");
            if (person2 == null) throw new ArgumentNullException("person2");

            if (person1.BirthDate < person2.BirthDate)
            {
                Person1 = person1;
                Person2 = person2;
            }
            else
            {
                Person1 = person2;
                Person2 = person1;
            }

            Distance = Person2.BirthDate - Person1.BirthDate;
        }

        static public bool operator <(AgeDistance x, AgeDistance y)
        {
            if (IsNullOrEmpty(x)) return false;
            if (IsNullOrEmpty(y)) return true;

            return x.Distance < y.Distance;
        }

        static public bool operator >(AgeDistance x, AgeDistance y)
        {
            if (IsNullOrEmpty(x)) return false;
            if (IsNullOrEmpty(y)) return true;
            
            return x.Distance > y.Distance;
        }

        static bool IsNullOrEmpty(AgeDistance x)
        {
            return x == null || x == Empty;
        }
    }
}