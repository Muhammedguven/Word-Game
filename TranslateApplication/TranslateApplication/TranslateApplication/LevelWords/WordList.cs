using System;
using System.Collections.Generic;
using System.Text;

namespace TranslateApplication.LevelWords
{
    public class WordList
    {
        public List<Words> allWords = new List<Words>()
        {
            new Words{ Level=1, Word="summer"},
            new Words{ Level=1, Word="game"},
            new Words{ Level=1, Word="pencil"},
            new Words{ Level=1, Word="rubber"},
            new Words{ Level=1, Word="book"},
            new Words{ Level=2, Word="series"},
            new Words{ Level=2, Word="computer"},
            new Words{ Level=2, Word="phone"},
            new Words{ Level=2, Word="milk"},
            new Words{ Level=2, Word="water"},
            new Words{ Level=3, Word="cat"},
            new Words{ Level=3, Word="short"},
            new Words{ Level=3, Word="long"},
            new Words{ Level=3, Word="scarf"},
            new Words{ Level=3, Word="cinema"},
            new Words{ Level=4, Word="theater"},
            new Words{ Level=4, Word="school"},
            new Words{ Level=4, Word="university"},
            new Words{ Level=4, Word="information"},
            new Words{ Level=4, Word="application"},
            new Words{ Level=5, Word="beautiful"},
            new Words{ Level=5, Word="handsome"},

        };
        public List<Words> usedWords = new List<Words>();

        public Words getRandom()
        {
            while (true)
            {
                Random rnd = new Random();
                int r = rnd.Next(allWords.Count);
                if (usedWords.Contains(allWords[r]))
                    continue;

                usedWords.Add(allWords[r]);
                return allWords[r];
            }
        }
    }
}
