using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Scrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueWordScrambler = true;

            do
            {

                Console.Write("Please  select an option  F for file and M for Maually entry of words:");

                string wordScramblerOption = Console.ReadLine();

                switch (wordScramblerOption.ToUpper())
                {
                    case "F":
                        Console.Write("Please enter path of file for scrambled word");
                        break;
                    case "M":
                        Console.Write("Please enter scrambled words manually");
                        break;

                    default:
                        Console.Write("Entered option was not recognized");

                        break;
                }


                var wordUnscramblerDecision = string.Empty;
                do
                {


                    Console.Write("Please Select an option: Continue Y and  Exit N");

                    wordUnscramblerDecision = Console.ReadLine() ?? string.Empty;


                } while (!wordUnscramblerDecision.Equals("Y", StringComparison.OrdinalIgnoreCase)  && !wordUnscramblerDecision.Equals("N", StringComparison.OrdinalIgnoreCase));



                continueWordScrambler = wordUnscramblerDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueWordScrambler);

            Console.ReadKey();
            

        }
    }
}
