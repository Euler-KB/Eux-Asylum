using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UXDictionary.Models;

namespace UXDictionary.ViewModels
{
    public class DefinitionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotiftPropertyChanged([CallerMemberName]string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public DefinitionViewModel() { }

        public DefinitionViewModel(WordDefinition definition)
        {

        }

        string header;
        public string Header
        {
            get { return header; }
            set
            {
                if (header != value)
                {
                    header = value;
                    NotiftPropertyChanged();
                }
            }
        }

        object content;
        public object Content
        {
            get
            {
                if(content == null)
                {

                }

                return content;
            }
        }

        public void InvalidateContent()
        {

        }
    }
}
