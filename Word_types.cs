using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicApp
{
    class Word
    {
        public string text;
        //heello
        public Word(string text)
        {
            this.text = text;
        }

        
    }

    class Noun : Word
    {
        public string article;
        public string plural;
        public string englishMeaning;
        public string[] otherMeanings;

        public Noun(string text, string article, string plural, string englishMeaning, string[] otherMeanings) : base(text)
        {
            this.article = article;
            this.plural = plural;
            this.englishMeaning = englishMeaning;
            this.otherMeanings = otherMeanings;
        }
    }

    class Verb : Word
    {
        public string verbType;
        public string mainMeaning;
        public string[] otherMeanings;

        public Verb(string text, string verbType, string mainMeaning, string[] otherMeanings) : base(text)
        {
            this.verbType = verbType;
            this.mainMeaning = mainMeaning;
            this.otherMeanings = otherMeanings;
        }
    }

    class Adjective : Word
    {
        public string mainMeaning;
        public string[] otherMeanings;

        public Adjective(string text, string mainMeaning, string[] otherMeanings) : base(text)
        {
            this.mainMeaning = mainMeaning;
            this.otherMeanings = otherMeanings;
        }
    }
}
