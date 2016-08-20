using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UXDictionary.Models;

namespace UXDictionary
{
    public static class DictionaryItemsDataSource
    {
        //
        public const string DictionaryDataPath = "UXDictionary.xml";

        //
        static bool _isLoaded = false;
        static List<WordItem> _wordsDataSource;
        public static IEnumerable<WordItem> GetWords()
        {
            if (_isLoaded)
                return _wordsDataSource;

            //#
            using (var file = File.OpenRead(DictionaryDataPath))
            {
                //
                var doc = XDocument.Load(file);

                //
                _wordsDataSource = new List<WordItem>();
                foreach (var word in doc.Descendants("word"))
                {
                    //#
                    WordItem element = new WordItem(word.Element("Name")?.Value);

                    //#
                    foreach (var def in word.Descendants("definition").Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => new WordDefinition(x.Value)))
                        element.Definitions.Add(def);

                    //
                    _wordsDataSource.Add(element);
                }
            }

            _isLoaded = true;
            return _wordsDataSource;
        }

        public static Task<IEnumerable<WordItem>> GetWordsAsync()
        {
            return Task.Factory.StartNew(GetWords);
        }
    }
}
