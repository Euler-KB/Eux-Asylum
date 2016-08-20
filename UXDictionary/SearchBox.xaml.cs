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

namespace UXDictionary
{

    public enum HeaderTextPosition
    {
        Left,
        Right
    }

    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public event EventHandler<string> SearchTermChanged;
        public event EventHandler<string> SearchRequested;

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderTextProperty =
            DependencyProperty.Register("HeaderText", typeof(string), typeof(SearchBox), new PropertyMetadata(string.Empty));



        public HeaderTextPosition HeaderTextAlignment
        {
            get { return (HeaderTextPosition)GetValue(HeaderTextAlignmentProperty); }
            set { SetValue(HeaderTextAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderTextAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderTextAlignmentProperty =
            DependencyProperty.Register("HeaderTextAlignment", typeof(HeaderTextPosition), typeof(SearchBox), new PropertyMetadata(HeaderTextPosition.Left, OnPropertyChanged));

        bool _isSearchTermLocalUpdate = false;
        public string SearchTerm
        {
            get { return (string)GetValue(SearchTermProperty); }
            set { SetValue(SearchTermProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchTerm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchTermProperty =
            DependencyProperty.Register("SearchTerm", typeof(string), typeof(SearchBox), new PropertyMetadata(string.Empty, OnPropertyChanged));


        static void OnPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            SearchBox sb = obj as SearchBox;
            if (args.Property == HeaderTextAlignmentProperty)
            {
                switch ((HeaderTextPosition)args.NewValue)
                {
                    case HeaderTextPosition.Left:
                        sb.tbHeader.HorizontalAlignment = HorizontalAlignment.Left;
                        break;
                    case HeaderTextPosition.Right:
                        sb.tbHeader.HorizontalAlignment = HorizontalAlignment.Right;
                        break;
                }
            }
            else if (args.Property == SearchTermProperty)
            {
                if (!sb._isSearchTermLocalUpdate)
                    sb.tbInput.Text = (string)args.NewValue;

                sb._isSearchTermLocalUpdate = false;
            }
        }

        public SearchBox()
        {
            InitializeComponent();
        }

        private void OnClickSearch(object sender, RoutedEventArgs e)
        {
            SearchRequested?.Invoke(this, tbInput.Text);
        }

        private void LocalUpdateSearchTerm(string searchTerm)
        {
            _isSearchTermLocalUpdate = true;
            SearchTerm = searchTerm;
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            LocalUpdateSearchTerm(tbInput.Text);
            SearchTermChanged?.Invoke(this, tbInput.Text);
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            SearchRequested?.Invoke(this, tbInput.Text);
        }
    }
}
