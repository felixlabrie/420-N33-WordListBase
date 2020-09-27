using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab2WS
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(Constants.howTo);

                string option = Console.ReadLine() ?? throw new Exception(Constants.isNull);

                switch (option.ToUpper())
                {
                    case Constants.file:
                        Console.WriteLine(Constants.filePath);
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case Constants.manual:
                        Console.WriteLine(Constants.manEntry);
                        ExecuteScrambledWordsManualEntryScenario();
                        break;
                    default:
                        Console.WriteLine(Constants.invEntry);
                        break;
                }

                // Optional for now (when you have no loop)  (Take out when finished)
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(Constants.error + e.Message);
            }
            


        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string fileName = Console.ReadLine();
            string[] scrambledWords = fileReader.Read(fileName);
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            // 1 get the user's input - comma separated string containing scrambled words
            Console.WriteLine("Enter your words separated by a comma");
        
            string userInput = Console.ReadLine();
            
            WordMatcher matcher = new WordMatcher();
            if (!File.Exists("wordlist.txt"))
            {
                Console.WriteLine("File does not exist");
                return;
            }
            
            
            
            string[] arrStrings =  File.ReadAllLines("worldlist.txt");
            if (arrStrings.Length ==0 )
            
            {
                Console.WriteLine("File is empty");
                return;
            }

            string[] scrambledWords = userInput.Split(',');


            List<MatchedWord> matchedWords = matcher.Match(scrambledWords, arrStrings);

            foreach(MatchedWord word in matchedWords)
            {
                Console.WriteLine(word.ScrambledWord + " = " + word.Word);
            }
            // 2 Extract the words into a string (red,blue,green) 
            // 3 Call the DisplayMatchedUnscrambledWords method passing the scrambled words string array

        }

        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(@"wordlist.txt"); // Put in a constants file. CAPITAL LETTERS.  READONLY.

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);


            // Rule:  Use a formatter to display ... eg:  {0}{1}

            // Rule:  USe an IF to determine if matchedWords is empty or not......
            //            if empty - display no words found message.
            //            if NOT empty - Display the matches.... use "foreach" with the list (matchedWords)
        }
    }
}
