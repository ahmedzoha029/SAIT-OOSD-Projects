using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Scrambler
{
    class Program
    {
        private const string wordListFilePath = "Words.txt";
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();


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
                        executeFileScrambler();
                        break;
                    case "M":
                        Console.Write("Please enter scrambled words manually");
                        executeManualScrambler();

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


                } while (
                    !wordUnscramblerDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && 
                    !wordUnscramblerDecision.Equals("N", StringComparison.OrdinalIgnoreCase));



                continueWordScrambler = wordUnscramblerDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueWordScrambler);

            Console.ReadKey();
            

        }

        private static void executeFileScrambler()
        {
            string fileName = (Console.ReadLine() ?? String.Empty);

            string[] inputScrambleWords = fileReader.Read(fileName);

            executeMatchScrambleWords(inputScrambleWords);

        }

        private static void executeManualScrambler()
        {
            string words = (Console.ReadLine() ?? string.Empty);

            string[] inputScrambleWords = words.Split(',');

            executeMatchScrambleWords(inputScrambleWords);


        }

        private static void executeMatchScrambleWords(string[] inputScrambleWords)
        {
            string[] wordList = fileReader.Read(wordListFilePath);

            List<MatchedWord> matchedWords = wordMatcher.Match(inputScrambleWords, wordList);

            if (matchedWords.Any())
            {
                foreach(var matchedWord in matchedWords)
                {
                    Console.WriteLine("Match Found For {0} : {1}", matchedWord.inputScrambleWord, matchedWord.wordList);
                }
            }

            else
            {
                Console.WriteLine("No Match Fouund");
            }
        }
    }
}
