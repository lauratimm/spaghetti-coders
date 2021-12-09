using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Spaghetti_Coders.Controls
{
    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public delegate void OnSearchViewActivatedDelegate();

        public event OnSearchViewActivatedDelegate OnSearchViewActivated;

        public delegate void OnSearchViewDeactivatedDelegate();

        public event OnSearchViewDeactivatedDelegate OnSearchViewDeactivated;

        public delegate void OnSearchTextChangedDelegate( string searchText );

        public event OnSearchTextChangedDelegate OnSearchTextChanged;

        public delegate void OnSearchBoxLostFocusDelegate();

        public event OnSearchBoxLostFocusDelegate OnSearchBoxLostFocus;

        public delegate void OnSearchBoxGotFocusDelegate();

        public event OnSearchBoxGotFocusDelegate OnSearchBoxGotFocus;

        public SearchBox()
        {
            InitializeComponent();
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox searchBox = (TextBox)sender;
            if (searchBox.Text.Equals("Search..."))
                searchBox.Text = string.Empty;
            OnSearchViewActivated.Invoke();
            ActivateSearchView();
            OnSearchBoxGotFocus.Invoke();
        }

        private void SearchBox_LostFocus( object sender, RoutedEventArgs e )
        {
            TextBox searchBox = (TextBox)sender;
            if(searchBox.Text.Equals(string.Empty))
                searchBox.Text = "Search...";
            OnSearchBoxLostFocus.Invoke();
        }

        private void SearchBox_TextChanged( object sender, RoutedEventArgs e)
        {
            string searchText = Search_TextBox.Text;
            if ( searchText.Equals( "Search..." ) ) return;

            OnSearchTextChanged.Invoke( searchText );
        }

        private void CloseSearchView( object sender, RoutedEventArgs e )
        {
            Search_TextBox.Text = "Search...";
            DeactivateSearchView();
        }

        private void ActivateSearchView()
        {
            SearchImage.Visibility = Visibility.Hidden;
            CloseImage.Visibility = Visibility.Visible;
            OnSearchViewActivated.Invoke();
        }

        private void DeactivateSearchView()
        {
            SearchImage.Visibility = Visibility.Visible;
            CloseImage.Visibility = Visibility.Hidden;
            OnSearchViewDeactivated.Invoke();
        }
    }
}
