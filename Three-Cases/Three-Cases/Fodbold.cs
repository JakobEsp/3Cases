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
        public void MatchStart(bool debug)
        {
            output.Printline(debug, $"How many passes?");
            if (!int.TryParse(Console.ReadLine(), out int passes))
            {
                output.Printline(debug, $"Write it in numbers please!");
                MatchStart(debug);
                return;
            }
            if (passes < 0)
            {
                output.Printline(debug, $"Are your team moving backwards?! Try again");
                MatchStart(debug);
                return;
            }
            HasScoredCheck(debug);
            GetResult getResult = new GetResult();
            string result = getResult.Result(goals, passes);
            output.Printline(debug, result);
            Console.ReadLine();
        }
        public void HasScoredCheck(bool debug)
        {
            Output op = new Output();
            op.Printline(debug, $"Have your team Scored? [Yes] or [No]");

            goals = Console.ReadLine();
            goals = goals.ToLower(); 

            switch (goals)
            {
                case "yes":
                case "no":
                    return;
                default:
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
                return CheerGoal(goals);
            }
            else
            {
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
                    couplePasses = couplePasses += "HUH!";
                }
                return (couplePasses);
            }
        }

    }
}

