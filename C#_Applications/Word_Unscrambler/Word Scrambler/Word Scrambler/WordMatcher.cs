using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Scrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] inputScrambleWords, string[] wordList)
        {
            List<MatchedWord> matchedWord = new List<MatchedWord>();

            foreach (var scrambledWord in inputScrambleWords)
            {
                foreach(var word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWord.Add(BuildMatchedWord(scrambledWord, word));
                    }

                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = new String(scrambledWordArray);
                        var sortedWord = new String(wordArray);
                         if (sortedScrambledWord.Equals(sortedWord,StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWord.Add(BuildMatchedWord(scrambledWord, word));
                        }


                    }
                }
            }


            return matchedWord;

        }

        private MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matachedWords = new MatchedWord();
            matachedWords.inputScrambleWord = scrambledWord;
            matachedWords.wordList = word;
            return matachedWords;

        }
    }
}
