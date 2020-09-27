using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
                Console.WriteLine(Constants.HOWTO);

                string option = Console.ReadLine() ?? throw new Exception(Constants.ISNULL);



                switch (option.ToUpper())
                {
                    case Constants.FILE:
                        Console.WriteLine(Constants.FILEPATH);
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case Constants.MANUAL:
                        Console.WriteLine(Constants.MANENTRY);
                        ExecuteScrambledWordsManualEntryScenario();
                        break;
                    default:
                        Console.WriteLine(Constants.INVENTRY);
                        break;
                }

                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(Constants.ERROR + e.Message);
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
            
            string userInput = Console.ReadLine();
            
            WordMatcher matcher = new WordMatcher();
            var thisExeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(thisExeDirectory, "wordlist.txt");
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist");
                return;
            }


            FileReader reader = new FileReader();
            string[] arrStrings = reader.Read(filePath);
            
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
