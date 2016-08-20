using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UXDictionary.Models
{
    public class WordDefinition
    {
        public WordDefinition() { }
        public WordDefinition(string definition)
        {
            Content = definition;
        }

        public string Content { get; set; }
    }

    public class WordItem
    {
        public WordItem() : this(string.Empty){
        }

        public WordItem(string wordName){
            Definitions = new List<WordDefinition>();
        }

        public string Word { get; set; }

        public IList<WordDefinition> Definitions { get; set; }

        public override string ToString()
        {
            return Word;
        }
    }
}
