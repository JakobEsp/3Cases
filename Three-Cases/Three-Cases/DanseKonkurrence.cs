using System;
using System.Linq;

namespace Three_Cases
{
    internal class DanseKonkurrence
    {
        
        public void GetInputs(bool debug)
        {
            Output output = new Output();
            RunLogin login = new RunLogin();
            ConsoleKey tast;

            int tmp;
            string score = string.Empty;
            Person person1 = new Person("", 0);
            Verify vf = new Verify();
            Output op = new Output();
            Person person2 = new Person("", 0);
            
            do
            {
                if (!vf.IsString(person1.Name))
                {
                    //Tells user if input is incorrect
                    Console.Clear();
                    op.Printline(debug, "Fejl!");
                }
                op.Printline(debug,"Name of first dancer: ");
                person1.Name = Console.ReadLine();
                //when there is a valid input it breaks the loop.
            } while (!vf.IsString(person1.Name));

            do
            {
                op.Printline(debug, "Dancer Score: ");
                //when input is a int it breaks the loop.
            } while (!int.TryParse(Console.ReadLine(), out tmp));
            person1.Score = tmp;

            do
            {
                if (!vf.IsString(person1.Name))
                {
                    Console.Clear();
                    op.Printline(debug, "Fejl!");
                }
                op.Printline(debug,"Name of second dancer: ");
                person2.Name = Console.ReadLine();
            } while (!vf.IsString(person2.Name));


            do
            {
                op.Printline(debug,"Dancer Score: ");
            } while (!int.TryParse(Console.ReadLine(), out tmp));
            person2.Score = tmp;

            //makes new person witch contains 2 persons
            Person samletPerson = person1 + person2;
            //outputs the results of the new person.
            op.Printline(debug, samletPerson.Name + "\n" + samletPerson.Score);
            Console.ReadLine();Console.Clear();
            output.Printline(debug, "Run new[R] CloseProgram[Any]");
            //gets keypress input.
            output.KeyPress(out tast);
            if (tast == ConsoleKey.R)
            {
                login.GetProgram();
            }
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
            //overloads the + operator, so it's now possible to plus 2 of the same Class
            Person person = new Person ($"{a.Name} & {b.Name}", a.Score + b.Score);
            return person;
        }
    }

    class Verify
    {
        public bool IsString(string input)
        {
            //returns true if input string are all letters
            if (input.All(char.IsLetter))
            {
                return true;
            }
            return false;
        }
    }
}
