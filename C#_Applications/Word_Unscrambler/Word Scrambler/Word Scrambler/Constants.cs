using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Scrambler
{
    class Constants


    {
        public const string optionOnHowToEnterScrambledWords = "Enter scrambled word(s) manually or a file: F-file/M-manually : ";
        public const string optionOnContinuingTheProgram = "Would you like to continue ?  Y/N : ";
        public const string enterScrambledWordsViaFile = "Enter full path including the file name:  ";
        public const string enterScrambledWordsManually = "Enter word(s) manually (seprated by commas if  multiple) : ";
        public const string enterScrambledWordsOptionNotRecognized = "The option selected option was not recognized ";

        public const string errorScrambledWordsCannotbeLoaded = "Scrambled words cannot be loaded becuase there was and error";
        public const string errorWordListCannotbeLoaded = "Words List cannot be loaded becuase there was and error";
        public const string errorProgramWillbeTerminated = "The program will be terminated";

        public const string matchFound = "Match found for {0} : {1}";
        public const string matchNotFound = "Not Matches have been found";

        public const string yes = "Y";
        public const string no = "N";
        public const string file = "F";
        public const string manual = "M";

        public const string wordListFilePath = "wordlist.txt";



    }
}
