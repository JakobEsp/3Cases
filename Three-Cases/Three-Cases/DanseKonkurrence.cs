using System;

namespace Three_Cases
{
    internal class DanseKonkurrence
    {
        
        public void GetInputs()
        {
            Person person1 = new Person("", 0);
            Person person2 = new Person("", 0);
            Console.Write("Name of first dancer: ");
            person1.Name = Console.ReadLine();
            Console.Write("Dancer Score: ");
            person1.Score = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name of second dancer: ");
            person2.Name = Console.ReadLine();
            Console.Write("Dancer Score: ");
            person2.Score = Convert.ToInt32(Console.ReadLine());

            Person samletPerson = person1 + person2;
            System.Diagnostics.Debug.WriteLine(samletPerson.Name + "\n" + samletPerson.Score);
            Console.WriteLine(samletPerson.Name + "\n" + samletPerson.Score);
            Console.ReadLine();
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public Person(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public static Person operator +(Person a, Person b)
        {
            Person person = new Person ($"{a.Name} & {b.Name}", a.Score + b.Score);
            return person;
        }
    }
}
