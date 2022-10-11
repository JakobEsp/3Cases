using System;
using System.Linq;

namespace Three_Cases
{
    internal class DanseKonkurrence
    {
        
        public void GetInputs(bool debug)
        {
            int tmp;
            Person person1 = new Person("", 0);
            Verify vf = new Verify();
            Output op = new Output();
            Person person2 = new Person("", 0);
            do
            {
                if (!vf.IsString(person1.Name))
                {
                    op.Printline(debug, "Fejl!");
                }
                op.Printline(debug,"Name of first dancer: ");
                person1.Name = Console.ReadLine();
            } while (!vf.IsString(person1.Name));

            do
            {
                op.Printline(debug, "Dancer Score: ");
            } while (!int.TryParse(Console.ReadLine(), out tmp));
            person1.Score = tmp;

            do
            {
                op.Printline(debug,"Name of second dancer: ");
                person2.Name = Console.ReadLine();
            } while (!vf.IsString(person2.Name));


            do
            {
                op.Printline(debug,"Dancer Score: ");
            } while (!int.TryParse(Console.ReadLine(), out tmp));
            person2.Score = tmp;


            Person samletPerson = person1 + person2;
            System.Diagnostics.Debug.WriteLine(samletPerson.Name + "\n" + samletPerson.Score);
            op.Printline(debug, samletPerson.Name + "\n" + samletPerson.Score);
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

    class Verify
    {
        public bool IsInt(string input, int number)
        {
            if (int.TryParse(input, out number))
            {
                return true;
            }
            return false;
        }
        public bool IsString(string input)
        {
            if (input.All(char.IsLetter))
            {
                return true;
            }

            return false;
        }
    }
}
