using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UXDictionary.Utilities;

namespace UXDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BeginLoadItems()
        {

        }

        private void EndLoadItems()
        {

        }

        private void OnSearchDictionaryItem(object sender, string e)
        {

        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            using (BusyState.Begin(BeginLoadItems, EndLoadItems))
            {
                try
                {
                    //  Load words
                    var words = await DictionaryItemsDataSource.GetWordsAsync();
                    lbDictionaryItems.ItemsSource = words;

                }
                catch (Exception)
                {

                }
            }
        }
    }
}
