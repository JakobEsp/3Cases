using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Cases
{
    internal class Fodbold
    {
        string goals = string.Empty;
        Output output = new Output();
        RunLogin login = new RunLogin();
        ConsoleKey tast;
        public void MatchStart(bool debug)
        {
            output.Printline(debug, $"How many passes?");
            //catches input if it isnt an int
            if (!int.TryParse(Console.ReadLine(), out int passes))
            {
                output.Printline(debug, $"Write it in numbers please!");
                MatchStart(debug);
                return;
            }
            if (passes < 0)
            {
                //if int is invalid it restarts.
                output.Printline(debug, $"Are your team moving backwards?! Try again");
                MatchStart(debug);
                return;
            }
            HasScoredCheck(debug);
            GetResult getResult = new GetResult();
            //gets result
            string result = getResult.Result(goals, passes);
            //prints result.
            output.Printline(debug, result);
            //clears console after some input.
            Console.ReadLine(); Console.Clear();
            output.Printline(debug, "Run new[R] CloseProgram[Any]");
            //gets keypress.
            output.KeyPress(out tast);
            if(tast == ConsoleKey.R)
            {
                //goes back to choose program.
                login.GetProgram();
            }

        }
        public void HasScoredCheck(bool debug)
        {
            Output op = new Output();
            op.Printline(debug, $"Have your team Scored? [Yes] or [No]");

            goals = Console.ReadLine();
            //converts input to lower.
            goals = goals.ToLower(); 

            switch (goals)
            {
                //Checks if input is correct.
                case "yes":
                case "no":
                    Console.Clear();
                    return;
                default:
                    //makes user try again if input is invalid.
                    Console.Clear();
                    output.Printline(debug, $"pleasewrite Yes or No.");
                    HasScoredCheck(debug);
                    return;
            }
        }
    }
    class GetResult
    {
        string cheerGoal = "Olé olé olé";
        string noPasses = "Shh";
        string manyPasses = "High Five - Jubel";
        string couplePasses = "";
        public GetResult()
        {

        }
        public string Result(string goals, int passes)
        {
            if (goals.ToLower() == "yes")
            {
                //cheers on goal
                return CheerGoal(goals);
            }
            else
            {
                //finds output.
                return HappyWithPasses(passes);
            }

        }

        private string CheerGoal(string goals)
        {
            return (cheerGoal);
        }

        private string HappyWithPasses(int passes)
        {   
            if (passes <= 0)
            {
                return (noPasses);
            }
            else if (passes >= 10)
            {
                return (manyPasses);
            }
            else
            {
                for (int i = 0; i < passes; i++)
                {
                    //for every pass adds to string.
                    couplePasses = couplePasses += "HUH!";
                }
                return (couplePasses);
            }
        }

    }
}

