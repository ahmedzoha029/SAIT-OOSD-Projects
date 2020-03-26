using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Scrambler
{
    class Program
    {


        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();


        static void Main(string[] args)
        {
            try {
                bool continueWordScrambler = true;

                do
                {

                    Console.Write(Constants.optionOnHowToEnterScrambledWords);

                    string wordScramblerOption = Console.ReadLine();

                    switch (wordScramblerOption.ToUpper())
                    {
                        case Constants.file:
                            Console.Write(Constants.enterScrambledWordsViaFile);
                            executeFileScrambler();
                            break;
                        case Constants.manual:
                            Console.Write(Constants.enterScrambledWordsManually);
                            executeManualScrambler();

                            break;

                        default:
                            Console.Write(Constants.enterScrambledWordsOptionNotRecognized);

                            break;
                    }


                    var wordUnscramblerDecision = string.Empty;
                    do
                    {


                        Console.Write(Constants.optionOnContinuingTheProgram);

                        wordUnscramblerDecision = Console.ReadLine() ?? string.Empty;


                    } while (
                        !wordUnscramblerDecision.Equals(Constants.yes, StringComparison.OrdinalIgnoreCase) &&
                        !wordUnscramblerDecision.Equals(Constants.no, StringComparison.OrdinalIgnoreCase));



                    continueWordScrambler = wordUnscramblerDecision.Equals(Constants.yes, StringComparison.OrdinalIgnoreCase);

                } while (continueWordScrambler);

                Console.WriteLine(" Thank you for using this application");
                Console.ReadKey();
            }
            catch {
                Console.WriteLine(Constants.errorProgramWillbeTerminated);
            }
            
            

        }

        private static void executeFileScrambler()
        {   
            try
            {
                string fileName = (Console.ReadLine() ?? String.Empty);

                string[] inputScrambleWords = fileReader.Read(fileName);

                executeMatchScrambleWords(inputScrambleWords);
            }

            catch(Exception ex)
            {
                Console.WriteLine(Constants.errorScrambledWordsCannotbeLoaded+ex.Message);
            }
       

        }

        private static void executeManualScrambler()
        {
            try
            {
                string words = (Console.ReadLine() ?? string.Empty);

                string[] inputScrambleWords = words.Split(',');

                executeMatchScrambleWords(inputScrambleWords);
            }

            catch (Exception ex)
            {
                Console.WriteLine(Constants.errorWordListCannotbeLoaded + ex.Message);
            }


            


        }

        private static void executeMatchScrambleWords(string[] inputScrambleWords)
        {
            try
            {

                string[] wordList = fileReader.Read(Constants.wordListFilePath);

                List<MatchedWord> matchedWords = wordMatcher.Match(inputScrambleWords, wordList);

                if (matchedWords.Any())
                {
                    foreach (var matchedWord in matchedWords)
                    {
                        Console.WriteLine(Constants.matchFound, matchedWord.inputScrambleWord, matchedWord.wordList);
                    }
                }

                else
                {
                    Console.WriteLine(Constants.matchNotFound);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(Constants.errorWordListCannotbeLoaded+ ex.Message);
            }


    
        }
    }
}
