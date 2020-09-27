﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace Lab2WS
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scrambledWord in scrambledWords)
            {
                foreach (string word in wordList)
                {
                   
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        //matchedWords.Add(BuildMatchedWord(scrambledWord, word));

                        matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });

                    }
                    else
                    {
                        char[] arr1 = word.ToCharArray();
                        char[] arr2 = scrambledWord.ToCharArray();
                        //convert strings into character arrays i.e. ToCharArray()
                        //sort both character arrays
                        Array.Sort(arr1);
                        Array.Sort(arr2);
                        string s1 = arr1.ToString();
                        string s2 = arr2.ToString();
                        //convert sorted character arrays into strings (toString)
                        // 
                        int icompare = string.Compare(s1, s2, true);
                        if(icompare == 0)
                            matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = s1 });
                        //compare the two sorted strings. If they match, build the MatchWord
                        //struct and add to matchedWords list.
                    }

                }
            }
           

            return matchedWords;
        }
        
        MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word
            };

            return matchedWord;
        }



    }
}
