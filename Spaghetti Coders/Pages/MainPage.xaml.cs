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
using System.Diagnostics;
using Spaghetti_Coders.Data;
using Spaghetti_Coders.Controls;
using Spaghetti_Coders.Popups;
using Menu = Spaghetti_Coders.Controls.Menu;

namespace Spaghetti_Coders.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            SpecialsTab.Content = new Menu
            {
                Title = FoodCategory.Specials.Value
            };
            ( SpecialsTab.Content as Menu ).OnFoodItemClick += new Menu.OnFoodItemClickDelegate( OnItemClick );
            ( SpecialsTab.Content as Menu ).OnOrderButtonClick += new Menu.OnOrderButtonClickDelegate( OnOrderButtonClick );
            ( SpecialsTab.Content as Menu ).OnSetSortMethod += new Menu.OnSetSortMethodDelegate( OnSetSortMethod ); 

            MainTab.Content = new Menu
            {
                Title = FoodCategory.Main.Value
            };
            ( MainTab.Content as Menu ).OnFoodItemClick += new Menu.OnFoodItemClickDelegate( OnItemClick );
            ( MainTab.Content as Menu ).OnOrderButtonClick += new Menu.OnOrderButtonClickDelegate( OnOrderButtonClick );
            ( MainTab.Content as Menu ).OnSetSortMethod += new Menu.OnSetSortMethodDelegate( OnSetSortMethod );

            SidesTab.Content = new Menu
            {
                Title = FoodCategory.Sides.Value
            };
            ( SidesTab.Content as Menu ).OnFoodItemClick += new Menu.OnFoodItemClickDelegate( OnItemClick );
            ( SidesTab.Content as Menu ).OnOrderButtonClick += new Menu.OnOrderButtonClickDelegate( OnOrderButtonClick );
            ( SidesTab.Content as Menu ).OnSetSortMethod += new Menu.OnSetSortMethodDelegate( OnSetSortMethod );

            DessertsTab.Content = new Menu
            {
                Title = FoodCategory.Desserts.Value
            };
            ( DessertsTab.Content as Menu ).OnFoodItemClick += new Menu.OnFoodItemClickDelegate( OnItemClick );
            ( DessertsTab.Content as Menu ).OnOrderButtonClick += new Menu.OnOrderButtonClickDelegate( OnOrderButtonClick );
            ( DessertsTab.Content as Menu ).OnSetSortMethod += new Menu.OnSetSortMethodDelegate( OnSetSortMethod );

            DrinksTab.Content = new Menu
            {
                Title = FoodCategory.Drinks.Value
            };
            ( DrinksTab.Content as Menu ).OnFoodItemClick += new Menu.OnFoodItemClickDelegate( OnItemClick );
            ( DrinksTab.Content as Menu ).OnOrderButtonClick += new Menu.OnOrderButtonClickDelegate( OnOrderButtonClick );
            ( DrinksTab.Content as Menu ).OnSetSortMethod += new Menu.OnSetSortMethodDelegate( OnSetSortMethod );

            SearchMenu.OnFoodItemClick += new Menu.OnFoodItemClickDelegate( OnItemClick );
            SearchMenu.OnOrderButtonClick += new Menu.OnOrderButtonClickDelegate( OnOrderButtonClick );
            SearchMenu.OnSetSortMethod += new Menu.OnSetSortMethodDelegate( OnSetSortMethod );

            SearchBox.OnSearchViewActivated += new SearchBox.OnSearchViewActivatedDelegate( OnSearchViewActivated );
            SearchBox.OnSearchViewDeactivated += new SearchBox.OnSearchViewDeactivatedDelegate( OnSearchViewDeactivated );
            SearchBox.OnSearchTextChanged += new SearchBox.OnSearchTextChangedDelegate( OnSearchTextChanged );
            SearchBox.OnSearchBoxLostFocus += new SearchBox.OnSearchBoxLostFocusDelegate( DisableKeyboard );
            SearchBox.OnSearchBoxGotFocus += new SearchBox.OnSearchBoxGotFocusDelegate( EnableKeyboard );
        }

        private void OnItemClick(FoodItem foodItem)
        {
            NavigationService.Navigate( new ItemDetailsPage(foodItem) );
        }

        private void OnOrderButtonClick()
        {
            NavigationService.Navigate( new OrderPage() );
        }

        private void OnSetSortMethod(SortMethod sortMethod)
        {
            ( SpecialsTab.Content as Menu ).sortMethod = sortMethod;
            ( MainTab.Content as Menu ).sortMethod = sortMethod;
            ( SidesTab.Content as Menu ).sortMethod = sortMethod;
            ( DessertsTab.Content as Menu ).sortMethod = sortMethod;
            ( DrinksTab.Content as Menu ).sortMethod = sortMethod;
            SearchMenu.sortMethod = sortMethod;
        }

        private void OnSearchViewActivated()
        {
            CategoryTabs.Visibility = Visibility.Hidden;
            SearchMenu.Visibility = Visibility.Visible;
            SearchKeyboard.Visibility = Visibility.Visible;
        }
        private void OnSearchViewDeactivated()
        {
            CategoryTabs.Visibility = Visibility.Visible;
            SearchMenu.Visibility = Visibility.Hidden;
            SearchKeyboard.Visibility = Visibility.Hidden;
            Keyboard.Focus(CategoryTabs);
        }

        private void OnSearchTextChanged(string searchText)
        {
            SearchMenu.SearchText = searchText;
        }

        private void DisableKeyboard()
        {

            SearchKeyboard.Visibility = Visibility.Hidden;
        }

        private void EnableKeyboard()
        {
            SearchKeyboard.Visibility = Visibility.Visible;
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            if ( sender.Equals( Bell ) )
            {
                BellPopup bellPopup = new BellPopup();
                bellPopup.Show();
            }
        }
    }
}
